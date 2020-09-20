// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Class to work with anonymous types.
    /// </summary>
    public class AnonymousTypeAdapter : IAnonymousTypeAdapter
    {
        /// <summary>
        /// Anonymous initializer.
        /// </summary>
        private readonly ConstructorInfo anonInitCtor = typeof(AnonInitializer).GetConstructors()
            .First(c => c.GetParameters().Length == 3);

        /// <summary>
        /// Anonymous value initializer.
        /// </summary>
        private readonly ConstructorInfo anonValueCtor = typeof(AnonValue).GetConstructors()
            .First(c => c.GetParameters().Length == 2);

        /// <summary>
        /// Initialization value.
        /// </summary>
        private readonly PropertyInfo anonInitValue = typeof(AnonInitializer)
            .GetProperty(nameof(AnonInitializer.AnonValue));

        /// <summary>
        /// Value getter.
        /// </summary>
        private readonly MethodInfo getValue = typeof(AnonType)
            .GetMethod(nameof(AnonType.GetValue));

        /// <summary>
        /// Transforms the object to an anonymous type.
        /// </summary>
        /// <param name="anonymous">The anonymous object.</param>
        /// <returns>The anonymous type.</returns>
        public AnonType TransformAnonymousObject(object anonymous)
        {
            if (anonymous == null)
            {
                return null;
            }

            if (anonymous.GetType().IsAnonymousType())
            {
                return new AnonType(anonymous);
            }

            throw new ArgumentException($"{anonymous.GetType()} is not anonymous.");
        }

        /// <summary>
        /// Transform a <see cref="ConstantExpression"/>.
        /// </summary>
        /// <remarks>Outbound anonymous become <see cref="AnonType"/> and inbound
        /// become dynamic.</remarks>
        /// <param name="expression">The <see cref="ConstantExpression"/>.</param>
        /// <returns>Transformed to handle anonymous types.</returns>
        public ConstantExpression TransformConstant(ConstantExpression expression)
        {
            if (expression == null)
            {
                return null;
            }

            if (expression.Type.IsAnonymousType())
            {
                return Expression.Constant(new AnonType(expression.Value));
            }

            if (expression.Type == typeof(AnonType))
            {
                return Expression.Constant(((AnonType)expression.Value).GetValue());
            }

            if (expression.Type == typeof(AnonInitializer))
            {
                return Expression.Constant(((AnonInitializer)expression.Value).AnonValue.GetValue());
            }

            return expression;
        }

        /// <summary>
        /// Transform anonymous initializer.
        /// </summary>
        /// <param name="expression">The <see cref="NewExpression"/>.</param>
        /// <returns>A new expression that returns <see cref="AnonType"/>.</returns>
        public NewExpression TransformNew(NewExpression expression)
        {
            if (expression == null)
            {
                return null;
            }

            if (!expression.Type.IsAnonymousType())
            {
                return expression;
            }

            var name = Expression.Constant(expression.Type.ToString());

            // build property list => new [] { "Id", "Name" } etc.
            var properties = expression.Type.GetProperties()
                .Select(p => p.Name.AsConstantExpression())
                .ToArray();

            var initProperties = Expression.NewArrayInit(typeof(string), properties);

            NewArrayExpression initExpr = null;

            if (expression.Members == null || expression.Members.Count < 1)
            {
                // build list of AnonValue => new [] { new AnonValue(typeof(int), (object)1), new AnonValue(typeof(string), (object)"two") }
                var initValues = expression.Arguments.Select(
                    a => Expression.New(
                        anonValueCtor,
                        new Expression[] { a.Type.AsConstantExpression(), Expression.Convert(a, typeof(object)) }));
                initExpr = Expression.NewArrayInit(typeof(AnonValue), initValues);
            }
            else
            {
                // convert to member access
                var initValueMembers = new List<Expression>();

                for (var idx = 0; idx < expression.Arguments.Count; idx += 1)
                {
                    var arg = expression.Arguments[idx];
                    var args = new Expression[]
                    {
                        arg.Type.AsConstantExpression(),
                        Expression.Convert(arg, typeof(object)),
                    };
                    initValueMembers.Add(
                        Expression.New(
                            anonValueCtor,
                            args));
                }

                initExpr = Expression.NewArrayInit(typeof(AnonValue), initValueMembers);
            }

            // new AnonInitializer(name, properties, values);
            var newArgs = new Expression[] { name, initProperties, initExpr };
            return Expression.New(anonInitCtor, newArgs);
        }

        /// <summary>
        /// Transform a <see cref="LambdaExpression"/> that returns an anonymous type.
        /// </summary>
        /// <remarks>
        /// Outgoing turns into serializable <see cref="AnonInitializer"/>. Incoming converts
        /// back to dynamic.
        /// </remarks>
        /// <param name="lambda">The <see cref="LambdaExpression"/>.</param>
        /// <returns>The new Lambda expression.</returns>
        public LambdaExpression TransformLambda(LambdaExpression lambda)
        {
            if (lambda == null)
            {
                return null;
            }

            var anonymous = lambda.ReturnType.IsAnonymousType();
            if (!anonymous)
            {
                anonymous = lambda.Body.Type.IsAnonymousType();
            }

            if (!anonymous)
            {
                var anonInit = lambda.ReturnType == typeof(AnonInitializer)
                    || lambda.Body.Type == typeof(AnonInitializer);
                if (!anonInit)
                {
                    return lambda;
                }
            }

            var body = lambda.Body;

            if (anonymous)
            {
                switch (body.NodeType)
                {
                    case ExpressionType.New:
                        var anonInitializer = TransformNew(body as NewExpression);
                        var delegateType = GetDelegateType(lambda.Parameters, typeof(AnonInitializer));
                        return Expression.Lambda(delegateType, anonInitializer, lambda.Parameters);

                    case ExpressionType.MemberAccess:
                        var access = body as MemberExpression;
                        var resolver = Expression.Lambda(access);
                        var fn = resolver.Compile();
                        var anonConstant = TransformConstant(
                            Expression.Constant(fn.DynamicInvoke(null)));
                        var value = Expression.Call(anonConstant, getValue);
                        return Expression.Lambda<Func<ExpandoObject>>(
                            value,
                            lambda.Parameters);
                }
            }
            else
            {
                if (body.NodeType == ExpressionType.New)
                {
                    var innerType = GetDelegateType(lambda.Parameters, typeof(AnonType));
                    var memberAccess = Expression.MakeMemberAccess(body, anonInitValue);
                    var invoker = Expression.Lambda(innerType, memberAccess, lambda.Parameters);
                    var label = Expression.Label(typeof(AnonType));
                    var invoke = Expression.Invoke(invoker, lambda.Parameters);
                    var returnValue = Expression.Return(label, invoke, typeof(AnonType));
                    var block = Expression.Block(
                        returnValue,
                        Expression.Label(label, Expression.Constant(null, typeof(AnonType))));
                    var outerAccess = Expression.Call(block, getValue);
                    var outerType = GetDelegateType(lambda.Parameters, typeof(ExpandoObject));
                    return Expression.Lambda(outerType, outerAccess, lambda.Parameters);
                }
            }

            return lambda;
        }

        /// <summary>
        /// Transforms members for serialization.
        /// </summary>
        /// <param name="memberToTransform">The member to translate.</param>
        /// <returns>The transformed member.</returns>
        public string MemberKeyTransformer(string memberToTransform)
        {
            Ensure.NotNullOrWhitespace(() => memberToTransform);

            var posOfAnon = memberToTransform.IndexOf('<');
            if (posOfAnon < 0)
            {
                return memberToTransform;
            }

            var anon = memberToTransform.Substring(posOfAnon);
            var braceCount = 1;
            var end = anon.IndexOf('{') + 1;
            while (braceCount > 0 && end++ < anon.Length)
            {
                if (anon[end] == '{')
                {
                    braceCount++;
                }

                if (anon[end] == '}')
                {
                    braceCount--;
                }
            }

            var anonType = anon.Substring(0, end + 1);
            return memberToTransform.Replace(anonType, typeof(ExpandoObject).FullName);
        }

        /// <summary>
        /// Creates the right delegate based on number of parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="returnType">The propery closed function type.</param>
        /// <returns>The type of function to use.</returns>
        private Type GetDelegateType(ICollection<ParameterExpression> parameters, Type returnType)
        {
            Type baseType = null;

            switch (parameters.Count)
            {
                case 0:
                    baseType = typeof(Func<>);
                    break;
                case 1:
                    baseType = typeof(Func<,>);
                    break;
                case 2:
                    baseType = typeof(Func<,,>);
                    break;
                case 3:
                    baseType = typeof(Func<,,,>);
                    break;
                case 4:
                    baseType = typeof(Func<,,,,>);
                    break;
                case 5:
                    baseType = typeof(Func<,,,,,>);
                    break;
                case 6:
                    baseType = typeof(Func<,,,,,,>);
                    break;
                case 7:
                    baseType = typeof(Func<,,,,,,,>);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            var typeParams = parameters
                .Select(p => p.Type)
                .Union(new[] { returnType })
                .ToArray();

            return baseType.MakeGenericType(typeParams);
        }
    }
}

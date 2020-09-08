// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Rules;

namespace ExpressionPowerTools.Serialization.Extensions
{
    /// <summary>
    /// Extensions for selecting <see cref="MemberInfo"/>.
    /// </summary>
    public static class SelectorExtensions
    {
        /// <summary>
        /// The setting to retrieve instance and static types.
        /// </summary>
        private static readonly BindingFlags AllFlags =
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.Static;

        /// <summary>
        /// Pass the <see cref="MemberInfo"/> directly.
        /// </summary>
        /// <typeparam name="T">The <see cref="MemberInfo"/> type.</typeparam>
        /// <param name="memberSelector">The <see cref="MemberSelector{T}"/>.</param>
        /// <param name="member">The <see cref="MemberInfo"/>.</param>
        public static void ByMemberInfo<T>(
            this MemberSelector<T> memberSelector,
            T member)
            where T : MemberInfo
            => memberSelector.Member = new[] { member };

        /// <summary>
        /// Pass the <see cref="MemberInfo"/> using name on <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="MemberInfo"/>.</typeparam>
        /// <param name="memberSelector">The <see cref="MemberSelector{T}"/>.</param>
        /// <param name="type">The <see cref="Type"/> the member is on.</param>
        /// <param name="memberName">The name of the member.</param>
        public static void ByNameForType<T>(
            this MemberSelector<T> memberSelector,
            Type type,
            string memberName)
            where T : MemberInfo
        {
            if (typeof(T) == typeof(FieldInfo))
            {
                memberSelector.Member = new[]
                {
                    type.GetField(memberName, AllFlags) as T,
                };
            }
            else if (typeof(T) == typeof(PropertyInfo))
            {
                memberSelector.Member = new[]
                {
                    type.GetProperty(memberName, AllFlags) as T,
                };
            }
            else if (typeof(T) == typeof(MethodInfo))
            {
                memberSelector.Member = type.GetMethods(AllFlags)
                    .Where(m => m.Name == memberName)
                    .OfType<T>().ToArray();
            }
            else
            {
                throw new InvalidOperationException(type.ToString());
            }
        }

        /// <summary>
        /// Gets the <see cref="MemberInfo"/> using
        /// the name for the <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="MemberInfo"/> to retrieve.</typeparam>
        /// <typeparam name="TTarget">The type the member belongs to.</typeparam>
        /// <param name="memberSelector">The <see cref="MemberSelector{T}"/>.</param>
        /// <param name="memberName">The name of the member.</param>
        public static void ByNameForType<T, TTarget>(
            this MemberSelector<T> memberSelector,
            string memberName)
            where T : MemberInfo =>
            memberSelector.ByNameForType(typeof(TTarget), memberName);

        /// <summary>
        /// Gets the <see cref="MemberInfo"/> using a lambda expression
        /// as a template. The lambda is never invoked and is inspected
        /// to find the matching type.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="MemberInfo"/> to retrieve.</typeparam>
        /// <typeparam name="TTarget">The type the expression uses as a template.</typeparam>
        /// <param name="memberSelector">The <see cref="MemberSelector{T}"/>.</param>
        /// <param name="resolver">The  expression template.</param>
        public static void ByResolver<T, TTarget>(
            this MemberSelector<T> memberSelector,
            Expression<Func<TTarget, object>> resolver)
            where T : MemberInfo => Resolve<T, TTarget>(memberSelector, resolver);

        /// <summary>
        /// Gets the <see cref="MemberInfo"/> using a lambda expression
        /// as a template. The lambda is never invoked and is inspected
        /// to find the matching type.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="MemberInfo"/> to retrieve.</typeparam>
        /// <typeparam name="TTarget">The type the expression uses as a template.</typeparam>
        /// <param name="memberSelector">The <see cref="MemberSelector{T}"/>.</param>
        /// <param name="resolver">The  expression template.</param>
        public static void ByResolver<T, TTarget>(
            this MemberSelector<T> memberSelector,
            Expression<Action<TTarget>> resolver)
            where T : MemberInfo => Resolve<T, TTarget>(memberSelector, resolver);

        /// <summary>
        /// Resolves the expression based on type.
        /// </summary>
        /// <typeparam name="T">The <see cref="MemberInfo"/> to extract.</typeparam>
        /// <typeparam name="TTarget">The <see cref="Type"/> to extract from.</typeparam>
        /// <param name="memberSelector">The <see cref="MemberSelector{T}"/>.</param>
        /// <param name="expr">The <see cref="Expression"/>.</param>
        private static void Resolve<T, TTarget>(
            MemberSelector<T> memberSelector,
            Expression expr)
            where T : MemberInfo
        {
            if (typeof(T) == typeof(MethodInfo))
            {
                var methodCall = expr.AsEnumerable()
                    .OfType<MethodCallExpression>().FirstOrDefault();
                memberSelector.Member = new[] { methodCall.Method as T };
            }
            else if (typeof(T) == typeof(ConstructorInfo))
            {
                var ctor = expr.AsEnumerable()
                    .OfType<NewExpression>().FirstOrDefault();
                memberSelector.Member = new[] { ctor.Constructor as T };
            }
            else
            {
                var memberAccess = expr.AsEnumerable()
                .OfType<MemberExpression>().FirstOrDefault();
                memberSelector.Member = new[] { memberAccess.Member as T };
            }
        }
    }
}

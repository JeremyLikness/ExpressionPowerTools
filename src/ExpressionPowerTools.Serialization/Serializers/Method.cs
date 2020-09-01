// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Represents <see cref="MethodInfo"/> for serialization.
    /// </summary>
    [Serializable]
    public class Method : MemberBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Method"/> class.
        /// </summary>
        public Method()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Method"/> class and
        /// populates values based on the <see cref="MethodInfo"/> passed in.
        /// </summary>
        /// <param name="info">The <see cref="MethodInfo"/> to parse.</param>
        public Method(MethodInfo info)
        {
            DeclaringType = SerializeType(info.DeclaringType);
            MemberValueType = SerializeType(info.ReturnType);
            ReflectedType = SerializeType(info.ReflectedType);
            IsStatic = info.IsStatic;
            Name = info.Name;
            Parameters = info.GetParameters().Select(
                p => new
                {
                    p.Name,
                    Type = SerializeType(p.ParameterType),
                })
                .ToDictionary(p => p.Name, p => p.Type);

            if (info.IsGenericMethod && !info.IsGenericMethodDefinition)
            {
                GenericArguments = info
                    .GetGenericArguments()
                    .Select(t => SerializeType(t)).ToArray();
                GenericMethodDefinition = new Method(info.GetGenericMethodDefinition());
            }
        }

        /// <summary>
        /// Gets or sets the generic method definition that the method inherits from.
        /// </summary>
        public Method GenericMethodDefinition { get; set; }

        /// <summary>
        /// Gets or sets the generic arguments to the method.
        /// </summary>
        public SerializableType[] GenericArguments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the method is static.
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// Gets or sets the name of the method.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of parameters with parameter name mapped to the
        /// full name of the type.
        /// </summary>
        public Dictionary<string, SerializableType> Parameters { get; set; }
            = new Dictionary<string, SerializableType>();

        /// <summary>
        /// Gets or sets the member type.
        /// </summary>
        /// <remarks>
        /// Setting is only to accommodate serialization.
        /// </remarks>
        public override int MemberType
        {
            get => (int)MemberTypes.Method;
            set
            {
            }
        }

        /// <summary>
        /// Gets the unique key for the method.
        /// </summary>
        /// <returns>The unique key.</returns>
        public override string CalculateKey() =>
            string.Join(
                ",",
                new[] { "M:" }
                .Union(Parameters.Keys.ToArray())
                .Union(Parameters.Values.Select(p =>
                    GetFullNameOfType(p)).ToArray())
                .Union(new[]
                {
                    GetFullNameOfType(ReflectedType),
                    IsStatic.ToString(),
                    GetFullNameOfType(DeclaringType),
                    GetFullNameOfType(MemberValueType),
                    Name,
                }));
    }
}

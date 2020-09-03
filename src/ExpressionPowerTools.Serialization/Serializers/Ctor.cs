// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializable version of <see cref="ConstructorInfo"/>.
    /// </summary>
    [Serializable]
    public class Ctor : MemberBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ctor"/> class.
        /// </summary>
        public Ctor()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ctor"/> class and
        /// initializes it with a <see cref="ConstructorInfo"/>.
        /// </summary>
        /// <param name="info">The <see cref="ConstructorInfo"/> for initialization.</param>
        public Ctor(ConstructorInfo info)
        {
            DeclaringType = SerializeType(info.DeclaringType);
            MemberValueType = DeclaringType;
            ReflectedType = SerializeType(info.ReflectedType);
            IsStatic = info.IsStatic;
            Name = $"{DeclaringType.FullTypeName}()";
            Parameters = info.GetParameters().Select(
                p => new
                {
                    p.Name,
                    Type = SerializeType(p.ParameterType),
                })
                .ToDictionary(p => p.Name, p => p.Type);
        }

        /// <summary>
        /// Gets or sets the type of the member.
        /// </summary>
        /// <remarks>
        /// Setting is just to accommodate serialization.
        /// </remarks>
        public override int MemberType
        {
            get => (int)MemberTypes.Constructor;
            set { }
        }

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
        /// Gets the unique key for the method.
        /// </summary>
        /// <returns>The unique key.</returns>
        public override string CalculateKey() =>
            string.Join(
                ",",
                new[] { "C:" }
                .Union(Parameters.Keys.ToArray())
                .Union(Parameters.Values.Select(p =>
                    GetFullNameOfType(p)).ToArray())
                .Union(new[]
                {
                    GetFullNameOfType(ReflectedType),
                    IsStatic.ToString(),
                    GetFullNameOfType(DeclaringType),
                    Name,
                }));
    }
}

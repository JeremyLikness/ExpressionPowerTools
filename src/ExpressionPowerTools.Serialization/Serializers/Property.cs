// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// A serializable property.
    /// </summary>
    public class Property : MemberBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class.
        /// </summary>
        public Property()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class and
        /// populates values based on the <see cref="PropertyInfo"/> passed in.
        /// </summary>
        /// <param name="info">The <see cref="PropertyInfo"/> to parse.</param>
        public Property(PropertyInfo info)
        {
            DeclaringType = SerializeType(info.DeclaringType);
            MemberValueType = SerializeType(info.PropertyType);
            IsStatic = info.CanRead ? info.GetMethod.IsStatic :
                info.SetMethod.IsStatic;
            Name = info.Name;
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
        /// Gets or sets the member type.
        /// </summary>
        /// <remarks>
        /// Setting is only to accommodate serialization.
        /// </remarks>
        public override string MemberType
        {
            get => MemberTypes.Property.ToString();
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
                new[] { "P:" }
                .Union(new[]
                {
                    IsStatic.ToString(),
                    GetFullNameOfType(DeclaringType),
                    GetFullNameOfType(MemberValueType),
                    Name,
                }));
    }
}

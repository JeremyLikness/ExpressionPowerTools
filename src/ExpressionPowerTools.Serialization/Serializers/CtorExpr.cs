// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Represents a serializable <see cref="NewExpression"/>.
    /// </summary>
    [Serializable]
    public class CtorExpr : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CtorExpr"/> class.
        /// </summary>
        public CtorExpr()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CtorExpr"/> class
        /// initialized with a <see cref="NewExpression"/>.
        /// </summary>
        /// <param name="ctor">The <see cref="NewExpression"/> to
        /// serialize.</param>
        public CtorExpr(NewExpression ctor)
            : base(ctor)
        {
            CtorInfo = new Ctor(ctor.Constructor);

            if (ctor.Members != null)
            {
                foreach (var member in ctor.Members)
                {
                    if (member is PropertyInfo property)
                    {
                        var prop = new Property(property);
                        MemberTypeList.Add(prop.MemberType);
                        Properties.Add(prop);
                    }

                    if (member is FieldInfo field)
                    {
                        var fieldInfo = new Field(field);
                        MemberTypeList.Add(fieldInfo.MemberType);
                        Fields.Add(fieldInfo);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the serializable <see cref="ConstructorInfo"/>.
        /// </summary>
        public Ctor CtorInfo { get; set; }

        /// <summary>
        /// Gets or sets the method's object.
        /// </summary>
        public List<object> Arguments { get; set; } = new List<object>();

        /// <summary>
        /// Gets or sets the members.
        /// </summary>
        [ExcludeFromCodeCoverage]
        [JsonIgnore]
        public List<MemberBase> Members { get; set; } = new List<MemberBase>();

        /// <summary>
        /// Gets or sets the list of member types.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public List<int> MemberTypeList { get; set; } = new List<int>();

        /// <summary>
        /// Gets or sets the property list.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public List<Property> Properties { get; set; } = new List<Property>();

        /// <summary>
        /// Gets or sets the field list.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public List<Field> Fields { get; set; } = new List<Field>();
    }
}

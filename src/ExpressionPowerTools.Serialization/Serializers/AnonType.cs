// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Extensions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Helper for serializing and deserializing anonymous types.
    /// </summary>
    [Serializable]
    public class AnonType
    {
        /// <summary>
        /// Holds the dynamic value.
        /// </summary>
        private dynamic dynamicValue = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonType"/> class.
        /// </summary>
        public AnonType()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonType"/> class with the
        /// anonymous instance to serialize.
        /// </summary>
        /// <param name="value">The anonymous value.</param>
        public AnonType(object value)
        {
            Ensure.NotNull(() => value);
            AnonymousTypeName = value.GetType().ToString();
            PropertyNames = value.GetType().GetProperties()
                .Select(p => p.Name).ToArray();
            List<AnonValue> values =
                new List<AnonValue>();
            foreach (var name in PropertyNames)
            {
                var prop = value.GetType().GetProperty(name);
                var type = prop.PropertyType;
                var val = prop.GetValue(value);
                if (type.IsAnonymousType())
                {
                    val = new AnonType(val);
                    type = typeof(AnonType);
                }

                values.Add(new AnonValue(type, val));
            }

            PropertyValues = values.ToArray();
        }

        /// <summary>
        /// Gets or sets the anonymous type name.
        /// </summary>
        public string AnonymousTypeName { get; set; }

        /// <summary>
        /// Gets or sets the property names.
        /// </summary>
        public string[] PropertyNames { get; set; }

        /// <summary>
        /// Gets or sets the property values.
        /// </summary>
        public AnonValue[] PropertyValues { get; set; }

        /// <summary>
        /// Gets the value as a <see cref="DynamicObject"/>.
        /// </summary>
        /// <returns>The dynamic value.</returns>
        public ExpandoObject GetValue()
        {
            if (PropertyNames == null)
            {
                return null;
            }

            if (dynamicValue != null)
            {
                return dynamicValue;
            }

            var anon = (IDictionary<string, object>)new ExpandoObject();
            for (var idx = 0; idx < PropertyNames.Length; idx++)
            {
                if (PropertyValues[idx].AnonVal is AnonType nestedAnon)
                {
                    anon.Add(PropertyNames[idx], nestedAnon.GetValue());
                }
                else
                {
                    anon.Add(PropertyNames[idx], PropertyValues[idx].AnonVal);
                }
            }

            dynamicValue = anon;
            return dynamicValue;
        }
    }
}

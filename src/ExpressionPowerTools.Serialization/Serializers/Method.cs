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
    public class Method
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
            DeclaringType = info.DeclaringType.FullName;
            ReturnType = info.ReturnType.FullName;
            IsStatic = info.IsStatic;
            Name = info.Name;
            Parameters = info.GetParameters().Select(
                p => new KeyValuePair<string, string>(
                    p.Name, p.ParameterType.FullName))
                .ToDictionary(p => p.Key, p => p.Value);
            GetHashCode();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the method is static.
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// Gets or sets the full name of the declaring type.
        /// </summary>
        public string DeclaringType { get; set; }

        /// <summary>
        /// Gets or sets the full name of the return type.
        /// </summary>
        public string ReturnType { get; set; }

        /// <summary>
        /// Gets or sets the name of the method.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of parameters with parameter name mapped to the
        /// full name of the type.
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }
            = new Dictionary<string, string>();

        /// <summary>
        /// Generates a hash code based on the full method signature.
        /// </summary>
        /// <returns>The hash code based on parameters, parameter types, return type, declaring type and name.</returns>
        public override int GetHashCode() =>
            string.Join(
                ",",
                Parameters.Keys.ToArray()
                .Union(Parameters.Values.ToArray())
                .Union(new[] { DeclaringType, ReturnType, Name }))
                .GetHashCode();
    }
}

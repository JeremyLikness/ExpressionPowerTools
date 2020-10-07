// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Adapter to serialize and deserialize anonymous types.
    /// </summary>
    public class AnonymousTypeAdapter : IAnonymousTypeAdapter
    {
        /// <summary>
        /// Member adapter instance.
        /// </summary>
        private readonly Lazy<IMemberAdapter> memberAdapter =
            ServiceHost.GetLazyService<IMemberAdapter>();

        /// <summary>
        /// Encapsulates an anonymous type for serialization.
        /// </summary>
        /// <param name="anonymousInstance">The instance to convert.</param>
        /// <returns>The <see cref="AnonType"/>.</returns>
        public AnonType ConvertToAnonType(object anonymousInstance)
        {
            string KeyForMember(Type t) => memberAdapter.Value
                .GetKeyForMember(t);

            return new AnonType(
                anonymousInstance,
                KeyForMember);
        }

        /// <summary>
        /// Reconstructs an anonymous type from <see cref="AnonType"/>.
        /// </summary>
        /// <param name="anonType">The <see cref="AnonType"/>.</param>
        /// <param name="options">Serialization options.</param>
        /// <returns>The anonymous type instance.</returns>
        public object ConvertFromAnonType(
            AnonType anonType,
            JsonSerializerOptions options)
        {
            return UnrollAnonymous(anonType, options);
        }

        /// <summary>
        /// Unrolls anonymous types.
        /// </summary>
        /// <param name="valueType">The anonymous value type.</param>
        /// <param name="options">The serializer options.</param>
        /// <returns>The anonymous type.</returns>
        private object UnrollAnonymous(AnonType valueType, JsonSerializerOptions options)
        {
            var types = valueType.Types.Select(t =>
                memberAdapter.Value.GetMemberForKey<Type>(t)).ToArray();

            var values = new List<object>();

            var newTypes = new List<Type>();

            for (var idx = 0; idx < types.Length; idx++)
            {
                var obj = valueType.Values[idx];

                if (obj is JsonElement json)
                {
                    obj = JsonSerializer.Deserialize(
                        json.GetRawText(), types[idx], options);
                }

                if (types[idx] == typeof(AnonType))
                {
                    obj = UnrollAnonymous(obj as AnonType, options);
                    newTypes.Add(obj.GetType());
                }
                else
                {
                    newTypes.Add(types[idx]);
                }

                values.Add(obj);
            }

            var tuples = new List<(string prop, Type propType)>();
            for (var idx = 0; idx < valueType.Names.Count; idx++)
            {
                tuples.Add((valueType.Names[idx], newTypes[idx]));
            }

            var type = memberAdapter.Value.MakeAnonymousType(tuples.ToArray());
            var ctor = type.GetConstructors().First();
            return ctor.Invoke(values.ToArray());
        }
    }
}

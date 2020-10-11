// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Core.Signatures;
using ExpressionPowerTools.Serialization.Signatures;

namespace ExpressionPowerTools.Serialization.Compression
{
    /// <summary>
    /// Simple type compression.
    /// </summary>
    public class TypesCompressor : ITypesCompressor
    {
        /// <summary>
        /// Pattern to match ^0 .. ^20 etc.
        /// </summary>
        private const string CompressedPattern = @"(\^[\d]*)";

        /// <summary>
        /// Member adapter to help decompose types.
        /// </summary>
        private readonly Lazy<IMemberAdapter> memberAdapter
            = ServiceHost.GetLazyService<IMemberAdapter>();

        /// <summary>
        /// Recursively compresses the type index.
        /// </summary>
        /// <param name="typeIndex">The type index.</param>
        public void CompressTypeIndex(List<string> typeIndex)
        {
            Ensure.NotNull(() => typeIndex);

            // copy of expanded index
            var transformedIndex = typeIndex.Select(str => str).ToArray();

            for (var idx = 0; idx < typeIndex.Count; idx++)
            {
                var typeKey = typeIndex[idx];

                if (typeKey.IndexOf('{') < 0 || typeKey.IndexOf('^') >= 0)
                {
                    continue;
                }

                var type = memberAdapter.Value.GetMemberForKey<Type>(typeKey);
                if (type.IsGenericType)
                {
                    foreach (var subType in RecurseTypes(type.GenericTypeArguments)
                        .OrderByDescending(st => st.subTypes))
                    {
                        var subKey = memberAdapter.Value.GetKeyForMember(subType.type);
                        var subKeyType = subKey.Substring(2);
                        if (typeKey.Contains(subKeyType))
                        {
                            var subIdx = typeIndex.IndexOf(subKey);
                            if (subIdx >= 0)
                            {
                                typeKey = typeKey.Replace(subKeyType, $"^{subIdx}");
                            }
                        }
                    }
                }

                transformedIndex[idx] = typeKey;
            }

            typeIndex.Clear();
            typeIndex.AddRange(transformedIndex);
        }

        /// <summary>
        /// Compress the keys in a list.
        /// </summary>
        /// <param name="typeIndex">The index of existing types.</param>
        /// <param name="keys">The keys to compress.</param>
        public void CompressTypes(List<string> typeIndex, params (string key, Action<string> transformedKey)[] keys)
        {
            Ensure.NotNull(() => typeIndex);

            if (keys == null)
            {
                return;
            }

            foreach (var (key, keyFn) in keys)
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    keyFn(key);
                    continue;
                }

                var idx = typeIndex.IndexOf(key);
                if (idx >= 0)
                {
                    keyFn($"T:^{idx}");
                }
                else
                {
                    Type[] typeList = new Type[0];

                    switch (key[0])
                    {
                        case 'T':
                            var type = memberAdapter.Value.GetMemberForKey<Type>(key);
                            typeList = new[] { type };
                            break;

                        case 'P':
                            var property = memberAdapter.Value.GetMemberForKey<PropertyInfo>(key);
                            if (property.PropertyType.IsGenericType)
                            {
                                typeList = new[] { property.PropertyType };
                            }

                            break;

                        case 'F':
                            var field = memberAdapter.Value.GetMemberForKey<FieldInfo>(key);
                            if (field.FieldType.IsGenericType)
                            {
                                typeList = new[] { field.FieldType };
                            }

                            break;

                        case 'M':
                            var member = memberAdapter.Value.GetMemberForKey(key);
                            if (member is ConstructorInfo ctor)
                            {
                                typeList = ctor.GetParameters().Select(p => p.ParameterType)
                                    .Union(new[] { ctor.DeclaringType }.Where(t => t.IsGenericType))
                                    .ToArray();
                            }
                            else
                            {
                                var method = member as MethodInfo;
                                typeList = method.GetParameters().Select(p => p.ParameterType)
                                    .Union(new[] { method.DeclaringType, method.ReturnType }
                                        .Where(t => t.IsGenericType))
                                        .ToArray();
                            }

                            break;
                    }

                    if (typeList.Length > 0)
                    {
                        ProcessTypes(typeIndex, typeList);
                    }

                    keyFn(CompressKey(typeIndex, key));
                }
            }
        }

        /// <summary>
        /// Decompress the types in a list.
        /// </summary>
        /// <param name="typeIndex">The index of existing types.</param>
        /// <param name="keys">The keys to decompress.</param>
        public void DecompressTypes(List<string> typeIndex, params (string key, Action<string> transformedKey)[] keys)
        {
            Ensure.NotNull(() => typeIndex);
            DecompressTypeList(typeIndex);

            if (keys != null)
            {
                foreach (var (key, keyFn) in keys)
                {
                    if (string.IsNullOrWhiteSpace(key))
                    {
                        keyFn(key);
                    }
                    else
                    {
                        keyFn(DecompressKey(typeIndex, key));
                    }
                }
            }
        }

        /// <summary>
        /// Decompress index, i.e. <c>0=System.String 1=IEnumerable{^0}</c> becomes
        /// <c>0=System.String 1=IEnumerable{System.String}</c>.
        /// </summary>
        /// <param name="typeList">The type list to decompress.</param>
        private void DecompressTypeList(List<string> typeList)
        {
            while (typeList.Any(t => t.IndexOf('^') >= 0))
            {
                for (var idx = 0; idx < typeList.Count; idx++)
                {
                    typeList[idx] = DecompressKey(typeList, typeList[idx]);
                }
            }
        }

        /// <summary>
        /// Compresses a key.
        /// </summary>
        /// <param name="typeIndex">The type index to use.</param>
        /// <param name="key">The key.</param>
        /// <returns>The compressed key.</returns>
        private string CompressKey(List<string> typeIndex, string key)
        {
            var keyBody = key.Substring(2);
            foreach (var match in
                typeIndex
                .Where(t => keyBody.Contains(t.Substring(2)))
                .OrderByDescending(t => t.Length))
            {
                var replacement = $"^{typeIndex.IndexOf(match)}";
                keyBody = keyBody.Replace(match.Substring(2), replacement);
            }

            return $"{key[0]}:{keyBody}";
        }

        /// <summary>
        /// Processes compressed types for the key.
        /// </summary>
        /// <param name="typeIndex">The type index.</param>
        /// <param name="key">The key to process.</param>
        /// <returns>The processed key.</returns>
        private string DecompressKey(List<string> typeIndex, string key)
        {
            while (key.IndexOf('^') >= 0)
            {
                var matches = Regex.Matches(key, CompressedPattern, RegexOptions.IgnoreCase);
                foreach (Match match in matches)
                {
                    var idxKey = match.Value;
                    var idx = int.Parse(idxKey.Substring(1));
                    key = key.Replace(idxKey, typeIndex[idx].Substring(2));
                }
            }

            return key;
        }

        /// <summary>
        /// Processes a list of types for compression.
        /// </summary>
        /// <param name="typeIndex">The type index.</param>
        /// <param name="types">The types to process.</param>
        private void ProcessTypes(List<string> typeIndex, Type[] types)
        {
            foreach (var type in RecurseTypes(types).OrderBy(t => t.subTypes))
            {
                var key = memberAdapter.Value.GetKeyForMember(type.type);
                if (!typeIndex.Contains(key))
                {
                    typeIndex.Add(key);
                }
            }
        }

        /// <summary>
        /// Recurses generic type arguments and provides a count so the simplest types can be considered first.
        /// </summary>
        /// <param name="parentTypes">The list of parent types to consider.</param>
        /// <returns>The list of ranked types.</returns>
        private IEnumerable<(int subTypes, Type type)> RecurseTypes(Type[] parentTypes)
        {
            foreach (var type in parentTypes)
            {
                if (type.IsGenericType)
                {
                    var subTypes = RecurseTypes(type.GenericTypeArguments).ToList();
                    var count = subTypes.Count() + subTypes.Sum(s => s.subTypes);
                    yield return (count, type);
                    foreach (var childType in subTypes)
                    {
                        yield return childType;
                    }
                }
                else
                {
                    yield return (0, type);
                }
            }
        }
    }
}

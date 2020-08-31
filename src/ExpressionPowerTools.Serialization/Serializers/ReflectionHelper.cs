// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using ExpressionPowerTools.Core.Extensions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Helper class to cache <see cref="Type"/> and <see cref="MethodInfo"/> information.
    /// </summary>
    public class ReflectionHelper
    {
        /// <summary>
        /// Type cache.
        /// </summary>
        private readonly IDictionary<string, Type> types = new
            Dictionary<string, Type>();

        /// <summary>
        /// Serializable type cache.
        /// </summary>
        private readonly IDictionary<Type, SerializableType> serializableTypes =
            new Dictionary<Type, SerializableType>();

        /// <summary>
        /// Object for locking access to dictionary.
        /// </summary>
        private readonly object lockObj = new object();

        /// <summary>
        /// Cache of members.
        /// </summary>
        private readonly IDictionary<string, MemberInfo> memberCache =
            new Dictionary<string, MemberInfo>();

        /// <summary>
        /// Gets the static instance.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public static ReflectionHelper Instance { get; private set; }
            = new ReflectionHelper();

        /// <summary>
        /// Get a <see cref="Type"/> based on full name.
        /// </summary>
        /// <remarks>
        /// This will check the cache first, then try to create the type, and
        /// finally will scan all assemblies for the type.
        /// </remarks>
        /// <param name="name">The full name of the <see cref="Type"/>.</param>
        /// <returns>The <see cref="Type"/> or <c>null</c>.</returns>
        public Type GetTypeFromCache(string name)
        {
            if (types.ContainsKey(name))
            {
                return types[name];
            }

            var result = Type.GetType(name);

            if (result == null)
            {
                result = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t => t.FullName == name);
            }

            if (result == null)
            {
                return null;
            }

            SafeMutate(
                () => !types.ContainsKey(name),
                () => types.Add(name, result));

            return types[name];
        }

        /// <summary>
        /// Gets the full type name of the serialized type.
        /// </summary>
        /// <param name="serializedType">The <see cref="SerializableType"/>.</param>
        /// <param name="builder">A <see cref="StringBuilder"/>.</param>
        /// <param name="level">The recurision level.</param>
        /// <returns>The full type name.</returns>
        public string GetFullTypeName(
            SerializableType serializedType,
            StringBuilder builder = null,
            int level = 0)
        {
            builder = builder ?? new StringBuilder();

            if (!string.IsNullOrWhiteSpace(serializedType.TypeParamName))
            {
                builder.Append($"<{serializedType.TypeParamName}>");
                return level == 0 ? builder.ToString() : string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(serializedType.FullTypeName))
            {
                builder.Append(serializedType.FullTypeName);
                return level == 0 ? builder.ToString() : string.Empty;
            }

            builder.Append(serializedType.TypeName);
            if (serializedType.GenericTypeArguments != null &&
                serializedType.GenericTypeArguments.Length > 0)
            {
                if (!serializedType.TypeName.Contains("`"))
                {
                    builder.Append($"`{serializedType.GenericTypeArguments.Length}");
                }

                builder.Append("[");

                var first = true;
                foreach (var arg in serializedType.GenericTypeArguments)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        builder.Append(", ");
                    }

                    GetFullTypeName(arg, builder, level + 1);
                }

                builder.Append("]");
            }

            return level == 0 ? builder.ToString() : string.Empty;
        }

        /// <summary>
        /// Deserializes a <see cref="Type"/>.
        /// </summary>
        /// <param name="serializedType">The serialized <see cref="Type"/>.</param>
        /// <returns>The deserialized <see cref="Type"/>.</returns>
        public Type DeserializeType(SerializableType serializedType)
        {
            if (string.IsNullOrWhiteSpace(serializedType.TypeName))
            {
                return null;
            }

            var type = GetTypeFromCache(serializedType.TypeName);
            if (type.IsGenericTypeDefinition && serializedType.GenericTypeArguments != null)
            {
                var typeParams = serializedType
                    .GenericTypeArguments.Select(arg => DeserializeType(arg))
                    .ToArray();
                return type.MakeGenericType(typeParams);
            }

            return type;
        }

        /// <summary>
        /// Creates a serializable type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to serialize.</param>
        /// <returns>The <see cref="SerializableType"/>.</returns>
        public SerializableType SerializeType(Type type)
        {
            if (serializableTypes.ContainsKey(type))
            {
                return serializableTypes[type];
            }

            var serializableType = default(SerializableType);

            if (type.FullName == null)
            {
                serializableType.TypeParamName = type.Name;
                serializableType.FullTypeName = GetFullTypeName(serializableType);
                return serializableType;
            }

            if (type.IsGenericType && !type.IsGenericTypeDefinition)
            {
                var definition = type.GetGenericTypeDefinition();
                serializableType.TypeName = definition.FullName;
                serializableType.GenericTypeArguments =
                    type.GetGenericArguments()
                    .Select(arg => SerializeType(arg))
                    .ToArray();
            }
            else
            {
                serializableType.TypeName = type.FullName;
            }

            serializableType.FullTypeName = GetFullTypeName(serializableType);

            SafeMutate(
                () => !serializableTypes.ContainsKey(type),
                () => serializableTypes.Add(type, serializableType));

            return serializableType;
        }

        /// <summary>
        /// Gets the specified member. Will add to cache if not found.
        /// </summary>
        /// <typeparam name="TMemberInfo">The type of the item to retrieve.</typeparam>
        /// <typeparam name="TMemberBase">The type of the member base.</typeparam>
        /// <param name="member">The key for the item.</param>
        /// <returns>The cached item.</returns>
        public TMemberInfo GetMemberFromCache<TMemberInfo, TMemberBase>(TMemberBase member)
            where TMemberInfo : MemberInfo
            where TMemberBase : MemberBase
        {
            var key = member.GetKey();
            if (memberCache.ContainsKey(key))
            {
                return memberCache[key] as TMemberInfo;
            }

            if (member is Method method)
            {
                return AddMethodToCache(method, key) as TMemberInfo;
            }

            if (member is Property property)
            {
                return AddPropertyToCache(property, key) as TMemberInfo;
            }

            if (member is Field field)
            {
                return AddFieldToCache(field, key) as TMemberInfo;
            }

            return null;
        }

        /// <summary>
        /// Safely mutate the dictionary.
        /// </summary>
        /// <param name="test">Test that must pass.</param>
        /// <param name="action">The action to take.</param>
        protected void SafeMutate(Func<bool> test, Action action)
        {
            if (test())
            {
                Monitor.Enter(lockObj);

                try
                {
                    if (test())
                    {
                        action();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    Monitor.Exit(lockObj);
                }
            }
        }

        private MethodInfo AddMethodToCache(Method method, string key)
        {
            var type = DeserializeType(method.DeclaringType);

            if (type == null)
            {
                return null;
            }

            var staticFlag = method.IsStatic ? BindingFlags.Static : BindingFlags.Instance;
            var methods = type.GetMethods(
                BindingFlags.Public | staticFlag);

            MethodInfo methodInfo = null;
            foreach (var candidate in methods.Where(m => m.Name == method.Name))
            {
                var candidateType = candidate;
                if (method.GenericMethodDefinition != null && candidate.IsGenericMethodDefinition)
                {
                    var typeArgs = candidate.GetGenericArguments().Length;
                    if (method.GenericArguments?.Length == typeArgs)
                    {
                        var types = method.GenericArguments
                            .Select(t => DeserializeType(t))
                            .Where(dt => dt != null).ToArray();
                        if (types.Length == typeArgs)
                        {
                            candidateType = candidate.MakeGenericMethod(types);
                        }
                    }
                }

                var check = new Method(candidateType);
                if (check.GetKey() == key)
                {
                    methodInfo = candidateType;
                    break;
                }
            }

            if (methodInfo == null)
            {
                return null;
            }

            SafeMutate(
                () => !memberCache.ContainsKey(key),
                () => memberCache.Add(key, methodInfo));
            return methodInfo;
        }

        /// <summary>
        /// Finds the property to match and adds it to the cache.
        /// </summary>
        /// <param name="property">The <see cref="Property"/> template to use.</param>
        /// <param name="key">The unique key for the property.</param>
        /// <returns>The <see cref="PropertyInfo"/>.</returns>
        private PropertyInfo AddPropertyToCache(Property property, string key)
        {
            var type = DeserializeType(property.DeclaringType);

            var staticFlag = property.IsStatic ? BindingFlags.Static : BindingFlags.Instance;
            var properties = type.GetProperties(
                BindingFlags.Public | staticFlag);

            PropertyInfo propertyInfo = null;
            foreach (var candidate in properties.Where(p => p.Name == property.Name))
            {
                var check = new Property(candidate);
                if (check.GetKey() == key)
                {
                    propertyInfo = candidate;
                    break;
                }
            }

            if (propertyInfo == null)
            {
                return null;
            }

            SafeMutate(
                () => !memberCache.ContainsKey(key),
                () => memberCache.Add(key, propertyInfo));

            return propertyInfo;
        }

        /// <summary>
        /// Finds the field to match and adds it to the cache.
        /// </summary>
        /// <param name="field">The <see cref="Field"/> template to use.</param>
        /// <param name="key">The unique key for the field.</param>
        /// <returns>The <see cref="FieldInfo"/>.</returns>
        private FieldInfo AddFieldToCache(Field field, string key)
        {
            var type = DeserializeType(field.DeclaringType);

            var staticFlag = field.IsStatic ? BindingFlags.Static : BindingFlags.Instance;
            var fields = type.GetFields(
                BindingFlags.Public | staticFlag);

            FieldInfo fieldInfo = null;
            foreach (var candidate in fields.Where(f => f.Name == field.Name))
            {
                var check = new Field(candidate);
                if (check.GetKey() == key)
                {
                    fieldInfo = candidate;
                    break;
                }
            }

            if (fieldInfo == null)
            {
                return null;
            }

            SafeMutate(
                () => !memberCache.ContainsKey(key),
                () => memberCache.Add(key, fieldInfo));

            return fieldInfo;
        }
    }
}

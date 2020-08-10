// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Parsers
{
    /// <summary>
    /// Utilities for <see cref="MemberInfo"/>.
    /// </summary>
    public static class MemberUtils
    {
        /// <summary>
        /// List of built-in constraints for a type.
        /// </summary>
        private static readonly IDictionary<GenericParameterAttributes, string> BuiltInConstraints =
            new Dictionary<GenericParameterAttributes, string>
            {
                { GenericParameterAttributes.DefaultConstructorConstraint, "The parameter must have a default parameterless constructor." },
                { GenericParameterAttributes.ReferenceTypeConstraint, "The parameter must be a reference type." },
                { GenericParameterAttributes.Contravariant, "The parameter is contravariant. You may use a type that {0} derives from." },
                { GenericParameterAttributes.Covariant, "The parameter is covariant. You may use a type that derives from {0}." },
                { GenericParameterAttributes.NotNullableValueTypeConstraint, "The parameter must be a non-nullable value." },
            };

        /// <summary>
        /// Gets the selector in XML docs for the provided member.
        /// </summary>
        /// <param name="member">The <see cref="MemberInfo"/>.</param>
        /// <returns>The selector.</returns>
        public static string GetSelector(MemberInfo member)
        {
            var typeGenericMap = new Dictionary<string, int>();
            var methodGenericMap = new Dictionary<string, int>();

            char prefixCode;

            string memberName = (member is Type mbr)
                ? mbr.FullName
                : (member.DeclaringType.FullName + "." + member.Name);

            Type[] genericArguments = null;
            var parameterInfos = new ParameterInfo[0];
            var isMethod = member is MethodInfo;

            if (member.DeclaringType != null && member.DeclaringType.IsGenericType)
            {
                var tempTypeGeneric = 0;
                foreach (var genericArg in member.DeclaringType.GetGenericArguments())
                {
                    typeGenericMap[genericArg.Name] = tempTypeGeneric++;
                }
            }

            if (member is MethodInfo method)
            {
                if (method.IsGenericMethod)
                {
                    genericArguments = method.GetGenericArguments();
                }

                parameterInfos = method.GetParameters();
            }
            else if (member is ConstructorInfo ctor)
            {
                if (ctor.IsGenericMethod)
                {
                    genericArguments = ctor.GetGenericArguments();
                }

                parameterInfos = ctor.GetParameters();
            }

            if (genericArguments != null)
            {
                var tempMethodGeneric = 0;
                foreach (var methodGenericArg in genericArguments)
                {
                    methodGenericMap[methodGenericArg.Name] = tempMethodGeneric++;
                }
            }

            var parameters = ParseParameters(typeGenericMap, parameterInfos, isMethod);

            switch (member.MemberType)
            {
                case MemberTypes.Constructor:
                    memberName = memberName.Replace(".ctor", "#ctor");
                    goto case MemberTypes.Method;

                case MemberTypes.Method:
                    prefixCode = 'M';
                    string paramTypesList = string.Join(
                        ",",
                        parameters.ToArray());
                    if (!string.IsNullOrEmpty(paramTypesList))
                    {
                        memberName += "(" + paramTypesList + ")";
                    }

                    break;

                case MemberTypes.Event: prefixCode = 'E'; break;

                case MemberTypes.Field: prefixCode = 'F'; break;

                case MemberTypes.NestedType:
                    memberName = memberName.Replace('+', '.');
                    goto case MemberTypes.TypeInfo;

                case MemberTypes.TypeInfo:
                    prefixCode = 'T';
                    break;

                case MemberTypes.Property: prefixCode = 'P'; break;

                default:
                    throw new ArgumentException("Unknown member type", "member");
            }

            return string.Format("/doc/members/member[@name='{0}:{1}']", prefixCode, memberName);
        }

        /// <summary>
        /// Generates the code declaration for documentation.
        /// </summary>
        /// <param name="memberInfo">The <see cref="MemberInfo"/> to declare code for.</param>
        /// <returns>The code for the specified member.</returns>
        public static string GenerateCodeFor(MemberInfo memberInfo)
        {
            if (memberInfo is Type type)
            {
                return GenerateCodeForType(type);
            }

            if (memberInfo is MethodBase method)
            {
                return GenerateCodeForMethodOrCtor(method);
            }

            if (memberInfo is PropertyInfo property)
            {
                return GenerateCodeForProperty(property);
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns a list of generic type constraints.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to parse.</param>
        /// <param name="docType">The <see cref="DocTypeParameter"/> to parse to.</param>
        public static void ParseGenericTypeConstraints(Type type, DocTypeParameter docType)
        {
            docType.IsContravariant = (type.GenericParameterAttributes & GenericParameterAttributes.Contravariant) > 0;
            docType.IsCovariant = (type.GenericParameterAttributes & GenericParameterAttributes.Contravariant) > 0;
            foreach (var attribute in BuiltInConstraints)
            {
                if ((type.GenericParameterAttributes & attribute.Key) > 0)
                {
                    docType.TypeConstraints.Add(new TypeRef { FriendlyName = string.Format(attribute.Value, $"`{TypeCache.Cache[type].FriendlyName}`") });
                }
            }

            foreach (var constraint in type.GetGenericParameterConstraints())
            {
                docType.TypeConstraints.Add(TypeCache.Cache[constraint]);
            }
        }

        /// <summary>
        /// Processes parameters and annotates based on the type map.
        /// </summary>
        /// <param name="genericMap">The generic map for the type or method.</param>
        /// <param name="parameters">The list of <see cref="ParameterInfo"/>.</param>
        /// <param name="isMethod">Set to <c>true</c> for methods and <c>false</c> for types.</param>
        private static IList<string> ParseParameters(
            Dictionary<string, int> genericMap,
            ParameterInfo[] parameters,
            bool isMethod = false)
        {
            var result = new List<string>();

            foreach (var parameter in parameters)
            {
                var paramType = parameter.ParameterType;
                var param = string.Empty;
                var tick = isMethod ? "``" : "`";
                if (paramType.HasElementType)
                {
                    if (paramType.IsArray)
                    {
                        param = $"{paramType.FullName}[]";
                    }
                    else if (paramType.IsPointer)
                    {
                        param = $"{paramType.FullName}*";
                    }
                    else if (paramType.IsByRef)
                    {
                        param = $"{paramType.FullName}@";
                    }
                }
                else if (paramType.IsGenericParameter)
                {
                    if (paramType.FullName == null && genericMap.ContainsKey(paramType.Name))
                    {
                        param = $"{tick}{genericMap[paramType.Name]}";
                    }
                }
                else if (paramType.ContainsGenericParameters)
                {
                    var fullname = paramType.FullName ?? $"{paramType.Namespace}.{paramType.Name}";
                    fullname = fullname.Substring(0, fullname.IndexOf('`')) + "{";
                    var first = true;
                    foreach (var typeArg in paramType.GenericTypeArguments)
                    {
                        if (genericMap.ContainsKey(typeArg.Name))
                        {
                            if (first)
                            {
                                first = false;
                            }
                            else
                            {
                                fullname += ",";
                            }

                            fullname += $"{tick}{genericMap[typeArg.Name]}";
                        }
                    }

                    param = $"{fullname}}}";
                }
                else
                {
                    param = paramType.FullName ?? paramType.Name;
                }

                result.Add(param);
            }

            return result;
        }

        /// <summary>
        /// Generates the code that defines a property.
        /// </summary>
        /// <param name="property">The <see cref="PropertyInfo"/> to process.</param>
        /// <returns>The code declaration.</returns>
        private static string GenerateCodeForProperty(PropertyInfo property)
        {
            var sb = new StringBuilder();
            var methodInfo = property.CanRead ? property.GetMethod : property.SetMethod;
            ParseAccess(methodInfo, sb);
            sb.Append(TypeCache.Cache[property.PropertyType].FriendlyName);
            sb.Append($" {property.Name} {{ ");
            if (property.CanRead)
            {
                sb.Append("get; ");
            }

            if (property.CanWrite)
            {
                if (methodInfo.IsPublic && property.SetMethod.IsPrivate)
                {
                    sb.Append("private ");
                }

                sb.Append("set; ");
            }

            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// Parses the access information for the method or property.
        /// </summary>
        /// <param name="methodInfo">The <see cref="MethodInfo"/> to parse.</param>
        /// <param name="sb">The <see cref="StringBuilder"/> to parse into.</param>
        private static void ParseAccess(MethodInfo methodInfo, StringBuilder sb)
        {
            if (methodInfo.IsPublic)
            {
                sb.Append("public ");
            }
            else if (methodInfo.IsFamily)
            {
                sb.Append("protected ");
            }
            else if (methodInfo.IsPrivate)
            {
                sb.Append("private ");
            }

            if (methodInfo.IsStatic)
            {
                sb.Append("static ");
            }
            else if (methodInfo.IsVirtual)
            {
                sb.Append("virtual ");
            }
        }

        /// <summary>
        /// Generates the code for a method or a constructor.
        /// </summary>
        /// <param name="method">The <see cref="MethodBase"/> to process.</param>
        /// <returns>The code definition.</returns>
        private static string GenerateCodeForMethodOrCtor(MethodBase method)
        {
            var sb = new StringBuilder();

            if (method is ConstructorInfo ctor)
            {
                var type = TypeCache.Cache[ctor.DeclaringType].FriendlyName;

                // no generics in Ctor definition
                if (type.IndexOf("<") > 0)
                {
                    type = type.Substring(0, type.IndexOf("<"));
                }

                sb.Append(type);
            }
            else if (method is MethodInfo methodInfo)
            {
                ParseAccess(methodInfo, sb);
                var returnType = methodInfo.ReturnType;
                sb.Append(TypeCache.Cache[returnType].FriendlyName);
                sb.Append(" ");
                sb.Append(TypeCache.Cache.GetFriendlyMethodName(methodInfo));
            }

            sb.Append("(");

            var first = true;
            foreach (var parameter in method.GetParameters())
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }

                var type = TypeCache.Cache[parameter.ParameterType].FriendlyName;
                var name = parameter.Name;
                sb.Append($"{type} {name}");
            }

            sb.Append(")");
            return sb.ToString();
        }

        /// <summary>
        /// Generates the code to construct a type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to generate code for.</param>
        /// <returns>The code for the type.</returns>
        private static string GenerateCodeForType(Type type)
        {
            var sb = new StringBuilder("public ");
            if (type.IsInterface)
            {
                sb.Append("interface ");
            }
            else if (type.IsEnum)
            {
                sb.Append("enum ");
            }
            else
            {
                if (type.IsAbstract)
                {
                    sb.Append(type.IsSealed ? "static " : "abstract ");
                }

                sb.Append("class ");
            }

            sb.Append(TypeCache.Cache[type].FriendlyName);

            if (type.IsEnum)
            {
                return sb.ToString();
            }

            var first = true;
            var allInterfaces = type.GetInterfaces();

            var directInterfaces = allInterfaces
                .Where(i => !allInterfaces.Any(t => t.GetInterfaces().Contains(i)));

            var implemented = type.BaseType == typeof(object) ?
                directInterfaces : new[] { type.BaseType }.Union(directInterfaces);

            foreach (var i in implemented.Where(i => i != null))
            {
                if (first)
                {
                    sb.Append(" : ");
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(TypeCache.Cache[i].FriendlyName);
            }

            // check constraints
            foreach (var tParam in type.GetGenericArguments().Where(t => t.IsGenericParameter))
            {
                foreach (var constraint in tParam.GetGenericParameterConstraints())
                {
                    sb.Append($"{ParserUtils.NewLine}   where {tParam.Name} : {TypeCache.Cache[constraint].FriendlyName}");
                }
            }

            return sb.ToString();
        }
    }
}

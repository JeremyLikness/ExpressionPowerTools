// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Resources;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Extensions
{
    /// <summary>
    /// Extensions for filtering <see cref="IExpressionEnumerator"/>.
    /// </summary>
    public static class IExpressionEnumeratorExtensions
    {
        /// <summary>
        /// Helper extension to extract constants from an expression tree.
        /// </summary>
        /// <typeparam name="T">The type of constant to extract.</typeparam>
        /// <param name="expressionEnumerator">The <see cref="IExpressionEnumerator"/> to parse.</param>
        /// <exception cref="ArgumentNullException">Thrown when enumerator is null.</exception>
        /// <returns>The <see cref="IEnumerable{ConstantExpression}"/> with
        /// matching types.</returns>
        public static IEnumerable<ConstantExpression> ConstantsOfType<T>(
            this IExpressionEnumerator expressionEnumerator)
        {
            Ensure.NotNull(() => expressionEnumerator);
            return expressionEnumerator.OfType<ConstantExpression>()
                .Where(ce => ce.Type == typeof(T));
        }

        /// <summary>
        /// Extracts instances of expressions that represent a method
        /// on a type.
        /// </summary>
        /// <param name="expressionEnumerator">The <see cref="IExpressionEnumerator"/> to query.</param>
        /// <param name="type">The <see cref="Type"/> to check for.</param>
        /// <param name="name">The name of the method.</param>
        /// <returns>The filtered <see cref="IEnumerable{MethodCallExpression}"/> result.</returns>
        public static IEnumerable<MethodCallExpression>
            MethodsWithNameForType(
            this IExpressionEnumerator expressionEnumerator,
            Type type,
            string name)
        {
            Ensure.NotNull(() => expressionEnumerator);
            Ensure.NotNullOrWhitespace(() => name);
            return expressionEnumerator
                .OfType<MethodCallExpression>()
                .Where(mce => mce.Method.DeclaringType == type &&
                mce.Method.Name == name);
        }

        /// <summary>
        /// Extracts instances of expressions that represent a method
        /// on a type.
        /// </summary>
        /// <typeparam name="T">The type hosting the method.</typeparam>
        /// <param name="expressionEnumerator">The <see cref="IExpressionEnumerator"/> to query.</param>
        /// <param name="name">The name of the method to query for.</param>
        /// <returns>The <see cref="IEnumerable{MethodCallExpression}"/> filtered results.</returns>
        public static IEnumerable<MethodCallExpression>
            MethodsWithNameForType<T>(
            this IExpressionEnumerator expressionEnumerator,
            string name)
        {
            return MethodsWithNameForType(
                expressionEnumerator,
                typeof(T),
                name);
        }

        /// <summary>
        /// Use a template to specify the method to search for.
        /// </summary>
        /// <remarks>
        /// Only matches method name and declaring type. Arguments are ignored.
        /// </remarks>
        /// <typeparam name="T">The <see cref="Type"/> the method is on.</typeparam>
        /// <param name="expressionEnumerator">The <see cref="IExpressionEnumerator"/> to query.</param>
        /// <param name="method">An expression that accesses the method.</param>
        /// <returns>The list of matching <see cref="MethodCallExpression"/> instances.</returns>
        public static IEnumerable<MethodCallExpression>
            MethodsFromTemplate<T>(
            this IExpressionEnumerator expressionEnumerator,
            Expression<Action<T>> method)
        {
            Ensure.NotNull(() => method);
            var lambda = method as LambdaExpression;
            if (lambda.Body is MethodCallExpression mc)
            {
                if (mc.Method.DeclaringType == typeof(T))
                {
                    return MethodsWithNameForType<T>(
                        expressionEnumerator,
                        mc.Method.Name);
                }
            }

            throw ExceptionHelper
                .MethodCallOnTypeRequiredException(
                nameof(method));
        }

        /// <summary>
        /// Helper extension to extract methods with a particular name.
        /// </summary>
        /// <param name="expressionEnumerator">The <see cref="IExpressionEnumerator"/> to query.</param>
        /// <param name="name">The method name to extract.</param>
        /// <returns>The <see cref="IEnumerable{T}"/> result.</returns>
        public static IEnumerable<MethodCallExpression> MethodsWithName(
            this IExpressionEnumerator expressionEnumerator,
            string name)
        {
            Ensure.NotNull(() => expressionEnumerator);
            Ensure.NotNullOrWhitespace(() => name);
            return expressionEnumerator
                .OfType<MethodCallExpression>()
                .Where(mce => mce.Method.Name == name);
        }

        /// <summary>
        /// Helper method to extract members with a name.
        /// </summary>
        /// <typeparam name="T">The type the member belongs to.</typeparam>
        /// <param name="expressionEnumerator">The <see cref="IExpressionEnumerator"/>.</param>
        /// <param name="name">The name of the member.</param>
        /// <returns>The instances of <see cref="MemberExpression"/> that refer to it.</returns>
        public static IEnumerable<MemberExpression> MembersWithNameOnType<T>(
            this IExpressionEnumerator expressionEnumerator,
            string name)
        {
            Ensure.NotNull(() => expressionEnumerator);
            Ensure.NotNullOrWhitespace(() => name);
            return expressionEnumerator
                .OfType<MemberExpression>()
                .Where(me => me.Member.DeclaringType == typeof(T) &&
                me.Member.Name == name);
        }

        /// <summary>
        /// Helper extension to extract nodes with a specific
        /// <see cref="ExpressionType"/> value.
        /// </summary>
        /// <param name="expressionEnumerator">The <see cref="IExpressionEnumerator"/> to query.</param>
        /// <param name="type">The <see cref="ExpressionType"/> to extract.</param>
        /// <returns>The filtered result of <see cref="IEnumerable{Expression}"/>.</returns>
        public static IEnumerable<Expression> OfExpressionType(
            this IExpressionEnumerator expressionEnumerator, ExpressionType type)
        {
            Ensure.NotNull(() => expressionEnumerator);
            return expressionEnumerator
                .Where(e => e.NodeType == type);
        }
    }
}

// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Extensions
{
    /// <summary>
    /// Extensions related to comparisons of types on <see cref="Expression"/> instances.
    /// </summary>
    public static partial class ExpressionRulesExtensions
    {
        /// <summary>
        /// The <see cref="ExpressionType"/> must be the same.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>An expression that evaluates whether the node types match.</returns>
        public static Expression<Func<T, T, bool>> NodeTypesMustMatch<T>()
            where T : Expression => (s, t) => s.NodeType == t.NodeType;

        /// <summary>
        /// And the <see cref="ExpressionType"/> must be the same.
        /// </summary>
        /// <param name="rule">The existing rule.</param>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>An expression that evaluates whether the node types match.</returns>
        public static Expression<Func<T, T, bool>> AndNodeTypesMustMatch<T>(
            this Expression<Func<T, T, bool>> rule)
            where T : Expression => And(rule, NodeTypesMustMatch<T>());

        /// <summary>
        /// Or the <see cref="ExpressionType"/> must be the same.
        /// </summary>
        /// <param name="rule">The existing rule.</param>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>An expression that evaluates whether the node types match.</returns>
        public static Expression<Func<T, T, bool>> OrNodeTypesMustMatch<T>(
            this Expression<Func<T, T, bool>> rule)
            where T : Expression => Or(rule, NodeTypesMustMatch<T>());

        /// <summary>
        /// The source type must be similar to <see cref="Expression"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>A flag indicating whether the source type is similar to an expression.</returns>
        public static Expression<Func<T, T, bool>> SourceTypeMustBeSimilarToExpression<T>()
            where T : Expression => (s, t) => Comparisons.ExpressionSimilarity.TypesAreSimilar(
                 s.Type, typeof(Expression));

        /// <summary>
        /// The source type must be an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>A value that indicates whether the source type is a typed enumerable.</returns>
        public static Expression<Func<T, T, bool>> SourceTypeMustBeTypedEnumerable<T>()
            where T : Expression => (s, t) =>
                s.Type.GetInterfaces().Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

        /// <summary>
        /// The source type must derive from or be an <see cref="Array"/> or <see cref="System.Collections.ICollection"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>A value that indicates whether the source type is array or collection.</returns>
        public static Expression<Func<T, T, bool>> SourceTypeMustBeArrayOrCollection<T>()
            where T : Expression => (s, t) => typeof(Array).IsAssignableFrom(s.Type)
                     || typeof(System.Collections.ICollection).IsAssignableFrom(s.Type);

        /// <summary>
        /// Types of the expressions must be the same.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>An expression that evaluates whether the types match.</returns>
        public static Expression<Func<T, T, bool>> TypesMustMatch<T>()
            where T : Expression => (s, t) => s.Type == t.Type;

        /// <summary>
        /// Types of the expressions must be similar.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>An expression that evaluates whether the types are similar.</returns>
        public static Expression<Func<T, T, bool>> TypesMustBeSimilar<T>()
            where T : Expression => (s, t) => Comparisons.ExpressionSimilarity.TypesAreSimilar(s.Type, t.Type);

        /// <summary>
        /// AND types of the expressions must be similar.
        /// </summary>
        /// <param name="rule">The rule to include.</param>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>An expression that evaluates whether the types are similar.</returns>
        public static Expression<Func<T, T, bool>> AndTypesMustBeSimilar<T>(
            this Expression<Func<T, T, bool>> rule)
            where T : Expression => And(rule, TypesMustBeSimilar<T>());

        /// <summary>
        /// Types of the expressions must be similar.
        /// </summary>
        /// <param name="typeAccess">Access to the type.</param>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>An expression that evaluates whether the types are similar.</returns>
        public static Expression<Func<T, T, bool>> TypesMustBeSimilar<T>(
            Func<T, Type> typeAccess)
            where T : Expression => (s, t) => Comparisons.ExpressionSimilarity.TypesAreSimilar(
                typeAccess(s), typeAccess(t));

        /// <summary>
        /// Types of the expressions must be similar.
        /// </summary>
        /// <param name="rule">The rule to attach to.</param>
        /// <param name="typeAccess">Access to the type.</param>
        /// <typeparam name="T">The type of the <see cref="Expression"/>.</typeparam>
        /// <returns>An expression that evaluates whether the types are similar.</returns>
        public static Expression<Func<T, T, bool>> AndTypesMustBeSimilar<T>(
            this Expression<Func<T, T, bool>> rule,
            Func<T, Type> typeAccess)
            where T : Expression => rule.And(TypesMustBeSimilar(typeAccess));
    }
}

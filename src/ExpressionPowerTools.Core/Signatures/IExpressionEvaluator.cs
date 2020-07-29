// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Signatures
{
    /// <summary>
    /// Evaluator as facade to equivalency and similarity.
    /// </summary>
    public interface IExpressionEvaluator
    {
        /// <summary>
        /// Entry for equivalency comparisons. Will cast to
        /// known types and compare.
        /// </summary>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/> to compare to.</param>
        /// <returns>A flag indicating whether the source and target are equivalent.</returns>
        bool AreEquivalent(Expression source, Expression target);

        /// <summary>
        /// Entry for equivalency comparisons. Will cast to
        /// known types and compare.
        /// </summary>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <param name="source">The source <see cref="IQueryable{T}"/>.</param>
        /// <param name="target">The target <see cref="IQueryable{T}"/> to compare to.</param>
        /// <returns>A flag indicating whether the source and target are equivalent.</returns>
        bool AreEquivalent<T>(IQueryable<T> source, IQueryable<T> target);

        /// <summary>
        /// Comparison of multiple expressions. Equivalent
        /// only when all elements match, in order, and
        /// pass the equivalent test.
        /// </summary>
        /// <param name="source">The source expressions.</param>
        /// <param name="target">The target expressions.</param>
        /// <returns>A flag indicating whether the two sets of
        /// expressions are equivalent.</returns>
        bool AreEquivalent(
            IEnumerable<Expression> source, IEnumerable<Expression> target);

        /// <summary>
        /// Entry for similarity comparisons. Will cast to
        /// known types and compare.
        /// </summary>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/> to compare to.</param>
        /// <returns>A flag indicating whether the source and target are similar.</returns>
        bool AreSimilar(Expression source, Expression target);

        /// <summary>
        /// Entry for similarity comparisons. Will cast to
        /// known types and compare.
        /// </summary>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <param name="source">The source <see cref="IQueryable{T}"/>.</param>
        /// <param name="target">The target <see cref="IQueryable{T}"/> to compare to.</param>
        /// <returns>A flag indicating whether the source and target are similar.</returns>
        bool AreSimilar<T>(IQueryable<T> source, IQueryable<T> target);

        /// <summary>
        /// Comparison of multiple expressions. Similar
        /// only when all elements match, in order, and
        /// pass the similarity test. It's fine if the
        /// source does not have the same number of entities
        /// as the target.
        /// </summary>
        /// <param name="source">The source expressions.</param>
        /// <param name="target">The target expressions.</param>
        /// <returns>A flag indicating whether the two sets of
        /// expressions are Similar.</returns>
        bool AreSimilar(
            IEnumerable<Expression> source,
            IEnumerable<Expression> target);

        /// <summary>
        /// Determines whether an <see cref="Expression"/> is part of another expression.
        /// </summary>
        /// <remarks>
        /// A source is part of a target if an <see cref="Expression"/> exists in the
        /// target's tree that is similar to the source.
        /// </remarks>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/> to parse.</param>
        /// <returns>A flag indicating whether the source is part of the target.</returns>
        bool IsPartOf(Expression source, Expression target);

        /// <summary>
        /// Determines whether an <see cref="IQueryable{T}"/> is part of another query.
        /// </summary>
        /// <remarks>
        /// A source is part of a target if an <see cref="Expression"/> exists in the
        /// target's tree that is similar to the source.
        /// </remarks>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <param name="source">The source <see cref="IQueryable{T}"/>.</param>
        /// <param name="target">The target <see cref="IQueryable{T}"/> to parse.</param>
        /// <returns>A flag indicating whether the source is part of the target.</returns>
        bool IsPartOf<T>(IQueryable<T> source, IQueryable<T> target);
    }
}

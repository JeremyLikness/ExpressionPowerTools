// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections;
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
        /// Determine if a <see cref="Type"/> is equivalent to another type.
        /// </summary>
        /// <remarks>
        /// Handles anonymous types converted to dynamic dictionary.
        /// </remarks>
        /// <param name="source">The source <see cref="Type"/>.</param>
        /// <param name="target">The target <see cref="Type"/>.</param>
        /// <returns>A value indicating whether the types are equivalent.</returns>
        bool TypesAreEquivalent(Type source, Type target);

        /// <summary>
        /// Attempts to compare values in various ways.
        /// </summary>
        /// <remarks>
        /// <para>If one side is <c>null</c> and other is not <c>null</c>, returns <c>false</c>. If the objects are the same reference,
        /// returns <c>true</c>. If the type implements <see cref="IEquatable{T}"/> then the result of <see cref="IEquatable{T}.Equals(T)"/>
        /// is returned. If the type implements <see cref="IComparable"/> then the result is <c>true</c> if
        /// <see cref="IComparable.CompareTo(object)"/> is <c>0</c>. Otherwise, the result of <see cref="object.Equals(object)"/> from
        /// the source to the target is returned.</para>
        /// <para>Exceptions are compared by the `Message` property. The comparison is also recursive: if a type is found that has an
        /// existing comparison method, the method is called for further validation.</para>
        /// </remarks>
        /// <param name="source">The source value.</param>
        /// <param name="target">The target value.</param>
        /// <returns>A flag indicating equivalency.</returns>
        bool ValuesAreEquivalent(object source, object target);

        /// <summary>
        /// Ensures that two <see cref="MemberBinding"/> instances are equivalent.
        /// </summary>
        /// <param name="source">The source <see cref="MemberBinding"/>.</param>
        /// <param name="target">The target <see cref="MemberBinding"/>.</param>
        /// <returns>A value that indicates whether the bindings are equivalent.</returns>
        bool MemberBindingsAreEquivalent(MemberBinding source, MemberBinding target);

        /// <summary>
        /// Ensures two dictionaries are equivalent.
        /// </summary>
        /// <param name="source">The source <see cref="IDictionary"/>.</param>
        /// <param name="target">The target <see cref="IDictionary"/>.</param>
        /// <returns>A value indicating whether the dictionaries are equivalent.</returns>
        bool DictionariesAreEquivalent(IDictionary source, IDictionary target);

        /// <summary>
        /// Ensures two enumerables are same length an each value is equivalent.
        /// </summary>
        /// <param name="srcEnumerable">The source <see cref="IEnumerable"/>.</param>
        /// <param name="tgtEnumerable">The target <see cref="IEnumerable"/>.</param>
        /// <returns>A flag indicating whether the two are equivalent.</returns>
        bool NonGenericEnumerablesAreEquivalent(IEnumerable srcEnumerable, IEnumerable tgtEnumerable);

        /// <summary>
        /// Comparison matrix for types and nulls.
        /// </summary>
        /// <param name="source">The source to compare.</param>
        /// <param name="other">The target to compare to.</param>
        /// <returns>A flag indicating whether the types are
        /// equal and the values are both not null.</returns>
        bool NullAndTypeCheck(Expression source, Expression other);

        /// <summary>
        /// Compares two anonymous values.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns>A value indicating whether the anonymous values are equivalent.</returns>
        bool AnonymousValuesAreEquivalent(object source, object target);

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

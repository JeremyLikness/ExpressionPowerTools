// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Extensions
{
    /// <summary>
    /// Extensions that are rules for logical comparisons.
    /// </summary>
    public static partial class ExpressionRulesExtensions
    {
        /// <summary>
        /// Start of tree with left and right "or" branches.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="left">Left rule.</param>
        /// <param name="right">Right rule.</param>
        /// <returns>A value that indicates whether the left or the
        /// right resolved to <c>true</c>.</returns>
        public static Expression<Func<T, T, bool>> Or<T>(
            this Expression<Func<T, T, bool>> left,
            Expression<Func<T, T, bool>> right)
            where T : Expression
        {
            // left is the input to the right
            var expr = Expression.Invoke(right, left.Parameters);
            return Expression.Lambda<Func<T, T, bool>>(
                Expression.OrElse(left.Body, expr), left.Parameters);
        }

        /// <summary>
        /// Start of tree with left and right "and" branches.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="left">Left rule.</param>
        /// <param name="right">Right rule.</param>
        /// <returns>A value that indicates wheter both left and right evaluated to <c>true</c>.</returns>
        public static Expression<Func<T, T, bool>> And<T>(
            this Expression<Func<T, T, bool>> left,
            Expression<Func<T, T, bool>> right)
            where T : Expression
        {
            var expr = Expression.Invoke(right, left.Parameters);
            return Expression.Lambda<Func<T, T, bool>>(
                Expression.AndAlso(left.Body, expr), left.Parameters);
        }
    }
}

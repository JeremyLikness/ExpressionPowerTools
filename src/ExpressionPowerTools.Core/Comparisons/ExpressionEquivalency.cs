// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Comparisons
{
    /// <summary>
    /// Host for comparisons.
    /// </summary>
    public static class ExpressionEquivalency
    {
        /// <summary>
        /// Entry for equivalency comparisons. Will cast to
        /// known types and compare.
        /// </summary>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/> to compare to.</param>
        /// <returns>A flag indicating whether the source and target are equivalent.</returns>
        public static bool AreEquivalent(
            Expression source,
            Expression target)
        {
            var equivalent = false;

            if (NullAndTypeCheck(source, target))
            {
                switch (source)
                {
                    case ConstantExpression constant:
                        equivalent = ConstantsAreEquivalent(
                            constant,
                            (ConstantExpression)target);
                        break;

                    case ParameterExpression parameter:
                        equivalent = ParametersAreEquivalent(
                            parameter,
                            (ParameterExpression)target);
                        break;

                    case BinaryExpression binary:
                        equivalent = BinariesAreEquivalent(
                            binary,
                            (BinaryExpression)target);
                        break;

                    case UnaryExpression unary:
                        equivalent = UnariesAreEquivalent(
                            unary,
                            (UnaryExpression)target);
                        break;

                    case MemberExpression member:
                        equivalent = MembersAreEquivalent(
                            member,
                            (MemberExpression)target);
                        break;

                    case MethodCallExpression method:
                        equivalent = MethodsAreEquivalent(
                            method,
                            (MethodCallExpression)target);
                        break;

                    case LambdaExpression lambda:
                        equivalent = LambdasAreEquivalent(
                            lambda,
                            (LambdaExpression)target);
                        break;
                }
            }

            return equivalent;
        }

        /// <summary>
        /// Comparison of multiple expressions. Equivalent
        /// only when all elements match, in order, and
        /// pass the equivalent test.
        /// </summary>
        /// <param name="source">The source expressions.</param>
        /// <param name="target">The target expressions.</param>
        /// <returns>A flag indicating whether the two sets of
        /// expressions are equivalent.</returns>
        public static bool AreEquivalent(
            IEnumerable<Expression> source,
            IEnumerable<Expression> target)
        {
            var src = source.GetEnumerator();
            var tgt = target.GetEnumerator();
            while (src.MoveNext())
            {
                if (!tgt.MoveNext())
                {
                    return false;
                }

                if (!AreEquivalent(
                    src.Current,
                    tgt.Current))
                {
                    return false;
                }
            }

            return !tgt.MoveNext();
        }

        /// <summary>
        /// Determine whether two lambdas are equivalent.
        /// </summary>
        /// <remarks>
        /// Two lambda expressions are equivalent when they share the same type,
        /// name, tail call optimization, parameter count, and when both body
        /// and parameters are equivalent.
        /// </remarks>
        /// <param name="source">The source <see cref="LambdaExpression"/>.</param>
        /// <param name="target">The target <see cref="LambdaExpression"/>.</param>
        /// <returns>A flag indicating whether the two expressions are equivalent.</returns>
        private static bool LambdasAreEquivalent(
            LambdaExpression source,
            LambdaExpression target)
        {
            // the type check is handled already because the lambda's type
            // is the same

            // the parameter check is handled by the type check because it
            // shapes the type
            if (source.Name != target.Name ||
                source.TailCall != target.TailCall)
            {
                return false;
            }

            return AreEquivalent(source.Body, target.Body);
        }

        /// <summary>
        /// Determine whether two methods are equivalent.
        /// </summary>
        /// <remarks>
        /// Two metods are equivalent when they share the same return type,
        /// the same declaring type, the same name, are either both instance
        /// or static fields, and all arguments pass equivalency.
        /// </remarks>
        /// <param name="source">The source <see cref="MethodCallExpression"/>.</param>
        /// <param name="target">The target <see cref="MethodCallExpression"/>.</param>
        /// <returns>A flag indicating whether the two expressions are equivalent.</returns>
        private static bool MethodsAreEquivalent(
            MethodCallExpression source,
            MethodCallExpression target)
        {
            if (source.Type != target.Type ||
                source.Method.DeclaringType != target.Method.DeclaringType ||
                source.Method.Name != target.Method.Name)
            {
                return false;
            }

            if (source.Arguments.Count != target.Arguments.Count)
            {
                return false;
            }

            // always null when static
            if (source.Object != null)
            {
                if (!AreEquivalent(source.Object, target.Object))
                {
                    return false;
                }
            }

            return AreEquivalent(
                source.Arguments.AsEnumerable(),
                target.Arguments.AsEnumerable());
        }

        /// <summary>
        /// Determine whether two members are equivalent.
        /// </summary>
        /// <remarks>
        /// Two instances of <see cref="MemberInitExpression"/> are equivalent
        /// when they share the same type (this will match the member type), the same
        /// declaring type, the same name, and if there is an expression, the
        /// expressions are equivalent.
        /// </remarks>
        /// <param name="source">The source <see cref="MemberExpression"/>.</param>
        /// <param name="target">The target <see cref="MemberExpression"/>.</param>
        /// <returns>A flag indicating whether the two expressions are equivalent.</returns>
        private static bool MembersAreEquivalent(
            MemberExpression source,
            MemberExpression target)
        {
            if (source.Type != target.Type ||
                source.Member.DeclaringType != target.Member.DeclaringType ||
                source.Member.Name != target.Member.Name)
            {
                return false;
            }

            return source.Expression == null ||
                AreEquivalent(source.Expression, target.Expression);
        }

        /// <summary>
        /// Determines whether two unaries are equivalent.
        /// </summary>
        /// <remarks>
        /// Two instances of <see cref="UnaryExpression"/> are equivalent when they share the same
        /// <see cref="ExpressionType"/>, method information, and when their operands pass
        /// equivalency.
        /// </remarks>
        /// <param name="source">The source <see cref="UnaryExpression"/>.</param>
        /// <param name="target">The target <see cref="UnaryExpression"/>.</param>
        /// <returns>A flag that indicates whether the two expressions are equivalent.</returns>
        private static bool UnariesAreEquivalent(
            UnaryExpression source,
            UnaryExpression target)
        {
            if (source.NodeType != target.NodeType)
            {
                return false;
            }

            if (source.IsLifted != target.IsLifted ||
                source.IsLiftedToNull != target.IsLiftedToNull)
            {
                return false;
            }

            if ((source.Method != null && target.Method == null) ||
                (source.Method == null && target.Method != null))
            {
                return false;
            }

            if (source.Method != null)
            {
                if (source.Method.DeclaringType != target.Method.DeclaringType ||
                    source.Method.Name != target.Method.Name)
                {
                    return false;
                }
            }

            return AreEquivalent(source.Operand, target.Operand);
        }

        /// <summary>
        /// Determines whether two binaries are equivalent.
        /// </summary>
        /// <remarks>
        /// Two instances of <see cref="BinaryExpression"/> are equivalent when they share the same
        /// <see cref="ExpressionType"/> and the recursive determination of the left expressoin and
        /// the right expressions is equivalent.
        /// </remarks>
        /// <param name="source">The source <see cref="BinaryExpression"/>.</param>
        /// <param name="target">The target <see cref="BinaryExpression"/>.</param>
        /// <returns>A flag that indicates whether the two expressions are equivalent.</returns>
        private static bool BinariesAreEquivalent(
            BinaryExpression source,
            BinaryExpression target)
        {
            if (source.NodeType != target.NodeType)
            {
                return false;
            }

            return AreEquivalent(source.Left, target.Left) &&
                AreEquivalent(source.Right, target.Right);
        }

        /// <summary>
        /// Method to compare two <seealso cref="ConstantExpression"/>
        /// instances.
        /// </summary>
        /// <remarks>
        /// To be true, both must have the same type and value. If the
        /// value is an expression tree, it is recursed.
        /// </remarks>
        /// <param name="source">The source <see cref="ConstantExpression"/>.</param>
        /// <param name="target">The target <see cref="ConstantExpression"/>.</param>
        /// <returns>A flag indicating whether the two are equivalent.</returns>
        private static bool ConstantsAreEquivalent(
            ConstantExpression source,
            ConstantExpression target)
        {
            if (source.Type != target.Type)
            {
                return false;
            }

            if (source.Value == null)
            {
                return target.Value == null;
            }

            if (source.Value is Expression expression)
            {
                return AreEquivalent(
                    expression,
                    target.Value as Expression);
            }

            if (source.Value is System.Collections.IEnumerable enumerable)
            {
                var targetEnumerable = target.Value as System.Collections.IEnumerable;
                var src = enumerable.GetEnumerator();
                var tgt = targetEnumerable.GetEnumerator();
                while (src.MoveNext())
                {
                    if (!tgt.MoveNext())
                    {
                        return false;
                    }

                    if (src.Current == null && tgt.Current == null)
                    {
                        continue;
                    }

                    if (src.Current == null || tgt.Current == null)
                    {
                        return false;
                    }

                    if (!src.Current.Equals(tgt.Current))
                    {
                        return false;
                    }
                }

                return !tgt.MoveNext();
            }

            return source.Value.Equals(target.Value);
        }

        /// <summary>
        /// Check for equivalent parameters.
        /// </summary>
        /// <remarks>
        /// To be true, type, value, and reference must be the same.
        /// </remarks>
        /// <param name="source">The source <see cref="ParameterExpression"/>.</param>
        /// <param name="target">The target <see cref="ParameterExpression"/>.</param>
        /// <returns>A flag indicating whether the two are equivalent.</returns>
        private static bool ParametersAreEquivalent(
            ParameterExpression source,
            ParameterExpression target) =>
            source.Type == target.Type &&
            source.Name == target.Name &&
            source.IsByRef == target.IsByRef;

        /// <summary>
        /// Comparison matrix for types and nulls.
        /// </summary>
        /// <param name="source">The source to compare.</param>
        /// <param name="other">The target to compare to.</param>
        /// <returns>A flag indicating whether the types are
        /// equal and the values are both not null.</returns>
        private static bool NullAndTypeCheck(
            Expression source,
            Expression other)
        {
            if (source == null || other == null)
            {
                return false;
            }

            if (other.GetType() != source.GetType())
            {
                return false;
            }

            return true;
        }
    }
}

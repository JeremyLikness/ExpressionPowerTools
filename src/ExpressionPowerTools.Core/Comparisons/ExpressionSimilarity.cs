using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Comparisons
{
    /// <summary>
    /// Expression similarity methods.
    /// </summary>
    public static class ExpressionSimilarity
    {
        /// <summary>
        /// Entry for similarity comparisons. Will cast to
        /// known types and compare.
        /// </summary>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/> to compare to.</param>
        /// <returns>A flag indicating whether the source and target are similar.</returns>
        public static bool AreSimilar(
            Expression source,
            Expression target)
        {
            var similar = false;

            if (source != null && target != null)
            {
                switch (source)
                {
                    case ConstantExpression constant:
                        similar = TypeCheckAndCompare(
                            constant,
                            target,
                            (s, t) => ConstantsAreSimilar(s, t));
                        break;

                    case ParameterExpression parameter:
                        similar = target is ParameterExpression targetParam
                            && TypesAreSimilar(parameter.Type, targetParam.Type);
                        break;

                    case BinaryExpression binary:
                        similar = TypeCheckAndCompare(
                            binary,
                            target,
                            (s, t) => BinariesAreSimilar(s, t));
                        break;

                    case UnaryExpression unary:
                        similar = TypeCheckAndCompare(
                            unary,
                            target,
                            (s, t) => UnariesAreSimilar(s, t));
                        break;

                    case MemberExpression member:
                        similar = TypeCheckAndCompare(
                            member,
                            target,
                            (s, t) => MembersAreSimilar(s, t));
                        break;

                    case MethodCallExpression method:
                        similar = TypeCheckAndCompare(
                            method,
                            target,
                            (s, t) => MethodsAreSimilar(s, t));
                        break;

                    case LambdaExpression lambda:
                        similar = TypeCheckAndCompare(
                            lambda,
                            target,
                            (s, t) => LambdasAreSimilar(s, t));
                        break;
                }
            }

            return similar;
        }

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
        public static bool AreSimilar(
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

                if (!AreSimilar(
                    src.Current,
                    tgt.Current))
                {
                    return false;
                }
            }

            return true;
        }

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
        public static bool IsPartOf(
            Expression source,
            Expression target)
        {
            if (target == null)
            {
                return false;
            }

            var targetTree = new ExpressionEnumerator(target);
            return targetTree.Any(t => AreSimilar(source, t));
        }

        /// <summary>
        /// Determines whether types are similar.
        /// </summary>
        /// <remarks>
        /// Object must match object. Value types must match exactly.
        /// Other types can be derived from each other.
        /// </remarks>
        /// <param name="source">The source <see cref="Type"/> to check.</param>
        /// <param name="target">The target <see cref="Type"/> to check.</param>
        /// <returns>A flag indicating whether the types are similar.</returns>
        private static bool TypesAreSimilar(
            Type source,
            Type target)
        {
            if (source == typeof(object))
            {
                return target == typeof(object);
            }

            if (source.IsValueType)
            {
                return source == target;
            }

            return source.IsAssignableFrom(target) ||
                target.IsAssignableFrom(source);
        }

        /// <summary>
        /// Checks for a match of the target type and calls the comparison
        /// if there is a match.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type to evaluate.</typeparam>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/>.</param>
        /// <param name="compare">The method to compare.</param>
        /// <returns>A flag indicating whether the expressions are similar.</returns>
        private static bool TypeCheckAndCompare<T>(
            T source,
            Expression target,
            Func<T, T, bool> compare)
            where T : Expression
        {
            if (target is T targetExpression)
            {
                return compare(source, targetExpression);
            }

            return false;
        }

        /// <summary>
        /// Determine whether two lambdas are similar.
        /// </summary>
        /// <remarks>
        /// Two lambda expressions are similar when they share the same name,
        /// similar parameters, and when both body and parameters are similar.
        /// </remarks>
        /// <param name="source">The source <see cref="LambdaExpression"/>.</param>
        /// <param name="target">The target <see cref="LambdaExpression"/>.</param>
        /// <returns>A flag indicating whether the two expressions are similar.</returns>
        private static bool LambdasAreSimilar(
            LambdaExpression source,
            LambdaExpression target)
        {
            if (source.Name != target.Name)
            {
                return false;
            }

            if (source.Parameters.Count != target.Parameters.Count)
            {
                return false;
            }

            if (!AreSimilar(source.Parameters, target.Parameters))
            {
                return false;
            }

            return IsPartOf(source.Body, target.Body);
        }

        /// <summary>
        /// Determine whether two methods are similar.
        /// </summary>
        /// <remarks>
        /// Two metods are similar when they share the same return type, declaring type,
        /// the same name, are either both instance or static fields, and all
        /// arguments pass similarity. Arguments of same expression type are tested
        /// for similarity. Arguments of different expression types are tested for the
        /// same return type.
        /// </remarks>
        /// <param name="source">The source <see cref="MethodCallExpression"/>.</param>
        /// <param name="target">The target <see cref="MethodCallExpression"/>.</param>
        /// <returns>A flag indicating whether the two expressions are Similar.</returns>
        private static bool MethodsAreSimilar(
            MethodCallExpression source,
            MethodCallExpression target)
        {
            if (!TypesAreSimilar(source.Type, target.Type) ||
                !TypesAreSimilar(source.Method.DeclaringType, target.Method.DeclaringType) ||
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
                if (!IsPartOf(source.Object, target.Object))
                {
                    return false;
                }
            }

            for (var idx = 0; idx < source.Arguments.Count; idx += 1)
            {
                bool similar;
                if (source.Arguments[idx].GetType() == target.Arguments[idx].GetType())
                {
                    similar = IsPartOf(source.Arguments[idx], target.Arguments[idx]);
                }
                else
                {
                    similar = TypesAreSimilar(source.Type, target.Type);
                }

                if (!similar)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determine whether two members are similar.
        /// </summary>
        /// <remarks>
        /// Two instances of <see cref="MemberExpression"/> are similar
        /// when they share the same type (this will match the member type), the same
        /// declaring type, the same name, and if there is an expression, the
        /// expressions are similar.
        /// </remarks>
        /// <param name="source">The source <see cref="MemberExpression"/>.</param>
        /// <param name="target">The target <see cref="MemberExpression"/>.</param>
        /// <returns>A flag indicating whether the two expressions are Similar.</returns>
        private static bool MembersAreSimilar(
            MemberExpression source,
            MemberExpression target)
        {
            if (!TypesAreSimilar(source.Type, target.Type) ||
                !TypesAreSimilar(source.Member.DeclaringType, target.Member.DeclaringType) ||
                source.Member.Name != target.Member.Name)
            {
                return false;
            }

            return source.Expression == null ||
                IsPartOf(source.Expression, target.Expression);
        }

        /// <summary>
        /// Determines whether two unaries are similar.
        /// </summary>
        /// <remarks>
        /// Two instances of <see cref="UnaryExpression"/> are similar when they share the same
        /// <see cref="ExpressionType"/>, method information, and when their operands pass
        /// equivalency.
        /// </remarks>
        /// <param name="source">The source <see cref="UnaryExpression"/>.</param>
        /// <param name="target">The target <see cref="UnaryExpression"/>.</param>
        /// <returns>A flag that indicates whether the two expressions are Similar.</returns>
        private static bool UnariesAreSimilar(
            UnaryExpression source,
            UnaryExpression target)
        {
            if (source.NodeType != target.NodeType)
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
                if (!TypesAreSimilar(source.Method.DeclaringType, target.Method.DeclaringType) ||
                    source.Method.Name != target.Method.Name)
                {
                    return false;
                }
            }

            return IsPartOf(source.Operand, target.Operand);
        }

        /// <summary>
        /// Determines whether two binaries are similar.
        /// </summary>
        /// <remarks>
        /// Two instances of <see cref="BinaryExpression"/> are similar when they share the same
        /// <see cref="ExpressionType"/> and the recursive determination of the left expressoin and
        /// the right expressions is similar.
        /// </remarks>
        /// <param name="source">The source <see cref="BinaryExpression"/>.</param>
        /// <param name="target">The target <see cref="BinaryExpression"/>.</param>
        /// <returns>A flag that indicates whether the two expressions are similar.</returns>
        private static bool BinariesAreSimilar(
            BinaryExpression source,
            BinaryExpression target)
        {
            if (source.NodeType != target.NodeType)
            {
                return false;
            }

            return IsPartOf(source.Left, target.Left) &&
                IsPartOf(source.Right, target.Right);
        }

        /// <summary>
        /// Method to compare two <seealso cref="ConstantExpression"/>
        /// instances.
        /// </summary>
        /// <remarks>
        /// If the constant is an expression, similarity is recursed. If it is a value type,
        /// the source and target must be equal. Otherwise, similar is based on types.
        /// </remarks>
        /// <param name="source">The source <see cref="ConstantExpression"/>.</param>
        /// <param name="target">The target <see cref="ConstantExpression"/>.</param>
        /// <returns>A flag indicating whether the two are similar.</returns>
        private static bool ConstantsAreSimilar(
            ConstantExpression source,
            ConstantExpression target)
        {
            if (!TypesAreSimilar(source.Type, typeof(Expression)) &&
                !TypesAreSimilar(source.Type, target.Type))
            {
                return false;
            }

            if (source.Value == null)
            {
                return target.Value == null;
            }

            if (source.Value is Expression expression)
            {
                return AreSimilar(
                    expression,
                    target.Value as Expression);
            }

            // enumerable must have same type
            if (source.Type.GenericTypeArguments.Length > 0)
            {
                var enumerableType = typeof(IEnumerable<>)
                    .MakeGenericType(source.Type.GenericTypeArguments);
                if (enumerableType.IsAssignableFrom(source.Type))
                {
                    return true;
                }
            }

            if (source.Type == typeof(string))
            {
                return source.Value == target.Value;
            }

            return typeof(System.Collections.IEnumerable).IsAssignableFrom(source.Type)
                || source.Value.Equals(target.Value);
        }
    }
}

// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Signatures;
using eq = ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency;

namespace ExpressionPowerTools.Core.Comparisons
{
    /// <summary>
    /// This version is named "tongue-in-cheek" due to the assumption that code will outperform compiled expressions.
    /// Although that can be true, and this is included for testing as well as referencing if it helps with application scale,
    /// you should find the rules-based works fine for most scenarios and performs close to par with the programmed verssion.
    /// </summary>
    public class DefaultHighPerformanceRules : IExpressionComparisonRuleProvider
    {
        /// <summary>
        /// Rules for equivalency.
        /// </summary>
        private readonly IDictionary<Type, Func<Expression, Expression, bool>> equivalencyRules;

        /// <summary>
        /// Rules for similarity.
        /// </summary>
        private readonly IDictionary<Type, Func<Expression, Expression, bool>> similarityRules;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultHighPerformanceRules"/> class.
        /// </summary>
        public DefaultHighPerformanceRules()
        {
            equivalencyRules =
            new Dictionary<Type, Func<Expression, Expression, bool>>
            {
                { typeof(LambdaExpression), (s, t) => ExecuteRuleAs<LambdaExpression>(s, t, LambdasAreEquivalent) },
                { typeof(ConstantExpression), (s, t) => ExecuteRuleAs<ConstantExpression>(s, t, ConstantsAreEquivalent) },
                { typeof(InvocationExpression), (s, t) => ExecuteRuleAs<InvocationExpression>(s, t, InvocationsAreEquivalent) },
                { typeof(MemberExpression), (s, t) => ExecuteRuleAs<MemberExpression>(s, t, MembersAreEquivalent) },
                { typeof(MethodCallExpression), (s, t) => ExecuteRuleAs<MethodCallExpression>(s, t, MethodsAreEquivalent) },
                { typeof(BinaryExpression), (s, t) => ExecuteRuleAs<BinaryExpression>(s, t, BinariesAreEquivalent) },
                { typeof(NewArrayExpression), (s, t) => ExecuteRuleAs<NewArrayExpression>(s, t, NewArraysAreEquivalent) },
                { typeof(NewExpression), (s, t) => ExecuteRuleAs<NewExpression>(s, t, NewAreEquivalent) },
                { typeof(ParameterExpression), (s, t) => ExecuteRuleAs<ParameterExpression>(s, t, ParametersAreEquivalent) },
                { typeof(UnaryExpression), (s, t) => ExecuteRuleAs<UnaryExpression>(s, t, UnariesAreEquivalent) },
            };

            similarityRules =
            new Dictionary<Type, Func<Expression, Expression, bool>>
            {
                { typeof(LambdaExpression), (s, t) => ExecuteRuleAs<LambdaExpression>(s, t, LambdasAreSimilar) },
                { typeof(ConstantExpression), (s, t) => ExecuteRuleAs<ConstantExpression>(s, t, ConstantsAreSimilar) },
                { typeof(MemberExpression), (s, t) => ExecuteRuleAs<MemberExpression>(s, t, MembersAreSimilar) },
                { typeof(InvocationExpression), (s, t) => ExecuteRuleAs<InvocationExpression>(s, t, InvocationsAreSimilar) },
                { typeof(MethodCallExpression), (s, t) => ExecuteRuleAs<MethodCallExpression>(s, t, MethodsAreSimilar) },
                { typeof(BinaryExpression), (s, t) => ExecuteRuleAs<BinaryExpression>(s, t, BinariesAreSimilar) },
                { typeof(NewArrayExpression), (s, t) => ExecuteRuleAs<NewArrayExpression>(s, t, NewArraysAreSimilar) },
                { typeof(NewExpression), (s, t) => ExecuteRuleAs<NewExpression>(s, t, NewAreSimilar) },
                {
                    typeof(ParameterExpression), (s, t) => ExecuteRuleAs<ParameterExpression>(
                        s,
                        t,
                        (src, tgt) => ExpressionSimilarity.TypesAreSimilar(src.Type, tgt.Type))
                },
                { typeof(UnaryExpression), (s, t) => ExecuteRuleAs<UnaryExpression>(s, t, UnariesAreSimilar) },
            };
        }

        /// <summary>
        /// Check equivalency for a given type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/>.</param>
        /// <returns>A value indicating whether the expressions are equivalent.</returns>
        /// <exception cref="ArgumentNullException">Throws when source or target are null.</exception>
        public bool CheckEquivalency<T>(T source, Expression target)
            where T : Expression
        {
            Ensure.NotNull(() => source);
            Ensure.NotNull(() => target);
            if (equivalencyRules.ContainsKey(typeof(T)))
            {
                return equivalencyRules[typeof(T)](source, target);
            }

            return source.Equals(target);
        }

        /// <summary>
        /// Generic equivilency check.
        /// </summary>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/>.</param>
        /// <returns>A value indicating whether the expressions are equivalent.</returns>
        /// <exception cref="ArgumentNullException">Throws when source or target are null.</exception>
        public bool CheckEquivalency(Expression source, Expression target)
        {
            Ensure.NotNull(() => source);
            Ensure.NotNull(() => target);
            var type = source.GetType();
            if (equivalencyRules.ContainsKey(type))
            {
                return equivalencyRules[type](source, target);
            }

            var typeAs = equivalencyRules.Keys.FirstOrDefault(k => k.IsAssignableFrom(type));
            if (typeAs != null)
            {
                return equivalencyRules[typeAs](source, target);
            }

            return source.Equals(target);
        }

        /// <summary>
        /// Perform the check.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="source">The source expression.</param>
        /// <param name="target">The target expression.</param>
        /// <returns>A flag indicating whether the two expressions are similar.</returns>
        public bool CheckSimilarity<T>(T source, Expression target)
            where T : Expression
        {
            Ensure.NotNull(() => source);
            Ensure.NotNull(() => target);
            if (similarityRules.ContainsKey(typeof(T)))
            {
                return similarityRules[typeof(T)](source, target);
            }

            return source.Equals(target);
        }

        /// <summary>
        /// Checks for similarity against all types.
        /// </summary>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/>.</param>
        /// <returns>A value indicating whether a match was found and was successful.</returns>
        public bool CheckSimilarity(Expression source, Expression target)
        {
            Ensure.NotNull(() => source);
            Ensure.NotNull(() => target);
            var type = source.GetType();
            if (similarityRules.ContainsKey(type))
            {
                return similarityRules[type](source, target);
            }

            var typeAs = similarityRules.Keys.FirstOrDefault(k => k.IsAssignableFrom(type));
            if (typeAs != null)
            {
                return similarityRules[typeAs](source, target);
            }

            return source.Equals(target);
        }

        /// <summary>
        /// Get the equivalency rule.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>A rule that determines equivalency between the two expressions.</returns>
        public Func<T, T, bool> GetRuleForEquivalency<T>()
            where T : Expression
        {
            return equivalencyRules.ContainsKey(typeof(T)) ?
                equivalencyRules[typeof(T)] :
                null;
        }

        /// <summary>
        /// Get the similiarity rule.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>A rule that determines similarity between the two expressions.</returns>
        public Func<T, T, bool> GetRuleForSimilarity<T>()
            where T : Expression
        {
            return similarityRules.ContainsKey(typeof(T)) ?
                similarityRules[typeof(T)] :
                null;
        }

        /// <summary>
        /// Simple cast operation.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <param name="source">The source <see cref="Expression"/>.</param>
        /// <param name="target">The target <see cref="Expression"/>.</param>
        /// <param name="rule">The rule to apply.</param>
        /// <returns>The result of the rule.</returns>
        private bool ExecuteRuleAs<T>(Expression source, Expression target, Func<T, T, bool> rule)
            where T : Expression
        {
            if (target is T tgt)
            {
                return rule(source as T, tgt);
            }

            return false;
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
        private bool LambdasAreEquivalent(
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

            return eq.AreEquivalent(source.Body, target.Body);
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
        private bool MethodsAreEquivalent(
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
                if (!eq.AreEquivalent(source.Object, target.Object))
                {
                    return false;
                }
            }

            return eq.AreEquivalent(
                source.Arguments,
                target.Arguments);
        }

        /// <summary>
        /// Determine whether two members are equivalent.
        /// </summary>
        /// <remarks>
        /// Two instances of <see cref="MemberExpression"/> are equivalent
        /// when they share the same type (this will match the member type), the same
        /// declaring type, the same name, and if there is an expression, the
        /// expressions are equivalent.
        /// </remarks>
        /// <param name="source">The source <see cref="MemberExpression"/>.</param>
        /// <param name="target">The target <see cref="MemberExpression"/>.</param>
        /// <returns>A flag indicating whether the two expressions are equivalent.</returns>
        private bool MembersAreEquivalent(
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
                eq.AreEquivalent(source.Expression, target.Expression);
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
        private bool UnariesAreEquivalent(
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

            return eq.AreEquivalent(source.Operand, target.Operand);
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
        private bool BinariesAreEquivalent(
            BinaryExpression source,
            BinaryExpression target)
        {
            if (source.NodeType != target.NodeType)
            {
                return false;
            }

            return eq.AreEquivalent(source.Left, target.Left) &&
                eq.AreEquivalent(source.Right, target.Right);
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
        private bool ConstantsAreEquivalent(
            ConstantExpression source,
            ConstantExpression target)
        {
            if (!eq.TypesAreEquivalent(source.Type, target.Type))
            {
                return false;
            }

            if (source.Value == null)
            {
                return target.Value == null;
            }

            if (source.Value is Expression expression)
            {
                return eq.AreEquivalent(
                    expression,
                    target.Value as Expression);
            }

            return eq.ValuesAreEquivalent(source.Value, target.Value);
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
        private bool ParametersAreEquivalent(
            ParameterExpression source,
            ParameterExpression target) =>
            source.Type == target.Type &&
            source.Name == target.Name &&
            source.IsByRef == target.IsByRef;

        /// <summary>
        /// Check for equivalent array initializers.
        /// </summary>
        /// <remarks>
        /// To be true, type and expressions must be equivalent.
        /// </remarks>
        /// <param name="source">The source <see cref="NewArrayExpression"/>.</param>
        /// <param name="target">The target <see cref="NewArrayExpression"/>.</param>
        /// <returns>A flag indicating whether the array initializers are equivalent.</returns>
        private bool NewArraysAreEquivalent(
            NewArrayExpression source,
            NewArrayExpression target)
        {
            if (source.Type != target.Type)
            {
                return false;
            }

            return eq.AreEquivalent(source.Expressions, target.Expressions);
        }

        /// <summary>
        /// Check for equivalent object initializer.
        /// </summary>
        /// <remarks>
        /// To be true, type, constructor, methods and arguments must be equivalent.
        /// </remarks>
        /// <param name="source">The source <see cref="NewExpression"/>.</param>
        /// <param name="target">The target <see cref="NewExpression"/>.</param>
        /// <returns>A flag indicating whether the object initializers are equivalent.</returns>
        private bool NewAreEquivalent(
            NewExpression source,
            NewExpression target)
        {
            if (source.Type != target.Type)
            {
                return false;
            }

            if (!source.Constructor.Equals(target.Constructor))
            {
                return false;
            }

            return eq.AreEquivalent(source.Arguments, target.Arguments);
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
        private bool LambdasAreSimilar(
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

            if (!ExpressionSimilarity.AreSimilar(source.Parameters, target.Parameters))
            {
                return false;
            }

            return ExpressionSimilarity.IsPartOf(source.Body, target.Body);
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
        private bool MethodsAreSimilar(
            MethodCallExpression source,
            MethodCallExpression target)
        {
            if (!ExpressionSimilarity.TypesAreSimilar(source.Type, target.Type) ||
                !ExpressionSimilarity.TypesAreSimilar(source.Method.DeclaringType, target.Method.DeclaringType) ||
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
                if (!ExpressionSimilarity.IsPartOf(source.Object, target.Object))
                {
                    return false;
                }
            }

            for (var idx = 0; idx < source.Arguments.Count; idx += 1)
            {
                bool similar;
                if (source.Arguments[idx].GetType() == target.Arguments[idx].GetType())
                {
                    similar = ExpressionSimilarity.IsPartOf(source.Arguments[idx], target.Arguments[idx]);
                }
                else
                {
                    similar = ExpressionSimilarity.TypesAreSimilar(source.Type, target.Type);
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
        private bool MembersAreSimilar(
            MemberExpression source,
            MemberExpression target)
        {
            if (!ExpressionSimilarity.TypesAreSimilar(source.Type, target.Type) ||
                !ExpressionSimilarity.TypesAreSimilar(source.Member.DeclaringType, target.Member.DeclaringType) ||
                source.Member.Name != target.Member.Name)
            {
                return false;
            }

            return source.Expression == null ||
                ExpressionSimilarity.IsPartOf(source.Expression, target.Expression);
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
        private bool UnariesAreSimilar(
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
                if (!ExpressionSimilarity.TypesAreSimilar(source.Method.DeclaringType, target.Method.DeclaringType) ||
                    source.Method.Name != target.Method.Name)
                {
                    return false;
                }
            }

            return ExpressionSimilarity.IsPartOf(source.Operand, target.Operand);
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
        private bool BinariesAreSimilar(
            BinaryExpression source,
            BinaryExpression target)
        {
            if (source.NodeType != target.NodeType)
            {
                return false;
            }

            return ExpressionSimilarity.IsPartOf(source.Left, target.Left) &&
                ExpressionSimilarity.IsPartOf(source.Right, target.Right);
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
        private bool ConstantsAreSimilar(
            ConstantExpression source,
            ConstantExpression target)
        {
            if (!ExpressionSimilarity.TypesAreSimilar(source.Type, typeof(Expression)) &&
                !ExpressionSimilarity.TypesAreSimilar(source.Type, target.Type))
            {
                return false;
            }

            if (source.Value == null)
            {
                return target.Value == null;
            }

            if (source.Value is Expression expression)
            {
                return ExpressionSimilarity.AreSimilar(
                    expression,
                    target.Value as Expression);
            }

            // lists
            if (typeof(Array).IsAssignableFrom(source.Type) ||
                typeof(System.Collections.ICollection).IsAssignableFrom(source.Type))
            {
                return true;
            }

            // string
            if (source.Type == typeof(string))
            {
                return source.Value == target.Value;
            }

            // typed collections
            if (source.Type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            {
                return true;
            }

            // "primitives"
            return eq.ValuesAreEquivalent(
                    source.Value,
                    target.Value);
        }

        /// <summary>
        /// Method to compare two <see cref="InvocationExpression"/> instances.
        /// </summary>
        /// <remarks>
        /// Must match type (which includes expression) and arguments.
        /// </remarks>
        /// <param name="source">The source <see cref="InvocationExpression"/>.</param>
        /// <param name="target">The target <see cref="InvocationExpression"/>.</param>
        /// <returns>A value that indicates whether they are equivalent.</returns>
        private bool InvocationsAreEquivalent(
            InvocationExpression source,
            InvocationExpression target)
        {
            if (source.Type != target.Type)
            {
                return false;
            }

            return eq.AreEquivalent(source.Arguments, target.Arguments);
        }

        /// <summary>
        /// Method to compare two <see cref="InvocationExpression"/> for similarty.
        /// </summary>
        /// <remarks>
        /// To be similar, types must be assignable, arguments must be similar,
        /// and the source expression must be part of the target expression.
        /// </remarks>
        /// <param name="source">The source <see cref="InvocationExpression"/>.</param>
        /// <param name="target">The target <see cref="InvocationExpression"/>.</param>
        /// <returns>A value that indicates whether they are similar.</returns>
        private bool InvocationsAreSimilar(
            InvocationExpression source,
            InvocationExpression target)
        {
            if (!ExpressionSimilarity.TypesAreSimilar(source.Type, target.Type))
            {
                return false;
            }

            if (source.Arguments.Count != target.Arguments.Count)
            {
                return false;
            }

            if (!ExpressionSimilarity.AreSimilar(source.Arguments, target.Arguments))
            {
                return false;
            }

            return ExpressionSimilarity.IsPartOf(source.Expression, target.Expression);
        }

        /// <summary>
        /// Check for equivalent array initializers.
        /// </summary>
        /// <remarks>
        /// To be true, type must be equivalent and expressions must be similar.
        /// </remarks>
        /// <param name="source">The source <see cref="NewArrayExpression"/>.</param>
        /// <param name="target">The target <see cref="NewArrayExpression"/>.</param>
        /// <returns>A flag indicating whether the array initializers are equivalent.</returns>
        private bool NewArraysAreSimilar(
            NewArrayExpression source,
            NewArrayExpression target)
        {
            if (source.Type != target.Type)
            {
                return false;
            }

            return ExpressionSimilarity.AreSimilar(source.Expressions, target.Expressions);
        }

        /// <summary>
        /// Check for equivalent object initializer.
        /// </summary>
        /// <remarks>
        /// To be true, type, constructor, methods must be equivalent
        /// and arguments must be similar.
        /// </remarks>
        /// <param name="source">The source <see cref="NewExpression"/>.</param>
        /// <param name="target">The target <see cref="NewExpression"/>.</param>
        /// <returns>A flag indicating whether the object initializers are equivalent.</returns>
        private bool NewAreSimilar(
            NewExpression source,
            NewExpression target)
        {
            if (source.Type != target.Type)
            {
                return false;
            }

            if (!source.Constructor.Equals(target.Constructor))
            {
                return false;
            }

            return ExpressionSimilarity.AreSimilar(source.Arguments, target.Arguments);
        }
    }
}

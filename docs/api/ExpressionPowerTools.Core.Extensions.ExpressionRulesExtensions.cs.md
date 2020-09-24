# ExpressionRulesExtensions Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > **ExpressionRulesExtensions**

Building blocks for expression rules.

```csharp
public static class ExpressionRulesExtensions
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExpressionRulesExtensions**

## Remarks

The purpose of these extensions are to provide fluent building blocks for rules. They
            can be chained to test any aspect of comparison. See [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) for
            example implementations.

## Methods

| Method | Description |
| :-- | :-- |
| [Expression&lt;Func&lt;T, T, Boolean>> And&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> left, Expression&lt;Func&lt;T, T, Boolean>> right)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.And.m.md) | Start of tree with left and right "and" branches. |
| [Expression&lt;Func&lt;T, T, Boolean>> AndEnumerableExpressionsMustBeEquivalent&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IEnumerable&lt;Expression>> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.AndEnumerableExpressionsMustBeEquivalent.m.md) | Expression in each enumerable must be equivalent. |
| [Expression&lt;Func&lt;T, T, Boolean>> AndEnumerableExpressionsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IEnumerable&lt;Expression>> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.AndEnumerableExpressionsMustBeSimilar.m.md) | Expression in each enumerable must be similar. |
| [Expression&lt;Func&lt;T, T, Boolean>> AndExpressionsMustBeEquivalent&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Expression> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.AndExpressionsMustBeEquivalent.m.md) | Expressions must be equivalent. |
| [Expression&lt;Func&lt;T, T, Boolean>> AndExpressionsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Expression> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.AndExpressionsMustBeSimilar.m.md) | And expressions must be similar. |
| [Expression&lt;Func&lt;T, T, Boolean>> AndIf&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, T, Boolean>> ifTrue, Expression&lt;Func&lt;T, T, Boolean>> ifFalse)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.AndIf.m.md) | Logical AND applied to rule and `If` condition. |
| [Expression&lt;Func&lt;T, T, Boolean>> AndMemberBindingsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IList&lt;MemberBinding>> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.AndMemberBindingsMustBeSimilar.m.md) | Each value in the binding list must be similar. |
| [Expression&lt;Func&lt;T, T, Boolean>> AndMembersMustMatch&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Object> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.AndMembersMustMatch.m.md) | And match members. |
| [Expression&lt;Func&lt;T, T, Boolean>> AndMembersMustMatchNullOrNotNull&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Object> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.AndMembersMustMatchNullOrNotNull.m.md) | Both expressions must either have null members, or not null members. |
| [Expression&lt;Func&lt;T, T, Boolean>> AndNodeTypesMustMatch&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.AndNodeTypesMustMatch.m.md) | And the [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) must be the same. |
| [Expression&lt;Func&lt;T, T, Boolean>> AndNonGenericEnumerablesMustBeEquivalent&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IEnumerable> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.AndNonGenericEnumerablesMustBeEquivalent.m.md) | Each value in the enumerable must be equivalent. |
| [Expression&lt;Func&lt;T, T, Boolean>> AndSourceMustBePartofTarget&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Expression> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.AndSourceMustBePartofTarget.m.md) | Expression must be part of another. |
| [Expression&lt;Func&lt;T, T, Boolean>> AndTypesMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.AndTypesMustBeSimilar.m.md) | AND types of the expressions must be similar. |
| [Expression&lt;Func&lt;T, T, Boolean>> EnumerableExpressionsMustBeEquivalent&lt;T>(Func&lt;T, IEnumerable&lt;Expression>> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.EnumerableExpressionsMustBeEquivalent.m.md) | Expression in each enumerable must be equivalent. |
| [Expression&lt;Func&lt;T, T, Boolean>> EnumerableExpressionsMustBeSimilar&lt;T>(Func&lt;T, IEnumerable&lt;Expression>> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.EnumerableExpressionsMustBeSimilar.m.md) | Expression in each enumerable must be similar. |
| [Expression&lt;Func&lt;T, T, Boolean>> ExpressionsMustBeEquivalent&lt;T>(Func&lt;T, Expression> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.ExpressionsMustBeEquivalent.m.md) | Expressions must be equivalent. |
| [Expression&lt;Func&lt;T, T, Boolean>> ExpressionsMustBeSimilar&lt;T>(Func&lt;T, Expression> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.ExpressionsMustBeSimilar.m.md) | Expressions must be similar. |
| [Expression&lt;Func&lt;T, T, Boolean>> False&lt;T>()](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.False.m.md) | Lies. |
| [Expression&lt;Func&lt;T, T, Boolean>> If&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, T, Boolean>> ifTrue, Expression&lt;Func&lt;T, T, Boolean>> ifFalse)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.If.m.md) | Enables if ... then logic. |
| [Expression&lt;Func&lt;T, T, Boolean>> IfWithCast&lt;T, TOther>(Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, TOther>> conversion, Expression&lt;Func&lt;TOther, TOther, Boolean>> ifTrue, Expression&lt;Func&lt;TOther, TOther, Boolean>> ifFalse)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.IfWithCast.m.md) | Enables if ... then logic with a cast to inner evaluations. |
| [Expression&lt;Func&lt;T, T, Boolean>> MemberBindingsMustBeSimilar&lt;T>(Func&lt;T, IList&lt;MemberBinding>> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.MemberBindingsMustBeSimilar.m.md) | Each value in the binding list must be similar. |
| [Expression&lt;Func&lt;T, T, Boolean>> MembersMustMatch&lt;T>(Func&lt;T, Object> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.MembersMustMatch.m.md) | Member on source must match member on target. |
| [Expression&lt;Func&lt;T, T, Boolean>> MembersMustMatchNullOrNotNull&lt;T>(Func&lt;T, Object> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.MembersMustMatchNullOrNotNull.m.md) | Both expressions must either have null members, or not null members. |
| [Expression&lt;Func&lt;T, T, Boolean>> NodeTypesMustMatch&lt;T>()](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.NodeTypesMustMatch.m.md) | The [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) must be the same. |
| [Expression&lt;Func&lt;T, T, Boolean>> NonGenericEnumerablesMustBeEquivalent&lt;T>(Func&lt;T, IEnumerable> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.NonGenericEnumerablesMustBeEquivalent.m.md) | Each value in the enumerable must be equivalent. |
| [Expression&lt;Func&lt;T, T, Boolean>> Not&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.Not.m.md) | Logical NOT of result of rule. |
| [Expression&lt;Func&lt;T, T, Boolean>> Or&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> left, Expression&lt;Func&lt;T, T, Boolean>> right)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.Or.m.md) | Start of tree with left and right "or" branches. |
| [Expression&lt;Func&lt;T, T, Boolean>> OrIf&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, T, Boolean>> ifTrue, Expression&lt;Func&lt;T, T, Boolean>> ifFalse)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.OrIf.m.md) | Logical OR applied to rule and `If` condition. |
| [Expression&lt;Func&lt;T, T, Boolean>> OrNodeTypesMustMatch&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.OrNodeTypesMustMatch.m.md) | Or the [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) must be the same. |
| [Expression&lt;Func&lt;T, T, Boolean>> Rule&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.Rule.m.md) | Basic rule definition. Exists as a base to provide typed template. |
| [Expression&lt;Func&lt;T, T, Boolean>> SourceMustBePartofTarget&lt;T>(Func&lt;T, Expression> member)](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.SourceMustBePartofTarget.m.md) | Expression must be part of another. |
| [Expression&lt;Func&lt;T, T, Boolean>> SourceTypeMustBeArrayOrCollection&lt;T>()](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.SourceTypeMustBeArrayOrCollection.m.md) | The source type must derive from or be an [Array](https://docs.microsoft.com/dotnet/api/system.array) or [ICollection](https://docs.microsoft.com/dotnet/api/system.collections.icollection) . |
| [Expression&lt;Func&lt;T, T, Boolean>> SourceTypeMustBeSimilarToExpression&lt;T>()](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.SourceTypeMustBeSimilarToExpression.m.md) | The source type must be similar to [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| [Expression&lt;Func&lt;T, T, Boolean>> SourceTypeMustBeTypedEnumerable&lt;T>()](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.SourceTypeMustBeTypedEnumerable.m.md) | The source type must be an [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) . |
| [Expression&lt;Func&lt;T, T, Boolean>> True&lt;T>()](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.True.m.md) | Truth. |
| [Expression&lt;Func&lt;T, T, Boolean>> TypesMustBeSimilar&lt;T>()](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.TypesMustBeSimilar.m.md) | Types of the expressions must be similar. |
| [Expression&lt;Func&lt;T, T, Boolean>> TypesMustMatch&lt;T>()](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.TypesMustMatch.m.md) | Types of the expressions must be the same. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:02:13 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

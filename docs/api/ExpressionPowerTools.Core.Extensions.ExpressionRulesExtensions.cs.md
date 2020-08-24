# ExpressionRulesExtensions Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > **ExpressionRulesExtensions**



```csharp
public static class ExpressionRulesExtensions
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExpressionRulesExtensions**

## Methods

| Method | Description |
| :-- | :-- |
| [Expression&lt;Func&lt;T, T, Boolean>> And&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> left, Expression&lt;Func&lt;T, T, Boolean>> right)](ExpressionRulesExtensions-And.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> AndEnumerableExpressionsMustBeEquivalent&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IEnumerable&lt;Expression>> member)](ExpressionRulesExtensions-AndEnumerableExpressionsMustBeEquivalent.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> AndEnumerableExpressionsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IEnumerable&lt;Expression>> member)](ExpressionRulesExtensions-AndEnumerableExpressionsMustBeSimilar.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> AndExpressionsMustBeEquivalent&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Expression> member)](ExpressionRulesExtensions-AndExpressionsMustBeEquivalent.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> AndExpressionsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Expression> member)](ExpressionRulesExtensions-AndExpressionsMustBeSimilar.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> AndIf&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, T, Boolean>> ifTrue, Expression&lt;Func&lt;T, T, Boolean>> ifFalse)](ExpressionRulesExtensions-AndIf.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> AndMembersMustMatch&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Object> member)](ExpressionRulesExtensions-AndMembersMustMatch.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> AndMembersMustMatchNullOrNotNull&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Object> member)](ExpressionRulesExtensions-AndMembersMustMatchNullOrNotNull.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> AndNodeTypesMustMatch&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](ExpressionRulesExtensions-AndNodeTypesMustMatch.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> AndSourceMustBePartofTarget&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Expression> member)](ExpressionRulesExtensions-AndSourceMustBePartofTarget.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> AndTypesMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](ExpressionRulesExtensions-AndTypesMustBeSimilar.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> EnumerableExpressionsMustBeEquivalent&lt;T>(Func&lt;T, IEnumerable&lt;Expression>> member)](ExpressionRulesExtensions-EnumerableExpressionsMustBeEquivalent.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> EnumerableExpressionsMustBeSimilar&lt;T>(Func&lt;T, IEnumerable&lt;Expression>> member)](ExpressionRulesExtensions-EnumerableExpressionsMustBeSimilar.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> ExpressionsMustBeEquivalent&lt;T>(Func&lt;T, Expression> member)](ExpressionRulesExtensions-ExpressionsMustBeEquivalent.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> ExpressionsMustBeSimilar&lt;T>(Func&lt;T, Expression> member)](ExpressionRulesExtensions-ExpressionsMustBeSimilar.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> False&lt;T>()](ExpressionRulesExtensions-False.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> If&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, T, Boolean>> ifTrue, Expression&lt;Func&lt;T, T, Boolean>> ifFalse)](ExpressionRulesExtensions-If.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> IfWithCast&lt;T, TOther>(Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, TOther>> conversion, Expression&lt;Func&lt;TOther, TOther, Boolean>> ifTrue, Expression&lt;Func&lt;TOther, TOther, Boolean>> ifFalse)](ExpressionRulesExtensions-IfWithCast.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> MembersMustMatch&lt;T>(Func&lt;T, Object> member)](ExpressionRulesExtensions-MembersMustMatch.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> MembersMustMatchNullOrNotNull&lt;T>(Func&lt;T, Object> member)](ExpressionRulesExtensions-MembersMustMatchNullOrNotNull.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> NodeTypesMustMatch&lt;T>()](ExpressionRulesExtensions-NodeTypesMustMatch.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> Not&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](ExpressionRulesExtensions-Not.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> Or&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> left, Expression&lt;Func&lt;T, T, Boolean>> right)](ExpressionRulesExtensions-Or.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> OrIf&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, T, Boolean>> ifTrue, Expression&lt;Func&lt;T, T, Boolean>> ifFalse)](ExpressionRulesExtensions-OrIf.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> OrNodeTypesMustMatch&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](ExpressionRulesExtensions-OrNodeTypesMustMatch.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> Rule&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](ExpressionRulesExtensions-Rule.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> SourceMustBePartofTarget&lt;T>(Func&lt;T, Expression> member)](ExpressionRulesExtensions-SourceMustBePartofTarget.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> SourceTypeMustBeArrayOrCollection&lt;T>()](ExpressionRulesExtensions-SourceTypeMustBeArrayOrCollection.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> SourceTypeMustBeSimilarToExpression&lt;T>()](ExpressionRulesExtensions-SourceTypeMustBeSimilarToExpression.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> SourceTypeMustBeTypedEnumerable&lt;T>()](ExpressionRulesExtensions-SourceTypeMustBeTypedEnumerable.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> True&lt;T>()](ExpressionRulesExtensions-True.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> TypesMustBeSimilar&lt;T>()](ExpressionRulesExtensions-TypesMustBeSimilar.m.md) |  |
| [Expression&lt;Func&lt;T, T, Boolean>> TypesMustMatch&lt;T>()](ExpressionRulesExtensions-TypesMustMatch.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

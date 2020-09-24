# ExpressionRulesExtensions.EnumerableExpressionsMustBeEquivalent Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **EnumerableExpressionsMustBeEquivalent**

Expression in each enumerable must be equivalent.

## Overloads

| Overload | Description |
| :-- | :-- |
| [EnumerableExpressionsMustBeEquivalent&lt;T>(Func&lt;T, IEnumerable&lt;Expression>> member)](#enumerableexpressionsmustbeequivalenttfunct-ienumerableexpression-member) | Expression in each enumerable must be equivalent. |
## EnumerableExpressionsMustBeEquivalent&lt;T>(Func&lt;T, IEnumerable&lt;Expression>> member)

Expression in each enumerable must be equivalent.

```csharp
public static Expression<Func<T, T, Boolean>> EnumerableExpressionsMustBeEquivalent<T>(Func<T, IEnumerable<Expression>> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value indicating whether or not the enumerables match.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [Func&lt;T, IEnumerable&lt;Expression>>](https://docs.microsoft.com/dotnet/api/system.func-2) | The enumerable child expressions. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

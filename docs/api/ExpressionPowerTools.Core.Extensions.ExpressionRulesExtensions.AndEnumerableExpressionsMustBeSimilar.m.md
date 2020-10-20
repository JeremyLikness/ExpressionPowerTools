# ExpressionRulesExtensions.AndEnumerableExpressionsMustBeSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndEnumerableExpressionsMustBeSimilar**

Expression in each enumerable must be similar.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AndEnumerableExpressionsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IEnumerable&lt;Expression>> member)](#andenumerableexpressionsmustbesimilartexpressionfunct-t-boolean-rule-funct-ienumerableexpression-member) | Expression in each enumerable must be similar. |
## AndEnumerableExpressionsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IEnumerable&lt;Expression>> member)

Expression in each enumerable must be similar.

```csharp
public static Expression<Func<T, T, Boolean>> AndEnumerableExpressionsMustBeSimilar<T>(Expression<Func<T, T, Boolean>> rule, Func<T, IEnumerable<Expression>> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value indicating whether or not the enumerables are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The existing rule. |
| `member` | [Func&lt;T, IEnumerable&lt;Expression>>](https://docs.microsoft.com/dotnet/api/system.func-2) | The enumerable child expressions. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

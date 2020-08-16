# ExpressionRulesExtensions.AndEnumerableExpressionsMustBeEquivalent Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndEnumerableExpressionsMustBeEquivalent**



## Overloads

| Overload | Description |
| :-- | :-- |
| [AndEnumerableExpressionsMustBeEquivalent&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IEnumerable&lt;Expression>> member)](#andenumerableexpressionsmustbeequivalenttexpressionfunct-t-boolean-rule-funct-ienumerableexpression-member) |  |
## AndEnumerableExpressionsMustBeEquivalent&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IEnumerable&lt;Expression>> member)



```csharp
public static Expression<Func<T, T, Boolean>> AndEnumerableExpressionsMustBeEquivalent<T>(Expression<Func<T, T, Boolean>> rule, Func<T, IEnumerable<Expression>> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| `member` | [Func&lt;T, IEnumerable&lt;Expression>>](https://docs.microsoft.com/dotnet/api/system.func-2) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/15/2020 12:36:00 AM | (c) Copyright 2020 Jeremy Likness. | **v0.1.0.0** |

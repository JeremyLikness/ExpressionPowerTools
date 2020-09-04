# ExpressionRulesExtensions.AndNonGenericEnumerablesMustBeEquivalent Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndNonGenericEnumerablesMustBeEquivalent**

Each value in the enumerable must be equivalent.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AndNonGenericEnumerablesMustBeEquivalent&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IEnumerable> member)](#andnongenericenumerablesmustbeequivalenttexpressionfunct-t-boolean-rule-funct-ienumerable-member) | Each value in the enumerable must be equivalent. |
## AndNonGenericEnumerablesMustBeEquivalent&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IEnumerable> member)

Each value in the enumerable must be equivalent.

```csharp
public static Expression<Func<T, T, Boolean>> AndNonGenericEnumerablesMustBeEquivalent<T>(Expression<Func<T, T, Boolean>> rule, Func<T, IEnumerable> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value indicating whether or not the enumerable values match.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The existing rule. |
| `member` | [Func&lt;T, IEnumerable>](https://docs.microsoft.com/dotnet/api/system.func-2) | The enumerable child. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/4/2020 7:10:41 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.5-alpha |

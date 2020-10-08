# ExpressionRulesExtensions.NonGenericEnumerablesMustBeEquivalent Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **NonGenericEnumerablesMustBeEquivalent**

Each value in the enumerable must be equivalent.

## Overloads

| Overload | Description |
| :-- | :-- |
| [NonGenericEnumerablesMustBeEquivalent&lt;T>(Func&lt;T, IEnumerable> member)](#nongenericenumerablesmustbeequivalenttfunct-ienumerable-member) | Each value in the enumerable must be equivalent. |
## NonGenericEnumerablesMustBeEquivalent&lt;T>(Func&lt;T, IEnumerable> member)

Each value in the enumerable must be equivalent.

```csharp
public static Expression<Func<T, T, Boolean>> NonGenericEnumerablesMustBeEquivalent<T>(Func<T, IEnumerable> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value indicating whether or not the enumerable values match.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [Func&lt;T, IEnumerable>](https://docs.microsoft.com/dotnet/api/system.func-2) | The enumerable child. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |

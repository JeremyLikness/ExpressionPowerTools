# ExpressionRulesExtensions.MembersMustMatch Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **MembersMustMatch**

Member on source must match member on target.

## Overloads

| Overload | Description |
| :-- | :-- |
| [MembersMustMatch&lt;T>(Func&lt;T, Object> member)](#membersmustmatchtfunct-object-member) | Member on source must match member on target. |
## MembersMustMatch&lt;T>(Func&lt;T, Object> member)

Member on source must match member on target.

```csharp
public static Expression<Func<T, T, Boolean>> MembersMustMatch<T>(Func<T, Object> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - An expression that evaluates whether the members match.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [Func&lt;T, Object>](https://docs.microsoft.com/dotnet/api/system.func-2) | Member access. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 18:50:36 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

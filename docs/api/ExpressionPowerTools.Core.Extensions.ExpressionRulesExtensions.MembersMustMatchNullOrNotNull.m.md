# ExpressionRulesExtensions.MembersMustMatchNullOrNotNull Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **MembersMustMatchNullOrNotNull**

Both expressions must either have null members, or not null members.

## Overloads

| Overload | Description |
| :-- | :-- |
| [MembersMustMatchNullOrNotNull&lt;T>(Func&lt;T, Object> member)](#membersmustmatchnullornotnulltfunct-object-member) | Both expressions must either have null members, or not null members. |
## MembersMustMatchNullOrNotNull&lt;T>(Func&lt;T, Object> member)

Both expressions must either have null members, or not null members.

```csharp
public static Expression<Func<T, T, Boolean>> MembersMustMatchNullOrNotNull<T>(Func<T, Object> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - An expression that evaluates whether the expressions are both null or both not null.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [Func&lt;T, Object>](https://docs.microsoft.com/dotnet/api/system.func-2) | The access for the member property. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:57:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

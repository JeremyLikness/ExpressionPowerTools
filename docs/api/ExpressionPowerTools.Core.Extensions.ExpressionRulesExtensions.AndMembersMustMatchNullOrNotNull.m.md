# ExpressionRulesExtensions.AndMembersMustMatchNullOrNotNull Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndMembersMustMatchNullOrNotNull**

Both expressions must either have null members, or not null members.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AndMembersMustMatchNullOrNotNull&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Object> member)](#andmembersmustmatchnullornotnulltexpressionfunct-t-boolean-rule-funct-object-member) | Both expressions must either have null members, or not null members. |
## AndMembersMustMatchNullOrNotNull&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Object> member)

Both expressions must either have null members, or not null members.

```csharp
public static Expression<Func<T, T, Boolean>> AndMembersMustMatchNullOrNotNull<T>(Expression<Func<T, T, Boolean>> rule, Func<T, Object> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - An expression that evaluates whether the expressions are both null or both not null.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to add. |
| `member` | [Func&lt;T, Object>](https://docs.microsoft.com/dotnet/api/system.func-2) | The access for the member property. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/3/2020 10:27:04 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.4-alpha |

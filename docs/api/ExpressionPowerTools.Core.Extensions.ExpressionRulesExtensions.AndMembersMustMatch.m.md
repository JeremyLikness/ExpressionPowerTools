# ExpressionRulesExtensions.AndMembersMustMatch Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndMembersMustMatch**

And match members.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AndMembersMustMatch&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Object> member)](#andmembersmustmatchtexpressionfunct-t-boolean-rule-funct-object-member) | And match members. |
## AndMembersMustMatch&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Object> member)

And match members.

```csharp
public static Expression<Func<T, T, Boolean>> AndMembersMustMatch<T>(Expression<Func<T, T, Boolean>> rule, Func<T, Object> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - An expression that evaluates whether the members match.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The exist rule to combine with. |
| `member` | [Func&lt;T, Object>](https://docs.microsoft.com/dotnet/api/system.func-2) | Member access. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:50:49 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

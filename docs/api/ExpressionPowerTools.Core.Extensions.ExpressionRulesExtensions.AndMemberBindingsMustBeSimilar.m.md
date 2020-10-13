# ExpressionRulesExtensions.AndMemberBindingsMustBeSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndMemberBindingsMustBeSimilar**

Each value in the binding list must be similar.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AndMemberBindingsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IList&lt;MemberBinding>> member)](#andmemberbindingsmustbesimilartexpressionfunct-t-boolean-rule-funct-ilistmemberbinding-member) | Each value in the binding list must be similar. |
## AndMemberBindingsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IList&lt;MemberBinding>> member)

Each value in the binding list must be similar.

```csharp
public static Expression<Func<T, T, Boolean>> AndMemberBindingsMustBeSimilar<T>(Expression<Func<T, T, Boolean>> rule, Func<T, IList<MemberBinding>> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value indicating whether or not the bindings are all similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The existing rule. |
| `member` | [Func&lt;T, IList&lt;MemberBinding>>](https://docs.microsoft.com/dotnet/api/system.func-2) | The binding list child. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 5:26:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

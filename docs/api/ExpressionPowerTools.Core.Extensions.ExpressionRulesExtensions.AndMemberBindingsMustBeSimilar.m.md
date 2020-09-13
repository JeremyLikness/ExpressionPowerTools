# ExpressionRulesExtensions.AndMemberBindingsMustBeSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndMemberBindingsMustBeSimilar**



## Overloads

| Overload | Description |
| :-- | :-- |
| [AndMemberBindingsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IList&lt;MemberBinding>> member)](#andmemberbindingsmustbesimilartexpressionfunct-t-boolean-rule-funct-ilistmemberbinding-member) |  |
## AndMemberBindingsMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, IList&lt;MemberBinding>> member)



```csharp
public static Expression<Func<T, T, Boolean>> AndMemberBindingsMustBeSimilar<T>(Expression<Func<T, T, Boolean>> rule, Func<T, IList<MemberBinding>> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| `member` | [Func&lt;T, IList&lt;MemberBinding>>](https://docs.microsoft.com/dotnet/api/system.func-2) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

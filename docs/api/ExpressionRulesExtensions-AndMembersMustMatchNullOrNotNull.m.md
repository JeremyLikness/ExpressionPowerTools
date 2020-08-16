# ExpressionRulesExtensions.AndMembersMustMatchNullOrNotNull Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndMembersMustMatchNullOrNotNull**



## Overloads

| Overload | Description |
| :-- | :-- |
| [AndMembersMustMatchNullOrNotNull&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Object> member)](#andmembersmustmatchnullornotnulltexpressionfunct-t-boolean-rule-funct-object-member) |  |
## AndMembersMustMatchNullOrNotNull&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Object> member)



```csharp
public static Expression<Func<T, T, Boolean>> AndMembersMustMatchNullOrNotNull<T>(Expression<Func<T, T, Boolean>> rule, Func<T, Object> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| `member` | [Func&lt;T, Object>](https://docs.microsoft.com/dotnet/api/system.func-2) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/15/2020 12:36:00 AM | (c) Copyright 2020 Jeremy Likness. | **v0.1.0.0** |

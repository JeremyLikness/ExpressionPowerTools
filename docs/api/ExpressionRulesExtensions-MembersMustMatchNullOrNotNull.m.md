# ExpressionRulesExtensions.MembersMustMatchNullOrNotNull Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **MembersMustMatchNullOrNotNull**



## Overloads

| Overload | Description |
| :-- | :-- |
| [MembersMustMatchNullOrNotNull&lt;T>(Func&lt;T, Object> member)](#membersmustmatchnullornotnulltfunct-object-member) |  |
## MembersMustMatchNullOrNotNull&lt;T>(Func&lt;T, Object> member)



```csharp
public static Expression<Func<T, T, Boolean>> MembersMustMatchNullOrNotNull<T>(Func<T, Object> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [Func&lt;T, Object>](https://docs.microsoft.com/dotnet/api/system.func-2) |  |



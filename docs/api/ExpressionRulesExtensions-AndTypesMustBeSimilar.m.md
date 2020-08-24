# ExpressionRulesExtensions.AndTypesMustBeSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndTypesMustBeSimilar**



## Overloads

| Overload | Description |
| :-- | :-- |
| [AndTypesMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](#andtypesmustbesimilartexpressionfunct-t-boolean-rule) |  |
| [AndTypesMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Type> typeAccess)](#andtypesmustbesimilartexpressionfunct-t-boolean-rule-funct-type-typeaccess) |  |
## AndTypesMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)



```csharp
public static Expression<Func<T, T, Boolean>> AndTypesMustBeSimilar<T>(Expression<Func<T, T, Boolean>> rule)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |


## AndTypesMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Type> typeAccess)



```csharp
public static Expression<Func<T, T, Boolean>> AndTypesMustBeSimilar<T>(Expression<Func<T, T, Boolean>> rule, Func<T, Type> typeAccess)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| `typeAccess` | [Func&lt;T, Type>](https://docs.microsoft.com/dotnet/api/system.func-2) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

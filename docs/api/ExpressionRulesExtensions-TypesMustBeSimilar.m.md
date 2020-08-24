# ExpressionRulesExtensions.TypesMustBeSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **TypesMustBeSimilar**



## Overloads

| Overload | Description |
| :-- | :-- |
| [TypesMustBeSimilar&lt;T>()](#typesmustbesimilart) |  |
| [TypesMustBeSimilar&lt;T>(Func&lt;T, Type> typeAccess)](#typesmustbesimilartfunct-type-typeaccess) |  |
## TypesMustBeSimilar&lt;T>()



```csharp
public static Expression<Func<T, T, Boolean>> TypesMustBeSimilar<T>()
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 


## TypesMustBeSimilar&lt;T>(Func&lt;T, Type> typeAccess)



```csharp
public static Expression<Func<T, T, Boolean>> TypesMustBeSimilar<T>(Func<T, Type> typeAccess)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `typeAccess` | [Func&lt;T, Type>](https://docs.microsoft.com/dotnet/api/system.func-2) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

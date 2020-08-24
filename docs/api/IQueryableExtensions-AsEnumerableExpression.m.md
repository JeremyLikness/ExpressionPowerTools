# IQueryableExtensions.AsEnumerableExpression Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IQueryableExtensions](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.cs.md) > **AsEnumerableExpression**



## Overloads

| Overload | Description |
| :-- | :-- |
| [AsEnumerableExpression(IQueryable query)](#asenumerableexpressioniqueryable-query) |  |
| [AsEnumerableExpression&lt;T>(IQueryable&lt;T> query)](#asenumerableexpressiontiqueryablet-query) |  |
## AsEnumerableExpression(IQueryable query)



```csharp
public static IExpressionEnumerator AsEnumerableExpression(IQueryable query)
```

### Return Type

 [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) |  |


## AsEnumerableExpression&lt;T>(IQueryable&lt;T> query)



```csharp
public static IExpressionEnumerator AsEnumerableExpression<T>(IQueryable<T> query)
```

### Return Type

 [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

# IQueryableExtensions.CreateInterceptedQueryable Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IQueryableExtensions](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.cs.md) > **CreateInterceptedQueryable**



## Overloads

| Overload | Description |
| :-- | :-- |
| [CreateInterceptedQueryable&lt;T>(IQueryable&lt;T> source, ExpressionTransformer transformation)](#createinterceptedqueryabletiqueryablet-source-expressiontransformer-transformation) |  |
## CreateInterceptedQueryable&lt;T>(IQueryable&lt;T> source, ExpressionTransformer transformation)



```csharp
public static IQueryable<T> CreateInterceptedQueryable<T>(IQueryable<T> source, ExpressionTransformer transformation)
```

### Return Type

 [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) |  |
| `transformation` | [ExpressionTransformer](ExpressionPowerTools.Core.ExpressionTransformer.cs.md) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

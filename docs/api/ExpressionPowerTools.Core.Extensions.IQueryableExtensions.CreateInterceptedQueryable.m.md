# IQueryableExtensions.CreateInterceptedQueryable Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IQueryableExtensions](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.cs.md) > **CreateInterceptedQueryable**

Creates a query that can transformation the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) wen run.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CreateInterceptedQueryable&lt;T>(IQueryable&lt;T> source, ExpressionTransformer transformation)](#createinterceptedqueryabletiqueryablet-source-expressiontransformer-transformation) | Creates a query that can transformation the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) wen run. |
## CreateInterceptedQueryable&lt;T>(IQueryable&lt;T> source, ExpressionTransformer transformation)

Creates a query that can transformation the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) wen run.

```csharp
public static IQueryable<T> CreateInterceptedQueryable<T>(IQueryable<T> source, ExpressionTransformer transformation)
```

### Return Type

 [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1)  - The new intercepting query.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The source query. |
| `transformation` | [ExpressionTransformer](ExpressionPowerTools.Core.ExpressionTransformer.cs.md) | The transformation to apply. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |

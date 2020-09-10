# IQueryableExtensions.HasFragment Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IQueryableExtensions](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.cs.md) > **HasFragment**



## Overloads

| Overload | Description |
| :-- | :-- |
| [HasFragment&lt;T>(IQueryable&lt;T> source, Func&lt;IQueryable&lt;T>, IQueryable&lt;T>> fragment)](#hasfragmenttiqueryablet-source-funciqueryablet-iqueryablet-fragment) |  |
## HasFragment&lt;T>(IQueryable&lt;T> source, Func&lt;IQueryable&lt;T>, IQueryable&lt;T>> fragment)



```csharp
public static Boolean HasFragment<T>(IQueryable<T> source, Func<IQueryable<T>, IQueryable<T>> fragment)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) |  |
| `fragment` | [Func&lt;IQueryable&lt;T>, IQueryable&lt;T>>](https://docs.microsoft.com/dotnet/api/system.func-2) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |

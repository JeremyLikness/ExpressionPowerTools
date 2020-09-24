# IQueryableExtensions.HasFragment Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IQueryableExtensions](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.cs.md) > **HasFragment**

Determine whether a fragment of queryable exists in the
            target query.

## Overloads

| Overload | Description |
| :-- | :-- |
| [HasFragment&lt;T>(IQueryable&lt;T> source, Func&lt;IQueryable&lt;T>, IQueryable&lt;T>> fragment)](#hasfragmenttiqueryablet-source-funciqueryablet-iqueryablet-fragment) | Determine whether a fragment of queryable exists in the            target query. |
## HasFragment&lt;T>(IQueryable&lt;T> source, Func&lt;IQueryable&lt;T>, IQueryable&lt;T>> fragment)

Determine whether a fragment of queryable exists in the
            target query.

```csharp
public static Boolean HasFragment<T>(IQueryable<T> source, Func<IQueryable<T>, IQueryable<T>> fragment)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the fragment is part of the parent query.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) to check. |
| `fragment` | [Func&lt;IQueryable&lt;T>, IQueryable&lt;T>>](https://docs.microsoft.com/dotnet/api/system.func-2) | The fragment to test. |


## Remarks

This will return true if all parts of the fragment's expression tree
            are similar to all parts of a similar expression in the source.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:47:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

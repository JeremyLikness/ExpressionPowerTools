﻿# IQueryableExtensions.CreateQueryTemplate Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IQueryableExtensions](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.cs.md) > **CreateQueryTemplate**

Creates a queryable from an empty list used for templates to compare.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CreateQueryTemplate&lt;T>()](#createquerytemplatet) | Creates a queryable from an empty list used for templates to compare. |
| [CreateQueryTemplate&lt;T>(IQueryable&lt;T> noop)](#createquerytemplatetiqueryablet-noop) | Creates a new queryable to build a template from. |
## CreateQueryTemplate&lt;T>()

Creates a queryable from an empty list used for templates to compare.

```csharp
public static IQueryable<T> CreateQueryTemplate<T>()
```

### Return Type

 [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1)  - The [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) to build on.


## CreateQueryTemplate&lt;T>(IQueryable&lt;T> noop)

Creates a new queryable to build a template from.

```csharp
public static IQueryable<T> CreateQueryTemplate<T>(IQueryable<T> noop)
```

### Return Type

 [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1)  - The [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) to build on.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `noop` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The source [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/16/2020 4:18:46 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
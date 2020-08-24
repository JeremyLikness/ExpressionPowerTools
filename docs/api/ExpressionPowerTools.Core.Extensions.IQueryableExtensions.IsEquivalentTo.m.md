# IQueryableExtensions.IsEquivalentTo Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IQueryableExtensions](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.cs.md) > **IsEquivalentTo**

Determines whether the expression tree of the query is equivalent to the other query.

## Overloads

| Overload | Description |
| :-- | :-- |
| [IsEquivalentTo(IQueryable source, IQueryable target)](#isequivalenttoiqueryable-source-iqueryable-target) | Determines whether the expression tree of the query is equivalent to the other query. |
| [IsEquivalentTo&lt;T>(IQueryable&lt;T> source, IQueryable&lt;T> target)](#isequivalenttotiqueryablet-source-iqueryablet-target) | Determines whether the expression tree of the query is equivalent to the other query. |
## IsEquivalentTo(IQueryable source, IQueryable target)

Determines whether the expression tree of the query is equivalent to the other query.

```csharp
public static Boolean IsEquivalentTo(IQueryable source, IQueryable target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the queries are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The source [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) . |
| `target` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The target [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) . |


## IsEquivalentTo&lt;T>(IQueryable&lt;T> source, IQueryable&lt;T> target)

Determines whether the expression tree of the query is equivalent to the other query.

```csharp
public static Boolean IsEquivalentTo<T>(IQueryable<T> source, IQueryable<T> target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the queries are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The source [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) . |
| `target` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The target [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 11:34:48 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

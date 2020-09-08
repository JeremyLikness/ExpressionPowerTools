# QuerySnapshotProvider&lt;T> Constructors

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > [QuerySnapshotProvider<T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) > **QuerySnapshotProvider(IQueryable sourceQuery)**

Initializes a new instance of the [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [QuerySnapshotProvider(IQueryable sourceQuery)](#querysnapshotprovideriqueryable-sourcequery) | Initializes a new instance of the [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) class. |
| [QuerySnapshotProvider(IQueryable sourceQuery, IQuerySnapshot parent)](#querysnapshotprovideriqueryable-sourcequery-iquerysnapshot-parent) | Initializes a new instance of the [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) class. |

## QuerySnapshotProvider(IQueryable sourceQuery)

Initializes a new instance of the [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) class.

```csharp
public QuerySnapshotProvider(IQueryable sourceQuery)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `sourceQuery` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The query to snapshot. |



## QuerySnapshotProvider(IQueryable sourceQuery, IQuerySnapshot parent)

Initializes a new instance of the [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) class.

```csharp
public QuerySnapshotProvider(IQueryable sourceQuery, IQuerySnapshot parent)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `sourceQuery` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The query to snapshot. |
| `parent` | [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) | The parent that created this. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/8/2020 3:10:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.6-alpha |

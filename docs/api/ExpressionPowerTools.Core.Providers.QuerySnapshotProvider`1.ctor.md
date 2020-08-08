# QuerySnapshotProvider&lt;T> Constructors

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) > **QuerySnapshotProvider&lt;T>(IQueryable sourceQuery)**

Initializes a new instance of the [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [QuerySnapshotProvider&lt;T>(IQueryable sourceQuery)](#ctor-0) |
| [QuerySnapshotProvider&lt;T>(IQueryable sourceQuery, IQuerySnapshot parent)](#ctor-1) |

<a name="#ctor-0"></a>
## QuerySnapshotProvider&lt;T>(IQueryable sourceQuery)

Initializes a new instance of the [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) class.

```csharp
public QuerySnapshotProvider<T>(IQueryable sourceQuery)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `sourceQuery` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The query to snapshot. |



<a name="#ctor-0"></a>
## QuerySnapshotProvider&lt;T>(IQueryable sourceQuery, IQuerySnapshot parent)

Initializes a new instance of the [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) class.

```csharp
public QuerySnapshotProvider<T>(IQueryable sourceQuery, IQuerySnapshot parent)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `sourceQuery` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The query to snapshot. |
| `parent` | [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) | The parent that created this. |



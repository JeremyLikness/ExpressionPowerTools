# QuerySnapshotHost&lt;T> Constructors

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) > **QuerySnapshotHost&lt;T>(IQueryable&lt;T> source)**

Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [QuerySnapshotHost&lt;T>(IQueryable&lt;T> source)](#ctor-0) |
| [QuerySnapshotHost&lt;T>(IQueryable source, Expression expression)](#ctor-1) |
| [QuerySnapshotHost&lt;T>(Expression expression, IQuerySnapshotProvider&lt;T> provider)](#ctor-2) |

<a name="#ctor-0"></a>
## QuerySnapshotHost&lt;T>(IQueryable&lt;T> source)

Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class.

```csharp
public QuerySnapshotHost<T>(IQueryable<T> source)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The [IQueryable&lt;>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) to snapshot. |



<a name="#ctor-0"></a>
## QuerySnapshotHost&lt;T>(IQueryable source, Expression expression)

Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class.

```csharp
public QuerySnapshotHost<T>(IQueryable source, Expression expression)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The query source. |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to use. |



<a name="#ctor-0"></a>
## QuerySnapshotHost&lt;T>(Expression expression, IQuerySnapshotProvider&lt;T> provider)

Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class.

```csharp
public QuerySnapshotHost<T>(Expression expression, IQuerySnapshotProvider<T> provider)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to use. |
| `provider` | [IQuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1.i.md) | The [IQuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1.i.md) instance. |



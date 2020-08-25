# QuerySnapshotHost&lt;T> Constructors

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > [QuerySnapshotHost<T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) > **QuerySnapshotHost(IQueryable&lt;T> source)**

Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [QuerySnapshotHost(IQueryable&lt;T> source)](#querysnapshothostiqueryablet-source) | Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class. |
| [QuerySnapshotHost(IQueryable source, Expression expression)](#querysnapshothostiqueryable-source-expression-expression) | Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class. |
| [QuerySnapshotHost(Expression expression, IQuerySnapshotProvider&lt;T> provider)](#querysnapshothostexpression-expression-iquerysnapshotprovidert-provider) | Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class. |

## QuerySnapshotHost(IQueryable&lt;T> source)

Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class.

```csharp
public QuerySnapshotHost(IQueryable<T> source)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) to snapshot. |



## QuerySnapshotHost(IQueryable source, Expression expression)

Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class.

```csharp
public QuerySnapshotHost(IQueryable source, Expression expression)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The query source. |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to use. |



## QuerySnapshotHost(Expression expression, IQuerySnapshotProvider&lt;T> provider)

Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class.

```csharp
public QuerySnapshotHost(Expression expression, IQuerySnapshotProvider<T> provider)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to use. |
| `provider` | [IQuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1.i.md) | The [IQuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1.i.md) instance. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 6:00:34 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

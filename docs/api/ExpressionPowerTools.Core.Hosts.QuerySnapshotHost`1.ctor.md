# QuerySnapshotHost&lt;T> Constructors

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > [QuerySnapshotHost<T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) > **QuerySnapshotHost(IQueryable&lt;T> source)**



## Overloads

| Ctor | Description |
| :-- | :-- |
| [QuerySnapshotHost(IQueryable&lt;T> source)](#querysnapshothostiqueryablet-source) |  |
| [QuerySnapshotHost(IQueryable source, Expression expression)](#querysnapshothostiqueryable-source-expression-expression) |  |
| [QuerySnapshotHost(Expression expression, IQuerySnapshotProvider&lt;T> provider)](#querysnapshothostexpression-expression-iquerysnapshotprovidert-provider) |  |

## QuerySnapshotHost(IQueryable&lt;T> source)



```csharp
public QuerySnapshotHost(IQueryable<T> source)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) |  |



## QuerySnapshotHost(IQueryable source, Expression expression)



```csharp
public QuerySnapshotHost(IQueryable source, Expression expression)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) |  |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) |  |



## QuerySnapshotHost(Expression expression, IQuerySnapshotProvider&lt;T> provider)



```csharp
public QuerySnapshotHost(Expression expression, IQuerySnapshotProvider<T> provider)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) |  |
| `provider` | [IQuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1.i.md) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

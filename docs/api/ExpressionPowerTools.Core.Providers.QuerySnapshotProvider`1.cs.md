# QuerySnapshotProvider&lt;T> Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > **QuerySnapshotProvider<T>**



```csharp
public class QuerySnapshotProvider<T> : CustomQueryProvider<T>, IQuerySnapshotProvider<T>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. |  |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [CustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) → **QuerySnapshotProvider&lt;T>**

Implements  [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) ,  [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) ,  [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) ,  [IQuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [QuerySnapshotProvider(IQueryable sourceQuery)](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.ctor.md#querysnapshotprovideriqueryable-sourcequery) |  |
| [QuerySnapshotProvider(IQueryable sourceQuery, IQuerySnapshot parent)](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.ctor.md#querysnapshotprovideriqueryable-sourcequery-iquerysnapshot-parent) |  |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Parent`](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.Parent.prop.md) | [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) |  |

## Methods

| Method | Description |
| :-- | :-- |
| [Void add_QueryExecuted(EventHandler&lt;QuerySnapshotEventArgs> value)](QuerySnapshotProvider`1-add_QueryExecuted.m.md) |  |
| [IQueryable CreateQuery(Expression expression)](QuerySnapshotProvider`1-CreateQuery.m.md) |  |
| [IEnumerable&lt;T> ExecuteEnumerable(Expression expression)](QuerySnapshotProvider`1-ExecuteEnumerable.m.md) |  |
| [Void OnExecuteEnumerableCalled(Expression expression)](QuerySnapshotProvider`1-OnExecuteEnumerableCalled.m.md) |  |
| [Void remove_QueryExecuted(EventHandler&lt;QuerySnapshotEventArgs> value)](QuerySnapshotProvider`1-remove_QueryExecuted.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

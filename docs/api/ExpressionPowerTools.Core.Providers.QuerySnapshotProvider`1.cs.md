# QuerySnapshotProvider&lt;T> Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > **QuerySnapshotProvider<T>**

Provider that raises an event just before the query is executed.

```csharp
public class QuerySnapshotProvider<T> : CustomQueryProvider<T>, IQuerySnapshotProvider<T>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. | The type of entity. |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [CustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) → **QuerySnapshotProvider&lt;T>**

Implements  [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) ,  [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) ,  [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) ,  [IQuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [QuerySnapshotProvider(IQueryable sourceQuery)](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.ctor.md#querysnapshotprovideriqueryable-sourcequery) | Initializes a new instance of the [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) class. |
| [QuerySnapshotProvider(IQueryable sourceQuery, IQuerySnapshot parent)](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.ctor.md#querysnapshotprovideriqueryable-sourcequery-iquerysnapshot-parent) | Initializes a new instance of the [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Parent`](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.Parent.prop.md) | [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) | Gets or sets the [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) parent. |

## Methods

| Method | Description |
| :-- | :-- |
| [Void add_QueryExecuted(EventHandler&lt;QuerySnapshotEventArgs> value)](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.add_QueryExecuted.m.md) |  |
| [IQueryable CreateQuery(Expression expression)](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.CreateQuery.m.md) | Creates the query. |
| [IEnumerable&lt;T> ExecuteEnumerable(Expression expression)](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.ExecuteEnumerable.m.md) | Return the enumerable result. |
| [Void OnExecuteEnumerableCalled(Expression expression)](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.OnExecuteEnumerableCalled.m.md) | Raise the event. |
| [Void remove_QueryExecuted(EventHandler&lt;QuerySnapshotEventArgs> value)](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.remove_QueryExecuted.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:47:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

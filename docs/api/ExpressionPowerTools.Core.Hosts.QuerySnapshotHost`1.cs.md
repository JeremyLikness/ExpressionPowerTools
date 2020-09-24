# QuerySnapshotHost&lt;T> Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > **QuerySnapshotHost<T>**

A host to snapshot the query on execution.

```csharp
public class QuerySnapshotHost<T> : QueryHost<T, IQuerySnapshotProvider<T>>, IQuerySnapshotHost<T>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. | The type of the query. |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) → **QuerySnapshotHost&lt;T>**

Implements  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) ,  [IOrderedQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) ,  [IQueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Signatures.IQueryHost`2.i.md) ,  [IQuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [QuerySnapshotHost(IQueryable&lt;T> source)](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.ctor.md#querysnapshothostiqueryablet-source) | Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class. |
| [QuerySnapshotHost(IQueryable source, Expression expression)](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.ctor.md#querysnapshothostiqueryable-source-expression-expression) | Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class. |
| [QuerySnapshotHost(Expression expression, IQuerySnapshotProvider&lt;T> provider)](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.ctor.md#querysnapshothostexpression-expression-iquerysnapshotprovidert-provider) | Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [String RegisterSnap(Action&lt;Expression> callback)](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.RegisterSnap.m.md) | Register for a callback when the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is executed. |
| [Void UnregisterSnap(String id)](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.UnregisterSnap.m.md) | Stop listenining. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:47:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

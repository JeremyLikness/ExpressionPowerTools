# QuerySnapshotHost&lt;T> Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > **QuerySnapshotHost<T>**



```csharp
public class QuerySnapshotHost<T> : QueryHost<T, IQuerySnapshotProvider<T>>, IQuerySnapshotHost<T>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. |  |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) → **QuerySnapshotHost&lt;T>**

Implements  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) ,  [IOrderedQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) ,  [IQueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Signatures.IQueryHost`2.i.md) ,  [IQuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [QuerySnapshotHost(IQueryable&lt;T> source)](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.ctor.md#querysnapshothostiqueryablet-source) |  |
| [QuerySnapshotHost(IQueryable source, Expression expression)](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.ctor.md#querysnapshothostiqueryable-source-expression-expression) |  |
| [QuerySnapshotHost(Expression expression, IQuerySnapshotProvider&lt;T> provider)](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.ctor.md#querysnapshothostexpression-expression-iquerysnapshotprovidert-provider) |  |
## Methods

| Method | Description |
| :-- | :-- |
| [String RegisterSnap(Action&lt;Expression> callback)](QuerySnapshotHost`1-RegisterSnap.m.md) |  |
| [Void UnregisterSnap(String id)](QuerySnapshotHost`1-UnregisterSnap.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

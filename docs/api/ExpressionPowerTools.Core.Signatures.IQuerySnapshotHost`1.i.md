# IQuerySnapshotHost&lt;T> Interface

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IQuerySnapshotHost<T>**



```csharp
public interface IQuerySnapshotHost<T> : IQueryHost<T, IQuerySnapshotProvider<T>>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. |  |

Implements  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) ,  [IOrderedQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) ,  [IQueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Signatures.IQueryHost`2.i.md) 

Derived  [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [String RegisterSnap(Action&lt;Expression> callback)](IQuerySnapshotHost`1-RegisterSnap.m.md) |  |
| [Void UnregisterSnap(String id)](IQuerySnapshotHost`1-UnregisterSnap.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

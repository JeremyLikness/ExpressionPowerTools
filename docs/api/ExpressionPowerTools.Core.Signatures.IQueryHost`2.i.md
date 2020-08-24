# IQueryHost&lt;T, TProvider> Interface

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IQueryHost<T, TProvider>**



```csharp
public interface IQueryHost<T, TProvider> : IOrderedQueryable<T>
   where TProvider : ICustomQueryProvider<T>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. |  |
| `TProvider` | [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) |  |

Implements  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) ,  [IOrderedQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) 

Derived  [IQuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.i.md) ,  [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) ,  [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) 

## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`CustomProvider`](ExpressionPowerTools.Core.Signatures.IQueryHost`2.CustomProvider.prop.md) | TProvider |  |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

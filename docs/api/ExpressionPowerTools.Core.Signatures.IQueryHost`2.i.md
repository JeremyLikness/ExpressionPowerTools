# IQueryHost&lt;T, TProvider> Interface

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IQueryHost<T, TProvider>**

Interface for custom query host.

```csharp
public interface IQueryHost<T, TProvider> : IOrderedQueryable<T>
   where TProvider : ICustomQueryProvider<T>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. | The type of entity. |
| `TProvider` | [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) | The [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) to handle logic. |

Implements  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) ,  [IOrderedQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) 

Derived  [IQuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.i.md) ,  [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) ,  [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) 

## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`CustomProvider`](ExpressionPowerTools.Core.Signatures.IQueryHost`2.CustomProvider.prop.md) | TProvider | Gets the [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) that handles the custom logic. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

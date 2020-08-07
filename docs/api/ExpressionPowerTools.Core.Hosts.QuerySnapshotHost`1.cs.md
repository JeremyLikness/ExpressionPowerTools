# QuerySnapshotHost&lt;T> Class

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > **QuerySnapshotHost&lt;T>**

A host to snapshot the query on execution.

```csharp
public class QuerySnapshotHost<T> : QueryHost<T, IQuerySnapshotProvider<T>>, IQuerySnapshotHost<T>
```

## Type Parameters

**`T`**
The type of the query.

---

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) → **QuerySnapshotHost&lt;T>**

Implements  [IQueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Signatures.IQueryHost`2.i.md) ,  [IOrderedQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) ,  [IEnumerable&lt;T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) ,  [IQuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.i.md) 

## Examples


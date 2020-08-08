# QuerySnapshotHost&lt;T> Class

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > **QuerySnapshotHost<T>**

A host to snapshot the query on execution.

```csharp
public class QuerySnapshotHost<T> : QueryHost<T, IQuerySnapshotProvider<T>>, IQuerySnapshotHost<T>
```

### Type Parameters

| Parameter Name | Description |
| :-- | :-- |
| `T` | The type of the query. |

Inheritance [System.Object](https://docs.microsoft.com/dotnet/api/system.object) → [QueryHost<T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) → **QuerySnapshotHost&lt;T>**

Implements  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IEnumerable&lt;T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) ,  [IOrderedQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) ,  [IQueryHost<T, TProvider>](ExpressionPowerTools.Core.Signatures.IQueryHost`2.i.md) ,  [IQuerySnapshotHost<T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.i.md) 

# Constructors

| Ctor | Description |
| :-- | :-- |
| [QuerySnapshotHost&lt;T>(IQueryable&lt;T> source)](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.ctor.md#ctor-0) | Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class. |
| [QuerySnapshotHost&lt;T>(IQueryable source, Expression expression)](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.ctor.md#ctor-1) | Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class. |
| [QuerySnapshotHost&lt;T>(Expression expression, IQuerySnapshotProvider&lt;T> provider)](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.ctor.md#ctor-2) | Initializes a new instance of the [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) class. |

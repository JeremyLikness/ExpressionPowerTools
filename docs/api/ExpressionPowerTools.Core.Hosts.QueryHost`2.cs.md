# ExpressionPowerTools.Core.Hosts.QueryHost&lt;T, TProvider> Class

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > **QueryHost&lt;T, TProvider>**

Base class for custom query host.

```csharp
public class QueryHost<T, TProvider> : IQueryHost<T, TProvider>
   where TProvider : ICustomQueryProvider<T>
```

### Type Parameters

| Parameter Name | Description |
| :-- | :-- |
| `T` | The entity type. |
| `TProvider` | The [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) to use. |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **QueryHost&lt;T, TProvider>**

Implements  [IQueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Signatures.IQueryHost`2.i.md) ,  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IEnumerable&lt;T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IOrderedQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) 

Derived  [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) 

# Constructors

| Ctor | Description |
| :-- | :-- |
| [QueryHost&lt;T, TProvider>(Expression expression, TProvider provider)](ExpressionPowerTools.Core.Hosts.QueryHost`2.ctor.md#ctor-0) | Initializes a new instance of the [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) class. |

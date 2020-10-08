# RemoteQuery&lt;T, TProvider> Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Queryable](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.n.md) > **RemoteQuery<T, TProvider>**

Encapsulates query capabilities to build the template for remote submission.

```csharp
public class RemoteQuery<T, TProvider> : QueryHost<T, TProvider>, IQueryHost<T, TProvider>, IRemoteQueryable<T>
   where TProvider : ICustomQueryProvider<T>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. | The [Type](https://docs.microsoft.com/dotnet/api/system.type) of the query. |
| `TProvider` | [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) | The [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) . |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) → **RemoteQuery&lt;T, TProvider>**

Implements  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) ,  [IOrderedQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) ,  [IQueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Signatures.IQueryHost`2.i.md) ,  [IRemoteQuery](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQuery.i.md) ,  [IRemoteQueryable&lt;T>](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryable`1.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [RemoteQuery(Expression expression, TProvider provider)](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQuery`2.ctor.md#remotequeryexpression-expression-tprovider-provider) | Initializes a new instance of the [RemoteQuery&lt;T, TProvider>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQuery`2.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [IEnumerator&lt;T> GetEnumerator()](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQuery`2.GetEnumerator.m.md) | Gets the enumerator of the result. Overridden to prevent issues trying to execute            a database query directly. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

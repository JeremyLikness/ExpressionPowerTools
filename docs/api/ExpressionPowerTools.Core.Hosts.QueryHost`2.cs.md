# QueryHost&lt;T, TProvider> Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > **QueryHost<T, TProvider>**

Base class for custom query host.

```csharp
public class QueryHost<T, TProvider> : IQueryHost<T, TProvider>
   where TProvider : ICustomQueryProvider<T>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. | The entity type. |
| `TProvider` | [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) | The [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) to use. |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **QueryHost&lt;T, TProvider>**

Implements  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) ,  [IOrderedQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) ,  [IQueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Signatures.IQueryHost`2.i.md) 

Derived  [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [QueryHost(Expression expression, TProvider provider)](ExpressionPowerTools.Core.Hosts.QueryHost`2.ctor.md#queryhostexpression-expression-tprovider-provider) | Initializes a new instance of the [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`CustomProvider`](ExpressionPowerTools.Core.Hosts.QueryHost`2.CustomProvider.prop.md) | TProvider | Gets or sets the instance of the [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) . |
| [`ElementType`](ExpressionPowerTools.Core.Hosts.QueryHost`2.ElementType.prop.md) | [Type](https://docs.microsoft.com/dotnet/api/system.type) | Gets the type of element. |
| [`Expression`](ExpressionPowerTools.Core.Hosts.QueryHost`2.Expression.prop.md) | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | Gets the [Expression](ExpressionPowerTools.Core.Hosts.QueryHost`2.Expression.prop.md) for the query. |
| [`Provider`](ExpressionPowerTools.Core.Hosts.QueryHost`2.Provider.prop.md) | [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) | Gets the instance of the [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) . |

## Methods

| Method | Description |
| :-- | :-- |
| [IEnumerator&lt;T> GetEnumerator()](ExpressionPowerTools.Core.Hosts.QueryHost`2.GetEnumerator.m.md) | Gets an [IEnumerator&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerator-1) for the query results. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 11:34:48 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

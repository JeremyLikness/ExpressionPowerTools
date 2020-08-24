# QueryHost&lt;T, TProvider> Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > **QueryHost<T, TProvider>**



```csharp
public class QueryHost<T, TProvider> : IQueryHost<T, TProvider>
   where TProvider : ICustomQueryProvider<T>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. |  |
| `TProvider` | [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) |  |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **QueryHost&lt;T, TProvider>**

Implements  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) ,  [IOrderedQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) ,  [IQueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Signatures.IQueryHost`2.i.md) 

Derived  [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [QueryHost(Expression expression, TProvider provider)](ExpressionPowerTools.Core.Hosts.QueryHost`2.ctor.md#queryhostexpression-expression-tprovider-provider) |  |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`CustomProvider`](ExpressionPowerTools.Core.Hosts.QueryHost`2.CustomProvider.prop.md) | TProvider |  |
| [`ElementType`](ExpressionPowerTools.Core.Hosts.QueryHost`2.ElementType.prop.md) | [Type](https://docs.microsoft.com/dotnet/api/system.type) |  |
| [`Expression`](ExpressionPowerTools.Core.Hosts.QueryHost`2.Expression.prop.md) | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) |  |
| [`Provider`](ExpressionPowerTools.Core.Hosts.QueryHost`2.Provider.prop.md) | [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) |  |

## Methods

| Method | Description |
| :-- | :-- |
| [IEnumerator&lt;T> GetEnumerator()](QueryHost`2-GetEnumerator.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

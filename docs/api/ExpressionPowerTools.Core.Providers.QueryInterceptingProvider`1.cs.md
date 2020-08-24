# QueryInterceptingProvider&lt;T> Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > **QueryInterceptingProvider<T>**



```csharp
public class QueryInterceptingProvider<T> : CustomQueryProvider<T>, IQueryInterceptingProvider<T>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. |  |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [CustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) → **QueryInterceptingProvider&lt;T>**

Implements  [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) ,  [IQueryInterceptingProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQueryInterceptingProvider`1.i.md) ,  [IQueryInterceptor](ExpressionPowerTools.Core.Signatures.IQueryInterceptor.i.md) ,  [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [QueryInterceptingProvider(IQueryable sourceQuery)](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.ctor.md#queryinterceptingprovideriqueryable-sourcequery) |  |
## Methods

| Method | Description |
| :-- | :-- |
| [IQueryable CreateQuery(Expression expression)](QueryInterceptingProvider`1-CreateQuery.m.md) |  |
| [Object Execute(Expression expression)](QueryInterceptingProvider`1-Execute.m.md) |  |
| [IEnumerable&lt;T> ExecuteEnumerable(Expression expression)](QueryInterceptingProvider`1-ExecuteEnumerable.m.md) |  |
| [Void RegisterInterceptor(ExpressionTransformer transformation)](QueryInterceptingProvider`1-RegisterInterceptor.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

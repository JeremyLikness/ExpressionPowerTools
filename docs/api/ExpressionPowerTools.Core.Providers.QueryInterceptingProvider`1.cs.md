# QueryInterceptingProvider&lt;T> Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > **QueryInterceptingProvider<T>**

Provider that intercepts the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) when run.

```csharp
public class QueryInterceptingProvider<T> : CustomQueryProvider<T>, IQueryInterceptingProvider<T>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. | The entity type. |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [CustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) → **QueryInterceptingProvider&lt;T>**

Implements  [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) ,  [IQueryInterceptingProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQueryInterceptingProvider`1.i.md) ,  [IQueryInterceptor](ExpressionPowerTools.Core.Signatures.IQueryInterceptor.i.md) ,  [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [QueryInterceptingProvider(IQueryable sourceQuery)](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.ctor.md#queryinterceptingprovideriqueryable-sourcequery) | Initializes a new instance of the [QueryInterceptingProvider&lt;T>](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [IQueryable CreateQuery(Expression expression)](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.CreateQuery.m.md) | Creates a query host with this provider. |
| [Object Execute(Expression expression)](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.Execute.m.md) | Execute with transformation. |
| [IEnumerable&lt;T> ExecuteEnumerable(Expression expression)](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.ExecuteEnumerable.m.md) | Execute the enumerable. |
| [Void RegisterInterceptor(ExpressionTransformer transformation)](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.RegisterInterceptor.m.md) | Registers the transformation to apply. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

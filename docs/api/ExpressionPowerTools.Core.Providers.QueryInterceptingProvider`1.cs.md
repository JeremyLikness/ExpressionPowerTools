# QueryInterceptingProvider&lt;T> Class

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > **QueryInterceptingProvider<T>**

Provider that intercepts the [System.Linq.Expressions.Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) when run.

```csharp
public class QueryInterceptingProvider<T> : CustomQueryProvider<T>, IQueryInterceptingProvider<T>
```

### Type Parameters

| Parameter Name | Description |
| :-- | :-- |
| `T` | The entity type. |

Inheritance [System.Object](https://docs.microsoft.com/dotnet/api/system.object) → [CustomQueryProvider<T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) → **QueryInterceptingProvider&lt;T>**

Implements  [ICustomQueryProvider<T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) ,  [IQueryInterceptingProvider<T>](ExpressionPowerTools.Core.Signatures.IQueryInterceptingProvider`1.i.md) ,  [IQueryInterceptor](ExpressionPowerTools.Core.Signatures.IQueryInterceptor.i.md) ,  [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) 

# Constructors

| Ctor | Description |
| :-- | :-- |
| [QueryInterceptingProvider&lt;T>(IQueryable sourceQuery)](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.ctor.md#ctor-0) | Initializes a new instance of the [QueryInterceptingProvider&lt;T>](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.cs.md) class. |

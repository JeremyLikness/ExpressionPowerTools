# ICustomQueryProvider&lt;T> Interface

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **ICustomQueryProvider<T>**

Interface for a custom implementation of [System.Linq.IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) .

```csharp
public interface ICustomQueryProvider<T> : IQueryProvider
```

### Type Parameters

| Parameter Name | Description |
| :-- | :-- |
| `T` | The entity type. |

Implements  [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) 

Derived  [CustomQueryProvider<T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) ,  [IQueryInterceptingProvider<T>](ExpressionPowerTools.Core.Signatures.IQueryInterceptingProvider`1.i.md) ,  [IQuerySnapshotProvider<T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1.i.md) ,  [QueryInterceptingProvider<T>](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.cs.md) ,  [QuerySnapshotProvider<T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) 


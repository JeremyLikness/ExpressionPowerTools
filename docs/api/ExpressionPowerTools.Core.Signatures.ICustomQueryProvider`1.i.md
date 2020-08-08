# ExpressionPowerTools.Core.Signatures.ICustomQueryProvider&lt;T> Interface

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **ICustomQueryProvider&lt;T>**

Interface for a custom implementation of [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) .

```csharp
public interface ICustomQueryProvider<T> : IQueryProvider
```

### Type Parameters

| Parameter Name | Description |
| :-- | :-- |
| `T` | The entity type. |

Implements  [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) 

Derived  [CustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) ,  [QueryInterceptingProvider&lt;T>](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.cs.md) ,  [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) ,  [IQueryInterceptingProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQueryInterceptingProvider`1.i.md) ,  [IQuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1.i.md) 


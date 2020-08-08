# ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider&lt;T> Interface

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IQuerySnapshotProvider&lt;T>**

Provider to intercept query execution for inspection.

```csharp
public interface IQuerySnapshotProvider<T> : ICustomQueryProvider<T>, IQuerySnapshot
```

### Type Parameters

| Parameter Name | Description |
| :-- | :-- |
| `T` | The type of snapshot to provide for. |

Implements  [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) ,  [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) ,  [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) 

Derived  [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) 


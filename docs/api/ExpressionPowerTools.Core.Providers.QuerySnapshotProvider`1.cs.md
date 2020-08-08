# QuerySnapshotProvider&lt;T> Class

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > **QuerySnapshotProvider<T>**

Provider that raises an event just before the query is executed.

```csharp
public class QuerySnapshotProvider<T> : CustomQueryProvider<T>, IQuerySnapshotProvider<T>
```

### Type Parameters

| Parameter Name | Description |
| :-- | :-- |
| `T` | The type of entity. |

Inheritance [System.Object](https://docs.microsoft.com/dotnet/api/system.object) → [CustomQueryProvider<T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) → **QuerySnapshotProvider&lt;T>**

Implements  [ICustomQueryProvider<T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) ,  [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) ,  [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) ,  [IQuerySnapshotProvider<T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1.i.md) 

# Constructors

| Ctor | Description |
| :-- | :-- |
| [QuerySnapshotProvider&lt;T>(IQueryable sourceQuery)](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.ctor.md#ctor-0) | Initializes a new instance of the [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) class. |
| [QuerySnapshotProvider&lt;T>(IQueryable sourceQuery, IQuerySnapshot parent)](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.ctor.md#ctor-1) | Initializes a new instance of the [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) class. |
### Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Parent`](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.Parent.prop.md) | [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) | Gets or sets the [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) parent. |


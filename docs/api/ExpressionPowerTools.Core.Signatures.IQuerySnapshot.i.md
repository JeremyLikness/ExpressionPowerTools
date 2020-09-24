# IQuerySnapshot Interface

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IQuerySnapshot**

Non-generic interface for snapshot host.

```csharp
public interface IQuerySnapshot
```

Derived  [IQuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1.i.md) ,  [QuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) 

## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Parent`](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.Parent.prop.md) | [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) | Gets the parent provider for bubbling events. |

## Methods

| Method | Description |
| :-- | :-- |
| [Void add_QueryExecuted(EventHandler&lt;QuerySnapshotEventArgs> value)](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.add_QueryExecuted.m.md) |  |
| [Void OnExecuteEnumerableCalled(Expression expression)](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.OnExecuteEnumerableCalled.m.md) | Method to raise call. |
| [Void remove_QueryExecuted(EventHandler&lt;QuerySnapshotEventArgs> value)](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.remove_QueryExecuted.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:57:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

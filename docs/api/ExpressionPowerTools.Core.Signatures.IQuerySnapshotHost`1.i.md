﻿# IQuerySnapshotHost&lt;T> Interface

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IQuerySnapshotHost<T>**

Host to snapshot a query. Will raise an event when it is executed
            to allow inspecting the expression.

```csharp
public interface IQuerySnapshotHost<T> : IQueryHost<T, IQuerySnapshotProvider<T>>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. | The type of entity. |

Implements  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) ,  [IOrderedQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) ,  [IQueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Signatures.IQueryHost`2.i.md) 

Derived  [QuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [String RegisterSnap(Action&lt;Expression> callback)](ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.RegisterSnap.m.md) | Register a callback to receive the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) when snapped. |
| [Void UnregisterSnap(String id)](ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.UnregisterSnap.m.md) | Unregister for callbacks. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

# QuerySnapshotHost&lt;T>.RegisterSnap Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > [QuerySnapshotHost<T>](ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.cs.md) > **RegisterSnap**

Register for a callback when the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is executed.

## Overloads

| Overload | Description |
| :-- | :-- |
| [RegisterSnap(Action&lt;Expression> callback)](#registersnapactionexpression-callback) | Register for a callback when the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is executed. |
## RegisterSnap(Action&lt;Expression> callback)

Register for a callback when the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is executed.

```csharp
public virtual String RegisterSnap(Action<Expression> callback)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - A unique identifier for the registration.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `callback` | [Action&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.action-1) | The callback to pass the expression to. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when callback is null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:26:53 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

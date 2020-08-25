# IExpressionSerializer&lt;T, TSerializable>.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IExpressionSerializer<T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) > **Serialize**

Serializes an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a serializable class.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(T expression)](#serializet-expression) | Serializes an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a serializable class. |
## Serialize(T expression)

Serializes an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a serializable class.

```csharp
public virtual TSerializable Serialize(T expression)
```

### Return Type

TSerializable - The serializeable class.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | T | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to serialize. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 6:00:34 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

# IExpressionSerializer&lt;T, TSerializable>.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IExpressionSerializer<T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) > **Serialize**

Serializes an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a serializable class.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(T expression, SerializationState state)](#serializet-expression-serializationstate-state) | Serializes an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a serializable class. |
## Serialize(T expression, SerializationState state)

Serializes an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a serializable class.

```csharp
public virtual TSerializable Serialize(T expression, SerializationState state)
```

### Return Type

TSerializable - The serializeable class.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | T | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to serialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

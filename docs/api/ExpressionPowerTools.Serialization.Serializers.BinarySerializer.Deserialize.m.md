# BinarySerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [BinarySerializer](ExpressionPowerTools.Serialization.Serializers.BinarySerializer.cs.md) > **Deserialize**

Deserializes a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(Binary root, SerializationState state)](#deserializebinary-root-serializationstate-state) | Deserializes a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) . |
## Deserialize(Binary root, SerializationState state)

Deserializes a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) .

```csharp
public virtual BinaryExpression Deserialize(Binary root, SerializationState state)
```

### Return Type

 [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression)  - The [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `root` | [Binary](ExpressionPowerTools.Serialization.Serializers.Binary.cs.md) | The serialized fragment. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 18:50:36 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

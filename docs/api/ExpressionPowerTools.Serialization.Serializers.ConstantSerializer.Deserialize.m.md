# ConstantSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ConstantSerializer](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.cs.md) > **Deserialize**

Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(Constant constant, SerializationState state)](#deserializeconstant-constant-serializationstate-state) | Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
## Deserialize(Constant constant, SerializationState state)

Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

```csharp
public virtual ConstantExpression Deserialize(Constant constant, SerializationState state)
```

### Return Type

 [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression)  - The deserialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `constant` | [Constant](ExpressionPowerTools.Serialization.Serializers.Constant.cs.md) | The serialized fragment. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

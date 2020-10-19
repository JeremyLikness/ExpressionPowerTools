# ConstantSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ConstantSerializer](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.cs.md) > **Serialize**

Serializes the expression.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(ConstantExpression expression, SerializationState state)](#serializeconstantexpression-expression-serializationstate-state) | Serializes the expression. |
## Serialize(ConstantExpression expression, SerializationState state)

Serializes the expression.

```csharp
public virtual Constant Serialize(ConstantExpression expression, SerializationState state)
```

### Return Type

 [Constant](ExpressionPowerTools.Serialization.Serializers.Constant.cs.md)  - The serializable [Constant](ExpressionPowerTools.Serialization.Serializers.Constant.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) | The [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) to serialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |

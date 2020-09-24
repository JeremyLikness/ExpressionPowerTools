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
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State, such as [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) , for the serialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:26:53 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

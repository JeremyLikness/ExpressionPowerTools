# ParameterSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ParameterSerializer](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.cs.md) > **Deserialize**

Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(Parameter param, SerializationState state)](#deserializeparameter-param-serializationstate-state) | Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
## Deserialize(Parameter param, SerializationState state)

Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

```csharp
public virtual ParameterExpression Deserialize(Parameter param, SerializationState state)
```

### Return Type

 [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression)  - The deserialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `param` | [Parameter](ExpressionPowerTools.Serialization.Serializers.Parameter.cs.md) | The serialized fragment. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

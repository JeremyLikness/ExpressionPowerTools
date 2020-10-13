# LambdaSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) > **Deserialize**

Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(Lambda lambda, SerializationState state)](#deserializelambda-lambda-serializationstate-state) | Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) . |
## Deserialize(Lambda lambda, SerializationState state)

Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

```csharp
public virtual LambdaExpression Deserialize(Lambda lambda, SerializationState state)
```

### Return Type

 [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression)  - The [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `lambda` | [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) | The serialized fragment. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

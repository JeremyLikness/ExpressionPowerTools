# LambdaSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) > **Serialize**

Serialize a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) to a [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(LambdaExpression expression, SerializationState state)](#serializelambdaexpression-expression-serializationstate-state) | Serialize a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) to a [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) . |
## Serialize(LambdaExpression expression, SerializationState state)

Serialize a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) to a [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) .

```csharp
public virtual Lambda Serialize(LambdaExpression expression, SerializationState state)
```

### Return Type

 [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md)  - The [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) | The [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) . |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

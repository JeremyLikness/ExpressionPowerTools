# LambdaSerializer Constructors

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) > **LambdaSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)**

Initializes a new instance of the [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) class with a
            base serializer for recurision.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [LambdaSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](#lambdaserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) class with a            base serializer for recurision. |

## LambdaSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)

Initializes a new instance of the [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) class with a
            base serializer for recurision.

```csharp
public LambdaSerializer(IExpressionSerializer<Expression, SerializableExpression> serializer)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `serializer` | [IExpressionSerializer&lt;Expression, SerializableExpression>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) | The base serializer. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

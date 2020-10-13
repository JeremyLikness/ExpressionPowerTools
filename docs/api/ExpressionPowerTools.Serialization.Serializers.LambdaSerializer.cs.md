# LambdaSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **LambdaSerializer**

Serialization logic for expressions of type [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

```csharp
public class LambdaSerializer : BaseSerializer<LambdaExpression, Lambda>, IExpressionSerializer<LambdaExpression, Lambda>, IBaseSerializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) → **LambdaSerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [LambdaSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.ctor.md#lambdaserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) class with a            base serializer for recurision. |
## Methods

| Method | Description |
| :-- | :-- |
| [LambdaExpression Deserialize(Lambda lambda, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.Deserialize.m.md) | Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) . |
| [Lambda Serialize(LambdaExpression expression, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.Serialize.m.md) | Serialize a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) to a [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

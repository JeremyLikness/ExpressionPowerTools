# LambdaSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **LambdaSerializer**

Serialization logic for expressions of type [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

```csharp
public class LambdaSerializer : BaseSerializer, IBaseSerializer, IExpressionSerializer<LambdaExpression, Lambda>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer](ExpressionPowerTools.Serialization.Serializers.BaseSerializer.cs.md) → **LambdaSerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [LambdaSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.ctor.md#lambdaserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) class with a            base serializer for recurision. |
## Methods

| Method | Description |
| :-- | :-- |
| [LambdaExpression Deserialize(JsonElement json)](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.Deserialize.m.md) | Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) . |
| [Lambda Serialize(LambdaExpression expression)](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.Serialize.m.md) | Serialize a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) to a [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 6:00:34 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

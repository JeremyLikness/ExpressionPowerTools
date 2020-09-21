# BinarySerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **BinarySerializer**

Serialization services for [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) .

```csharp
public class BinarySerializer : BaseSerializer<BinaryExpression, Binary>, IExpressionSerializer<BinaryExpression, Binary>, IBaseSerializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) → **BinarySerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [BinarySerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.BinarySerializer.ctor.md#binaryserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [BinarySerializer](ExpressionPowerTools.Serialization.Serializers.BinarySerializer.cs.md) class with a            base serializer for recursion. |
## Methods

| Method | Description |
| :-- | :-- |
| [BinaryExpression Deserialize(JsonElement json, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.BinarySerializer.Deserialize.m.md) | Deserializes a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) . |
| [Binary Serialize(BinaryExpression expression, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.BinarySerializer.Serialize.m.md) | Serialize a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) to a [Binary](ExpressionPowerTools.Serialization.Serializers.Binary.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/21/2020 19:07:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

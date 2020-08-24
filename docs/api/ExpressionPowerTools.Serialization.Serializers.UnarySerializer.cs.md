# UnarySerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **UnarySerializer**



```csharp
public class UnarySerializer : BaseSerializer, IBaseSerializer, IExpressionSerializer<UnaryExpression, Unary>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer](ExpressionPowerTools.Serialization.Serializers.BaseSerializer.cs.md) → **UnarySerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [UnarySerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.ctor.md#unaryserializeriexpressionserializerexpression-serializableexpression-serializer) |  |
## Methods

| Method | Description |
| :-- | :-- |
| [UnaryExpression Deserialize(JsonElement json)](UnarySerializer-Deserialize.m.md) |  |
| [Unary Serialize(UnaryExpression expression)](UnarySerializer-Serialize.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

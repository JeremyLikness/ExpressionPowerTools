# ConstantSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **ConstantSerializer**



```csharp
public class ConstantSerializer : BaseSerializer, IBaseSerializer, IExpressionSerializer<ConstantExpression, Constant>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer](ExpressionPowerTools.Serialization.Serializers.BaseSerializer.cs.md) → **ConstantSerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ConstantSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.ctor.md#constantserializeriexpressionserializerexpression-serializableexpression-serializer) |  |
## Methods

| Method | Description |
| :-- | :-- |
| [ConstantExpression Deserialize(JsonElement json)](ConstantSerializer-Deserialize.m.md) |  |
| [Constant Serialize(ConstantExpression expression)](ConstantSerializer-Serialize.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

# ConstantSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **ConstantSerializer**

Serializer for [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) .

```csharp
public class ConstantSerializer : BaseSerializer<ConstantExpression, Constant>, IExpressionSerializer<ConstantExpression, Constant>, IBaseSerializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) → **ConstantSerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ConstantSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.ctor.md#constantserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [ConstantSerializer](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [ConstantExpression Deserialize(JsonElement json, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.Deserialize.m.md) | Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| [Constant Serialize(ConstantExpression expression, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.Serialize.m.md) | Serializes the expression. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:29:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

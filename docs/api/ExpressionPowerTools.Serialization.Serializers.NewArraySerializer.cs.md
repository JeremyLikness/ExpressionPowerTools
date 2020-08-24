# NewArraySerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **NewArraySerializer**



```csharp
public class NewArraySerializer : BaseSerializer, IBaseSerializer, IExpressionSerializer<NewArrayExpression, NewArray>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer](ExpressionPowerTools.Serialization.Serializers.BaseSerializer.cs.md) → **NewArraySerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [NewArraySerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.ctor.md#newarrayserializeriexpressionserializerexpression-serializableexpression-serializer) |  |
## Methods

| Method | Description |
| :-- | :-- |
| [NewArrayExpression Deserialize(JsonElement json)](NewArraySerializer-Deserialize.m.md) |  |
| [NewArray Serialize(NewArrayExpression expression)](NewArraySerializer-Serialize.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

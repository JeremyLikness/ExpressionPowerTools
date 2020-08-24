# ParameterSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **ParameterSerializer**



```csharp
public class ParameterSerializer : BaseSerializer, IBaseSerializer, IExpressionSerializer<ParameterExpression, Parameter>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer](ExpressionPowerTools.Serialization.Serializers.BaseSerializer.cs.md) → **ParameterSerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ParameterSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.ctor.md#parameterserializeriexpressionserializerexpression-serializableexpression-serializer) |  |
## Methods

| Method | Description |
| :-- | :-- |
| [ParameterExpression Deserialize(JsonElement json)](ParameterSerializer-Deserialize.m.md) |  |
| [Parameter Serialize(ParameterExpression expression)](ParameterSerializer-Serialize.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

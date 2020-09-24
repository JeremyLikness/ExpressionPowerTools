# ParameterSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **ParameterSerializer**

Serializer for [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) .

```csharp
public class ParameterSerializer : BaseSerializer<ParameterExpression, Parameter>, IExpressionSerializer<ParameterExpression, Parameter>, IBaseSerializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) → **ParameterSerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ParameterSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.ctor.md#parameterserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [ParameterSerializer](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [ParameterExpression Deserialize(JsonElement json, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.Deserialize.m.md) | Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| [Parameter Serialize(ParameterExpression expression, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.Serialize.m.md) | Serializes the expression. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:02:13 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

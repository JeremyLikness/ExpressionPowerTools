# ExpressionSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **ExpressionSerializer**

Top-level serializer that passes work off to specific types.

```csharp
public class ExpressionSerializer : IExpressionSerializer<Expression, SerializableExpression>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExpressionSerializer**

Implements  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Remarks

The constructor for this class scans the assembly for serializers tagged with [ExpressionSerializerAttribute](ExpressionPowerTools.Serialization.Serializers.ExpressionSerializerAttribute.cs.md) . These are loaded based on the [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) they represent and stored as [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) .
            The serializers should be accessed through the static [Serializer](ExpressionPowerTools.Serialization.Serializer.cs.md) class,
            which takes the serializable classes and serializes them to and from JSON.

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ExpressionSerializer()](ExpressionPowerTools.Serialization.Serializers.ExpressionSerializer.ctor.md#expressionserializer) | Initializes a new instance of the [ExpressionSerializer](ExpressionPowerTools.Serialization.Serializers.ExpressionSerializer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Expression Deserialize(JsonElement json, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.ExpressionSerializer.Deserialize.m.md) | Deserialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| [SerializableExpression Serialize(Expression expression, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.ExpressionSerializer.Serialize.m.md) | Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |

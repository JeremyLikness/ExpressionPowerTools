# ExpressionSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **ExpressionSerializer**

Top-level serializer that passes work off to specific types.

```csharp
public class ExpressionSerializer : IExpressionSerializer<Expression, SerializableExpression>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExpressionSerializer**

Implements  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ExpressionSerializer()](ExpressionPowerTools.Serialization.Serializers.ExpressionSerializer.ctor.md#expressionserializer) | Initializes a new instance of the [ExpressionSerializer](ExpressionPowerTools.Serialization.Serializers.ExpressionSerializer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Expression Deserialize(JsonElement json)](ExpressionSerializer-Deserialize.m.md) | Deserialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| [SerializableExpression Serialize(Expression expression)](ExpressionSerializer-Serialize.m.md) | Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/20/2020 6:23:17 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

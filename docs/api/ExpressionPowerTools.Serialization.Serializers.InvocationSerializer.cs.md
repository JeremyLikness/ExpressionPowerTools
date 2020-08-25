# InvocationSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **InvocationSerializer**

Serialization logic for expressions of type [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) .

```csharp
public class InvocationSerializer : BaseSerializer, IBaseSerializer, IExpressionSerializer<InvocationExpression, Invocation>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer](ExpressionPowerTools.Serialization.Serializers.BaseSerializer.cs.md) → **InvocationSerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [InvocationSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.ctor.md#invocationserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [InvocationSerializer](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.cs.md) class            with a base serializer for recurision. |
## Methods

| Method | Description |
| :-- | :-- |
| [InvocationExpression Deserialize(JsonElement json)](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.Deserialize.m.md) | Deserializes a [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) . |
| [Invocation Serialize(InvocationExpression expression)](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.Serialize.m.md) | Serialize an [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) to an [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 5:55:15 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

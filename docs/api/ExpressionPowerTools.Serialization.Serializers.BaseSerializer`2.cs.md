# BaseSerializer&lt;TExpression, TSerializable> Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **BaseSerializer<TExpression, TSerializable>**

Base class for serializers.

```csharp
public abstract class BaseSerializer<TExpression, TSerializable> : IExpressionSerializer<TExpression, TSerializable>
   where TExpression : Expression
   where TSerializable : SerializableExpression
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `TExpression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) supported by the serialize. |
| `TSerializable` | [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) | The serializer component it targets. |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **BaseSerializer&lt;TExpression, TSerializable>**

Implements  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

Derived  [ConstantSerializer](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.cs.md) ,  [InvocationSerializer](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.cs.md) ,  [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) ,  [MethodSerializer](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.cs.md) ,  [NewArraySerializer](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.cs.md) ,  [ParameterSerializer](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.cs.md) ,  [UnarySerializer](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.cs.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [BaseSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.ctor.md#baseserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) class with a default serializer. |
## Methods

| Method | Description |
| :-- | :-- |
| [TExpression Deserialize(JsonElement json)](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.Deserialize.m.md) | Deserialize a [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| [TSerializable Serialize(TExpression expression)](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.Serialize.m.md) | Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/26/2020 6:58:17 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

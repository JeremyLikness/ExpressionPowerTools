# BaseSerializer&lt;TExpression, TSerializable> Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **BaseSerializer<TExpression, TSerializable>**

Base class for serializers.

```csharp
public abstract class BaseSerializer<TExpression, TSerializable> : IExpressionSerializer<TExpression, TSerializable>, IBaseSerializer
   where TExpression : Expression
   where TSerializable : SerializableExpression
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `TExpression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) supported by the serialize. |
| `TSerializable` | The parameter must have a default parameterless constructor.  [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) | The serializer component it targets. |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **BaseSerializer&lt;TExpression, TSerializable>**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

Derived  [BinarySerializer](ExpressionPowerTools.Serialization.Serializers.BinarySerializer.cs.md) ,  [ConstantSerializer](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.cs.md) ,  [CtorSerializer](ExpressionPowerTools.Serialization.Serializers.CtorSerializer.cs.md) ,  [InvocationSerializer](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.cs.md) ,  [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) ,  [MemberInitSerializer](ExpressionPowerTools.Serialization.Serializers.MemberInitSerializer.cs.md) ,  [MemberSerializer](ExpressionPowerTools.Serialization.Serializers.MemberSerializer.cs.md) ,  [MethodSerializer](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.cs.md) ,  [NewArraySerializer](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.cs.md) ,  [ParameterSerializer](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.cs.md) ,  [UnarySerializer](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.cs.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [BaseSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.ctor.md#baseserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) class with a default serializer. |
| [static BaseSerializer()](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.ctor.md#static-baseserializer) | Initializes static members of the [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) class.            Captures the key delegates for compression. |
## Methods

| Method | Description |
| :-- | :-- |
| [Void CompressTypes(SerializableExpression serializable, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.CompressTypes.m.md) | Compress the types on the serializable class. |
| [TExpression Deserialize(TSerializable root, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.Deserialize.m.md) | Deserialize a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| [TSerializable Serialize(TExpression expression, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.Serialize.m.md) | Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

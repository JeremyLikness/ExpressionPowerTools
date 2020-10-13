# IBaseSerializer Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > **IBaseSerializer**

Non-generic interface for serializers.

```csharp
public interface IBaseSerializer
```

Derived  [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) ,  [BinarySerializer](ExpressionPowerTools.Serialization.Serializers.BinarySerializer.cs.md) ,  [ConstantSerializer](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.cs.md) ,  [CtorSerializer](ExpressionPowerTools.Serialization.Serializers.CtorSerializer.cs.md) ,  [InvocationSerializer](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.cs.md) ,  [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) ,  [MemberInitSerializer](ExpressionPowerTools.Serialization.Serializers.MemberInitSerializer.cs.md) ,  [MemberSerializer](ExpressionPowerTools.Serialization.Serializers.MemberSerializer.cs.md) ,  [MethodSerializer](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.cs.md) ,  [NewArraySerializer](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.cs.md) ,  [ParameterSerializer](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.cs.md) ,  [UnarySerializer](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [Void CompressTypes(SerializableExpression serializable, SerializationState state)](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.CompressTypes.m.md) | Compress the types on the serializable class. |
| [Void DecompressTypes(SerializableExpression serializable, SerializationState state)](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.DecompressTypes.m.md) | Deompress the types on the serializable class. |
| [Expression Deserialize(SerializableExpression root, SerializationState state)](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.Deserialize.m.md) | Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| [SerializableExpression Serialize(Expression expression, SerializationState state)](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.Serialize.m.md) | Serialize to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

# IExpressionSerializer&lt;T, TSerializable> Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > **IExpressionSerializer<T, TSerializable>**

Interface for serialization/deserialization.

```csharp
public interface IExpressionSerializer<T, TSerializable>
   where T : Expression
   where TSerializable : SerializableExpression
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The type of the expression. |
| `TSerializable` | [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) | The type of the serializable expression. |

Derived  [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) ,  [ConstantSerializer](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.cs.md) ,  [ExpressionSerializer](ExpressionPowerTools.Serialization.Serializers.ExpressionSerializer.cs.md) ,  [InvocationSerializer](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.cs.md) ,  [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) ,  [MemberSerializer](ExpressionPowerTools.Serialization.Serializers.MemberSerializer.cs.md) ,  [MethodSerializer](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.cs.md) ,  [NewArraySerializer](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.cs.md) ,  [ParameterSerializer](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.cs.md) ,  [UnarySerializer](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [T Deserialize(JsonElement json, SerializationState state)](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.Deserialize.m.md) | Deserialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| [TSerializable Serialize(T expression, SerializationState state)](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.Serialize.m.md) | Serializes an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a serializable class. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |

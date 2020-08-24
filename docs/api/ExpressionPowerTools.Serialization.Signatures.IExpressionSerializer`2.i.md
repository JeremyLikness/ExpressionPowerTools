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

Derived  [ConstantSerializer](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.cs.md) ,  [ExpressionSerializer](ExpressionPowerTools.Serialization.Serializers.ExpressionSerializer.cs.md) ,  [NewArraySerializer](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.cs.md) ,  [ParameterSerializer](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.cs.md) ,  [UnarySerializer](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [T Deserialize(JsonElement json)](IExpressionSerializer`2-Deserialize.m.md) | Deserialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| [TSerializable Serialize(T expression)](IExpressionSerializer`2-Serialize.m.md) | Serializes an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a serializable class. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

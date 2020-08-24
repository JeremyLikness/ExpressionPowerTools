# IBaseSerializer Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > **IBaseSerializer**

Non-generic interface for serializers.

```csharp
public interface IBaseSerializer
```

Derived  [ConstantSerializer](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.cs.md) ,  [NewArraySerializer](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.cs.md) ,  [ParameterSerializer](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.cs.md) ,  [UnarySerializer](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [Expression Deserialize(JsonElement json)](IBaseSerializer-Deserialize.m.md) | Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| [SerializableExpression Serialize(Expression expression)](IBaseSerializer-Serialize.m.md) | Serialize to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

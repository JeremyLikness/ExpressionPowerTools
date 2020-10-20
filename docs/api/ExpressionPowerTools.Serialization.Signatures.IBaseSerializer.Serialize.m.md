# IBaseSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) > **Serialize**

Serialize to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(Expression expression, SerializationState state)](#serializeexpression-expression-serializationstate-state) | Serialize to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |
## Serialize(Expression expression, SerializationState state)

Serialize to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

```csharp
public virtual SerializableExpression Serialize(Expression expression, SerializationState state)
```

### Return Type

 [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md)  - The [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to serialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

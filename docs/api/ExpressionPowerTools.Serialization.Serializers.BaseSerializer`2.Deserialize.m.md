# BaseSerializer&lt;TExpression, TSerializable>.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [BaseSerializer<TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) > **Deserialize**

Deserialize a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(TSerializable root, SerializationState state)](#deserializetserializable-root-serializationstate-state) | Deserialize a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
## Deserialize(TSerializable root, SerializationState state)

Deserialize a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

```csharp
public virtual TExpression Deserialize(TSerializable root, SerializationState state)
```

### Return Type

TExpression - The deserialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `root` | TSerializable | The [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) to deserialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 18:50:36 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

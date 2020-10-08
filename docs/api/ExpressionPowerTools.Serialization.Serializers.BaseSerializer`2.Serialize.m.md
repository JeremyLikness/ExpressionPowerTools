# BaseSerializer&lt;TExpression, TSerializable>.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [BaseSerializer<TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) > **Serialize**

Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(TExpression expression, SerializationState state)](#serializetexpression-expression-serializationstate-state) | Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |
## Serialize(TExpression expression, SerializationState state)

Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

```csharp
public virtual TSerializable Serialize(TExpression expression, SerializationState state)
```

### Return Type

TSerializable - The [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | TExpression | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to serialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State, such as [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) , for the deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |

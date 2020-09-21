# UnarySerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [UnarySerializer](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.cs.md) > **Serialize**

Serialize a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) to a [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(UnaryExpression expression, SerializationState state)](#serializeunaryexpression-expression-serializationstate-state) | Serialize a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) to a [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) . |
## Serialize(UnaryExpression expression, SerializationState state)

Serialize a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) to a [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) .

```csharp
public virtual Unary Serialize(UnaryExpression expression, SerializationState state)
```

### Return Type

 [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md)  - The [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) | The [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) . |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State, such as [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) , for the serialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/21/2020 19:07:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

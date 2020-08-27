# UnarySerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [UnarySerializer](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.cs.md) > **Serialize**

Serialize a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) to a [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(UnaryExpression expression, JsonSerializerOptions options)](#serializeunaryexpression-expression-jsonserializeroptions-options) | Serialize a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) to a [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) . |
## Serialize(UnaryExpression expression, JsonSerializerOptions options)

Serialize a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) to a [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) .

```csharp
public virtual Unary Serialize(UnaryExpression expression, JsonSerializerOptions options)
```

### Return Type

 [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md)  - The [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) | The [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) . |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

# ExpressionSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ExpressionSerializer](ExpressionPowerTools.Serialization.Serializers.ExpressionSerializer.cs.md) > **Serialize**

Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(Expression expression, JsonSerializerOptions options)](#serializeexpression-expression-jsonserializeroptions-options) | Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
## Serialize(Expression expression, JsonSerializerOptions options)

Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

```csharp
public virtual SerializableExpression Serialize(Expression expression, JsonSerializerOptions options)
```

### Return Type

 [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md)  - The serialized [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to serialize. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

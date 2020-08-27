# UnarySerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [UnarySerializer](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.cs.md) > **Deserialize**

Deserializes a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)](#deserializejsonelement-json-expression-queryroot-jsonserializeroptions-options) | Deserializes a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) . |
## Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)

Deserializes a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) .

```csharp
public virtual UnaryExpression Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)
```

### Return Type

 [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression)  - The [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The serialized fragment. |
| `queryRoot` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The query root to apply. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

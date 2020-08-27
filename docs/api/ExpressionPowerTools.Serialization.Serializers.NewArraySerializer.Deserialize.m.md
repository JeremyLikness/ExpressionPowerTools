# NewArraySerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [NewArraySerializer](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.cs.md) > **Deserialize**

Deserializes a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)](#deserializejsonelement-json-expression-queryroot-jsonserializeroptions-options) | Deserializes a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) . |
## Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)

Deserializes a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) .

```csharp
public virtual NewArrayExpression Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)
```

### Return Type

 [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression)  - The [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) .

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

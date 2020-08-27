# ParameterSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ParameterSerializer](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.cs.md) > **Deserialize**

Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)](#deserializejsonelement-json-expression-queryroot-jsonserializeroptions-options) | Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
## Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)

Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

```csharp
public virtual ParameterExpression Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)
```

### Return Type

 [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression)  - The deserialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

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

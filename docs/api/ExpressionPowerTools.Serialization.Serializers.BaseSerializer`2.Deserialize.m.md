# BaseSerializer&lt;TExpression, TSerializable>.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [BaseSerializer<TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) > **Deserialize**

Deserialize a [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)](#deserializejsonelement-json-expression-queryroot-jsonserializeroptions-options) | Deserialize a [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
## Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)

Deserialize a [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

```csharp
public virtual TExpression Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)
```

### Return Type

TExpression - The deserialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to deserialize. |
| `queryRoot` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The query root to apply. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

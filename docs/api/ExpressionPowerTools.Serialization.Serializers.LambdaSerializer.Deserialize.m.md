# LambdaSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) > **Deserialize**

Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)](#deserializejsonelement-json-expression-queryroot-jsonserializeroptions-options) | Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) . |
## Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)

Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

```csharp
public virtual LambdaExpression Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)
```

### Return Type

 [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression)  - The [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

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

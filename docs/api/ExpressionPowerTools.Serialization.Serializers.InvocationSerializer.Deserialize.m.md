# InvocationSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [InvocationSerializer](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.cs.md) > **Deserialize**

Deserializes a [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)](#deserializejsonelement-json-expression-queryroot-jsonserializeroptions-options) | Deserializes a [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) . |
## Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)

Deserializes a [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) .

```csharp
public virtual InvocationExpression Deserialize(JsonElement json, Expression queryRoot, JsonSerializerOptions options)
```

### Return Type

 [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression)  - The [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) .

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

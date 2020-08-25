# InvocationSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [InvocationSerializer](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.cs.md) > **Deserialize**

Deserializes a [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json)](#deserializejsonelement-json) | Deserializes a [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) . |
## Deserialize(JsonElement json)

Deserializes a [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) .

```csharp
public virtual InvocationExpression Deserialize(JsonElement json)
```

### Return Type

 [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression)  - The [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The serialized fragment. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 5:55:15 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

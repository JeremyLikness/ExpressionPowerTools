# LambdaSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) > **Deserialize**

Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json)](#deserializejsonelement-json) | Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) . |
## Deserialize(JsonElement json)

Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

```csharp
public virtual LambdaExpression Deserialize(JsonElement json)
```

### Return Type

 [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression)  - The [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The serialized fragment. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 5:55:15 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

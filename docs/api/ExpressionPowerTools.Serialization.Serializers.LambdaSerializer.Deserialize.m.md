# LambdaSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) > **Deserialize**

Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json, SerializationState state)](#deserializejsonelement-json-serializationstate-state) | Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) . |
## Deserialize(JsonElement json, SerializationState state)

Deserializes a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

```csharp
public virtual LambdaExpression Deserialize(JsonElement json, SerializationState state)
```

### Return Type

 [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression)  - The [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The serialized fragment. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State, such as [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) , for the deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:02:13 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

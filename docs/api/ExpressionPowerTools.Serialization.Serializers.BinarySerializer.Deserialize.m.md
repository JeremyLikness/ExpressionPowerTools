# BinarySerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [BinarySerializer](ExpressionPowerTools.Serialization.Serializers.BinarySerializer.cs.md) > **Deserialize**

Deserializes a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json, SerializationState state)](#deserializejsonelement-json-serializationstate-state) | Deserializes a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) . |
## Deserialize(JsonElement json, SerializationState state)

Deserializes a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) .

```csharp
public virtual BinaryExpression Deserialize(JsonElement json, SerializationState state)
```

### Return Type

 [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression)  - The [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The serialized fragment. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State, such as [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) , for the deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

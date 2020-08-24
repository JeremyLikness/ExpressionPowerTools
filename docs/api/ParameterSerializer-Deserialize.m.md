# ParameterSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ParameterSerializer](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.cs.md) > **Deserialize**

Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json)](#deserializejsonelement-json) | Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
## Deserialize(JsonElement json)

Deserialize a serializable class to an actionable [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

```csharp
public virtual ParameterExpression Deserialize(JsonElement json)
```

### Return Type

 [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression)  - The deserialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The serialized fragment. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

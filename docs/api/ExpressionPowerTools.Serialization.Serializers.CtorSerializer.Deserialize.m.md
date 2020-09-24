# CtorSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [CtorSerializer](ExpressionPowerTools.Serialization.Serializers.CtorSerializer.cs.md) > **Deserialize**

Deserialize a [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) to a [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json, SerializationState state)](#deserializejsonelement-json-serializationstate-state) | Deserialize a [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) to a [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) . |
## Deserialize(JsonElement json, SerializationState state)

Deserialize a [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) to a [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) .

```csharp
public virtual NewExpression Deserialize(JsonElement json, SerializationState state)
```

### Return Type

 [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression)  - The [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to deserialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State, such as [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) , for the deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:47:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

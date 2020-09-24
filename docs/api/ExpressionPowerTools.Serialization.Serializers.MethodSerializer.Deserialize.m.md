# MethodSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [MethodSerializer](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.cs.md) > **Deserialize**

Deserialize a [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) to a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json, SerializationState state)](#deserializejsonelement-json-serializationstate-state) | Deserialize a [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) to a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) . |
## Deserialize(JsonElement json, SerializationState state)

Deserialize a [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) to a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

```csharp
public virtual MethodCallExpression Deserialize(JsonElement json, SerializationState state)
```

### Return Type

 [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression)  - The [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to deserialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State, such as [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) , for the deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:47:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

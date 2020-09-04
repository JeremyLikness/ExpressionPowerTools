# MemberSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [MemberSerializer](ExpressionPowerTools.Serialization.Serializers.MemberSerializer.cs.md) > **Deserialize**

Deserialize a [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) to a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json, SerializationState state)](#deserializejsonelement-json-serializationstate-state) | Deserialize a [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) to a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) . |
## Deserialize(JsonElement json, SerializationState state)

Deserialize a [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) to a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) .

```csharp
public virtual MemberExpression Deserialize(JsonElement json, SerializationState state)
```

### Return Type

 [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression)  - The [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to deserialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State, such as [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) , for the deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/4/2020 7:10:41 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.5-alpha |

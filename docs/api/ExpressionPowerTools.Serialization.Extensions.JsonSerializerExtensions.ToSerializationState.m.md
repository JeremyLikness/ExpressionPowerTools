# JsonSerializerExtensions.ToSerializationState Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [JsonSerializerExtensions](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.cs.md) > **ToSerializationState**

Cast [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) into the [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) the APIs expect.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ToSerializationState(Expression queryRoot)](#toserializationstateexpression-queryroot) | Cast an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) into the [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) the APIs expect. |
| [ToSerializationState(JsonSerializerOptions options)](#toserializationstatejsonserializeroptions-options) | Cast [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) into the [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) the APIs expect. |
## ToSerializationState(Expression queryRoot)

Cast an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) into the [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) the APIs expect.

```csharp
public static SerializationState ToSerializationState(Expression queryRoot)
```

### Return Type

 [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md)  - The initialized [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) instance.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `queryRoot` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) that is the root fo the query.. |


## ToSerializationState(JsonSerializerOptions options)

Cast [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) into the [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) the APIs expect.

```csharp
public static SerializationState ToSerializationState(JsonSerializerOptions options)
```

### Return Type

 [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md)  - The initialized [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) instance.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

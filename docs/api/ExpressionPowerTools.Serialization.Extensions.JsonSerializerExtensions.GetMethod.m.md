# JsonSerializerExtensions.GetMethod Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [JsonSerializerExtensions](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.cs.md) > **GetMethod**

Gets the method from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetMethod(JsonElement element, SerializationState state)](#getmethodjsonelement-element-serializationstate-state) | Gets the method from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) . |
## GetMethod(JsonElement element, SerializationState state)

Gets the method from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) .

```csharp
public static Method GetMethod(JsonElement element, SerializationState state)
```

### Return Type

 [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md)  - The deserialized [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `element` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to parse. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | The state of serialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/3/2020 10:27:04 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.4-alpha |

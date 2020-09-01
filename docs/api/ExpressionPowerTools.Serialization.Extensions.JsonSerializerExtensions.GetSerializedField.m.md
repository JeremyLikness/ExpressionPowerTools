# JsonSerializerExtensions.GetSerializedField Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [JsonSerializerExtensions](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.cs.md) > **GetSerializedField**

Gets the field from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetSerializedField(JsonElement element, SerializationState state)](#getserializedfieldjsonelement-element-serializationstate-state) | Gets the field from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) . |
## GetSerializedField(JsonElement element, SerializationState state)

Gets the field from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) .

```csharp
public static Field GetSerializedField(JsonElement element, SerializationState state)
```

### Return Type

 [Field](ExpressionPowerTools.Serialization.Serializers.Field.cs.md)  - The deserialized [Field](ExpressionPowerTools.Serialization.Serializers.Field.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `element` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to parse. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | The state of serialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |

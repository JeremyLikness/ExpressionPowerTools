# JsonSerializerExtensions.GetSerializedProperty Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [JsonSerializerExtensions](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.cs.md) > **GetSerializedProperty**

Gets the property from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetSerializedProperty(JsonElement element, SerializationState state)](#getserializedpropertyjsonelement-element-serializationstate-state) | Gets the property from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) . |
## GetSerializedProperty(JsonElement element, SerializationState state)

Gets the property from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) .

```csharp
public static Property GetSerializedProperty(JsonElement element, SerializationState state)
```

### Return Type

 [Property](ExpressionPowerTools.Serialization.Serializers.Property.cs.md)  - The deserialized [Property](ExpressionPowerTools.Serialization.Serializers.Property.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `element` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to parse. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | The state of serialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

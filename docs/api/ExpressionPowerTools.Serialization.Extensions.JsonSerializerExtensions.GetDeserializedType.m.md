# JsonSerializerExtensions.GetDeserializedType Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [JsonSerializerExtensions](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.cs.md) > **GetDeserializedType**

Gets the type, including generic arguments.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetDeserializedType(JsonElement element, SerializationState state)](#getdeserializedtypejsonelement-element-serializationstate-state) | Gets the type, including generic arguments. |
## GetDeserializedType(JsonElement element, SerializationState state)

Gets the type, including generic arguments.

```csharp
public static Type GetDeserializedType(JsonElement element, SerializationState state)
```

### Return Type

 [Type](https://docs.microsoft.com/dotnet/api/system.type)  - The deserialized [Type](https://docs.microsoft.com/dotnet/api/system.type) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `element` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) that contains the type. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | The state for the serialization operation. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/4/2020 7:10:41 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.5-alpha |

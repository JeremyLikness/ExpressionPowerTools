# JsonSerializerExtensions.GetDeserializedType Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [JsonSerializerExtensions](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.cs.md) > **GetDeserializedType**

Gets the type, including generic arguments.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetDeserializedType(JsonElement element)](#getdeserializedtypejsonelement-element) | Gets the type, including generic arguments. |
## GetDeserializedType(JsonElement element)

Gets the type, including generic arguments.

```csharp
public static Type GetDeserializedType(JsonElement element)
```

### Return Type

 [Type](https://docs.microsoft.com/dotnet/api/system.type)  - The deserialized [Type](https://docs.microsoft.com/dotnet/api/system.type) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `element` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) that contains the type. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

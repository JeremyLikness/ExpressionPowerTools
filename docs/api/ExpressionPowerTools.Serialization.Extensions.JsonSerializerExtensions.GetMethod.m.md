# JsonSerializerExtensions.GetMethod Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [JsonSerializerExtensions](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.cs.md) > **GetMethod**

Gets the method from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetMethod(JsonElement element)](#getmethodjsonelement-element) | Gets the method from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) . |
## GetMethod(JsonElement element)

Gets the method from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) .

```csharp
public static Method GetMethod(JsonElement element)
```

### Return Type

 [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md)  - The deserialized [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `element` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to parse. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

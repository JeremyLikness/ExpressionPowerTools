# JsonSerializerExtensions.GetNullableProperty Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [JsonSerializerExtensions](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.cs.md) > **GetNullableProperty**

Safe way to access a property. Returns an element that evaluates to `null` when the underlying property doesn't exist.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetNullableProperty(JsonElement element, String propertyName)](#getnullablepropertyjsonelement-element-string-propertyname) | Safe way to access a property. Returns an element that evaluates to `null` when the underlying property doesn't exist. |
## GetNullableProperty(JsonElement element, String propertyName)

Safe way to access a property. Returns an element that evaluates to `null` when the underlying property doesn't exist.

```csharp
public static JsonElement GetNullableProperty(JsonElement element, String propertyName)
```

### Return Type

 [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement)  - The property node, or a `null` node.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `element` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to inspect. |
| `propertyName` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The name of the property. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |

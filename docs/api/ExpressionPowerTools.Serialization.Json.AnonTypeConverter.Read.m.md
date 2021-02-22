# AnonTypeConverter.Read Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > [AnonTypeConverter](ExpressionPowerTools.Serialization.Json.AnonTypeConverter.cs.md) > **Read**

Reads to deserialize.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)](#readutf8jsonreader&-reader-type-typetoconvert-jsonserializeroptions-options) | Reads to deserialize. |
## Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)

Reads to deserialize.

```csharp
public virtual AnonType Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)
```

### Return Type

 [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md)  - The [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `reader` | [Utf8JsonReader&](https://docs.microsoft.com/dotnet/api/system.text.json.utf8jsonreader&) | The reader. |
| `typeToConvert` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The type of the [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) . |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The options. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

# SerializationRootConverter.Read Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > [SerializationRootConverter](ExpressionPowerTools.Serialization.Json.SerializationRootConverter.cs.md) > **Read**

Reads to deserialize.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)](#readutf8jsonreader&-reader-type-typetoconvert-jsonserializeroptions-options) | Reads to deserialize. |
## Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)

Reads to deserialize.

```csharp
public virtual SerializationRoot Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)
```

### Return Type

 [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md)  - The [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `reader` | [Utf8JsonReader&](https://docs.microsoft.com/dotnet/api/system.text.json.utf8jsonreader&) | The reader. |
| `typeToConvert` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The type of the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) . |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The options. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 18:50:36 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

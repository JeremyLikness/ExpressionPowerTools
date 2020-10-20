# AnonTypeConverter Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > **AnonTypeConverter**

Json handler for [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) .

```csharp
public class AnonTypeConverter : JsonConverter<AnonType>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [JsonConverter](https://docs.microsoft.com/dotnet/api/system.text.json.serialization.jsonconverter) → [JsonConverter&lt;T>](https://docs.microsoft.com/dotnet/api/system.text.json.serialization.jsonconverter-1) → **AnonTypeConverter**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [AnonTypeConverter()](ExpressionPowerTools.Serialization.Json.AnonTypeConverter.ctor.md#anontypeconverter) | Initializes a new instance of the [AnonTypeConverter](ExpressionPowerTools.Serialization.Json.AnonTypeConverter.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`TypeIndex`](ExpressionPowerTools.Serialization.Json.AnonTypeConverter.TypeIndex.prop.md) | [List&lt;String>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the type index. |

## Methods

| Method | Description |
| :-- | :-- |
| [AnonType Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Json.AnonTypeConverter.Read.m.md) | Reads to deserialize. |
| [Void Write(Utf8JsonWriter writer, AnonType value, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Json.AnonTypeConverter.Write.m.md) | Writes the [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 18:50:36 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

# SerializationRootConverter Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > **SerializationRootConverter**

Converter for overall [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) .

```csharp
public class SerializationRootConverter : JsonConverter<SerializationRoot>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [JsonConverter](https://docs.microsoft.com/dotnet/api/system.text.json.serialization.jsonconverter) → [JsonConverter&lt;T>](https://docs.microsoft.com/dotnet/api/system.text.json.serialization.jsonconverter-1) → **SerializationRootConverter**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [SerializationRootConverter(SerializableExpressionConverter converter, AnonTypeConverter anonTypeConverter)](ExpressionPowerTools.Serialization.Json.SerializationRootConverter.ctor.md#serializationrootconverterserializableexpressionconverter-converter-anontypeconverter-anontypeconverter) | Initializes a new instance of the [SerializationRootConverter](ExpressionPowerTools.Serialization.Json.SerializationRootConverter.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [SerializationRoot Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Json.SerializationRootConverter.Read.m.md) | Reads to deserialize. |
| [Void Write(Utf8JsonWriter writer, SerializationRoot value, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Json.SerializationRootConverter.Write.m.md) | Writes the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 5:26:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

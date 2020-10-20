# SerializableExpressionConverter Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > **SerializableExpressionConverter**

Converter writes the type so it can deserialize the derived type.

```csharp
public class SerializableExpressionConverter : JsonConverter<SerializableExpression>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [JsonConverter](https://docs.microsoft.com/dotnet/api/system.text.json.serialization.jsonconverter) → [JsonConverter&lt;T>](https://docs.microsoft.com/dotnet/api/system.text.json.serialization.jsonconverter-1) → **SerializableExpressionConverter**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [SerializableExpressionConverter()](ExpressionPowerTools.Serialization.Json.SerializableExpressionConverter.ctor.md#serializableexpressionconverter) | Initializes a new instance of the [SerializableExpressionConverter](ExpressionPowerTools.Serialization.Json.SerializableExpressionConverter.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`TypeIndex`](ExpressionPowerTools.Serialization.Json.SerializableExpressionConverter.TypeIndex.prop.md) | [List&lt;String>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the type index to decompress types. |

## Methods

| Method | Description |
| :-- | :-- |
| [SerializableExpression Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Json.SerializableExpressionConverter.Read.m.md) | Read a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |
| [Void Write(Utf8JsonWriter writer, SerializableExpression value, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Json.SerializableExpressionConverter.Write.m.md) | Write the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

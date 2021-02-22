# SerializableExpressionConverter.Read Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > [SerializableExpressionConverter](ExpressionPowerTools.Serialization.Json.SerializableExpressionConverter.cs.md) > **Read**

Read a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)](#readutf8jsonreader&-reader-type-typetoconvert-jsonserializeroptions-options) | Read a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |
## Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)

Read a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

```csharp
public virtual SerializableExpression Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)
```

### Return Type

 [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md)  - The serializable expression.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `reader` | [Utf8JsonReader&](https://docs.microsoft.com/dotnet/api/system.text.json.utf8jsonreader&) | The reader. |
| `typeToConvert` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The type. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The options. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

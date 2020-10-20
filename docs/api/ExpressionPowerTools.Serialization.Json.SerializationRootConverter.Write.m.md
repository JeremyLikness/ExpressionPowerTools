# SerializationRootConverter.Write Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > [SerializationRootConverter](ExpressionPowerTools.Serialization.Json.SerializationRootConverter.cs.md) > **Write**

Writes the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Write(Utf8JsonWriter writer, SerializationRoot value, JsonSerializerOptions options)](#writeutf8jsonwriter-writer-serializationroot-value-jsonserializeroptions-options) | Writes the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) . |
## Write(Utf8JsonWriter writer, SerializationRoot value, JsonSerializerOptions options)

Writes the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) .

```csharp
public virtual Void Write(Utf8JsonWriter writer, SerializationRoot value, JsonSerializerOptions options)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `writer` | [Utf8JsonWriter](https://docs.microsoft.com/dotnet/api/system.text.json.utf8jsonwriter) | The writer. |
| `value` | [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) | The [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) to serialize. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The options. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

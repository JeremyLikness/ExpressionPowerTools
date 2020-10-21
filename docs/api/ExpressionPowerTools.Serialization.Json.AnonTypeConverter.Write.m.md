# AnonTypeConverter.Write Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > [AnonTypeConverter](ExpressionPowerTools.Serialization.Json.AnonTypeConverter.cs.md) > **Write**

Writes the [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Write(Utf8JsonWriter writer, AnonType value, JsonSerializerOptions options)](#writeutf8jsonwriter-writer-anontype-value-jsonserializeroptions-options) | Writes the [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) . |
## Write(Utf8JsonWriter writer, AnonType value, JsonSerializerOptions options)

Writes the [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) .

```csharp
public virtual Void Write(Utf8JsonWriter writer, AnonType value, JsonSerializerOptions options)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `writer` | [Utf8JsonWriter](https://docs.microsoft.com/dotnet/api/system.text.json.utf8jsonwriter) | The writer. |
| `value` | [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) | The [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) to serialize. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The options. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

# JsonSerializerExtensions Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > **JsonSerializerExtensions**

Extensions for serialization/deserialization.

```csharp
public static class JsonSerializerExtensions
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **JsonSerializerExtensions**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [static JsonSerializerExtensions()](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.ctor.md#static-jsonserializerextensions) | Initializes a new instance of the [JsonSerializerExtensions](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [JsonElement GetNullableProperty(JsonElement element, String propertyName)](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.GetNullableProperty.m.md) | Safe way to access a property. Returns an element that evaluates to `null` when the underlying property doesn't exist. |
| [SerializationState ToSerializationState(JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.ToSerializationState.m.md) | Cast [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) into the [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) the APIs expect. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:47:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

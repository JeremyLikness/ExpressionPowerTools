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
| [Type GetDeserializedType(JsonElement element, SerializationState state)](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.GetDeserializedType.m.md) | Gets the type, including generic arguments. |
| [Method GetMethod(JsonElement element, SerializationState state)](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.GetMethod.m.md) | Gets the method from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) . |
| [JsonElement GetNullableProperty(JsonElement element, String propertyName)](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.GetNullableProperty.m.md) | Safe way to access a property. Returns an element that evaluates to `null` when the underlying property doesn't exist. |
| [Ctor GetSerializedCtor(JsonElement element, SerializationState state)](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.GetSerializedCtor.m.md) | Gets the field from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) . |
| [Field GetSerializedField(JsonElement element, SerializationState state)](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.GetSerializedField.m.md) | Gets the field from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) . |
| [Property GetSerializedProperty(JsonElement element, SerializationState state)](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.GetSerializedProperty.m.md) | Gets the property from the [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) . |
| [Int32 IndexOfType(IList&lt;SerializableType> typeList, SerializableType type)](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.IndexOfType.m.md) | Gets the index of the [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) in the list. |
| [SerializationState ToSerializationState(JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.ToSerializationState.m.md) | Cast [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) into the [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) the APIs expect. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

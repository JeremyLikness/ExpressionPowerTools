# IConfigurationBuilder.WithJsonSerializerOptions Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md) > **WithJsonSerializerOptions**

Adds the [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to the options.

## Overloads

| Overload | Description |
| :-- | :-- |
| [WithJsonSerializerOptions(JsonSerializerOptions options)](#withjsonserializeroptionsjsonserializeroptions-options) | Adds the [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to the options. |
## WithJsonSerializerOptions(JsonSerializerOptions options)

Adds the [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to the options.

```csharp
public virtual IConfigurationBuilder WithJsonSerializerOptions(JsonSerializerOptions options)
```

### Return Type

 [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md)  - The chainable [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:50:49 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

# IConfigurationBuilder.WithJsonSerializerOptions Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md) > **WithJsonSerializerOptions**

Adds the [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to the options.

## Overloads

| Overload | Description |
| :-- | :-- |
| [WithJsonSerializerOptions(Action&lt;JsonSerializerOptions> options)](#withjsonserializeroptionsactionjsonserializeroptions-options) | Adds the [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to the options. |
## WithJsonSerializerOptions(Action&lt;JsonSerializerOptions> options)

Adds the [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to the options.

```csharp
public virtual IConfigurationBuilder WithJsonSerializerOptions(Action<JsonSerializerOptions> options)
```

### Return Type

 [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md)  - The chainable [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `options` | [Action&lt;JsonSerializerOptions>](https://docs.microsoft.com/dotnet/api/system.action-1) | The default [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

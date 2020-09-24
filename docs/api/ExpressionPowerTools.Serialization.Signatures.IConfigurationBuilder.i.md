# IConfigurationBuilder Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > **IConfigurationBuilder**

Configuration builder for [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) .

```csharp
public interface IConfigurationBuilder
```

Derived  [ConfigurationBuilder](ExpressionPowerTools.Serialization.Configuration.ConfigurationBuilder.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [IConfigurationBuilder CompressTypes(Boolean compressTypes)](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.CompressTypes.m.md) | Sets the flag to indicate whether types should be compressed. |
| [SerializationState Configure()](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.Configure.m.md) | Takes the configuration and returns the serialization state. |
| [IConfigurationBuilder WithJsonSerializerOptions(JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.WithJsonSerializerOptions.m.md) | Adds the [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to the options. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:02:13 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

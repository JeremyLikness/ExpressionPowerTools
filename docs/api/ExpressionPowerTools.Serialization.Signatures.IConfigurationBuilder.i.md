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
| [IConfigurationBuilder CompressExpressionTree(Boolean compressExpressionTree)](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.CompressExpressionTree.m.md) | Sets the flag to indicate whether expression trees should be partially            evaluated so that local variable references aren't serialized. |
| [IConfigurationBuilder CompressTypes(Boolean compressTypes)](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.CompressTypes.m.md) | Sets the flag to indicate whether types should be compressed. |
| [SerializationState Configure()](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.Configure.m.md) | Takes the configuration and returns the serialization state. |
| [IConfigurationBuilder WithJsonSerializerOptions(Action&lt;JsonSerializerOptions> options)](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.WithJsonSerializerOptions.m.md) | Adds the [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) to the options. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

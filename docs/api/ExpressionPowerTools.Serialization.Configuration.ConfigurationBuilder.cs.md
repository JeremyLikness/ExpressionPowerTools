# ConfigurationBuilder Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Configuration](ExpressionPowerTools.Serialization.Configuration.n.md) > **ConfigurationBuilder**

Configuration builder for wiring up configuration fluently.

```csharp
public class ConfigurationBuilder : IConfigurationBuilder
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ConfigurationBuilder**

Implements  [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ConfigurationBuilder()](ExpressionPowerTools.Serialization.Configuration.ConfigurationBuilder.ctor.md#configurationbuilder) | Initializes a new instance of the [ConfigurationBuilder](ExpressionPowerTools.Serialization.Configuration.ConfigurationBuilder.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [IConfigurationBuilder CompressExpressionTree(Boolean compressExpressionTree)](ExpressionPowerTools.Serialization.Configuration.ConfigurationBuilder.CompressExpressionTree.m.md) | Sets the flag to indicate whether expression trees should be partially            evaluated so that local variable references aren't serialized. |
| [IConfigurationBuilder CompressTypes(Boolean compressTypes)](ExpressionPowerTools.Serialization.Configuration.ConfigurationBuilder.CompressTypes.m.md) | Configure the type compression. |
| [SerializationState Configure()](ExpressionPowerTools.Serialization.Configuration.ConfigurationBuilder.Configure.m.md) | Configuration complete. Return the [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) . |
| [IConfigurationBuilder WithJsonSerializerOptions(Action&lt;JsonSerializerOptions> options)](ExpressionPowerTools.Serialization.Configuration.ConfigurationBuilder.WithJsonSerializerOptions.m.md) | Sets the [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |

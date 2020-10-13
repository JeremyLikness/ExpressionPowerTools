# DefaultConfiguration Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Configuration](ExpressionPowerTools.Serialization.Configuration.n.md) > **DefaultConfiguration**

The default configuration used when none is explicitly provided.

```csharp
public class DefaultConfiguration : IDefaultConfiguration
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **DefaultConfiguration**

Implements  [IDefaultConfiguration](ExpressionPowerTools.Serialization.Signatures.IDefaultConfiguration.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [DefaultConfiguration()](ExpressionPowerTools.Serialization.Configuration.DefaultConfiguration.ctor.md#defaultconfiguration) | Initializes a new instance of the [DefaultConfiguration](ExpressionPowerTools.Serialization.Configuration.DefaultConfiguration.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [SerializationState GetDefaultState()](ExpressionPowerTools.Serialization.Configuration.DefaultConfiguration.GetDefaultState.m.md) | Gets a new [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) with default options. |
| [Void SetDefaultState(Action&lt;IConfigurationBuilder> builder)](ExpressionPowerTools.Serialization.Configuration.DefaultConfiguration.SetDefaultState.m.md) | Uses the configuration builder to configure the default state. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

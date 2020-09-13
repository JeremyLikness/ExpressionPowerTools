# Serializer.ConfigureDefaults Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [Serializer](ExpressionPowerTools.Serialization.Serializer.cs.md) > **ConfigureDefaults**

Configure default settings.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ConfigureDefaults(Action&lt;IConfigurationBuilder> config)](#configuredefaultsactioniconfigurationbuilder-config) | Configure default settings. |
## ConfigureDefaults(Action&lt;IConfigurationBuilder> config)

Configure default settings.

```csharp
public static Void ConfigureDefaults(Action<IConfigurationBuilder> config)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `config` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | The configuration builder. |


## Examples

For example:

```csharp

Serializer.ConfigureDefaults(config => config.CompressTypes(false).Configure());
            
```

## Remarks

Will set the global defaults moving forward. Can be called multiple times.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

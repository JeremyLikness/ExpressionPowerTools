﻿# QueryExprSerializer.ConfigureDefaults Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [QueryExprSerializer](ExpressionPowerTools.Serialization.QueryExprSerializer.cs.md) > **ConfigureDefaults**

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
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

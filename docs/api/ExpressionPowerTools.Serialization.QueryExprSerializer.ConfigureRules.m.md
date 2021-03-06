﻿# QueryExprSerializer.ConfigureRules Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [QueryExprSerializer](ExpressionPowerTools.Serialization.QueryExprSerializer.cs.md) > **ConfigureRules**

Configures the rule set for serialization.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ConfigureRules(Action&lt;IRulesConfiguration> rules, Boolean noDefaults)](#configurerulesactionirulesconfiguration-rules-boolean-nodefaults) | Configures the rule set for serialization. |
## ConfigureRules(Action&lt;IRulesConfiguration> rules, Boolean noDefaults)

Configures the rule set for serialization.

```csharp
public static Void ConfigureRules(Action<IRulesConfiguration> rules, Boolean noDefaults)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rules` | [Action&lt;IRulesConfiguration>](https://docs.microsoft.com/dotnet/api/system.action-1) | The [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) to configure rules. |
| `noDefaults` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | A value that indicates whether the default type permissions can be applied. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

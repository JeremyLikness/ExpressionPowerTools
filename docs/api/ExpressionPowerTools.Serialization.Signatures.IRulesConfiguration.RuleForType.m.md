# IRulesConfiguration.RuleForType Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) > **RuleForType**

Set rule for [Type](https://docs.microsoft.com/dotnet/api/system.type) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [RuleForType(Type type)](#rulefortypetype-type) | Set rule for [Type](https://docs.microsoft.com/dotnet/api/system.type) . |
| [RuleForType&lt;T>()](#rulefortypet) | Set rule for [Type](https://docs.microsoft.com/dotnet/api/system.type) . |
## RuleForType(Type type)

Set rule for [Type](https://docs.microsoft.com/dotnet/api/system.type) .

```csharp
public virtual IRulesConfiguration RuleForType(Type type)
```

### Return Type

 [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md)  - The chainable [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `type` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The [Type](https://docs.microsoft.com/dotnet/api/system.type) to opt in. |


## RuleForType&lt;T>()

Set rule for [Type](https://docs.microsoft.com/dotnet/api/system.type) .

```csharp
public virtual IRulesConfiguration RuleForType<T>()
```

### Return Type

 [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md)  - The chainable [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) .



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

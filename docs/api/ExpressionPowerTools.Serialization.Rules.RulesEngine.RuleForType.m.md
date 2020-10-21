# RulesEngine.RuleForType Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Rules](ExpressionPowerTools.Serialization.Rules.n.md) > [RulesEngine](ExpressionPowerTools.Serialization.Rules.RulesEngine.cs.md) > **RuleForType**

Adds the rules for a type.

## Overloads

| Overload | Description |
| :-- | :-- |
| [RuleForType(Type type)](#rulefortypetype-type) | Adds the rules for a type. |
| [RuleForType&lt;T>()](#rulefortypet) | Adds the rules for a type. |
## RuleForType(Type type)

Adds the rules for a type.

```csharp
public virtual IRulesConfiguration RuleForType(Type type)
```

### Return Type

 [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md)  - The [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `type` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The [Type](https://docs.microsoft.com/dotnet/api/system.type) to add. |


## RuleForType&lt;T>()

Adds the rules for a type.

```csharp
public virtual IRulesConfiguration RuleForType<T>()
```

### Return Type

 [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md)  - The [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) .



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

﻿# IRulesEngine Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > **IRulesEngine**

The rules engine.

```csharp
public interface IRulesEngine
```

Derived  [RulesEngine](ExpressionPowerTools.Serialization.Rules.RulesEngine.cs.md) 

## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`AllowAnonymousTypes`](ExpressionPowerTools.Serialization.Signatures.IRulesEngine.AllowAnonymousTypes.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether or not anonymous types are allowed. |

## Methods

| Method | Description |
| :-- | :-- |
| [Void AddRule(ISerializationRule rule)](ExpressionPowerTools.Serialization.Signatures.IRulesEngine.AddRule.m.md) | Add a rule to the engine. |
| [Boolean MemberIsAllowed(MemberInfo member)](ExpressionPowerTools.Serialization.Signatures.IRulesEngine.MemberIsAllowed.m.md) | Checks if a member is allowed. |
| [IList&lt;ValueTuple&lt;String, Boolean>> Reset()](ExpressionPowerTools.Serialization.Signatures.IRulesEngine.Reset.m.md) | Clears the rules, returning a snapshot. |
| [Void Restore(IList&lt;ValueTuple&lt;String, Boolean>> rules)](ExpressionPowerTools.Serialization.Signatures.IRulesEngine.Restore.m.md) | Restores the rules. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

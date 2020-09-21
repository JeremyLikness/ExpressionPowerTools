# IRulesEngine Interface

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
| [Void Reset()](ExpressionPowerTools.Serialization.Signatures.IRulesEngine.Reset.m.md) | Clears the rules. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/21/2020 19:07:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

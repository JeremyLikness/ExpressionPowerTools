# IRulesEngine Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > **IRulesEngine**

The rules engine.

```csharp
public interface IRulesEngine
```

Derived  [RulesEngine](ExpressionPowerTools.Serialization.Rules.RulesEngine.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [Void AddRule(ISerializationRule rule)](ExpressionPowerTools.Serialization.Signatures.IRulesEngine.AddRule.m.md) | Add a rule to the engine. |
| [Void Compile()](ExpressionPowerTools.Serialization.Signatures.IRulesEngine.Compile.m.md) | Compiles the rules for efficiency. |
| [Boolean MemberIsAllowed(MemberInfo member)](ExpressionPowerTools.Serialization.Signatures.IRulesEngine.MemberIsAllowed.m.md) | Checks if a member is allowed. |
| [Void Reset()](ExpressionPowerTools.Serialization.Signatures.IRulesEngine.Reset.m.md) | Clears the rules. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/8/2020 3:10:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.6-alpha |

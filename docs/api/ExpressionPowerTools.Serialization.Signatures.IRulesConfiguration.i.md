# IRulesConfiguration Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > **IRulesConfiguration**

Interface for configuring rules.

```csharp
public interface IRulesConfiguration
```

Derived  [RulesEngine](ExpressionPowerTools.Serialization.Rules.RulesEngine.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [IRulesConfiguration Allow()](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.Allow.m.md) | Allow the rule. |
| [IRulesConfiguration Deny()](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.Deny.m.md) | Deny the rule. |
| [IRulesConfiguration DenyAnonymousTypes()](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.DenyAnonymousTypes.m.md) | Rule to deny anonymous types. |
| [IRulesConfiguration RuleForConstructor(Action&lt;MemberSelector&lt;ConstructorInfo>> selector)](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.RuleForConstructor.m.md) | Rule for a [ConstructorInfo](https://docs.microsoft.com/dotnet/api/system.reflection.constructorinfo) . |
| [IRulesConfiguration RuleForField(Action&lt;MemberSelector&lt;FieldInfo>> selector)](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.RuleForField.m.md) | Rule for a [FieldInfo](https://docs.microsoft.com/dotnet/api/system.reflection.fieldinfo) . |
| [IRulesConfiguration RuleForMethod(Action&lt;MemberSelector&lt;MethodInfo>> selector)](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.RuleForMethod.m.md) | Rule for a [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) . |
| [IRulesConfiguration RuleForProperty(Action&lt;MemberSelector&lt;PropertyInfo>> selector)](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.RuleForProperty.m.md) | Rule for a [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) . |
| [IRulesConfiguration RuleForType(Type type)](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.RuleForType.m.md) | Set rule for [Type](https://docs.microsoft.com/dotnet/api/system.type) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

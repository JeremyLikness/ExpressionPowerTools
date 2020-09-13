# RulesEngine.RuleForMethod Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Rules](ExpressionPowerTools.Serialization.Rules.n.md) > [RulesEngine](ExpressionPowerTools.Serialization.Rules.RulesEngine.cs.md) > **RuleForMethod**

Sets up a method rule.

## Overloads

| Overload | Description |
| :-- | :-- |
| [RuleForMethod(Action&lt;MemberSelector&lt;MethodInfo>> selector)](#ruleformethodactionmemberselectormethodinfo-selector) | Sets up a method rule. |
## RuleForMethod(Action&lt;MemberSelector&lt;MethodInfo>> selector)

Sets up a method rule.

```csharp
public virtual IRulesConfiguration RuleForMethod(Action<MemberSelector<MethodInfo>> selector)
```

### Return Type

 [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md)  - The [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `selector` | [Action&lt;MemberSelector&lt;MethodInfo>>](https://docs.microsoft.com/dotnet/api/system.action-1) | The selector. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

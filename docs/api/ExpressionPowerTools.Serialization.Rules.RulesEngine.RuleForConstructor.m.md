# RulesEngine.RuleForConstructor Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Rules](ExpressionPowerTools.Serialization.Rules.n.md) > [RulesEngine](ExpressionPowerTools.Serialization.Rules.RulesEngine.cs.md) > **RuleForConstructor**

Sets up a constructor rule.

## Overloads

| Overload | Description |
| :-- | :-- |
| [RuleForConstructor(Action&lt;MemberSelector&lt;ConstructorInfo>> selector)](#ruleforconstructoractionmemberselectorconstructorinfo-selector) | Sets up a constructor rule. |
## RuleForConstructor(Action&lt;MemberSelector&lt;ConstructorInfo>> selector)

Sets up a constructor rule.

```csharp
public virtual IRulesConfiguration RuleForConstructor(Action<MemberSelector<ConstructorInfo>> selector)
```

### Return Type

 [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md)  - The [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `selector` | [Action&lt;MemberSelector&lt;ConstructorInfo>>](https://docs.microsoft.com/dotnet/api/system.action-1) | The selector. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:50:49 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

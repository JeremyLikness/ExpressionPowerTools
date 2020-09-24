# IRulesConfiguration.RuleForProperty Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) > **RuleForProperty**

Rule for a [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [RuleForProperty(Action&lt;MemberSelector&lt;PropertyInfo>> selector)](#ruleforpropertyactionmemberselectorpropertyinfo-selector) | Rule for a [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) . |
## RuleForProperty(Action&lt;MemberSelector&lt;PropertyInfo>> selector)

Rule for a [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) .

```csharp
public virtual IRulesConfiguration RuleForProperty(Action<MemberSelector<PropertyInfo>> selector)
```

### Return Type

 [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md)  - The chainable [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `selector` | [Action&lt;MemberSelector&lt;PropertyInfo>>](https://docs.microsoft.com/dotnet/api/system.action-1) | The selector to resolve the property. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:57:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

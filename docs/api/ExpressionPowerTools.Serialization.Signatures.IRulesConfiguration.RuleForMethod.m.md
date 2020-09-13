# IRulesConfiguration.RuleForMethod Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) > **RuleForMethod**

Rule for a [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [RuleForMethod(Action&lt;MemberSelector&lt;MethodInfo>> selector)](#ruleformethodactionmemberselectormethodinfo-selector) | Rule for a [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) . |
## RuleForMethod(Action&lt;MemberSelector&lt;MethodInfo>> selector)

Rule for a [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) .

```csharp
public virtual IRulesConfiguration RuleForMethod(Action<MemberSelector<MethodInfo>> selector)
```

### Return Type

 [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md)  - The chainable [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `selector` | [Action&lt;MemberSelector&lt;MethodInfo>>](https://docs.microsoft.com/dotnet/api/system.action-1) | The selector to resolve the method. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

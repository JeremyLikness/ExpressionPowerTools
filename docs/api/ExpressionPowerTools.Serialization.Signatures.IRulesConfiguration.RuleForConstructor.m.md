# IRulesConfiguration.RuleForConstructor Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) > **RuleForConstructor**

Rule for a [ConstructorInfo](https://docs.microsoft.com/dotnet/api/system.reflection.constructorinfo) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [RuleForConstructor(Action&lt;MemberSelector&lt;ConstructorInfo>> selector)](#ruleforconstructoractionmemberselectorconstructorinfo-selector) | Rule for a [ConstructorInfo](https://docs.microsoft.com/dotnet/api/system.reflection.constructorinfo) . |
## RuleForConstructor(Action&lt;MemberSelector&lt;ConstructorInfo>> selector)

Rule for a [ConstructorInfo](https://docs.microsoft.com/dotnet/api/system.reflection.constructorinfo) .

```csharp
public virtual IRulesConfiguration RuleForConstructor(Action<MemberSelector<ConstructorInfo>> selector)
```

### Return Type

 [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md)  - The chainable [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `selector` | [Action&lt;MemberSelector&lt;ConstructorInfo>>](https://docs.microsoft.com/dotnet/api/system.action-1) | The selector to resolve the constructor. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:26:53 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

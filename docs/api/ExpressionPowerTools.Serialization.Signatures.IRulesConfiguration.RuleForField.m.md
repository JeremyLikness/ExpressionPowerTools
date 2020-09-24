# IRulesConfiguration.RuleForField Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) > **RuleForField**

Rule for a [FieldInfo](https://docs.microsoft.com/dotnet/api/system.reflection.fieldinfo) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [RuleForField(Action&lt;MemberSelector&lt;FieldInfo>> selector)](#ruleforfieldactionmemberselectorfieldinfo-selector) | Rule for a [FieldInfo](https://docs.microsoft.com/dotnet/api/system.reflection.fieldinfo) . |
## RuleForField(Action&lt;MemberSelector&lt;FieldInfo>> selector)

Rule for a [FieldInfo](https://docs.microsoft.com/dotnet/api/system.reflection.fieldinfo) .

```csharp
public virtual IRulesConfiguration RuleForField(Action<MemberSelector<FieldInfo>> selector)
```

### Return Type

 [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md)  - The chainable [IRulesConfiguration](ExpressionPowerTools.Serialization.Signatures.IRulesConfiguration.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `selector` | [Action&lt;MemberSelector&lt;FieldInfo>>](https://docs.microsoft.com/dotnet/api/system.action-1) | The selector to resolve the field. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:02:13 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

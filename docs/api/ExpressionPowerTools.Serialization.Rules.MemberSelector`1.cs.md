# MemberSelector&lt;T> Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Rules](ExpressionPowerTools.Serialization.Rules.n.md) > **MemberSelector<T>**

Helps with selection of a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) .

```csharp
public class MemberSelector<T>
   where T : MemberInfo
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) | The type of [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) . |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **MemberSelector&lt;T>**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [MemberSelector()](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.ctor.md#memberselector) | Initializes a new instance of the [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Member`](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.Member.prop.md) | T[] | Gets or sets the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) . |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

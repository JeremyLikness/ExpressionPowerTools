# SelectorExtensions.ByMemberInfo Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [SelectorExtensions](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.cs.md) > **ByMemberInfo**

Pass the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) directly.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ByMemberInfo&lt;T>(MemberSelector&lt;T> memberSelector, T member)](#bymemberinfotmemberselectort-memberselector-t-member) | Pass the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) directly. |
## ByMemberInfo&lt;T>(MemberSelector&lt;T> memberSelector, T member)

Pass the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) directly.

```csharp
public static Void ByMemberInfo<T>(MemberSelector<T> memberSelector, T member)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `memberSelector` | [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) | The [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) . |
| `member` | T | The [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:57:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

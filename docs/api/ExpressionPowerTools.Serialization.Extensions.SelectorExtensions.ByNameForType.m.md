# SelectorExtensions.ByNameForType Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [SelectorExtensions](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.cs.md) > **ByNameForType**

Pass the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using name on [Type](https://docs.microsoft.com/dotnet/api/system.type) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [ByNameForType&lt;T, TTarget>(MemberSelector&lt;T> memberSelector, String memberName)](#bynamefortypet-ttargetmemberselectort-memberselector-string-membername) | Gets the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using            the name for the [Type](https://docs.microsoft.com/dotnet/api/system.type) . |
| [ByNameForType&lt;T>(MemberSelector&lt;T> memberSelector, Type type, String memberName)](#bynamefortypetmemberselectort-memberselector-type-type-string-membername) | Pass the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using name on [Type](https://docs.microsoft.com/dotnet/api/system.type) . |
## ByNameForType&lt;T, TTarget>(MemberSelector&lt;T> memberSelector, String memberName)

Gets the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using
            the name for the [Type](https://docs.microsoft.com/dotnet/api/system.type) .

```csharp
public static Void ByNameForType<T, TTarget>(MemberSelector<T> memberSelector, String memberName)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `memberSelector` | [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) | The [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) . |
| `memberName` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The name of the member. |


## ByNameForType&lt;T>(MemberSelector&lt;T> memberSelector, Type type, String memberName)

Pass the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using name on [Type](https://docs.microsoft.com/dotnet/api/system.type) .

```csharp
public static Void ByNameForType<T>(MemberSelector<T> memberSelector, Type type, String memberName)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `memberSelector` | [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) | The [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) . |
| `type` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The [Type](https://docs.microsoft.com/dotnet/api/system.type) the member is on. |
| `memberName` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The name of the member. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |

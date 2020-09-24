# SelectorExtensions Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > **SelectorExtensions**

Extensions for selecting [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) .

```csharp
public static class SelectorExtensions
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **SelectorExtensions**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [static SelectorExtensions()](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.ctor.md#static-selectorextensions) | Initializes a new instance of the [SelectorExtensions](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Void ByMemberInfo&lt;T>(MemberSelector&lt;T> memberSelector, T member)](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.ByMemberInfo.m.md) | Pass the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) directly. |
| [Void ByNameForType&lt;T>(MemberSelector&lt;T> memberSelector, Type type, String memberName)](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.ByNameForType.m.md) | Pass the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using name on [Type](https://docs.microsoft.com/dotnet/api/system.type) . |
| [Void ByResolver&lt;T, TTarget>(MemberSelector&lt;T> memberSelector, Expression&lt;Func&lt;TTarget, Object>> resolver)](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.ByResolver.m.md) | Gets the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using a lambda expression            as a template. The lambda is never invoked and is inspected            to find the matching type. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:47:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

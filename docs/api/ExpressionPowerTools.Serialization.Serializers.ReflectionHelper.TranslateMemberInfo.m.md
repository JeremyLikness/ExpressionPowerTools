# ReflectionHelper.TranslateMemberInfo Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) > **TranslateMemberInfo**

Translates a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) to a [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [TranslateMemberInfo(MemberInfo member)](#translatememberinfomemberinfo-member) | Translates a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) to a [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) . |
## TranslateMemberInfo(MemberInfo member)

Translates a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) to a [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) .

```csharp
public virtual MemberBase TranslateMemberInfo(MemberInfo member)
```

### Return Type

 [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md)  - The [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) | The [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) to translate. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

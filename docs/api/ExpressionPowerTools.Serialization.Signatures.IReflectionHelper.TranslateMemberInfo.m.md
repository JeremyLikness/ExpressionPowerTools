# IReflectionHelper.TranslateMemberInfo Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IReflectionHelper](ExpressionPowerTools.Serialization.Signatures.IReflectionHelper.i.md) > **TranslateMemberInfo**

Translates a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) to the [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) derived type.

## Overloads

| Overload | Description |
| :-- | :-- |
| [TranslateMemberInfo(MemberInfo member)](#translatememberinfomemberinfo-member) | Translates a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) to the [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) derived type. |
## TranslateMemberInfo(MemberInfo member)

Translates a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) to the [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) derived type.

```csharp
public virtual MemberBase TranslateMemberInfo(MemberInfo member)
```

### Return Type

 [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md)  - The [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) | The [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) to transform. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |

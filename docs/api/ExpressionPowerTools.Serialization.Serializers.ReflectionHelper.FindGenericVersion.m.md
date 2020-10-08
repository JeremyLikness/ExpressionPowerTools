# ReflectionHelper.FindGenericVersion Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) > **FindGenericVersion**

Finds the generic counterpart of a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [FindGenericVersion(MemberInfo member, Type genericType)](#findgenericversionmemberinfo-member-type-generictype) | Finds the generic counterpart of a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) . |
## FindGenericVersion(MemberInfo member, Type genericType)

Finds the generic counterpart of a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) .

```csharp
public virtual MemberInfo FindGenericVersion(MemberInfo member, Type genericType)
```

### Return Type

 [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo)  - The correleated member.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) | The [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) to check. |
| `genericType` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The generic [Type](https://docs.microsoft.com/dotnet/api/system.type) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

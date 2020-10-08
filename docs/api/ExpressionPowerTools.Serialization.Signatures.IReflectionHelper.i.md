# IReflectionHelper Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > **IReflectionHelper**

Helper class to cache [Type](https://docs.microsoft.com/dotnet/api/system.type) and [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) information.

```csharp
public interface IReflectionHelper
```

Derived  [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) 

## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`AllPublic`](ExpressionPowerTools.Serialization.Signatures.IReflectionHelper.AllPublic.prop.md) | [BindingFlags](https://docs.microsoft.com/dotnet/api/system.reflection.bindingflags) | Gets the [BindingFlags](https://docs.microsoft.com/dotnet/api/system.reflection.bindingflags) for public instance or static. |

## Methods

| Method | Description |
| :-- | :-- |
| [MemberInfo FindGenericVersion(MemberInfo member, Type genericType)](ExpressionPowerTools.Serialization.Signatures.IReflectionHelper.FindGenericVersion.m.md) | Finds the generic counterpart of a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

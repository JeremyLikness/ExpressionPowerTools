# ReflectionHelper Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **ReflectionHelper**

Helper class to cache [Type](https://docs.microsoft.com/dotnet/api/system.type) and [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) information.

```csharp
public class ReflectionHelper : IReflectionHelper
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ReflectionHelper**

Implements  [IReflectionHelper](ExpressionPowerTools.Serialization.Signatures.IReflectionHelper.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ReflectionHelper()](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.ctor.md#reflectionhelper) | Initializes a new instance of the [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`AllPublic`](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.AllPublic.prop.md) | [BindingFlags](https://docs.microsoft.com/dotnet/api/system.reflection.bindingflags) | Gets the [BindingFlags](https://docs.microsoft.com/dotnet/api/system.reflection.bindingflags) for public instance and static. |

## Methods

| Method | Description |
| :-- | :-- |
| [MemberInfo FindGenericVersion(MemberInfo member, Type genericType)](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.FindGenericVersion.m.md) | Finds the generic counterpart of a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |

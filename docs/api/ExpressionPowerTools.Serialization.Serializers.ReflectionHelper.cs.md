# ReflectionHelper Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **ReflectionHelper**

Helper class to cache [Type](https://docs.microsoft.com/dotnet/api/system.type) and [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) information.

```csharp
public class ReflectionHelper
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ReflectionHelper**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ReflectionHelper()](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.ctor.md#reflectionhelper) | Initializes a new instance of the [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) class. |
| [static ReflectionHelper()](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.ctor.md#static-reflectionhelper) | Initializes a new instance of the [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Instance`](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.Instance.prop.md) | [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) | Gets the static instance. |

## Methods

| Method | Description |
| :-- | :-- |
| [MethodInfo GetMethodFromCache(Method method)](ReflectionHelper-GetMethodFromCache.m.md) | Gets the [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) based on the hash computed            by the [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) signature. |
| [Type GetTypeFromCache(String name)](ReflectionHelper-GetTypeFromCache.m.md) | Get a [Type](https://docs.microsoft.com/dotnet/api/system.type) based on full name. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/23/2020 9:59:26 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

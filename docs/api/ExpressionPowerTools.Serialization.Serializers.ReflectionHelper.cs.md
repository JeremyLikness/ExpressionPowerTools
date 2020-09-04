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
## Methods

| Method | Description |
| :-- | :-- |
| [Type DeserializeType(SerializableType serializedType)](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.DeserializeType.m.md) | Deserializes a [Type](https://docs.microsoft.com/dotnet/api/system.type) . |
| [String GetFullTypeName(SerializableType serializedType, StringBuilder builder, Int32 level)](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.GetFullTypeName.m.md) | Gets the full type name of the serialized type. |
| [TMemberInfo GetMemberFromCache&lt;TMemberInfo, TMemberBase>(TMemberBase member)](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.GetMemberFromCache.m.md) | Gets the specified member. Will add to cache if not found. |
| [Type GetTypeFromCache(String name)](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.GetTypeFromCache.m.md) | Get a [Type](https://docs.microsoft.com/dotnet/api/system.type) based on full name. |
| [Void RegisterTypes(Type[] typeList)](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.RegisterTypes.m.md) | Pre-register types to the cache to improve discoverability. |
| [SerializableType SerializeType(Type type)](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.SerializeType.m.md) | Creates a serializable type. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/4/2020 7:10:41 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.5-alpha |

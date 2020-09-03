# IReflectionHelper Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > **IReflectionHelper**

Helper class to cache [Type](https://docs.microsoft.com/dotnet/api/system.type) and [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) information.

```csharp
public interface IReflectionHelper
```

Derived  [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [Type DeserializeType(SerializableType serializedType)](ExpressionPowerTools.Serialization.Signatures.IReflectionHelper.DeserializeType.m.md) | Deserializes a [Type](https://docs.microsoft.com/dotnet/api/system.type) . |
| [String GetFullTypeName(SerializableType serializedType, StringBuilder builder, Int32 level)](ExpressionPowerTools.Serialization.Signatures.IReflectionHelper.GetFullTypeName.m.md) | Gets the full type name of the serialized type. |
| [TMemberInfo GetMemberFromCache&lt;TMemberInfo, TMemberBase>(TMemberBase member)](ExpressionPowerTools.Serialization.Signatures.IReflectionHelper.GetMemberFromCache.m.md) | Gets the specified member. Will add to cache if not found. |
| [Type GetTypeFromCache(String name)](ExpressionPowerTools.Serialization.Signatures.IReflectionHelper.GetTypeFromCache.m.md) | Get a [Type](https://docs.microsoft.com/dotnet/api/system.type) based on full name. |
| [Void RegisterTypes(Type[] typeList)](ExpressionPowerTools.Serialization.Signatures.IReflectionHelper.RegisterTypes.m.md) | Pre-register types to the cache to improve discoverability. |
| [SerializableType SerializeType(Type type)](ExpressionPowerTools.Serialization.Signatures.IReflectionHelper.SerializeType.m.md) | Creates a serializable type. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/3/2020 10:27:04 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.4-alpha |

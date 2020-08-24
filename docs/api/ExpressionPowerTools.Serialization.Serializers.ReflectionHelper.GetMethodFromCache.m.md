# ReflectionHelper.GetMethodFromCache Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) > **GetMethodFromCache**

Gets the [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) based on the hash computed
            by the [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) signature.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetMethodFromCache(Method method)](#getmethodfromcachemethod-method) | Gets the [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) based on the hash computed            by the [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) signature. |
## GetMethodFromCache(Method method)

Gets the [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) based on the hash computed
            by the [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) signature.

```csharp
public MethodInfo GetMethodFromCache(Method method)
```

### Return Type

 [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo)  - The [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `method` | [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) | The [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) template to use. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 11:34:48 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

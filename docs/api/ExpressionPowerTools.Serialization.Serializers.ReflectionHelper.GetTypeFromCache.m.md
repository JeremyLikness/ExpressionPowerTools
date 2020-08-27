# ReflectionHelper.GetTypeFromCache Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) > **GetTypeFromCache**

Get a [Type](https://docs.microsoft.com/dotnet/api/system.type) based on full name.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetTypeFromCache(String name)](#gettypefromcachestring-name) | Get a [Type](https://docs.microsoft.com/dotnet/api/system.type) based on full name. |
## GetTypeFromCache(String name)

Get a [Type](https://docs.microsoft.com/dotnet/api/system.type) based on full name.

```csharp
public Type GetTypeFromCache(String name)
```

### Return Type

 [Type](https://docs.microsoft.com/dotnet/api/system.type)  - The [Type](https://docs.microsoft.com/dotnet/api/system.type) or `null` .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `name` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The full name of the [Type](https://docs.microsoft.com/dotnet/api/system.type) . |


## Remarks

This will check the cache first, then try to create the type, and
            finally will scan all assemblies for the type.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

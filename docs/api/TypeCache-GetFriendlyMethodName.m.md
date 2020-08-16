﻿# TypeCache.GetFriendlyMethodName Method

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.n.md) > [TypeCache](ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy.TypeCache.cs.md) > **GetFriendlyMethodName**

Gets the friendly (with generic parameters) name for the method.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetFriendlyMethodName(MethodInfo method)](#getfriendlymethodnamemethodinfo-method) | Gets the friendly (with generic parameters) name for the method. |
## GetFriendlyMethodName(MethodInfo method)

Gets the friendly (with generic parameters) name for the method.

```csharp
public String GetFriendlyMethodName(MethodInfo method)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The friendly type name.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `method` | [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) | The [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) to parse. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/16/2020 4:18:46 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
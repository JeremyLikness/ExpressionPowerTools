﻿# IServices.GetService Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > [IServices](ExpressionPowerTools.Core.Signatures.IServices.i.md) > **GetService**

Gets a configured service.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetService&lt;T>(Object[] parameters)](#getservicetobject[]-parameters) | Gets a configured service. |
## GetService&lt;T>(Object[] parameters)

Gets a configured service.

```csharp
public virtual T GetService<T>(Object[] parameters)
```

### Return Type

T - The service instance.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `parameters` | [Object[]](https://docs.microsoft.com/dotnet/api/system.object[]) | List of parameters. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [InvalidOperationException](https://docs.microsoft.com/dotnet/api/system.invalidoperationexception) | Throws when service not found. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/16/2020 4:18:46 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
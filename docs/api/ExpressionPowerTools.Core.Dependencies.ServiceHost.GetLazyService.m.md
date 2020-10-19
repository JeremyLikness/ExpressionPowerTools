# ServiceHost.GetLazyService Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > [ServiceHost](ExpressionPowerTools.Core.Dependencies.ServiceHost.cs.md) > **GetLazyService**

Gets a lazy loaded service.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetLazyService&lt;T>(Object[] parameters)](#getlazyservicetobject[]-parameters) | Gets a lazy loaded service. |
## GetLazyService&lt;T>(Object[] parameters)

Gets a lazy loaded service.

```csharp
public static Lazy<T> GetLazyService<T>(Object[] parameters)
```

### Return Type

 [Lazy&lt;T>](https://docs.microsoft.com/dotnet/api/system.lazy-1)  - The lazy intialization for the service.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `parameters` | [Object[]](https://docs.microsoft.com/dotnet/api/system.object) | The parameters. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |

# ExpressionPowerToolsEFCoreMiddleware.Invoke Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.n.md) > [ExpressionPowerToolsEFCoreMiddleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.ExpressionPowerToolsEFCoreMiddleware.cs.md) > **Invoke**

The main invocation of the middleware component.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Invoke(HttpContext httpContext, IServiceProvider provider)](#invokehttpcontext-httpcontext-iserviceprovider-provider) | The main invocation of the middleware component. |
## Invoke(HttpContext httpContext, IServiceProvider provider)

The main invocation of the middleware component.

```csharp
public Task Invoke(HttpContext httpContext, IServiceProvider provider)
```

### Return Type

 [Task](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task)  - A [Task](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task) representing the result of the asynchronous operation.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `httpContext` | [HttpContext](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext) | The [HttpContext](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext) in the pipeline. |
| `provider` | [IServiceProvider](https://docs.microsoft.com/dotnet/api/system.iserviceprovider) | The [IServiceProvider](https://docs.microsoft.com/dotnet/api/system.iserviceprovider) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

# Services.RegisterServices Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > [Services](ExpressionPowerTools.Core.Dependencies.Services.cs.md) > **RegisterServices**

Register multiple services and call configured.

## Overloads

| Overload | Description |
| :-- | :-- |
| [RegisterServices(Action&lt;IServiceRegistration> register)](#registerservicesactioniserviceregistration-register) | Register multiple services and call configured. |
## RegisterServices(Action&lt;IServiceRegistration> register)

Register multiple services and call configured.

```csharp
public virtual Void RegisterServices(Action<IServiceRegistration> register)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `register` | [Action&lt;IServiceRegistration>](https://docs.microsoft.com/dotnet/api/system.action-1) | The action to register. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/20/2020 6:23:17 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

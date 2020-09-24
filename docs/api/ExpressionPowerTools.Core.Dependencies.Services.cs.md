# Services Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > **Services**

Container for services.

```csharp
public class Services : IServices, IServiceRegistration
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **Services**

Implements  [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md) ,  [IServices](ExpressionPowerTools.Core.Signatures.IServices.i.md) 

## Remarks

Use the register overloads to register services. Call [ExpressionPowerTools.Core.Dependencies.Services.Configured](https://docs.microsoft.com/dotnet/api/ExpressionPowerTools.Core.Dependencies.Services.Configured) when done setting up and
            before attempting to retrieve other instances.

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Services()](ExpressionPowerTools.Core.Dependencies.Services.ctor.md#services) | Initializes a new instance of the [Services](ExpressionPowerTools.Core.Dependencies.Services.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [T GetService&lt;T>(Object[] parameters)](ExpressionPowerTools.Core.Dependencies.Services.GetService.m.md) | Get a service based on registration. |
| [IServiceRegistration Register&lt;T, TImpl>()](ExpressionPowerTools.Core.Dependencies.Services.Register.m.md) | Register a service. |
| [IServiceRegistration RegisterGeneric(Type signature, Type implementation)](ExpressionPowerTools.Core.Dependencies.Services.RegisterGeneric.m.md) | Register a generic service. |
| [Void RegisterServices(Action&lt;IServiceRegistration> register)](ExpressionPowerTools.Core.Dependencies.Services.RegisterServices.m.md) | Register multiple services and call configured. |
| [IServiceRegistration RegisterSingleton&lt;T>(T instance)](ExpressionPowerTools.Core.Dependencies.Services.RegisterSingleton.m.md) | Register a singleton to satisfy a type request. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:26:53 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

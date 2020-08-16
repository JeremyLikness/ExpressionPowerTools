# Services Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > **Services**

Container for services. Can be configured to use [IServiceProvider](https://docs.microsoft.com/dotnet/api/system.iserviceprovider) for certain types.

```csharp
public class Services : IServices, IServiceRegistration
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **Services**

Implements  [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md) ,  [IServices](ExpressionPowerTools.Core.Signatures.IServices.i.md) 

## Remarks

Use the register overloads to register services. Callwhen done setting up and
            before attempting to retrieve other instances.

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Services()](ExpressionPowerTools.Core.Dependencies.Services.ctor.md#services) | Initializes a new instance of the [Services](ExpressionPowerTools.Core.Dependencies.Services.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [T GetService&lt;T>(Object[] parameters)](Services-GetService.m.md) | Get a service based on registration. |
| [IServiceRegistration Register&lt;T, TImpl>()](Services-Register.m.md) | Register a service. |
| [IServiceRegistration RegisterGeneric(Type signature, Type implementation)](Services-RegisterGeneric.m.md) | Register a generic service. |
| [Void RegisterServices(Action&lt;IServiceRegistration> register)](Services-RegisterServices.m.md) | Register multiple services and call configured. |
| [IServiceRegistration RegisterSingleton&lt;T>(T instance)](Services-RegisterSingleton.m.md) | Register a singleton to satisfy a type request. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/15/2020 12:36:00 AM | (c) Copyright 2020 Jeremy Likness. | **v0.1.0.0** |

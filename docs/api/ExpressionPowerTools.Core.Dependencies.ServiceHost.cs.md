﻿# ServiceHost Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > **ServiceHost**

Host to obtain services.

```csharp
public static class ServiceHost
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ServiceHost**

## Examples

To register a type `MyType` that implements `IMyType` :

```csharp
ServiceHost.Initialize(register => register.Register<IMyType, MyType>());
            
```

To register a singleton:

```csharp
var singleton = new MyType();
            ServiceHost.Initialize(register => register.RegisterSingleton<IMyType>(singleton);
            
```

To register a generic type `IGenericType<T>` that is implemented by `GenericType<T>` :

```csharp
ServiceHost.Initialize(register =>
                register.RegisterGeneric(typeof(IGenericType<>), typeof(GenericType<>)));
            
```

To retrieve a service:

```csharp
var implementation = ServiceHost.GetService<IMyType>();
            
```

Retrieving a generic service (closed) with parameters:

```csharp
var implementation = ServiceHost.GetService<IGenericType<string>>(5, 6);
            
```

## Remarks

This is a very simple dependency injection container. It allows registration
            of type implementations, generic implementations, and singletons. It does not
            recursively resolve dependencies. Registration happens in the call toand can only be done once.is provided mainly for testing purposes.

Satellite assemblies can hook into the registration by implementing [IDependentServiceRegistration](ExpressionPowerTools.Core.Signatures.IDependentServiceRegistration.i.md) . This is
            scanned and loaded before user overridees. Services can be lazy-loaded by using themethod.

The [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md) provided by initialization is chainable (each call returns itself).

## Constructors

| Ctor | Description |
| :-- | :-- |
| [static ServiceHost()](ExpressionPowerTools.Core.Dependencies.ServiceHost.ctor.md#static-servicehost) | Initializes static members of the [ServiceHost](ExpressionPowerTools.Core.Dependencies.ServiceHost.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Lazy&lt;T> GetLazyService&lt;T>(Object[] parameters)](ExpressionPowerTools.Core.Dependencies.ServiceHost.GetLazyService.m.md) | Gets a lazy loaded service. |
| [T GetService&lt;T>(Object[] parameters)](ExpressionPowerTools.Core.Dependencies.ServiceHost.GetService.m.md) | Get the service implementation. |
| [Void Initialize(Action&lt;IServiceRegistration> registration)](ExpressionPowerTools.Core.Dependencies.ServiceHost.Initialize.m.md) | Initialize the container. Can only be done once unlessis called. |
| [Void Reset()](ExpressionPowerTools.Core.Dependencies.ServiceHost.Reset.m.md) | Reset to new services instance. |
| [IList&lt;Type> SafeGetTypes(Predicate&lt;Type> filter)](ExpressionPowerTools.Core.Dependencies.ServiceHost.SafeGetTypes.m.md) | Safely enumerate types across loaded assemblies. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

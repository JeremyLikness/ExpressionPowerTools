# ServiceHost Class

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > **ServiceHost**

Host to obtain services.

```csharp
public static class ServiceHost
```

Inheritance [System.Object](https://docs.microsoft.com/dotnet/api/system.object) → **ServiceHost**

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

To retrive a service:

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

The [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md) provided by initialization is chainable (each call returns itself).


# Services Class

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > **Services**

Container for services. Can be configured to use [System.IServiceProvider](https://docs.microsoft.com/dotnet/api/system.iserviceprovider) for certain types.

```csharp
public class Services : IServices, IServiceRegistration
```

Inheritance [System.Object](https://docs.microsoft.com/dotnet/api/system.object) → **Services**

Implements  [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md) ,  [IServices](ExpressionPowerTools.Core.Signatures.IServices.i.md) 

## Remarks

Use the register overloads to register services. Callwhen done setting up and
            before attempting to retrieve other instances.

# Constructors

| Ctor | Description |
| :-- | :-- |
| [Services()](ExpressionPowerTools.Core.Dependencies.Services.ctor.md#ctor-0) | Initializes a new instance of the  [Services](ExpressionPowerTools.Core.Dependencies.Services.cs.md)  class. |

# Services Class

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > **Services**

Container for services. Can be configured to use [IServiceProvider](https://docs.microsoft.com/dotnet/api/system.iserviceprovider) for certain types.

```csharp
public class Services : IServices, IServiceRegistration
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **Services**

Implements  [IServices](ExpressionPowerTools.Core.Signatures.IServices.i.md) ,  [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md) 

## Remarks

Use the register overloads to register services. Callwhen done setting up and
            before attempting to retrieve other instances.

## Examples


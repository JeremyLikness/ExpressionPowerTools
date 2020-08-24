# Services Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > **Services**



```csharp
public class Services : IServices, IServiceRegistration
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **Services**

Implements  [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md) ,  [IServices](ExpressionPowerTools.Core.Signatures.IServices.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Services()](ExpressionPowerTools.Core.Dependencies.Services.ctor.md#services) |  |
## Methods

| Method | Description |
| :-- | :-- |
| [T GetService&lt;T>(Object[] parameters)](Services-GetService.m.md) |  |
| [IServiceRegistration Register&lt;T, TImpl>()](Services-Register.m.md) |  |
| [IServiceRegistration RegisterGeneric(Type signature, Type implementation)](Services-RegisterGeneric.m.md) |  |
| [Void RegisterServices(Action&lt;IServiceRegistration> register)](Services-RegisterServices.m.md) |  |
| [IServiceRegistration RegisterSingleton&lt;T>(T instance)](Services-RegisterSingleton.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

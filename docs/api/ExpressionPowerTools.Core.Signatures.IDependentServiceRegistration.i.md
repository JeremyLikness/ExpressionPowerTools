# IDependentServiceRegistration Interface

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IDependentServiceRegistration**

Interface to implement in other projects that will plug into the registration
            pipeline for dependency injection.

```csharp
public interface IDependentServiceRegistration
```

## Methods

| Method | Description |
| :-- | :-- |
| [Void AfterRegistered()](ExpressionPowerTools.Core.Signatures.IDependentServiceRegistration.AfterRegistered.m.md) | Called after registration is complete. |
| [Void RegisterDefaultServices(IServiceRegistration registration)](ExpressionPowerTools.Core.Signatures.IDependentServiceRegistration.RegisterDefaultServices.m.md) | Implement to register default services. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

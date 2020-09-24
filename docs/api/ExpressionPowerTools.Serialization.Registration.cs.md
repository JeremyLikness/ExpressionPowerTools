# Registration Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > **Registration**

Registration of services for serialization.

```csharp
public class Registration : IDependentServiceRegistration
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **Registration**

Implements  [IDependentServiceRegistration](ExpressionPowerTools.Core.Signatures.IDependentServiceRegistration.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Registration()](ExpressionPowerTools.Serialization.Registration.ctor.md#registration) | Initializes a new instance of the [Registration](ExpressionPowerTools.Serialization.Registration.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Void AfterRegistered()](ExpressionPowerTools.Serialization.Registration.AfterRegistered.m.md) | Adds default "safe" rules for serialization. |
| [Void RegisterDefaultRules(IRulesConfiguration rules)](ExpressionPowerTools.Serialization.Registration.RegisterDefaultRules.m.md) | Registers the default rules. |
| [Void RegisterDefaultServices(IServiceRegistration registration)](ExpressionPowerTools.Serialization.Registration.RegisterDefaultServices.m.md) | Registers the services used by serialization. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:50:49 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

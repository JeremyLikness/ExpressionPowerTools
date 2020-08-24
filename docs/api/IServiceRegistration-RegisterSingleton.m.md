# IServiceRegistration.RegisterSingleton Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md) > **RegisterSingleton**

Register a service with two parameters.

## Overloads

| Overload | Description |
| :-- | :-- |
| [RegisterSingleton&lt;T>(T instance)](#registersingletontt-instance) | Register a service with two parameters. |
## RegisterSingleton&lt;T>(T instance)

Register a service with two parameters.

```csharp
public virtual IServiceRegistration RegisterSingleton<T>(T instance)
```

### Return Type

 [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md)  - The [IServices](ExpressionPowerTools.Core.Signatures.IServices.i.md) for chaining.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `instance` | T | The singleton to register. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 8:28:46 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

# Services.RegisterSingleton Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > [Services](ExpressionPowerTools.Core.Dependencies.Services.cs.md) > **RegisterSingleton**

Register a singleton to satisfy a type request.

## Overloads

| Overload | Description |
| :-- | :-- |
| [RegisterSingleton&lt;T>(T instance)](#registersingletontt-instance) | Register a singleton to satisfy a type request. |
## RegisterSingleton&lt;T>(T instance)

Register a singleton to satisfy a type request.

```csharp
public virtual IServiceRegistration RegisterSingleton<T>(T instance)
```

### Return Type

 [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md)  - The [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md) for chaining.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `instance` | T | The singleton. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

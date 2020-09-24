# Services.RegisterGeneric Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > [Services](ExpressionPowerTools.Core.Dependencies.Services.cs.md) > **RegisterGeneric**

Register a generic service.

## Overloads

| Overload | Description |
| :-- | :-- |
| [RegisterGeneric(Type signature, Type implementation)](#registergenerictype-signature-type-implementation) | Register a generic service. |
## RegisterGeneric(Type signature, Type implementation)

Register a generic service.

```csharp
public virtual IServiceRegistration RegisterGeneric(Type signature, Type implementation)
```

### Return Type

 [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md)  - An [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md) for chaining.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `signature` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The signature type. |
| `implementation` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The implementation type. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:47:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

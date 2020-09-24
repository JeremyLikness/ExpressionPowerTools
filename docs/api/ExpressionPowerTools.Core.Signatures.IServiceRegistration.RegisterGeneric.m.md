# IServiceRegistration.RegisterGeneric Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md) > **RegisterGeneric**

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

 [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md)  - The [IServices](ExpressionPowerTools.Core.Signatures.IServices.i.md) for chaining.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `signature` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The interface or base type of the registration. |
| `implementation` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The implementation. |


## Examples

For example:

```csharp
registration.RegisterGeneric(typeof(IQueryHost<,>), typeof(QueryHost<,>));
            var target = source.GetService<IQueryHost<IdType, ICustomQueryProvider<IdType>>>(
                query.Expression, provider);
            
```

## Remarks

To register a generic type, register the open type descriptor and the open
            implementation. Request the typed implementation.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:50:49 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

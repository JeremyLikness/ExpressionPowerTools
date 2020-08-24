# ServiceHost.Initialize Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > [ServiceHost](ExpressionPowerTools.Core.Dependencies.ServiceHost.cs.md) > **Initialize**

Initialize the container. Can only be done once unlessis called.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Initialize(Action&lt;IServiceRegistration> registration)](#initializeactioniserviceregistration-registration) | Initialize the container. Can only be done once unlessis called. |
## Initialize(Action&lt;IServiceRegistration> registration)

Initialize the container. Can only be done once unlessis called.

```csharp
public static Void Initialize(Action<IServiceRegistration> registration)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `registration` | [Action&lt;IServiceRegistration>](https://docs.microsoft.com/dotnet/api/system.action-1) | The registration callback. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 11:34:48 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

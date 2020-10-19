# ServiceHost.SafeGetTypes Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Dependencies](ExpressionPowerTools.Core.Dependencies.n.md) > [ServiceHost](ExpressionPowerTools.Core.Dependencies.ServiceHost.cs.md) > **SafeGetTypes**

Safely enumerate types across loaded assemblies.

## Overloads

| Overload | Description |
| :-- | :-- |
| [SafeGetTypes(Predicate&lt;Type> filter)](#safegettypespredicatetype-filter) | Safely enumerate types across loaded assemblies. |
## SafeGetTypes(Predicate&lt;Type> filter)

Safely enumerate types across loaded assemblies.

```csharp
public static IList<Type> SafeGetTypes(Predicate<Type> filter)
```

### Return Type

 [IList&lt;Type>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1)  - The list of types.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `filter` | [Predicate&lt;Type>](https://docs.microsoft.com/dotnet/api/system.predicate-1) | Filter for types to return. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 18:50:36 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

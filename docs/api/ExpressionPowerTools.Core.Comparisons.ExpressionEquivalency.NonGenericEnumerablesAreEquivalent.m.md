# ExpressionEquivalency.NonGenericEnumerablesAreEquivalent Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [ExpressionEquivalency](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.cs.md) > **NonGenericEnumerablesAreEquivalent**

Ensures two enumerables are same length an each value is equivalent.

## Overloads

| Overload | Description |
| :-- | :-- |
| [NonGenericEnumerablesAreEquivalent(IEnumerable srcEnumerable, IEnumerable tgtEnumerable)](#nongenericenumerablesareequivalentienumerable-srcenumerable-ienumerable-tgtenumerable) | Ensures two enumerables are same length an each value is equivalent. |
## NonGenericEnumerablesAreEquivalent(IEnumerable srcEnumerable, IEnumerable tgtEnumerable)

Ensures two enumerables are same length an each value is equivalent.

```csharp
public static Boolean NonGenericEnumerablesAreEquivalent(IEnumerable srcEnumerable, IEnumerable tgtEnumerable)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the two are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `srcEnumerable` | [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) | The source [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) . |
| `tgtEnumerable` | [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) | The target [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |

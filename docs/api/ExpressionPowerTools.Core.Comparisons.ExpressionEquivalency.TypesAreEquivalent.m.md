# ExpressionEquivalency.TypesAreEquivalent Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [ExpressionEquivalency](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.cs.md) > **TypesAreEquivalent**

Determine if a [Type](https://docs.microsoft.com/dotnet/api/system.type) is equivalent to another type.

## Overloads

| Overload | Description |
| :-- | :-- |
| [TypesAreEquivalent(Type source, Type target)](#typesareequivalenttype-source-type-target) | Determine if a [Type](https://docs.microsoft.com/dotnet/api/system.type) is equivalent to another type. |
## TypesAreEquivalent(Type source, Type target)

Determine if a [Type](https://docs.microsoft.com/dotnet/api/system.type) is equivalent to another type.

```csharp
public static Boolean TypesAreEquivalent(Type source, Type target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A value indicating whether the types are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The source [Type](https://docs.microsoft.com/dotnet/api/system.type) . |
| `target` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The target [Type](https://docs.microsoft.com/dotnet/api/system.type) . |


## Remarks

Handles anonymous types converted to dynamic dictionary.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/20/2020 6:32:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.9.0-alpha |

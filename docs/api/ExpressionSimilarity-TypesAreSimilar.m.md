# ExpressionSimilarity.TypesAreSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [ExpressionSimilarity](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.cs.md) > **TypesAreSimilar**

Determines whether types are similar.

## Overloads

| Overload | Description |
| :-- | :-- |
| [TypesAreSimilar(Type source, Type target)](#typesaresimilartype-source-type-target) | Determines whether types are similar. |
## TypesAreSimilar(Type source, Type target)

Determines whether types are similar.

```csharp
public static Boolean TypesAreSimilar(Type source, Type target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the types are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The source [Type](https://docs.microsoft.com/dotnet/api/system.type) to check. |
| `target` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The target [Type](https://docs.microsoft.com/dotnet/api/system.type) to check. |


## Remarks

Object must match object. Value types must match exactly.
            Other types can be derived from each other.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/20/2020 6:23:17 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

# ExpressionSimilarity.ParameterInfosAreSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [ExpressionSimilarity](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.cs.md) > **ParameterInfosAreSimilar**

Determines whether a list of parameters for a method or constructor are similar.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ParameterInfosAreSimilar(IList&lt;ParameterInfo> source, IList&lt;ParameterInfo> target)](#parameterinfosaresimilarilistparameterinfo-source-ilistparameterinfo-target) | Determines whether a list of parameters for a method or constructor are similar. |
## ParameterInfosAreSimilar(IList&lt;ParameterInfo> source, IList&lt;ParameterInfo> target)

Determines whether a list of parameters for a method or constructor are similar.

```csharp
public static Boolean ParameterInfosAreSimilar(IList<ParameterInfo> source, IList<ParameterInfo> target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag that indicates whether the parameters are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IList&lt;ParameterInfo>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | The source parameter list. |
| `target` | [IList&lt;ParameterInfo>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | The target parameter list. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/3/2020 10:27:04 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.4-alpha |

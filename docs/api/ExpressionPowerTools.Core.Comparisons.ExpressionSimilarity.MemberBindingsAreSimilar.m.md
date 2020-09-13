# ExpressionSimilarity.MemberBindingsAreSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [ExpressionSimilarity](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.cs.md) > **MemberBindingsAreSimilar**

Determines whether two lists of [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) are similar.

## Overloads

| Overload | Description |
| :-- | :-- |
| [MemberBindingsAreSimilar(IList&lt;MemberBinding> source, IList&lt;MemberBinding> target)](#memberbindingsaresimilarilistmemberbinding-source-ilistmemberbinding-target) | Determines whether two lists of [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) are similar. |
## MemberBindingsAreSimilar(IList&lt;MemberBinding> source, IList&lt;MemberBinding> target)

Determines whether two lists of [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) are similar.

```csharp
public static Boolean MemberBindingsAreSimilar(IList<MemberBinding> source, IList<MemberBinding> target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A value indicating whether the individual bindings are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IList&lt;MemberBinding>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | The source list. |
| `target` | [IList&lt;MemberBinding>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | The target list. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

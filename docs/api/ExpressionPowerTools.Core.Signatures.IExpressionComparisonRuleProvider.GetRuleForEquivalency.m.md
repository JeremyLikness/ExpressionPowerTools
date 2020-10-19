# IExpressionComparisonRuleProvider.GetRuleForEquivalency Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > [IExpressionComparisonRuleProvider](ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider.i.md) > **GetRuleForEquivalency**

Gets a predicate to compare two expressions of a given type.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetRuleForEquivalency&lt;T>()](#getruleforequivalencyt) | Gets a predicate to compare two expressions of a given type. |
## GetRuleForEquivalency&lt;T>()

Gets a predicate to compare two expressions of a given type.

```csharp
public virtual Func<T, T, Boolean> GetRuleForEquivalency<T>()
```

### Return Type

 [Func&lt;T, T, Boolean>](https://docs.microsoft.com/dotnet/api/system.func-3)  - The rule or null when not found.



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |

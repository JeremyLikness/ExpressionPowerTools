# ExpressionEvaluator.NullAndTypeCheck Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [ExpressionEvaluator](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.cs.md) > **NullAndTypeCheck**

Comparison matrix for types and nulls.

## Overloads

| Overload | Description |
| :-- | :-- |
| [NullAndTypeCheck(Expression source, Expression other)](#nullandtypecheckexpression-source-expression-other) | Comparison matrix for types and nulls. |
## NullAndTypeCheck(Expression source, Expression other)

Comparison matrix for types and nulls.

```csharp
public virtual Boolean NullAndTypeCheck(Expression source, Expression other)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the types are
            equal and the values are both not null.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The source to compare. |
| `other` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The target to compare to. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |

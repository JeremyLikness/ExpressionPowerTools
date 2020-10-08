# ExpressionRulesExtensions.IfWithCast Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **IfWithCast**

Enables if ... then logic with a cast to inner evaluations.

## Overloads

| Overload | Description |
| :-- | :-- |
| [IfWithCast&lt;T, TOther>(Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, TOther>> conversion, Expression&lt;Func&lt;TOther, TOther, Boolean>> ifTrue, Expression&lt;Func&lt;TOther, TOther, Boolean>> ifFalse)](#ifwithcastt-totherexpressionfunct-t-boolean-condition-expressionfunct-tother-conversion-expressionfunctother-tother-boolean-iftrue-expressionfunctother-tother-boolean-iffalse) | Enables if ... then logic with a cast to inner evaluations. |
## IfWithCast&lt;T, TOther>(Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, TOther>> conversion, Expression&lt;Func&lt;TOther, TOther, Boolean>> ifTrue, Expression&lt;Func&lt;TOther, TOther, Boolean>> ifFalse)

Enables if ... then logic with a cast to inner evaluations.

```csharp
public static Expression<Func<T, T, Boolean>> IfWithCast<T, TOther>(Expression<Func<T, T, Boolean>> condition, Expression<Func<T, TOther>> conversion, Expression<Func<TOther, TOther, Boolean>> ifTrue, Expression<Func<TOther, TOther, Boolean>> ifFalse)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - The result of the if/then/else evaluation.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `condition` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The condition that must pass. |
| `conversion` | [Expression&lt;Func&lt;T, TOther>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | How to convert to the type (property and cast). |
| `ifTrue` | [Expression&lt;Func&lt;TOther, TOther, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to apply for success. |
| `ifFalse` | [Expression&lt;Func&lt;TOther, TOther, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to apply for failure. |


## Examples

For example, if child is a constant and the constant type is integer, then it matches.

```csharp
ExpressionRulesExtensions.IfWithCast<BinaryExpression, ConstantExpression>(
                condition: (s, t) => s.Left is ConstantExpression,
                conversion: e => e.Left as ConstantExpression,
                ifTrue: (s, t) => ExpressionEquivalency.AreEquivalent(s, t), // runs as ConstantExpression
                ifFalse: ExpressionRulesExtensions.False<ConstantExpression>()).Compile();
            );
            
```

## Remarks

This special version allows transitioning from a parent expression to a child. For example,
            consider a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) with a [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) for the `Left` property. This rule enables you to test if the type matches, then run rules
            against the child [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . See thedefinition for more about how the final result is evaluated.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |

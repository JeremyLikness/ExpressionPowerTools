# ExpressionExtensions Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > **ExpressionExtensions**

Extension methods for fluent API over expressions.

```csharp
public static class ExpressionExtensions
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExpressionExtensions**

## Methods

| Method | Description |
| :-- | :-- |
| [ConstantExpression AsConstantExpression(Object obj)](ExpressionExtensions-AsConstantExpression.m.md) | Wraps an item as a [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) . |
| [IExpressionEnumerator AsEnumerable(Expression expression)](ExpressionExtensions-AsEnumerable.m.md) | Provides a way to enumerate an expression tree. |
| [ParameterExpression AsParameterExpression(Object obj, String name, Boolean byRef)](ExpressionExtensions-AsParameterExpression.m.md) | Creates a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) based on the            type of the object. |
| [ParameterExpression CreateParameterExpression&lt;T, TValue>(Expression&lt;Func&lt;T, TValue>> value)](ExpressionExtensions-CreateParameterExpression.m.md) | Extracts the parameter from a member expression. |
| [Boolean IsEquivalentTo(Expression source, Expression target)](ExpressionExtensions-IsEquivalentTo.m.md) | Uses [ExpressionEquivalency](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.cs.md) to determine equivalency. |
| [Boolean IsPartOf(Expression source, Expression target)](ExpressionExtensions-IsPartOf.m.md) | Uses [ExpressionSimilarity](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.cs.md) to determine if an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is part of another. |
| [Boolean IsSimilarTo(Expression source, Expression target)](ExpressionExtensions-IsSimilarTo.m.md) | Uses [ExpressionSimilarity](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.cs.md) to determine similarity. |
| [String MemberName&lt;T>(Expression&lt;Func&lt;T>> expr)](ExpressionExtensions-MemberName.m.md) | Extracts the name of the target of an expression. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/15/2020 12:36:00 AM | (c) Copyright 2020 Jeremy Likness. | **v0.1.0.0** |

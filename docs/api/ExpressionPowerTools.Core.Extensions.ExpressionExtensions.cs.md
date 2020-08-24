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
| [ConstantExpression AsConstantExpression(Object obj)](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.AsConstantExpression.m.md) | Wraps an item as a [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) . |
| [IExpressionEnumerator AsEnumerable(Expression expression)](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.AsEnumerable.m.md) | Provides a way to enumerate an expression tree. |
| [ParameterExpression AsParameterExpression(Object obj, String name, Boolean byRef)](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.AsParameterExpression.m.md) | Creates a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) based on the            type of the object. |
| [ParameterExpression CreateParameterExpression&lt;T, TValue>(Expression&lt;Func&lt;T, TValue>> value)](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.CreateParameterExpression.m.md) | Extracts the parameter from a member expression. |
| [Boolean IsEquivalentTo(Expression source, Expression target)](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.IsEquivalentTo.m.md) | Uses [ExpressionEquivalency](ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.cs.md) to determine equivalency. |
| [Boolean IsPartOf(Expression source, Expression target)](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.IsPartOf.m.md) | Uses [ExpressionSimilarity](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.cs.md) to determine if an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is part of another. |
| [Boolean IsSimilarTo(Expression source, Expression target)](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.IsSimilarTo.m.md) | Uses [ExpressionSimilarity](ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.cs.md) to determine similarity. |
| [String MemberName&lt;T>(Expression&lt;Func&lt;T>> expr)](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.MemberName.m.md) | Extracts the name of the target of an expression. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 11:34:48 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

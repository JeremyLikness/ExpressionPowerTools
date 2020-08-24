# DefaultComparisonRules Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > **DefaultComparisonRules**



```csharp
public class DefaultComparisonRules : IExpressionComparisonRuleProvider
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **DefaultComparisonRules**

Implements  [IExpressionComparisonRuleProvider](ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [DefaultComparisonRules()](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.ctor.md#defaultcomparisonrules) |  |
| [static DefaultComparisonRules()](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.ctor.md#static-defaultcomparisonrules) |  |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`DefaultBinaryRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultBinaryRules.prop.md) | [Expression&lt;Func&lt;BinaryExpression, BinaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultBinarySimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultBinarySimilarities.prop.md) | [Expression&lt;Func&lt;BinaryExpression, BinaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultConstantRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultConstantRules.prop.md) | [Expression&lt;Func&lt;ConstantExpression, ConstantExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultConstantSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultConstantSimilarities.prop.md) | [Expression&lt;Func&lt;ConstantExpression, ConstantExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultLambdaRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultLambdaRules.prop.md) | [Expression&lt;Func&lt;LambdaExpression, LambdaExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultLambdaSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultLambdaSimilarities.prop.md) | [Expression&lt;Func&lt;LambdaExpression, LambdaExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultMemberRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMemberRules.prop.md) | [Expression&lt;Func&lt;MemberExpression, MemberExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultMemberSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMemberSimilarities.prop.md) | [Expression&lt;Func&lt;MemberExpression, MemberExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultMethodRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMethodRules.prop.md) | [Expression&lt;Func&lt;MethodCallExpression, MethodCallExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultMethodSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMethodSimilarities.prop.md) | [Expression&lt;Func&lt;MethodCallExpression, MethodCallExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultNewArrayRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultNewArrayRules.prop.md) | [Expression&lt;Func&lt;NewArrayExpression, NewArrayExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultNewArraySimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultNewArraySimilarities.prop.md) | [Expression&lt;Func&lt;NewArrayExpression, NewArrayExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultNewRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultNewRules.prop.md) | [Expression&lt;Func&lt;NewExpression, NewExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultNewSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultNewSimilarities.prop.md) | [Expression&lt;Func&lt;NewExpression, NewExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultParameterRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultParameterRules.prop.md) | [Expression&lt;Func&lt;ParameterExpression, ParameterExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultParameterSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultParameterSimilarities.prop.md) | [Expression&lt;Func&lt;ParameterExpression, ParameterExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultUnaryRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultUnaryRules.prop.md) | [Expression&lt;Func&lt;UnaryExpression, UnaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| [`DefaultUnarySimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultUnarySimilarities.prop.md) | [Expression&lt;Func&lt;UnaryExpression, UnaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |

## Methods

| Method | Description |
| :-- | :-- |
| [Boolean CheckEquivalency&lt;T>(T source, Expression target)](DefaultComparisonRules-CheckEquivalency.m.md) |  |
| [Boolean CheckSimilarity&lt;T>(T source, Expression target)](DefaultComparisonRules-CheckSimilarity.m.md) |  |
| [Func&lt;T, T, Boolean> GetRuleForEquivalency&lt;T>()](DefaultComparisonRules-GetRuleForEquivalency.m.md) |  |
| [Func&lt;T, T, Boolean> GetRuleForSimilarity&lt;T>()](DefaultComparisonRules-GetRuleForSimilarity.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

# DefaultComparisonRules Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > **DefaultComparisonRules**

Default set of rules to use.

```csharp
public class DefaultComparisonRules : IExpressionComparisonRuleProvider
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **DefaultComparisonRules**

Implements  [IExpressionComparisonRuleProvider](ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider.i.md) 

## Remarks

The documentation for each rule has remarks that detail the application of the rule.

When documentation refers to "are similar" it means the similarity rules are applied to the child expressions.
            Types are similar if one is assignable to the other.

Is a part of refers to the expression tree. For example, a take might be buried inside an include, but a top level
            take will pass "is part of" an expression with a nest take.

## Constructors

| Ctor | Description |
| :-- | :-- |
| [DefaultComparisonRules()](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.ctor.md#defaultcomparisonrules) | Initializes a new instance of the [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) class. |
| [static DefaultComparisonRules()](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.ctor.md#static-defaultcomparisonrules) | Initializes a new instance of the [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`DefaultBinaryRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultBinaryRules.prop.md) | [Expression&lt;Func&lt;BinaryExpression, BinaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for binaries. |
| [`DefaultBinarySimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultBinarySimilarities.prop.md) | [Expression&lt;Func&lt;BinaryExpression, BinaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for binary similarities. |
| [`DefaultConstantRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultConstantRules.prop.md) | [Expression&lt;Func&lt;ConstantExpression, ConstantExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the rules for equivalency of [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) . |
| [`DefaultConstantSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultConstantSimilarities.prop.md) | [Expression&lt;Func&lt;ConstantExpression, ConstantExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rule for similarities between constants. |
| [`DefaultInvocationRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultInvocationRules.prop.md) | [Expression&lt;Func&lt;InvocationExpression, InvocationExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for invocations. |
| [`DefaultInvocationSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultInvocationSimilarities.prop.md) | [Expression&lt;Func&lt;InvocationExpression, InvocationExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default similarities for lambda. |
| [`DefaultLambdaRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultLambdaRules.prop.md) | [Expression&lt;Func&lt;LambdaExpression, LambdaExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for lambda. |
| [`DefaultLambdaSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultLambdaSimilarities.prop.md) | [Expression&lt;Func&lt;LambdaExpression, LambdaExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default similarities for lambda. |
| [`DefaultMemberInitRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMemberInitRules.prop.md) | [Expression&lt;Func&lt;MemberInitExpression, MemberInitExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for member initializers. |
| [`DefaultMemberInitSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMemberInitSimilarities.prop.md) | [Expression&lt;Func&lt;MemberInitExpression, MemberInitExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for member initializer similarites. |
| [`DefaultMemberRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMemberRules.prop.md) | [Expression&lt;Func&lt;MemberExpression, MemberExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for member equivalency. |
| [`DefaultMemberSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMemberSimilarities.prop.md) | [Expression&lt;Func&lt;MemberExpression, MemberExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for member similarity. |
| [`DefaultMethodRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMethodRules.prop.md) | [Expression&lt;Func&lt;MethodCallExpression, MethodCallExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for method calls. |
| [`DefaultMethodSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMethodSimilarities.prop.md) | [Expression&lt;Func&lt;MethodCallExpression, MethodCallExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the defeault rules for method call similarities. |
| [`DefaultNewArrayRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultNewArrayRules.prop.md) | [Expression&lt;Func&lt;NewArrayExpression, NewArrayExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for new arrays. |
| [`DefaultNewArraySimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultNewArraySimilarities.prop.md) | [Expression&lt;Func&lt;NewArrayExpression, NewArrayExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for new array similarities. |
| [`DefaultNewRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultNewRules.prop.md) | [Expression&lt;Func&lt;NewExpression, NewExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for object initializers. |
| [`DefaultNewSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultNewSimilarities.prop.md) | [Expression&lt;Func&lt;NewExpression, NewExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for object initializer similarities. |
| [`DefaultParameterRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultParameterRules.prop.md) | [Expression&lt;Func&lt;ParameterExpression, ParameterExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for parameters. |
| [`DefaultParameterSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultParameterSimilarities.prop.md) | [Expression&lt;Func&lt;ParameterExpression, ParameterExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for parameter similarities. |
| [`DefaultUnaryRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultUnaryRules.prop.md) | [Expression&lt;Func&lt;UnaryExpression, UnaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for unaries. |
| [`DefaultUnarySimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultUnarySimilarities.prop.md) | [Expression&lt;Func&lt;UnaryExpression, UnaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for unary similarities. |

## Methods

| Method | Description |
| :-- | :-- |
| [Boolean CheckEquivalency&lt;T>(T source, Expression target)](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.CheckEquivalency.m.md) | Perform the check. |
| [Boolean CheckSimilarity&lt;T>(T source, Expression target)](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.CheckSimilarity.m.md) | Perform the check. |
| [Func&lt;T, T, Boolean> GetRuleForEquivalency&lt;T>()](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.GetRuleForEquivalency.m.md) | Gets a predicate to compare two expressions of a given type. |
| [Func&lt;T, T, Boolean> GetRuleForSimilarity&lt;T>()](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.GetRuleForSimilarity.m.md) | Gets a predicate to compare two expressions of a given type. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/25/2020 00:25:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

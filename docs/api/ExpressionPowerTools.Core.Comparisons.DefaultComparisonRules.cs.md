# DefaultComparisonRules Class

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > **DefaultComparisonRules**

Default set of rules to use.

```csharp
public class DefaultComparisonRules : IExpressionComparisonRuleProvider
```

Inheritance [System.Object](https://docs.microsoft.com/dotnet/api/system.object) → **DefaultComparisonRules**

Implements  [IExpressionComparisonRuleProvider](ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider.i.md) 

# Constructors

| Ctor | Description |
| :-- | :-- |
| [DefaultComparisonRules()](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.ctor.md#ctor-0) | Initializes a new instance of the [DefaultComparisonRules](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md) class. |
### Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`DefaultConstantRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultConstantRules.prop.md) | [Expression&lt;Func&lt;ConstantExpression, ConstantExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the rules for equivalency of [System.Linq.Expressions.ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) . |
| [`DefaultConstantSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultConstantSimilarities.prop.md) | [Expression&lt;Func&lt;ConstantExpression, ConstantExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rule for similarities between constants. |
| [`DefaultLambdaRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultLambdaRules.prop.md) | [Expression&lt;Func&lt;LambdaExpression, LambdaExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the rules for lambda. |
| [`DefaultLambdaSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultLambdaSimilarities.prop.md) | [Expression&lt;Func&lt;LambdaExpression, LambdaExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the similarities for lambda. |
| [`DefaultMethodRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMethodRules.prop.md) | [Expression&lt;Func&lt;MethodCallExpression, MethodCallExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the rules for method calls. |
| [`DefaultMethodSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMethodSimilarities.prop.md) | [Expression&lt;Func&lt;MethodCallExpression, MethodCallExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the rules for method call similarities. |
| [`DefaultMemberRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMemberRules.prop.md) | [Expression&lt;Func&lt;MemberExpression, MemberExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for member equivalency. |
| [`DefaultMemberSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultMemberSimilarities.prop.md) | [Expression&lt;Func&lt;MemberExpression, MemberExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for member similarity. |
| [`DefaultUnaryRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultUnaryRules.prop.md) | [Expression&lt;Func&lt;UnaryExpression, UnaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for unaries. |
| [`DefaultUnarySimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultUnarySimilarities.prop.md) | [Expression&lt;Func&lt;UnaryExpression, UnaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for unary similarities. |
| [`DefaultBinaryRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultBinaryRules.prop.md) | [Expression&lt;Func&lt;BinaryExpression, BinaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for binaries. |
| [`DefaultBinarySimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultBinarySimilarities.prop.md) | [Expression&lt;Func&lt;BinaryExpression, BinaryExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for binary similarities. |
| [`DefaultParameterRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultParameterRules.prop.md) | [Expression&lt;Func&lt;ParameterExpression, ParameterExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for parameters. |
| [`DefaultParameterSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultParameterSimilarities.prop.md) | [Expression&lt;Func&lt;ParameterExpression, ParameterExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for parameter similarities. |
| [`DefaultNewArrayRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultNewArrayRules.prop.md) | [Expression&lt;Func&lt;NewArrayExpression, NewArrayExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for new arrays. |
| [`DefaultNewArraySimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultNewArraySimilarities.prop.md) | [Expression&lt;Func&lt;NewArrayExpression, NewArrayExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for new array similarities. |
| [`DefaultNewRules`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultNewRules.prop.md) | [Expression&lt;Func&lt;NewExpression, NewExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for object initializers. |
| [`DefaultNewSimilarities`](ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.DefaultNewSimilarities.prop.md) | [Expression&lt;Func&lt;NewExpression, NewExpression, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | Gets the default rules for object initializer similarities. |


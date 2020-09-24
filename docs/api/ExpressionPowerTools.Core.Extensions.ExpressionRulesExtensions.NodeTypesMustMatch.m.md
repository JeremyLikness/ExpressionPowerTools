# ExpressionRulesExtensions.NodeTypesMustMatch Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **NodeTypesMustMatch**

The [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) must be the same.

## Overloads

| Overload | Description |
| :-- | :-- |
| [NodeTypesMustMatch&lt;T>()](#nodetypesmustmatcht) | The [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) must be the same. |
## NodeTypesMustMatch&lt;T>()

The [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) must be the same.

```csharp
public static Expression<Func<T, T, Boolean>> NodeTypesMustMatch<T>()
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - An expression that evaluates whether the node types match.



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

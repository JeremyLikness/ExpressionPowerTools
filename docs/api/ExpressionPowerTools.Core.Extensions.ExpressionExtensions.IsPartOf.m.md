# ExpressionExtensions.IsPartOf Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionExtensions](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.cs.md) > **IsPartOf**

Uses [IExpressionEvaluator](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.i.md) to determine if an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is part of another.

## Overloads

| Overload | Description |
| :-- | :-- |
| [IsPartOf(Expression source, Expression target)](#ispartofexpression-source-expression-target) | Uses [IExpressionEvaluator](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.i.md) to determine if an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is part of another. |
## IsPartOf(Expression source, Expression target)

Uses [IExpressionEvaluator](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.i.md) to determine if an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is part of another.

```csharp
public static Boolean IsPartOf(Expression source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A flag indicating whether the source is part of the target.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The source [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The target [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to parse. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

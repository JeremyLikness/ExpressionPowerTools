# ExpressionExtensions.AsInvocationExpression Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionExtensions](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.cs.md) > **AsInvocationExpression**

Converts a lambda expresion into an invocation.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AsInvocationExpression(LambdaExpression lambda)](#asinvocationexpressionlambdaexpression-lambda) | Converts a lambda expresion into an invocation. |
## AsInvocationExpression(LambdaExpression lambda)

Converts a lambda expresion into an invocation.

```csharp
public static InvocationExpression AsInvocationExpression(LambdaExpression lambda)
```

### Return Type

 [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression)  - The transformed [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `lambda` | [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) | The [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) to convert. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when lambda is null. |

## Examples

For example:

```csharp
Expression<Func<int, bool>> lambda = i => i > 2;
            var invocation = lambda.AsInvocationExpression();
            
```


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

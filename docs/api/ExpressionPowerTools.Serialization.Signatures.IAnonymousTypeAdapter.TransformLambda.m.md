# IAnonymousTypeAdapter.TransformLambda Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IAnonymousTypeAdapter](ExpressionPowerTools.Serialization.Signatures.IAnonymousTypeAdapter.i.md) > **TransformLambda**

Transform a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) that returns an anonymous type.

## Overloads

| Overload | Description |
| :-- | :-- |
| [TransformLambda(LambdaExpression lambda)](#transformlambdalambdaexpression-lambda) | Transform a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) that returns an anonymous type. |
## TransformLambda(LambdaExpression lambda)

Transform a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) that returns an anonymous type.

```csharp
public virtual LambdaExpression TransformLambda(LambdaExpression lambda)
```

### Return Type

 [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression)  - The new Lambda expression.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `lambda` | [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) | The [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/20/2020 6:32:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.9.0-alpha |

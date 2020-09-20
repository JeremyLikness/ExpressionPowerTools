# AnonymousTypeAdapter.TransformLambda Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [AnonymousTypeAdapter](ExpressionPowerTools.Serialization.Serializers.AnonymousTypeAdapter.cs.md) > **TransformLambda**

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


## Remarks

Outgoing turns into serializable [AnonInitializer](ExpressionPowerTools.Serialization.Serializers.AnonInitializer.cs.md) . Incoming converts
            back to dynamic.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/20/2020 6:32:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.9.0-alpha |

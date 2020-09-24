# IAnonymousTypeAdapter.TransformConstant Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IAnonymousTypeAdapter](ExpressionPowerTools.Serialization.Signatures.IAnonymousTypeAdapter.i.md) > **TransformConstant**

Transform a [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [TransformConstant(ConstantExpression expression)](#transformconstantconstantexpression-expression) | Transform a [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) . |
## TransformConstant(ConstantExpression expression)

Transform a [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) .

```csharp
public virtual ConstantExpression TransformConstant(ConstantExpression expression)
```

### Return Type

 [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression)  - Transformed to handle anonymous types.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) | The [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:57:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

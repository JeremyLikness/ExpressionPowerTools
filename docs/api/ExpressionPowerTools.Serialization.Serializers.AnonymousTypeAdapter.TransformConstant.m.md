# AnonymousTypeAdapter.TransformConstant Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [AnonymousTypeAdapter](ExpressionPowerTools.Serialization.Serializers.AnonymousTypeAdapter.cs.md) > **TransformConstant**

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


## Remarks

Outbound anonymous become [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) and inbound
            become dynamic.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:57:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

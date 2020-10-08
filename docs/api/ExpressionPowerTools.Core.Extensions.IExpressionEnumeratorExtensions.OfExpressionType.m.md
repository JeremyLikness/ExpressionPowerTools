# IExpressionEnumeratorExtensions.OfExpressionType Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IExpressionEnumeratorExtensions](ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.cs.md) > **OfExpressionType**

Helper extension to extract nodes with a specific [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) value.

## Overloads

| Overload | Description |
| :-- | :-- |
| [OfExpressionType(IExpressionEnumerator expressionEnumerator, ExpressionType type)](#ofexpressiontypeiexpressionenumerator-expressionenumerator-expressiontype-type) | Helper extension to extract nodes with a specific [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) value. |
## OfExpressionType(IExpressionEnumerator expressionEnumerator, ExpressionType type)

Helper extension to extract nodes with a specific [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) value.

```csharp
public static IEnumerable<Expression> OfExpressionType(IExpressionEnumerator expressionEnumerator, ExpressionType type)
```

### Return Type

 [IEnumerable&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)  - The filtered result of [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expressionEnumerator` | [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) | The [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) to query. |
| `type` | [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) | The [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) to extract. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |

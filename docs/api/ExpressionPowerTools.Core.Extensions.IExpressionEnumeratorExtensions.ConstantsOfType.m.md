# IExpressionEnumeratorExtensions.ConstantsOfType Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IExpressionEnumeratorExtensions](ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.cs.md) > **ConstantsOfType**

Helper extension to extract constants from an expression tree.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ConstantsOfType&lt;T>(IExpressionEnumerator expressionEnumerator)](#constantsoftypetiexpressionenumerator-expressionenumerator) | Helper extension to extract constants from an expression tree. |
## ConstantsOfType&lt;T>(IExpressionEnumerator expressionEnumerator)

Helper extension to extract constants from an expression tree.

```csharp
public static IEnumerable<ConstantExpression> ConstantsOfType<T>(IExpressionEnumerator expressionEnumerator)
```

### Return Type

 [IEnumerable&lt;ConstantExpression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)  - The [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) with
            matching types.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expressionEnumerator` | [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) | The [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) to parse. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when enumerator is null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/20/2020 6:32:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.9.0-alpha |

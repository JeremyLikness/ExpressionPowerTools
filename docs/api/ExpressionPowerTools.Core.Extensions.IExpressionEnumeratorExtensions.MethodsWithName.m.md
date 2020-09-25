# IExpressionEnumeratorExtensions.MethodsWithName Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IExpressionEnumeratorExtensions](ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.cs.md) > **MethodsWithName**

Helper extension to extract methods with a particular name.

## Overloads

| Overload | Description |
| :-- | :-- |
| [MethodsWithName(IExpressionEnumerator expressionEnumerator, String name)](#methodswithnameiexpressionenumerator-expressionenumerator-string-name) | Helper extension to extract methods with a particular name. |
## MethodsWithName(IExpressionEnumerator expressionEnumerator, String name)

Helper extension to extract methods with a particular name.

```csharp
public static IEnumerable<MethodCallExpression> MethodsWithName(IExpressionEnumerator expressionEnumerator, String name)
```

### Return Type

 [IEnumerable&lt;MethodCallExpression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)  - The [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expressionEnumerator` | [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) | The [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) to query. |
| `name` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The method name to extract. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/25/2020 00:25:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

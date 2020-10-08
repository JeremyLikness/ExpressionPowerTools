# IExpressionEnumeratorExtensions.MethodsFromTemplate Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IExpressionEnumeratorExtensions](ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.cs.md) > **MethodsFromTemplate**

Use a template to specify the method to search for.

## Overloads

| Overload | Description |
| :-- | :-- |
| [MethodsFromTemplate&lt;T>(IExpressionEnumerator expressionEnumerator, Expression&lt;Action&lt;T>> method)](#methodsfromtemplatetiexpressionenumerator-expressionenumerator-expressionactiont-method) | Use a template to specify the method to search for. |
## MethodsFromTemplate&lt;T>(IExpressionEnumerator expressionEnumerator, Expression&lt;Action&lt;T>> method)

Use a template to specify the method to search for.

```csharp
public static IEnumerable<MethodCallExpression> MethodsFromTemplate<T>(IExpressionEnumerator expressionEnumerator, Expression<Action<T>> method)
```

### Return Type

 [IEnumerable&lt;MethodCallExpression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)  - The list of matching [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) instances.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expressionEnumerator` | [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) | The [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) to query. |
| `method` | [Expression&lt;Action&lt;T>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | An expression that accesses the method. |


## Remarks

Only matches method name and declaring type. Arguments are ignored.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |

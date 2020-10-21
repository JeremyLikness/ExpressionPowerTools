# ExpressionExtensions.AsEnumerable Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionExtensions](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.cs.md) > **AsEnumerable**

Provides a way to enumerate an expression tree.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AsEnumerable(Expression expression)](#asenumerableexpression-expression) | Provides a way to enumerate an expression tree. |
## AsEnumerable(Expression expression)

Provides a way to enumerate an expression tree.

```csharp
public static IExpressionEnumerator AsEnumerable(Expression expression)
```

### Return Type

 [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md)  - The [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) instance.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to recurse. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when expression is null. |

## Examples

For example:

```csharp
var expr = Expression.Constant(this);
            var target = expr.AsEnumerable();
            
```


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

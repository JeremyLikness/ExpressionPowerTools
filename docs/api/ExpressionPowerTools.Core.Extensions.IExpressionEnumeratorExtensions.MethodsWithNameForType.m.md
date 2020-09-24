# IExpressionEnumeratorExtensions.MethodsWithNameForType Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IExpressionEnumeratorExtensions](ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.cs.md) > **MethodsWithNameForType**

Extracts instances of expressions that represent a method
            on a type.

## Overloads

| Overload | Description |
| :-- | :-- |
| [MethodsWithNameForType(IExpressionEnumerator expressionEnumerator, Type type, String name)](#methodswithnamefortypeiexpressionenumerator-expressionenumerator-type-type-string-name) | Extracts instances of expressions that represent a method            on a type. |
| [MethodsWithNameForType&lt;T>(IExpressionEnumerator expressionEnumerator, String name)](#methodswithnamefortypetiexpressionenumerator-expressionenumerator-string-name) | Extracts instances of expressions that represent a method            on a type. |
## MethodsWithNameForType(IExpressionEnumerator expressionEnumerator, Type type, String name)

Extracts instances of expressions that represent a method
            on a type.

```csharp
public static IEnumerable<MethodCallExpression> MethodsWithNameForType(IExpressionEnumerator expressionEnumerator, Type type, String name)
```

### Return Type

 [IEnumerable&lt;MethodCallExpression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)  - The filtered [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expressionEnumerator` | [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) | The [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) to query. |
| `type` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The [Type](https://docs.microsoft.com/dotnet/api/system.type) to check for. |
| `name` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The name of the method. |


## MethodsWithNameForType&lt;T>(IExpressionEnumerator expressionEnumerator, String name)

Extracts instances of expressions that represent a method
            on a type.

```csharp
public static IEnumerable<MethodCallExpression> MethodsWithNameForType<T>(IExpressionEnumerator expressionEnumerator, String name)
```

### Return Type

 [IEnumerable&lt;MethodCallExpression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)  - The [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) filtered results.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expressionEnumerator` | [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) | The [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) to query. |
| `name` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The name of the method to query for. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:29:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

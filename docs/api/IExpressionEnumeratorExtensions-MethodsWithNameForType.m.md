# IExpressionEnumeratorExtensions.MethodsWithNameForType Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IExpressionEnumeratorExtensions](ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.cs.md) > **MethodsWithNameForType**



## Overloads

| Overload | Description |
| :-- | :-- |
| [MethodsWithNameForType(IExpressionEnumerator expressionEnumerator, Type type, String name)](#methodswithnamefortypeiexpressionenumerator-expressionenumerator-type-type-string-name) |  |
| [MethodsWithNameForType&lt;T>(IExpressionEnumerator expressionEnumerator, String name)](#methodswithnamefortypetiexpressionenumerator-expressionenumerator-string-name) |  |
## MethodsWithNameForType(IExpressionEnumerator expressionEnumerator, Type type, String name)



```csharp
public static IEnumerable<MethodCallExpression> MethodsWithNameForType(IExpressionEnumerator expressionEnumerator, Type type, String name)
```

### Return Type

 [IEnumerable&lt;MethodCallExpression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expressionEnumerator` | [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) |  |
| `type` | [Type](https://docs.microsoft.com/dotnet/api/system.type) |  |
| `name` | [String](https://docs.microsoft.com/dotnet/api/system.string) |  |


## MethodsWithNameForType&lt;T>(IExpressionEnumerator expressionEnumerator, String name)



```csharp
public static IEnumerable<MethodCallExpression> MethodsWithNameForType<T>(IExpressionEnumerator expressionEnumerator, String name)
```

### Return Type

 [IEnumerable&lt;MethodCallExpression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expressionEnumerator` | [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) |  |
| `name` | [String](https://docs.microsoft.com/dotnet/api/system.string) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

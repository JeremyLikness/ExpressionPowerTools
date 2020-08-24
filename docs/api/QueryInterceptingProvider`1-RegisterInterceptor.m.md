# QueryInterceptingProvider&lt;T>.RegisterInterceptor Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > [QueryInterceptingProvider<T>](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.cs.md) > **RegisterInterceptor**

Registers the transformation to apply.

## Overloads

| Overload | Description |
| :-- | :-- |
| [RegisterInterceptor(ExpressionTransformer transformation)](#registerinterceptorexpressiontransformer-transformation) | Registers the transformation to apply. |
## RegisterInterceptor(ExpressionTransformer transformation)

Registers the transformation to apply.

```csharp
public virtual Void RegisterInterceptor(ExpressionTransformer transformation)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `transformation` | [ExpressionTransformer](ExpressionPowerTools.Core.ExpressionTransformer.cs.md) | A method that transforms an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when transformation is null. |
| [InvalidOperationException](https://docs.microsoft.com/dotnet/api/system.invalidoperationexception) | Thrown when interceptor already registered. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

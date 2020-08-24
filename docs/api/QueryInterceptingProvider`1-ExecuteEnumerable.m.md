# QueryInterceptingProvider&lt;T>.ExecuteEnumerable Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > [QueryInterceptingProvider<T>](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.cs.md) > **ExecuteEnumerable**

Execute the enumerable.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ExecuteEnumerable(Expression expression)](#executeenumerableexpression-expression) | Execute the enumerable. |
## ExecuteEnumerable(Expression expression)

Execute the enumerable.

```csharp
public virtual IEnumerable<T> ExecuteEnumerable(Expression expression)
```

### Return Type

 [IEnumerable&lt;T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)  - The result of the transformed expression.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to execute. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 8:28:46 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

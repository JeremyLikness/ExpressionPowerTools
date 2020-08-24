# ExpressionEvaluator.IsPartOf Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Comparisons](ExpressionPowerTools.Core.Comparisons.n.md) > [ExpressionEvaluator](ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.cs.md) > **IsPartOf**



## Overloads

| Overload | Description |
| :-- | :-- |
| [IsPartOf(Expression source, Expression target)](#ispartofexpression-source-expression-target) |  |
| [IsPartOf&lt;T>(IQueryable&lt;T> source, IQueryable&lt;T> target)](#ispartoftiqueryablet-source-iqueryablet-target) |  |
## IsPartOf(Expression source, Expression target)



```csharp
public virtual Boolean IsPartOf(Expression source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) |  |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) |  |


## IsPartOf&lt;T>(IQueryable&lt;T> source, IQueryable&lt;T> target)



```csharp
public virtual Boolean IsPartOf<T>(IQueryable<T> source, IQueryable<T> target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) |  |
| `target` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

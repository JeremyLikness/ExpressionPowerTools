# IExpressionEvaluator.AreEquivalent Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > [IExpressionEvaluator](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.i.md) > **AreEquivalent**



## Overloads

| Overload | Description |
| :-- | :-- |
| [AreEquivalent(Expression source, Expression target)](#areequivalentexpression-source-expression-target) |  |
| [AreEquivalent(IEnumerable&lt;Expression> source, IEnumerable&lt;Expression> target)](#areequivalentienumerableexpression-source-ienumerableexpression-target) |  |
| [AreEquivalent&lt;T>(IQueryable&lt;T> source, IQueryable&lt;T> target)](#areequivalenttiqueryablet-source-iqueryablet-target) |  |
## AreEquivalent(Expression source, Expression target)



```csharp
public virtual Boolean AreEquivalent(Expression source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) |  |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) |  |


## AreEquivalent(IEnumerable&lt;Expression> source, IEnumerable&lt;Expression> target)



```csharp
public virtual Boolean AreEquivalent(IEnumerable<Expression> source, IEnumerable<Expression> target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IEnumerable&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) |  |
| `target` | [IEnumerable&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) |  |


## AreEquivalent&lt;T>(IQueryable&lt;T> source, IQueryable&lt;T> target)



```csharp
public virtual Boolean AreEquivalent<T>(IQueryable<T> source, IQueryable<T> target)
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

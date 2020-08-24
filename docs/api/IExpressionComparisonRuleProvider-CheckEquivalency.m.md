# IExpressionComparisonRuleProvider.CheckEquivalency Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > [IExpressionComparisonRuleProvider](ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider.i.md) > **CheckEquivalency**



## Overloads

| Overload | Description |
| :-- | :-- |
| [CheckEquivalency(Expression source, Expression target)](#checkequivalencyexpression-source-expression-target) |  |
| [CheckEquivalency&lt;T>(T source, Expression target)](#checkequivalencytt-source-expression-target) |  |
## CheckEquivalency(Expression source, Expression target)



```csharp
public virtual Boolean CheckEquivalency(Expression source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) |  |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) |  |


## CheckEquivalency&lt;T>(T source, Expression target)



```csharp
public virtual Boolean CheckEquivalency<T>(T source, Expression target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | T |  |
| `target` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

# ExpressionExtensions.CreateParameterExpression Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionExtensions](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.cs.md) > **CreateParameterExpression**



## Overloads

| Overload | Description |
| :-- | :-- |
| [CreateParameterExpression&lt;T, TValue>(Expression&lt;Func&lt;T, TValue>> value)](#createparameterexpressiont-tvalueexpressionfunct-tvalue-value) |  |
## CreateParameterExpression&lt;T, TValue>(Expression&lt;Func&lt;T, TValue>> value)



```csharp
public static ParameterExpression CreateParameterExpression<T, TValue>(Expression<Func<T, TValue>> value)
```

### Return Type

 [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `value` | [Expression&lt;Func&lt;T, TValue>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/8/2020 3:10:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.6-alpha |

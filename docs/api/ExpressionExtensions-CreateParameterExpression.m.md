# ExpressionExtensions.CreateParameterExpression Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionExtensions](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.cs.md) > **CreateParameterExpression**

Extracts the parameter from a member expression.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CreateParameterExpression&lt;T, TValue>(Expression&lt;Func&lt;T, TValue>> value)](#createparameterexpressiont-tvalueexpressionfunct-tvalue-value) | Extracts the parameter from a member expression. |
## CreateParameterExpression&lt;T, TValue>(Expression&lt;Func&lt;T, TValue>> value)

Extracts the parameter from a member expression.

```csharp
public static ParameterExpression CreateParameterExpression<T, TValue>(Expression<Func<T, TValue>> value)
```

### Return Type

 [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression)  - The [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `value` | [Expression&lt;Func&lt;T, TValue>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | An expression that evaluates to the member. |


## Examples

For example:

```csharp

var result = ExpressionExtensions
    .CreateParameterExpression<Foo, string>(
       foo => foo.Bar);
// result.Type == typeof(string)
// result.Name == "Bar";
            
```


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/20/2020 6:23:17 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

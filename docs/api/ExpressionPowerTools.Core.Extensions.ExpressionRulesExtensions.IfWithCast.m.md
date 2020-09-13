# ExpressionRulesExtensions.IfWithCast Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **IfWithCast**



## Overloads

| Overload | Description |
| :-- | :-- |
| [IfWithCast&lt;T, TOther>(Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, TOther>> conversion, Expression&lt;Func&lt;TOther, TOther, Boolean>> ifTrue, Expression&lt;Func&lt;TOther, TOther, Boolean>> ifFalse)](#ifwithcastt-totherexpressionfunct-t-boolean-condition-expressionfunct-tother-conversion-expressionfunctother-tother-boolean-iftrue-expressionfunctother-tother-boolean-iffalse) |  |
## IfWithCast&lt;T, TOther>(Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, TOther>> conversion, Expression&lt;Func&lt;TOther, TOther, Boolean>> ifTrue, Expression&lt;Func&lt;TOther, TOther, Boolean>> ifFalse)



```csharp
public static Expression<Func<T, T, Boolean>> IfWithCast<T, TOther>(Expression<Func<T, T, Boolean>> condition, Expression<Func<T, TOther>> conversion, Expression<Func<TOther, TOther, Boolean>> ifTrue, Expression<Func<TOther, TOther, Boolean>> ifFalse)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `condition` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| `conversion` | [Expression&lt;Func&lt;T, TOther>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| `ifTrue` | [Expression&lt;Func&lt;TOther, TOther, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |
| `ifFalse` | [Expression&lt;Func&lt;TOther, TOther, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

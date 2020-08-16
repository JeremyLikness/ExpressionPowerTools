# ExpressionRulesExtensions.SourceMustBePartofTarget Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **SourceMustBePartofTarget**



## Overloads

| Overload | Description |
| :-- | :-- |
| [SourceMustBePartofTarget&lt;T>(Func&lt;T, Expression> member)](#sourcemustbepartoftargettfunct-expression-member) |  |
## SourceMustBePartofTarget&lt;T>(Func&lt;T, Expression> member)



```csharp
public static Expression<Func<T, T, Boolean>> SourceMustBePartofTarget<T>(Func<T, Expression> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [Func&lt;T, Expression>](https://docs.microsoft.com/dotnet/api/system.func-2) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/15/2020 12:36:00 AM | (c) Copyright 2020 Jeremy Likness. | **v0.1.0.0** |

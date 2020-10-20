# ExpressionRulesExtensions.SourceMustBePartofTarget Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **SourceMustBePartofTarget**

Expression must be part of another.

## Overloads

| Overload | Description |
| :-- | :-- |
| [SourceMustBePartofTarget&lt;T>(Func&lt;T, Expression> member)](#sourcemustbepartoftargettfunct-expression-member) | Expression must be part of another. |
## SourceMustBePartofTarget&lt;T>(Func&lt;T, Expression> member)

Expression must be part of another.

```csharp
public static Expression<Func<T, T, Boolean>> SourceMustBePartofTarget<T>(Func<T, Expression> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - A value indicating whether the source is part of the target.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [Func&lt;T, Expression>](https://docs.microsoft.com/dotnet/api/system.func-2) | Reference the property that is an expression. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

# ExpressionRulesExtensions.TypesMustMatch Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **TypesMustMatch**

Types of the expressions must be the same.

## Overloads

| Overload | Description |
| :-- | :-- |
| [TypesMustMatch&lt;T>()](#typesmustmatcht) | Types of the expressions must be the same. |
## TypesMustMatch&lt;T>()

Types of the expressions must be the same.

```csharp
public static Expression<Func<T, T, Boolean>> TypesMustMatch<T>()
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - An expression that evaluates whether the types match.


## Remarks

Returns `true` c> if types are same, or one type is anonymous and the othere is a dictionary.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

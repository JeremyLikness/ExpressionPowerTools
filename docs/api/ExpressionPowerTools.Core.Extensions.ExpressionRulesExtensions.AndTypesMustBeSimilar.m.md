# ExpressionRulesExtensions.AndTypesMustBeSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **AndTypesMustBeSimilar**

AND types of the expressions must be similar.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AndTypesMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)](#andtypesmustbesimilartexpressionfunct-t-boolean-rule) | AND types of the expressions must be similar. |
| [AndTypesMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Type> typeAccess)](#andtypesmustbesimilartexpressionfunct-t-boolean-rule-funct-type-typeaccess) | Types of the expressions must be similar. |
## AndTypesMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule)

AND types of the expressions must be similar.

```csharp
public static Expression<Func<T, T, Boolean>> AndTypesMustBeSimilar<T>(Expression<Func<T, T, Boolean>> rule)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - An expression that evaluates whether the types are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to include. |


## AndTypesMustBeSimilar&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> rule, Func&lt;T, Type> typeAccess)

Types of the expressions must be similar.

```csharp
public static Expression<Func<T, T, Boolean>> AndTypesMustBeSimilar<T>(Expression<Func<T, T, Boolean>> rule, Func<T, Type> typeAccess)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - An expression that evaluates whether the types are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `rule` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to attach to. |
| `typeAccess` | [Func&lt;T, Type>](https://docs.microsoft.com/dotnet/api/system.func-2) | Access to the type. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/26/2020 6:58:17 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

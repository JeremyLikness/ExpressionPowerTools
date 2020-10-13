# ExpressionRulesExtensions.TypesMustBeSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **TypesMustBeSimilar**

Types of the expressions must be similar.

## Overloads

| Overload | Description |
| :-- | :-- |
| [TypesMustBeSimilar&lt;T>()](#typesmustbesimilart) | Types of the expressions must be similar. |
| [TypesMustBeSimilar&lt;T>(Func&lt;T, Type> typeAccess)](#typesmustbesimilartfunct-type-typeaccess) | Types of the expressions must be similar. |
## TypesMustBeSimilar&lt;T>()

Types of the expressions must be similar.

```csharp
public static Expression<Func<T, T, Boolean>> TypesMustBeSimilar<T>()
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - An expression that evaluates whether the types are similar.


## TypesMustBeSimilar&lt;T>(Func&lt;T, Type> typeAccess)

Types of the expressions must be similar.

```csharp
public static Expression<Func<T, T, Boolean>> TypesMustBeSimilar<T>(Func<T, Type> typeAccess)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - An expression that evaluates whether the types are similar.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `typeAccess` | [Func&lt;T, Type>](https://docs.microsoft.com/dotnet/api/system.func-2) | Access to the type. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 5:26:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

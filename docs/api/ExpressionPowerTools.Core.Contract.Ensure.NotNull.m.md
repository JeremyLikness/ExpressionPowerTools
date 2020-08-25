# Ensure.NotNull Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Contract](ExpressionPowerTools.Core.Contract.n.md) > [Ensure](ExpressionPowerTools.Core.Contract.Ensure.cs.md) > **NotNull**

Ensures that the result of an argument expression is
            not null.

## Overloads

| Overload | Description |
| :-- | :-- |
| [NotNull&lt;T>(Expression&lt;Func&lt;T>> value)](#notnulltexpressionfunct-value) | Ensures that the result of an argument expression is            not null. |
## NotNull&lt;T>(Expression&lt;Func&lt;T>> value)

Ensures that the result of an argument expression is
            not null.

```csharp
public static Void NotNull<T>(Expression<Func<T>> value)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `value` | [Expression&lt;Func&lt;T>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | An expression that resolves to the value. |


## Examples

```csharp

Ensure.NotNull(() => parameter);
            
```


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 5:55:15 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

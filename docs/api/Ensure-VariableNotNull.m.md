# Ensure.VariableNotNull Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Contract](ExpressionPowerTools.Core.Contract.n.md) > [Ensure](ExpressionPowerTools.Core.Contract.Ensure.cs.md) > **VariableNotNull**

Ensures that the result of an expression is not null.

## Overloads

| Overload | Description |
| :-- | :-- |
| [VariableNotNull&lt;T>(Expression&lt;Func&lt;T>> value)](#variablenotnulltexpressionfunct-value) | Ensures that the result of an expression is not null. |
## VariableNotNull&lt;T>(Expression&lt;Func&lt;T>> value)

Ensures that the result of an expression is not null.

```csharp
public static Void VariableNotNull<T>(Expression<Func<T>> value)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `value` | [Expression&lt;Func&lt;T>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | An expression that resolves to the value. |


## Examples

For example:

```csharp

Ensure.VariableNotNull(() => localVariable);
            
```


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/15/2020 12:36:00 AM | (c) Copyright 2020 Jeremy Likness. | **v0.1.0.0** |

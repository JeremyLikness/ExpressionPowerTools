# ExpressionExtensions.MemberName Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionExtensions](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.cs.md) > **MemberName**

Extracts the name of the target of an expression.

## Overloads

| Overload | Description |
| :-- | :-- |
| [MemberName&lt;T>(Expression&lt;Func&lt;T>> expr)](#membernametexpressionfunct-expr) | Extracts the name of the target of an expression. |
## MemberName&lt;T>(Expression&lt;Func&lt;T>> expr)

Extracts the name of the target of an expression.

```csharp
public static String MemberName<T>(Expression<Func<T>> expr)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The name of the target.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expr` | [Expression&lt;Func&lt;T>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | An expression that results in a parameter. |


## Examples

For example:

```csharp

Expression<Func<string>> expr = () => foo;
expr.MemberName(); // "foo"
            
```


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

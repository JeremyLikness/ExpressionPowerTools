# ExpressionRulesExtensions.If Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **If**

Enables if ... then logic.

## Overloads

| Overload | Description |
| :-- | :-- |
| [If&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, T, Boolean>> ifTrue, Expression&lt;Func&lt;T, T, Boolean>> ifFalse)](#iftexpressionfunct-t-boolean-condition-expressionfunct-t-boolean-iftrue-expressionfunct-t-boolean-iffalse) | Enables if ... then logic. |
## If&lt;T>(Expression&lt;Func&lt;T, T, Boolean>> condition, Expression&lt;Func&lt;T, T, Boolean>> ifTrue, Expression&lt;Func&lt;T, T, Boolean>> ifFalse)

Enables if ... then logic.

```csharp
public static Expression<Func<T, T, Boolean>> If<T>(Expression<Func<T, T, Boolean>> condition, Expression<Func<T, T, Boolean>> ifTrue, Expression<Func<T, T, Boolean>> ifFalse)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1)  - The result of the if/then/else evaluation.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `condition` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The condition that must pass. |
| `ifTrue` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to apply for success. |
| `ifFalse` | [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The rule to apply for failure. |


## Examples

For example, if first name matches and *if* last name isn't `null` , then it matches.

```csharp

ExpressionRulesExtension.Rule((s, t) => s.FirstName == t.FirstName)
    .And(If(
            condition: (s, t) => s.LastName != null,
            ifTrue: (s, t) => s.LastName == t.LastName
            ));
            
```

In another example, if first name matches *or* if last name is not null and matches.
            For last name to "light up" requires that both condition and `ifTrue` pass.

```csharp

ExpressionRulesExtension.Rule((s, t) => s.FirstName == t.FirstName)
    .Or(If(
            condition: (s, t) => s.LastName != null,
            ifTrue: (s, t) => s.LastName == t.LastName,
            ifFalse: ExpressionRuleExtension.False()
            ));
            
```

## Remarks

Since the logic is Boolean, the statement always returns a `bool` . If the condition
            is true, it evaluates to the result of the `ifThen` condition. If the condition
            is false, it evaluates to the result of the `ifFalse` condition. The `ifFalse` condition evaluates to `true` by default so it can be part of an "AND" chain. If it
            is part of an "OR" chain, you should override `ifFalse` to return `false` .


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 8:28:46 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

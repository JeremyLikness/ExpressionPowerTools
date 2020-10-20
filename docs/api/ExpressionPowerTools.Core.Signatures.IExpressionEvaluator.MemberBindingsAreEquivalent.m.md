# IExpressionEvaluator.MemberBindingsAreEquivalent Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > [IExpressionEvaluator](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.i.md) > **MemberBindingsAreEquivalent**

Ensures that two [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) instances are equivalent.

## Overloads

| Overload | Description |
| :-- | :-- |
| [MemberBindingsAreEquivalent(MemberBinding source, MemberBinding target)](#memberbindingsareequivalentmemberbinding-source-memberbinding-target) | Ensures that two [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) instances are equivalent. |
## MemberBindingsAreEquivalent(MemberBinding source, MemberBinding target)

Ensures that two [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) instances are equivalent.

```csharp
public virtual Boolean MemberBindingsAreEquivalent(MemberBinding source, MemberBinding target)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A value that indicates whether the bindings are equivalent.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) | The source [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) . |
| `target` | [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) | The target [MemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberbinding) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

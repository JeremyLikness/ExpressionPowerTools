# ExpressionNominator.Nominate Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Compression](ExpressionPowerTools.Serialization.Compression.n.md) > [ExpressionNominator](ExpressionPowerTools.Serialization.Compression.ExpressionNominator.cs.md) > **Nominate**

Uses the visitor to return the candidates.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Nominate(Expression expression)](#nominateexpression-expression) | Uses the visitor to return the candidates. |
## Nominate(Expression expression)

Uses the visitor to return the candidates.

```csharp
public HashSet<Expression> Nominate(Expression expression)
```

### Return Type

 [HashSet&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.hashset-1)  - The list of candiates.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to nominate. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 5:26:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

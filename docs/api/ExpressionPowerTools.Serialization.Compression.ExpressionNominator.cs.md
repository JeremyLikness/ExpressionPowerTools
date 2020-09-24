# ExpressionNominator Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Compression](ExpressionPowerTools.Serialization.Compression.n.md) > **ExpressionNominator**

Parses a tree to find candidates for resolution (i.e. variables, local method calls).

```csharp
public class ExpressionNominator : ExpressionVisitor
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [ExpressionVisitor](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressionvisitor) → **ExpressionNominator**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ExpressionNominator()](ExpressionPowerTools.Serialization.Compression.ExpressionNominator.ctor.md#expressionnominator) | Initializes a new instance of the [ExpressionNominator](ExpressionPowerTools.Serialization.Compression.ExpressionNominator.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [HashSet&lt;Expression> Nominate(Expression expression)](ExpressionPowerTools.Serialization.Compression.ExpressionNominator.Nominate.m.md) | Uses the visitor to return the candidates. |
| [Expression Visit(Expression expression)](ExpressionPowerTools.Serialization.Compression.ExpressionNominator.Visit.m.md) | Vist the expression. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:02:13 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

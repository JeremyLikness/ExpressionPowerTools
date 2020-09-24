# SubtreeEvaluator Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Compression](ExpressionPowerTools.Serialization.Compression.n.md) > **SubtreeEvaluator**

Parses the candidates and evaluates so that variables are collapsed to constants.

```csharp
public class SubtreeEvaluator : ExpressionVisitor
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [ExpressionVisitor](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressionvisitor) → **SubtreeEvaluator**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [SubtreeEvaluator(HashSet&lt;Expression> candidates)](ExpressionPowerTools.Serialization.Compression.SubtreeEvaluator.ctor.md#subtreeevaluatorhashsetexpression-candidates) | Initializes a new instance of the [SubtreeEvaluator](ExpressionPowerTools.Serialization.Compression.SubtreeEvaluator.cs.md) class            with the list of nominated candidates. |
## Methods

| Method | Description |
| :-- | :-- |
| [Expression Eval(Expression exp)](ExpressionPowerTools.Serialization.Compression.SubtreeEvaluator.Eval.m.md) | Evaluate the expression. |
| [Expression Visit(Expression exp)](ExpressionPowerTools.Serialization.Compression.SubtreeEvaluator.Visit.m.md) | Vists the node. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:50:49 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

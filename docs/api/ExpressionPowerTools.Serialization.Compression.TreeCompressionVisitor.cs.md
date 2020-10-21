# TreeCompressionVisitor Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Compression](ExpressionPowerTools.Serialization.Compression.n.md) > **TreeCompressionVisitor**

Visitor that compresses expressions.

```csharp
public class TreeCompressionVisitor : ExpressionVisitor
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [ExpressionVisitor](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressionvisitor) → **TreeCompressionVisitor**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [TreeCompressionVisitor()](ExpressionPowerTools.Serialization.Compression.TreeCompressionVisitor.ctor.md#treecompressionvisitor) | Initializes a new instance of the [TreeCompressionVisitor](ExpressionPowerTools.Serialization.Compression.TreeCompressionVisitor.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Expression Compress(Expression source)](ExpressionPowerTools.Serialization.Compression.TreeCompressionVisitor.Compress.m.md) | Compress the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree by collapsing logical nodes that            can be evaluated. |
| [Expression Eval(Expression expression)](ExpressionPowerTools.Serialization.Compression.TreeCompressionVisitor.Eval.m.md) | Evaluates the expression for segments that can be invoked. |
| [Expression EvalAndCompress(Expression expression)](ExpressionPowerTools.Serialization.Compression.TreeCompressionVisitor.EvalAndCompress.m.md) | Performs evaluation and replacement of independent sub-trees. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

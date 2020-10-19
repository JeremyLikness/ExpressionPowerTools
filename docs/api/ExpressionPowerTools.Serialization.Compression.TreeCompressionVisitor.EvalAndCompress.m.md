# TreeCompressionVisitor.EvalAndCompress Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Compression](ExpressionPowerTools.Serialization.Compression.n.md) > [TreeCompressionVisitor](ExpressionPowerTools.Serialization.Compression.TreeCompressionVisitor.cs.md) > **EvalAndCompress**

Performs evaluation and replacement of independent sub-trees.

## Overloads

| Overload | Description |
| :-- | :-- |
| [EvalAndCompress(Expression expression)](#evalandcompressexpression-expression) | Performs evaluation and replacement of independent sub-trees. |
## EvalAndCompress(Expression expression)

Performs evaluation and replacement of independent sub-trees.

```csharp
public Expression EvalAndCompress(Expression expression)
```

### Return Type

 [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression)  - A new tree with sub-trees evaluated and replaced.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The root of the expression tree. |


## Remarks

Logic borrowed from https://docs.microsoft.com/en-us/archive/blogs/mattwar/linq-building-an-iqueryable-provider-series post.
            Heavily modified to work here.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |

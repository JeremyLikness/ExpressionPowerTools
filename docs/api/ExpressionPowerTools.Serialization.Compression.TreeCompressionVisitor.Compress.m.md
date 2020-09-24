# TreeCompressionVisitor.Compress Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Compression](ExpressionPowerTools.Serialization.Compression.n.md) > [TreeCompressionVisitor](ExpressionPowerTools.Serialization.Compression.TreeCompressionVisitor.cs.md) > **Compress**

Compress the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree by collapsing logical nodes that
            can be evaluated.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Compress(Expression source)](#compressexpression-source) | Compress the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree by collapsing logical nodes that            can be evaluated. |
## Compress(Expression source)

Compress the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree by collapsing logical nodes that
            can be evaluated.

```csharp
public Expression Compress(Expression source)
```

### Return Type

 [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression)  - The compressed [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to compress. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:57:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

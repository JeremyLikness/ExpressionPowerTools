# ExpressionEnumerator Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.n.md) > **ExpressionEnumerator**

Recurse an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

```csharp
public class ExpressionEnumerator : IExpressionEnumerator
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExpressionEnumerator**

Implements  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ExpressionEnumerator(Expression expr)](ExpressionPowerTools.Core.ExpressionEnumerator.ctor.md#expressionenumeratorexpression-expr) | Initializes a new instance of the [ExpressionEnumerator](ExpressionPowerTools.Core.ExpressionEnumerator.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [IEnumerator&lt;Expression> GetEnumerator()](ExpressionPowerTools.Core.ExpressionEnumerator.GetEnumerator.m.md) | Implements [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) . |
| [String ToString()](ExpressionPowerTools.Core.ExpressionEnumerator.ToString.m.md) | String display of the tree. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

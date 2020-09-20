# ICustomQueryProvider&lt;T>.ExecuteEnumerable Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > [ICustomQueryProvider<T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) > **ExecuteEnumerable**

Execute enumeration from the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [ExecuteEnumerable(Expression expression)](#executeenumerableexpression-expression) | Execute enumeration from the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
## ExecuteEnumerable(Expression expression)

Execute enumeration from the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) .

```csharp
public virtual IEnumerable<T> ExecuteEnumerable(Expression expression)
```

### Return Type

 [IEnumerable&lt;T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)  - An instance of [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to enumerate. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/20/2020 6:32:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.9.0-alpha |

# ExecuteEnumerable Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > [QuerySnapshotProvider<T>](ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.cs.md) > **ExecuteEnumerable**

Return the enumerable result.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ExecuteEnumerable(Expression expression)](#executeenumerableexpression-expression) | Return the enumerable result. |
## ExecuteEnumerable(Expression expression)

Return the enumerable result.

```csharp
public virtual IEnumerable<T> ExecuteEnumerable(Expression expression)
```

### Return Type

 [IEnumerable&lt;T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)  - The [IEnumerable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to parse. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when expression is null. |


# CustomQueryProvider&lt;T>.Execute Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > [CustomQueryProvider<T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) > **Execute**

Runs the query and returns the result.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Execute(Expression expression)](#executeexpression-expression) | Runs the query and returns the result. |
| [Execute&lt;TResult>(Expression expression)](#executetresultexpression-expression) | Runs the query and returns the typed result. |
## Execute(Expression expression)

Runs the query and returns the result.

```csharp
public virtual Object Execute(Expression expression)
```

### Return Type

 [Object](https://docs.microsoft.com/dotnet/api/system.object)  - The query result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to use. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throw when expression is null. |

## Execute&lt;TResult>(Expression expression)

Runs the query and returns the typed result.

```csharp
public virtual TResult Execute<TResult>(Expression expression)
```

### Return Type

 [Object](https://docs.microsoft.com/dotnet/api/system.object)  - The query result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The query [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throw when expression is null. |


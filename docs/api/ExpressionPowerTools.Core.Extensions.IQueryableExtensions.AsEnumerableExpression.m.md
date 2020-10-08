# IQueryableExtensions.AsEnumerableExpression Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IQueryableExtensions](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.cs.md) > **AsEnumerableExpression**

Providers a way to enumerate the expression behind a query.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AsEnumerableExpression(IQueryable query)](#asenumerableexpressioniqueryable-query) | Providers a way to enumerate the expression behind a query. |
| [AsEnumerableExpression&lt;T>(IQueryable&lt;T> query)](#asenumerableexpressiontiqueryablet-query) | Generic extension. |
## AsEnumerableExpression(IQueryable query)

Providers a way to enumerate the expression behind a query.

```csharp
public static IExpressionEnumerator AsEnumerableExpression(IQueryable query)
```

### Return Type

 [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md)  - The [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) instance.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The query to enumerate. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when query is null. |

## Examples

For example:

```csharp
var query = new List<IQueryableExtensionsTests>()
                   .AsQueryable()
                   .Where(t => t.GetHashCode() == int.MaxValue);
            var target = query.AsEnumerableExpression();
            
```

## AsEnumerableExpression&lt;T>(IQueryable&lt;T> query)

Generic extension.

```csharp
public static IExpressionEnumerator AsEnumerableExpression<T>(IQueryable<T> query)
```

### Return Type

 [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md)  - The [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

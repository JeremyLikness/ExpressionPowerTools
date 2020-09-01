# IQueryableExtensions Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > **IQueryableExtensions**

Extensions over the [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) interface.

```csharp
public static class IQueryableExtensions
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **IQueryableExtensions**

## Methods

| Method | Description |
| :-- | :-- |
| [IExpressionEnumerator AsEnumerableExpression(IQueryable query)](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.AsEnumerableExpression.m.md) | Providers a way to enumerate the expression behind a query. |
| [IQueryable&lt;T> CreateInterceptedQueryable&lt;T>(IQueryable&lt;T> source, ExpressionTransformer transformation)](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.CreateInterceptedQueryable.m.md) | Creates a query that can transformation the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) wen run. |
| [IQueryable&lt;T> CreateQueryTemplate&lt;T>()](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.CreateQueryTemplate.m.md) | Creates a queryable from an empty list used for templates to compare. |
| [IQuerySnapshotHost&lt;T> CreateSnapshotQueryable&lt;T>(IQueryable&lt;T> source, Action&lt;Expression> callback)](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.CreateSnapshotQueryable.m.md) | Creates a snapshot that allows a registered callback to            inspect the expression when the query is executed. |
| [Boolean HasFragment&lt;T>(IQueryable&lt;T> source, Func&lt;IQueryable&lt;T>, IQueryable&lt;T>> fragment)](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.HasFragment.m.md) | Determine whether a fragment of queryable exists in the            target query. |
| [Boolean IsEquivalentTo(IQueryable source, IQueryable target)](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.IsEquivalentTo.m.md) | Determines whether the expression tree of the query is equivalent to the other query. |
| [Boolean IsSimilarTo(IQueryable source, IQueryable target)](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.IsSimilarTo.m.md) | Determines whether the expression tree of the query is similar to the other query. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |

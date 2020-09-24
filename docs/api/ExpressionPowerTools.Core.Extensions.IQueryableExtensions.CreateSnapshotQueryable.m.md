# IQueryableExtensions.CreateSnapshotQueryable Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IQueryableExtensions](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.cs.md) > **CreateSnapshotQueryable**

Creates a snapshot that allows a registered callback to
            inspect the expression when the query is executed.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CreateSnapshotQueryable&lt;T>(IQueryable&lt;T> source, Action&lt;Expression> callback)](#createsnapshotqueryabletiqueryablet-source-actionexpression-callback) | Creates a snapshot that allows a registered callback to            inspect the expression when the query is executed. |
## CreateSnapshotQueryable&lt;T>(IQueryable&lt;T> source, Action&lt;Expression> callback)

Creates a snapshot that allows a registered callback to
            inspect the expression when the query is executed.

```csharp
public static IQuerySnapshotHost<T> CreateSnapshotQueryable<T>(IQueryable<T> source, Action<Expression> callback)
```

### Return Type

 [IQuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.i.md)  - The query with snapshot applied.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The source query. |
| `callback` | [Action&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.action-1) | The callback. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:57:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

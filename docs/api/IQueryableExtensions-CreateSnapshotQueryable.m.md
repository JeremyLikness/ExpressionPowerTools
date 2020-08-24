# IQueryableExtensions.CreateSnapshotQueryable Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IQueryableExtensions](ExpressionPowerTools.Core.Extensions.IQueryableExtensions.cs.md) > **CreateSnapshotQueryable**



## Overloads

| Overload | Description |
| :-- | :-- |
| [CreateSnapshotQueryable&lt;T>(IQueryable&lt;T> source, Action&lt;Expression> callback)](#createsnapshotqueryabletiqueryablet-source-actionexpression-callback) |  |
## CreateSnapshotQueryable&lt;T>(IQueryable&lt;T> source, Action&lt;Expression> callback)



```csharp
public static IQuerySnapshotHost<T> CreateSnapshotQueryable<T>(IQueryable<T> source, Action<Expression> callback)
```

### Return Type

 [IQuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.i.md) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `source` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) |  |
| `callback` | [Action&lt;Expression>](https://docs.microsoft.com/dotnet/api/system.action-1) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

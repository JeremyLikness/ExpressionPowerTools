﻿# HttpRemoteQueryResolver.ToListAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Transport](ExpressionPowerTools.Serialization.EFCore.Http.Transport.n.md) > [HttpRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.cs.md) > **ToListAsync**

Execute the remote query and materialize the results.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ToListAsync&lt;T>(IQueryable&lt;T> query)](#tolistasynctiqueryablet-query) | Execute the remote query and materialize the results. |
## ToListAsync&lt;T>(IQueryable&lt;T> query)

Execute the remote query and materialize the results.

```csharp
public virtual Task<List<T>> ToListAsync<T>(IQueryable<T> query)
```

### Return Type

 [Task&lt;List&lt;T>>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The base query to run. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

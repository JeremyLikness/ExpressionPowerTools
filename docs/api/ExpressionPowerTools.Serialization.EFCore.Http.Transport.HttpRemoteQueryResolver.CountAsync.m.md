# HttpRemoteQueryResolver.CountAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Transport](ExpressionPowerTools.Serialization.EFCore.Http.Transport.n.md) > [HttpRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.cs.md) > **CountAsync**

Execute the remote query and materialize the count.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CountAsync&lt;T>(IQueryable&lt;T> query)](#countasynctiqueryablet-query) | Execute the remote query and materialize the count. |
## CountAsync&lt;T>(IQueryable&lt;T> query)

Execute the remote query and materialize the count.

```csharp
public virtual Task<Int32> CountAsync<T>(IQueryable<T> query)
```

### Return Type

 [Task&lt;Int32>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The base query to run. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/20/2020 6:32:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.9.0-alpha |

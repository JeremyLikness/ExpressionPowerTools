# HttpRemoteQueryResolver.ToHashSetAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Transport](ExpressionPowerTools.Serialization.EFCore.Http.Transport.n.md) > [HttpRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.cs.md) > **ToHashSetAsync**

Execute the remote query and materialize the results.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ToHashSetAsync&lt;T>(IQueryable&lt;T> query)](#tohashsetasynctiqueryablet-query) | Execute the remote query and materialize the results. |
## ToHashSetAsync&lt;T>(IQueryable&lt;T> query)

Execute the remote query and materialize the results.

```csharp
public virtual Task<HashSet<T>> ToHashSetAsync<T>(IQueryable<T> query)
```

### Return Type

 [Task&lt;HashSet&lt;T>>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The base query to run. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

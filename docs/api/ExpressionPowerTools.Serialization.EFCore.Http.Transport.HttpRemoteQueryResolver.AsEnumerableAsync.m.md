# HttpRemoteQueryResolver.AsEnumerableAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Transport](ExpressionPowerTools.Serialization.EFCore.Http.Transport.n.md) > [HttpRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.cs.md) > **AsEnumerableAsync**

Execute the remote query and materialize the results.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AsEnumerableAsync&lt;T>(IQueryable&lt;T> query)](#asenumerableasynctiqueryablet-query) | Execute the remote query and materialize the results. |
## AsEnumerableAsync&lt;T>(IQueryable&lt;T> query)

Execute the remote query and materialize the results.

```csharp
public virtual Task<IEnumerable<T>> AsEnumerableAsync<T>(IQueryable<T> query)
```

### Return Type

 [Task&lt;IEnumerable&lt;T>>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The base query to run. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/20/2020 6:32:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.9.0-alpha |

# IRemoteQueryResolver.CountAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Signatures](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.n.md) > [IRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.i.md) > **CountAsync**

Resolves to a count..

## Overloads

| Overload | Description |
| :-- | :-- |
| [CountAsync&lt;T>(IQueryable&lt;T> query)](#countasynctiqueryablet-query) | Resolves to a count.. |
## CountAsync&lt;T>(IQueryable&lt;T> query)

Resolves to a count..

```csharp
public virtual Task<Int32> CountAsync<T>(IQueryable<T> query)
```

### Return Type

 [Task&lt;Int32>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The count.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The query to run remotely. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

# IRemoteQueryResolver.ToListAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Signatures](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.n.md) > [IRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.i.md) > **ToListAsync**

Resolves to a list.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ToListAsync&lt;T>(IQueryable&lt;T> query)](#tolistasynctiqueryablet-query) | Resolves to a list. |
## ToListAsync&lt;T>(IQueryable&lt;T> query)

Resolves to a list.

```csharp
public virtual Task<IList<T>> ToListAsync<T>(IQueryable<T> query)
```

### Return Type

 [Task&lt;IList&lt;T>>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The list.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The query to run remotely. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/25/2020 00:25:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

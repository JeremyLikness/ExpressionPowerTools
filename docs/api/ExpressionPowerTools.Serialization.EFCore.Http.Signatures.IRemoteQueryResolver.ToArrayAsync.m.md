# IRemoteQueryResolver.ToArrayAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Signatures](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.n.md) > [IRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.i.md) > **ToArrayAsync**

Resolves to an array.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ToArrayAsync&lt;T>(IQueryable&lt;T> query)](#toarrayasynctiqueryablet-query) | Resolves to an array. |
## ToArrayAsync&lt;T>(IQueryable&lt;T> query)

Resolves to an array.

```csharp
public virtual Task<T[]> ToArrayAsync<T>(IQueryable<T> query)
```

### Return Type

 [Task&lt;T[]>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The array.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The query to run remotely. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

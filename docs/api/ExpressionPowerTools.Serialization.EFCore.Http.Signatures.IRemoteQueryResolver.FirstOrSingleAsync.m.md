# IRemoteQueryResolver.FirstOrSingleAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Signatures](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.n.md) > [IRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.i.md) > **FirstOrSingleAsync**

Returns a single entity.

## Overloads

| Overload | Description |
| :-- | :-- |
| [FirstOrSingleAsync&lt;T>(IQueryable&lt;T> query)](#firstorsingleasynctiqueryablet-query) | Returns a single entity. |
## FirstOrSingleAsync&lt;T>(IQueryable&lt;T> query)

Returns a single entity.

```csharp
public virtual Task<T> FirstOrSingleAsync<T>(IQueryable<T> query)
```

### Return Type

 [Task&lt;T>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The entity.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The query. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

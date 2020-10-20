# IRemoteQueryResolver.ToHashSetAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Signatures](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.n.md) > [IRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.i.md) > **ToHashSetAsync**

Resolves to a hash set.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ToHashSetAsync&lt;T>(IQueryable&lt;T> query)](#tohashsetasynctiqueryablet-query) | Resolves to a hash set. |
## ToHashSetAsync&lt;T>(IQueryable&lt;T> query)

Resolves to a hash set.

```csharp
public virtual Task<HashSet<T>> ToHashSetAsync<T>(IQueryable<T> query)
```

### Return Type

 [Task&lt;HashSet&lt;T>>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The [HashSet&lt;T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.hashset-1) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The query to run remotely. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

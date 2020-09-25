# IRemoteQueryResolver.AsEnumerableAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Signatures](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.n.md) > [IRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.i.md) > **AsEnumerableAsync**

Resolves to an enumerable.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AsEnumerableAsync&lt;T>(IQueryable&lt;T> query)](#asenumerableasynctiqueryablet-query) | Resolves to an enumerable. |
## AsEnumerableAsync&lt;T>(IQueryable&lt;T> query)

Resolves to an enumerable.

```csharp
public virtual Task<IEnumerable<T>> AsEnumerableAsync<T>(IQueryable<T> query)
```

### Return Type

 [Task&lt;IEnumerable&lt;T>>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The enumerable.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The query to run remotely. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/25/2020 00:25:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

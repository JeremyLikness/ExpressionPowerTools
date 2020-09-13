# ClientExtensions.CountAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Extensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.n.md) > [ClientExtensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.cs.md) > **CountAsync**

Provides a count of the query.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CountAsync&lt;T>(IRemoteQueryable&lt;T> query)](#countasynctiremotequeryablet-query) | Provides a count of the query. |
## CountAsync&lt;T>(IRemoteQueryable&lt;T> query)

Provides a count of the query.

```csharp
public static Task<Int32> CountAsync<T>(IRemoteQueryable<T> query)
```

### Return Type

 [Task&lt;Int32>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IRemoteQueryable&lt;T>](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryable`1.i.md) | The query. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

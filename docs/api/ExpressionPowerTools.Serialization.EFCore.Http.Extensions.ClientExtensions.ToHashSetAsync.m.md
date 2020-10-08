# ClientExtensions.ToHashSetAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Extensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.n.md) > [ClientExtensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.cs.md) > **ToHashSetAsync**

Grabs the hash set.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ToHashSetAsync&lt;T>(IRemoteQueryable&lt;T> query)](#tohashsetasynctiremotequeryablet-query) | Grabs the hash set. |
## ToHashSetAsync&lt;T>(IRemoteQueryable&lt;T> query)

Grabs the hash set.

```csharp
public static Task<HashSet<T>> ToHashSetAsync<T>(IRemoteQueryable<T> query)
```

### Return Type

 [Task&lt;HashSet&lt;T>>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IRemoteQueryable&lt;T>](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryable`1.i.md) | The query. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

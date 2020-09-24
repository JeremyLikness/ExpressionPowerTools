# ClientExtensions.FirstOrSingleAsync Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Extensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.n.md) > [ClientExtensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.cs.md) > **FirstOrSingleAsync**

Grabs the first item, or the single item, from the result.

## Overloads

| Overload | Description |
| :-- | :-- |
| [FirstOrSingleAsync&lt;T>(IRemoteQueryable&lt;T> query)](#firstorsingleasynctiremotequeryablet-query) | Grabs the first item, or the single item, from the result. |
## FirstOrSingleAsync&lt;T>(IRemoteQueryable&lt;T> query)

Grabs the first item, or the single item, from the result.

```csharp
public static Task<T> FirstOrSingleAsync<T>(IRemoteQueryable<T> query)
```

### Return Type

 [Task&lt;T>](https://docs.microsoft.com/dotnet/api/system.threading.tasks.task-1)  - The result.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IRemoteQueryable&lt;T>](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryable`1.i.md) | The query. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

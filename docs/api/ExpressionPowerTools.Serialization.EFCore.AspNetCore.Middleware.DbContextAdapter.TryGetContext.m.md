# DbContextAdapter.TryGetContext Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > [DbContextAdapter](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.DbContextAdapter.cs.md) > **TryGetContext**

Tries to match context name with the list of eligible types.

## Overloads

| Overload | Description |
| :-- | :-- |
| [TryGetContext(Type[] eligibleTypes, String context, Type& dbContextType)](#trygetcontexttype[]-eligibletypes-string-context-type&-dbcontexttype) | Tries to match context name with the list of eligible types. |
## TryGetContext(Type[] eligibleTypes, String context, Type& dbContextType)

Tries to match context name with the list of eligible types.

```csharp
public virtual Boolean TryGetContext(Type[] eligibleTypes, String context, Type& dbContextType)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A value indicating whether the match was successful.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `eligibleTypes` | [Type[]](https://docs.microsoft.com/dotnet/api/system.type) | The list of potential [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) types. |
| `context` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The context name. |
| `dbContextType` | [Type&](https://docs.microsoft.com/dotnet/api/system.type&) | The type of the matched [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

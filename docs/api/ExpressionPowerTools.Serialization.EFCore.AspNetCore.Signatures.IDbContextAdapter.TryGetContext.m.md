# IDbContextAdapter.TryGetContext Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.n.md) > [IDbContextAdapter](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IDbContextAdapter.i.md) > **TryGetContext**

Tries to match the text to the context.

## Overloads

| Overload | Description |
| :-- | :-- |
| [TryGetContext(Type[] eligibleTypes, String context, Type& dbContextType)](#trygetcontexttype[]-eligibletypes-string-context-type&-dbcontexttype) | Tries to match the text to the context. |
## TryGetContext(Type[] eligibleTypes, String context, Type& dbContextType)

Tries to match the text to the context.

```csharp
public virtual Boolean TryGetContext(Type[] eligibleTypes, String context, Type& dbContextType)
```

### Return Type

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean)  - A value indicating whether nor not the collection on the context is valid.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `eligibleTypes` | [Type[]](https://docs.microsoft.com/dotnet/api/system.type) | The list of registered [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) types. |
| `context` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The name of the `DbContext` . |
| `dbContextType` | [Type&](https://docs.microsoft.com/dotnet/api/system.type&) | The resolved type. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

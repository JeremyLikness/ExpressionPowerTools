# QueryDeserializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > **QueryDeserializer**

Resonsible for deserializing the query to run.

```csharp
public class QueryDeserializer : IQueryDeserializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **QueryDeserializer**

Implements  [IQueryDeserializer](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IQueryDeserializer.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [QueryDeserializer()](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryDeserializer.ctor.md#querydeserializer) | Initializes a new instance of the [QueryDeserializer](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryDeserializer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Task&lt;QueryResult> DeserializeAsync(IQueryable template, Stream json, ILogger logger)](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryDeserializer.DeserializeAsync.m.md) | Deserializes the query. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

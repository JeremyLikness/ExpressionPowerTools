# QueryResultSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > **QueryResultSerializer**

Responsible for serializing the result to send back.

```csharp
public class QueryResultSerializer : IQueryResultSerializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **QueryResultSerializer**

Implements  [IQueryResultSerializer](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IQueryResultSerializer.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [QueryResultSerializer()](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryResultSerializer.ctor.md#queryresultserializer) | Initializes a new instance of the [QueryResultSerializer](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryResultSerializer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Task SerializeAsync(Stream response, IQueryable query, PayloadType type)](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryResultSerializer.SerializeAsync.m.md) | Serializes the result of a query to the stream. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

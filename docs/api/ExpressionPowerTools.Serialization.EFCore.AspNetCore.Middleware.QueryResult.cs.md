# QueryResult Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > **QueryResult**

Represents the result of deserializing a query payload.

```csharp
public class QueryResult
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **QueryResult**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [QueryResult()](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryResult.ctor.md#queryresult) | Initializes a new instance of the [QueryResult](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryResult.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`IsCount`](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryResult.IsCount.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether the query is a count operation. |
| [`Query`](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.QueryResult.Query.prop.md) | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | Gets or sets the query. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |

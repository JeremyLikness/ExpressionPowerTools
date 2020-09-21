# RouteProcessor.ParseRoute Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.n.md) > [RouteProcessor](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware.RouteProcessor.cs.md) > **ParseRoute**

Parses the required segments from the path.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ParseRoute(RouteValueDictionary values)](#parserouteroutevaluedictionary-values) | Parses the required segments from the path. |
## ParseRoute(RouteValueDictionary values)

Parses the required segments from the path.

```csharp
public virtual ValueTuple<String, String> ParseRoute(RouteValueDictionary values)
```

### Return Type

 [ValueTuple&lt;String, String>](https://docs.microsoft.com/dotnet/api/system.valuetuple-2)  - The parsed portions.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `values` | [RouteValueDictionary](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.routing.routevaluedictionary) | The route values. |


## Remarks

Expected is `/root/contextName/collectionName` .


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/21/2020 19:07:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

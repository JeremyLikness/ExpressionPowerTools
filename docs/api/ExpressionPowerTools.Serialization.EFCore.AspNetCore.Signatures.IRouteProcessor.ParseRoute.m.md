# IRouteProcessor.ParseRoute Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.n.md) > [IRouteProcessor](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures.IRouteProcessor.i.md) > **ParseRoute**

Parse the path for segments.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ParseRoute(RouteValueDictionary route)](#parserouteroutevaluedictionary-route) | Parse the path for segments. |
## ParseRoute(RouteValueDictionary route)

Parse the path for segments.

```csharp
public virtual ValueTuple<String, String> ParseRoute(RouteValueDictionary route)
```

### Return Type

 [ValueTuple&lt;String, String>](https://docs.microsoft.com/dotnet/api/system.valuetuple-2)  - A tuple with the name of the `DbContext` and the collection.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `route` | [RouteValueDictionary](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.routing.routevaluedictionary) | The route. |


## Remarks

Expects it in the format `/root/contextName/collectionName` .


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:47:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

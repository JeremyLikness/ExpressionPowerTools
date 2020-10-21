# ClientHttpConfiguration.SetPathTemplate Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Configuration](ExpressionPowerTools.Serialization.EFCore.Http.Configuration.n.md) > [ClientHttpConfiguration](ExpressionPowerTools.Serialization.EFCore.Http.Configuration.ClientHttpConfiguration.cs.md) > **SetPathTemplate**

Set the path template.

## Overloads

| Overload | Description |
| :-- | :-- |
| [SetPathTemplate(String pathTemplate)](#setpathtemplatestring-pathtemplate) | Set the path template. |
## SetPathTemplate(String pathTemplate)

Set the path template.

```csharp
public virtual IClientHttpConfiguration SetPathTemplate(String pathTemplate)
```

### Return Type

 [IClientHttpConfiguration](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IClientHttpConfiguration.i.md)  - The [IClientHttpConfiguration](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IClientHttpConfiguration.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `pathTemplate` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The path template. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) | Thrown when path template is null, empty, or does not contain the proper segments. |

## Remarks

This is used to compose the URL for the query request. It must contain
            a reference to `{context}` and `{collection}` . The default
            is `/efcore/{context}/{collection}` so a [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) named ProductsContext with a list named Products will resolve to `/efcore/ProductsContext/Products` .


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

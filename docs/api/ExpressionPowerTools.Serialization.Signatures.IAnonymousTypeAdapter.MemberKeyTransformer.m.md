# IAnonymousTypeAdapter.MemberKeyTransformer Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IAnonymousTypeAdapter](ExpressionPowerTools.Serialization.Signatures.IAnonymousTypeAdapter.i.md) > **MemberKeyTransformer**

Parses a type to swap (i.e. anonymous to [ExpandoObject](https://docs.microsoft.com/dotnet/api/system.dynamic.expandoobject) ).

## Overloads

| Overload | Description |
| :-- | :-- |
| [MemberKeyTransformer(String memberToTransform)](#memberkeytransformerstring-membertotransform) | Parses a type to swap (i.e. anonymous to [ExpandoObject](https://docs.microsoft.com/dotnet/api/system.dynamic.expandoobject) ). |
## MemberKeyTransformer(String memberToTransform)

Parses a type to swap (i.e. anonymous to [ExpandoObject](https://docs.microsoft.com/dotnet/api/system.dynamic.expandoobject) ).

```csharp
public virtual String MemberKeyTransformer(String memberToTransform)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The transformed typed.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `memberToTransform` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The type to transform. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/25/2020 00:25:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

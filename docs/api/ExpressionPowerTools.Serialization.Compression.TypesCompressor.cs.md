# TypesCompressor Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Compression](ExpressionPowerTools.Serialization.Compression.n.md) > **TypesCompressor**

Simple type compression.

```csharp
public class TypesCompressor : ITypesCompressor
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **TypesCompressor**

Implements  [ITypesCompressor](ExpressionPowerTools.Serialization.Signatures.ITypesCompressor.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [TypesCompressor()](ExpressionPowerTools.Serialization.Compression.TypesCompressor.ctor.md#typescompressor) | Initializes a new instance of the [TypesCompressor](ExpressionPowerTools.Serialization.Compression.TypesCompressor.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Void CompressTypeIndex(List&lt;String> typeIndex)](ExpressionPowerTools.Serialization.Compression.TypesCompressor.CompressTypeIndex.m.md) | Recursively compresses the type index. |
| [Void CompressTypes(List&lt;String> typeIndex, ValueTuple keys)](ExpressionPowerTools.Serialization.Compression.TypesCompressor.CompressTypes.m.md) |  |
| [Void DecompressTypes(List&lt;String> typeIndex, ValueTuple keys)](ExpressionPowerTools.Serialization.Compression.TypesCompressor.DecompressTypes.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

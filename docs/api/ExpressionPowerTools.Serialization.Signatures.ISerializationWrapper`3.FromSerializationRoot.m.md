# ISerializationWrapper&lt;T, TSerializeOptions, TDeserializeOptions>.FromSerializationRoot Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [ISerializationWrapper<T, TSerializeOptions, TDeserializeOptions>](ExpressionPowerTools.Serialization.Signatures.ISerializationWrapper`3.i.md) > **FromSerializationRoot**

Serialize the root.

## Overloads

| Overload | Description |
| :-- | :-- |
| [FromSerializationRoot(SerializationRoot root, TSerializeOptions options)](#fromserializationrootserializationroot-root-tserializeoptions-options) | Serialize the root. |
## FromSerializationRoot(SerializationRoot root, TSerializeOptions options)

Serialize the root.

```csharp
public virtual T FromSerializationRoot(SerializationRoot root, TSerializeOptions options)
```

### Return Type

T - The target type for the serializer.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `root` | [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) | The [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) . |
| `options` | TSerializeOptions | The options. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 5:26:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

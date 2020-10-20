# ISerializationWrapper&lt;T, TSerializeOptions, TDeserializeOptions>.ToSerializationRoot Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [ISerializationWrapper<T, TSerializeOptions, TDeserializeOptions>](ExpressionPowerTools.Serialization.Signatures.ISerializationWrapper`3.i.md) > **ToSerializationRoot**

Deserialize the root.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ToSerializationRoot(T serialized, TDeserializeOptions options)](#toserializationroott-serialized-tdeserializeoptions-options) | Deserialize the root. |
## ToSerializationRoot(T serialized, TDeserializeOptions options)

Deserialize the root.

```csharp
public virtual SerializationRoot ToSerializationRoot(T serialized, TDeserializeOptions options)
```

### Return Type

 [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md)  - The [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `serialized` | T | The serialized expression. |
| `options` | TDeserializeOptions | The options. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 18:50:36 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

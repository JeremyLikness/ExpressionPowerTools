# ISerializationWrapper&lt;T, TSerializeOptions, TDeserializeOptions> Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > **ISerializationWrapper<T, TSerializeOptions, TDeserializeOptions>**

Wrapper for serialization of a specific type.

```csharp
public interface ISerializationWrapper<T, TSerializeOptions, TDeserializeOptions>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. | The type that the serializer deals with. |
| `TSerializeOptions` | The parameter must be a reference type. | Any options needed for the serializer. |
| `TDeserializeOptions` | The parameter must be a reference type. | Any options needed for the deserializer. |

Derived  [JsonWrapper](ExpressionPowerTools.Serialization.Json.JsonWrapper.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [T FromSerializationRoot(SerializationRoot root, TSerializeOptions options)](ExpressionPowerTools.Serialization.Signatures.ISerializationWrapper`3.FromSerializationRoot.m.md) | Serialize the root. |
| [SerializationRoot ToSerializationRoot(T serialized, TDeserializeOptions options)](ExpressionPowerTools.Serialization.Signatures.ISerializationWrapper`3.ToSerializationRoot.m.md) | Deserialize the root. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 5:26:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

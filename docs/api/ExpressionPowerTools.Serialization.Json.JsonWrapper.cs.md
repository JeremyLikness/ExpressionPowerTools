# JsonWrapper Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > **JsonWrapper**

Wrapper for serializing/deserializing to Json using [JsonSerializer](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializer) .

```csharp
public class JsonWrapper : ISerializationWrapper<String, JsonSerializerOptions, JsonSerializerOptions>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **JsonWrapper**

Implements  [ISerializationWrapper&lt;T, TSerializeOptions, TDeserializeOptions>](ExpressionPowerTools.Serialization.Signatures.ISerializationWrapper`3.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [JsonWrapper()](ExpressionPowerTools.Serialization.Json.JsonWrapper.ctor.md#jsonwrapper) | Initializes a new instance of the [JsonWrapper](ExpressionPowerTools.Serialization.Json.JsonWrapper.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [String FromSerializationRoot(SerializationRoot root, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Json.JsonWrapper.FromSerializationRoot.m.md) | Serialize the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) . |
| [SerializationRoot ToSerializationRoot(String serialized, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Json.JsonWrapper.ToSerializationRoot.m.md) | Deserialize to a [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

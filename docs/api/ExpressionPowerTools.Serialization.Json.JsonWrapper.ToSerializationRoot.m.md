# JsonWrapper.ToSerializationRoot Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > [JsonWrapper](ExpressionPowerTools.Serialization.Json.JsonWrapper.cs.md) > **ToSerializationRoot**

Deserialize to a [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [ToSerializationRoot(String serialized, JsonSerializerOptions options)](#toserializationrootstring-serialized-jsonserializeroptions-options) | Deserialize to a [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) . |
## ToSerializationRoot(String serialized, JsonSerializerOptions options)

Deserialize to a [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) .

```csharp
public virtual SerializationRoot ToSerializationRoot(String serialized, JsonSerializerOptions options)
```

### Return Type

 [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md)  - The [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `serialized` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The serialized json. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The deserialization options. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 5:26:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

# JsonWrapper.FromSerializationRoot Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > [JsonWrapper](ExpressionPowerTools.Serialization.Json.JsonWrapper.cs.md) > **FromSerializationRoot**

Serialize the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [FromSerializationRoot(SerializationRoot root, JsonSerializerOptions options)](#fromserializationrootserializationroot-root-jsonserializeroptions-options) | Serialize the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) . |
## FromSerializationRoot(SerializationRoot root, JsonSerializerOptions options)

Serialize the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) .

```csharp
public virtual String FromSerializationRoot(SerializationRoot root, JsonSerializerOptions options)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The serialized json in text.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `root` | [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) | The [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) . |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The serialization options. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

# SerializableExpressionConverter.Write Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > [SerializableExpressionConverter](ExpressionPowerTools.Serialization.Json.SerializableExpressionConverter.cs.md) > **Write**

Write the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Write(Utf8JsonWriter writer, SerializableExpression value, JsonSerializerOptions options)](#writeutf8jsonwriter-writer-serializableexpression-value-jsonserializeroptions-options) | Write the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |
## Write(Utf8JsonWriter writer, SerializableExpression value, JsonSerializerOptions options)

Write the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

```csharp
public virtual Void Write(Utf8JsonWriter writer, SerializableExpression value, JsonSerializerOptions options)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `writer` | [Utf8JsonWriter](https://docs.microsoft.com/dotnet/api/system.text.json.utf8jsonwriter) | The writer. |
| `value` | [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) | The value to write. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The options. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

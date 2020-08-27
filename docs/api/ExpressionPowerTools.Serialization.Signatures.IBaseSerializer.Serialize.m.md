# IBaseSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) > **Serialize**

Serialize to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(Expression expression, JsonSerializerOptions options)](#serializeexpression-expression-jsonserializeroptions-options) | Serialize to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |
## Serialize(Expression expression, JsonSerializerOptions options)

Serialize to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

```csharp
public virtual SerializableExpression Serialize(Expression expression, JsonSerializerOptions options)
```

### Return Type

 [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md)  - The [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to serialize. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

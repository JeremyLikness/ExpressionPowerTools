# BaseSerializer&lt;TExpression, TSerializable>.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [BaseSerializer<TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) > **Serialize**

Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(TExpression expression, JsonSerializerOptions options)](#serializetexpression-expression-jsonserializeroptions-options) | Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |
## Serialize(TExpression expression, JsonSerializerOptions options)

Serialize an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

```csharp
public virtual TSerializable Serialize(TExpression expression, JsonSerializerOptions options)
```

### Return Type

TSerializable - The [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | TExpression | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to serialize. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

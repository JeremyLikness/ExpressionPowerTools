# NewArraySerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [NewArraySerializer](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.cs.md) > **Serialize**

Serialize a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) to a [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(NewArrayExpression expression, JsonSerializerOptions options)](#serializenewarrayexpression-expression-jsonserializeroptions-options) | Serialize a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) to a [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) . |
## Serialize(NewArrayExpression expression, JsonSerializerOptions options)

Serialize a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) to a [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) .

```csharp
public virtual NewArray Serialize(NewArrayExpression expression, JsonSerializerOptions options)
```

### Return Type

 [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md)  - The [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) | The [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) . |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

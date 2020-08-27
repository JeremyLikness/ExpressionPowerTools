# LambdaSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) > **Serialize**

Serialize a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) to a [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(LambdaExpression expression, JsonSerializerOptions options)](#serializelambdaexpression-expression-jsonserializeroptions-options) | Serialize a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) to a [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) . |
## Serialize(LambdaExpression expression, JsonSerializerOptions options)

Serialize a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) to a [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) .

```csharp
public virtual Lambda Serialize(LambdaExpression expression, JsonSerializerOptions options)
```

### Return Type

 [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md)  - The [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) | The [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) . |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

# InvocationSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [InvocationSerializer](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.cs.md) > **Serialize**

Serialize an [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) to an [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(InvocationExpression expression, JsonSerializerOptions options)](#serializeinvocationexpression-expression-jsonserializeroptions-options) | Serialize an [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) to an [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) . |
## Serialize(InvocationExpression expression, JsonSerializerOptions options)

Serialize an [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) to an [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) .

```csharp
public virtual Invocation Serialize(InvocationExpression expression, JsonSerializerOptions options)
```

### Return Type

 [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md)  - The [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) | The [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) . |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

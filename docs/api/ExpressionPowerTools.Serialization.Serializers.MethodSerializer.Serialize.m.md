# MethodSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [MethodSerializer](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.cs.md) > **Serialize**

Serialize a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(MethodCallExpression expression, JsonSerializerOptions options)](#serializemethodcallexpression-expression-jsonserializeroptions-options) | Serialize a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) . |
## Serialize(MethodCallExpression expression, JsonSerializerOptions options)

Serialize a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

```csharp
public virtual MethodExpr Serialize(MethodCallExpression expression, JsonSerializerOptions options)
```

### Return Type

 [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md)  - The serializable [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) | The [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) to serialize. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

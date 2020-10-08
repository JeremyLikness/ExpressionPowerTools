# MethodSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [MethodSerializer](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.cs.md) > **Serialize**

Serialize a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(MethodCallExpression expression, SerializationState state)](#serializemethodcallexpression-expression-serializationstate-state) | Serialize a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) . |
## Serialize(MethodCallExpression expression, SerializationState state)

Serialize a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

```csharp
public virtual MethodExpr Serialize(MethodCallExpression expression, SerializationState state)
```

### Return Type

 [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md)  - The serializable [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) | The [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) to serialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State, such as [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) , for the serialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

# MethodSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [MethodSerializer](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.cs.md) > **Deserialize**

Deserialize a [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) to a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(MethodExpr method, SerializationState state)](#deserializemethodexpr-method-serializationstate-state) | Deserialize a [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) to a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) . |
## Deserialize(MethodExpr method, SerializationState state)

Deserialize a [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) to a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

```csharp
public virtual MethodCallExpression Deserialize(MethodExpr method, SerializationState state)
```

### Return Type

 [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression)  - The [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `method` | [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) | The [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) to deserialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

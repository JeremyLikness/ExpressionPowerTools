# InvocationSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [InvocationSerializer](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.cs.md) > **Deserialize**

Deserializes a [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(Invocation expr, SerializationState state)](#deserializeinvocation-expr-serializationstate-state) | Deserializes a [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) . |
## Deserialize(Invocation expr, SerializationState state)

Deserializes a [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) .

```csharp
public virtual InvocationExpression Deserialize(Invocation expr, SerializationState state)
```

### Return Type

 [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression)  - The [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expr` | [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) | The serialized fragment. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

# InvocationSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [InvocationSerializer](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.cs.md) > **Serialize**

Serialize an [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) to an [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(InvocationExpression expression, SerializationState state)](#serializeinvocationexpression-expression-serializationstate-state) | Serialize an [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) to an [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) . |
## Serialize(InvocationExpression expression, SerializationState state)

Serialize an [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) to an [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) .

```csharp
public virtual Invocation Serialize(InvocationExpression expression, SerializationState state)
```

### Return Type

 [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md)  - The [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) | The [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) . |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

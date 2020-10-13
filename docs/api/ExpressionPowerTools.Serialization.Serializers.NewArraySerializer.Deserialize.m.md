# NewArraySerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [NewArraySerializer](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.cs.md) > **Deserialize**

Deserializes a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(NewArray newArray, SerializationState state)](#deserializenewarray-newarray-serializationstate-state) | Deserializes a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) . |
## Deserialize(NewArray newArray, SerializationState state)

Deserializes a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) .

```csharp
public virtual NewArrayExpression Deserialize(NewArray newArray, SerializationState state)
```

### Return Type

 [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression)  - The [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `newArray` | [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) | The serialized fragment. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 5:26:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

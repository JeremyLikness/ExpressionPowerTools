# NewArraySerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [NewArraySerializer](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.cs.md) > **Serialize**

Serialize a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) to a [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(NewArrayExpression expression, SerializationState state)](#serializenewarrayexpression-expression-serializationstate-state) | Serialize a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) to a [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) . |
## Serialize(NewArrayExpression expression, SerializationState state)

Serialize a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) to a [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) .

```csharp
public virtual NewArray Serialize(NewArrayExpression expression, SerializationState state)
```

### Return Type

 [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md)  - The [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) | The [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) . |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State, such as [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) , for the serialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

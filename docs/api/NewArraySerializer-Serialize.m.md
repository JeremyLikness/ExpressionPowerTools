# NewArraySerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [NewArraySerializer](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.cs.md) > **Serialize**

Serialize a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) to a [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(NewArrayExpression expression)](#serializenewarrayexpression-expression) | Serialize a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) to a [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) . |
## Serialize(NewArrayExpression expression)

Serialize a [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) to a [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) .

```csharp
public virtual NewArray Serialize(NewArrayExpression expression)
```

### Return Type

 [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md)  - The [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) | The [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

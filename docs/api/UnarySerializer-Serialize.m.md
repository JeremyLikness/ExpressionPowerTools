# UnarySerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [UnarySerializer](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.cs.md) > **Serialize**

Serialize a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) to a [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(UnaryExpression expression)](#serializeunaryexpression-expression) | Serialize a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) to a [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) . |
## Serialize(UnaryExpression expression)

Serialize a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) to a [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) .

```csharp
public virtual Unary Serialize(UnaryExpression expression)
```

### Return Type

 [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md)  - The [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) | The [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/23/2020 9:59:26 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

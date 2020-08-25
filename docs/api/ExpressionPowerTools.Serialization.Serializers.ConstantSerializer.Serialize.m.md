# ConstantSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ConstantSerializer](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.cs.md) > **Serialize**

Serializes the expression.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(ConstantExpression expression)](#serializeconstantexpression-expression) | Serializes the expression. |
## Serialize(ConstantExpression expression)

Serializes the expression.

```csharp
public virtual Constant Serialize(ConstantExpression expression)
```

### Return Type

 [Constant](ExpressionPowerTools.Serialization.Serializers.Constant.cs.md)  - The serializable [Constant](ExpressionPowerTools.Serialization.Serializers.Constant.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) | The [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) to serialize. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 6:00:34 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

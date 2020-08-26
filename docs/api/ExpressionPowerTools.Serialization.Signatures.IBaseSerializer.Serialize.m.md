# IBaseSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) > **Serialize**

Serialize to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(Expression expression)](#serializeexpression-expression) | Serialize to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) . |
## Serialize(Expression expression)

Serialize to a [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

```csharp
public virtual SerializableExpression Serialize(Expression expression)
```

### Return Type

 [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md)  - The [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to serialize. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/26/2020 6:58:17 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

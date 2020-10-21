# Binary Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **Binary**

Represents a serializable [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) .

```csharp
public class Binary : SerializableExpression
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) → **Binary**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Binary()](ExpressionPowerTools.Serialization.Serializers.Binary.ctor.md#binary) | Initializes a new instance of the [Binary](ExpressionPowerTools.Serialization.Serializers.Binary.cs.md) class. |
| [Binary(BinaryExpression expression)](ExpressionPowerTools.Serialization.Serializers.Binary.ctor.md#binarybinaryexpression-expression) | Initializes a new instance of the [Binary](ExpressionPowerTools.Serialization.Serializers.Binary.cs.md) class and            initialies with a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) . |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`BinaryMethod`](ExpressionPowerTools.Serialization.Serializers.Binary.BinaryMethod.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the related method. |
| [`Conversion`](ExpressionPowerTools.Serialization.Serializers.Binary.Conversion.prop.md) | [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) | Gets or sets the [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) for conversion. |
| [`Left`](ExpressionPowerTools.Serialization.Serializers.Binary.Left.prop.md) | [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) | Gets or sets the left expression. |
| [`LiftToNull`](ExpressionPowerTools.Serialization.Serializers.Binary.LiftToNull.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether it is lifted to null. |
| [`Right`](ExpressionPowerTools.Serialization.Serializers.Binary.Right.prop.md) | [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) | Gets or sets the right expression. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

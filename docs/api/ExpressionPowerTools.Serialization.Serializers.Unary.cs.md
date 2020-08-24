# Unary Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **Unary**

Serializable version of the [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) .

```csharp
public class Unary : SerializableExpression
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) → **Unary**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Unary()](ExpressionPowerTools.Serialization.Serializers.Unary.ctor.md#unary) | Initializes a new instance of the [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) class. |
| [Unary(UnaryExpression expression)](ExpressionPowerTools.Serialization.Serializers.Unary.ctor.md#unaryunaryexpression-expression) | Initializes a new instance of the [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) class and            initialies with a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) . |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Operand`](ExpressionPowerTools.Serialization.Serializers.Unary.Operand.prop.md) | [Object](https://docs.microsoft.com/dotnet/api/system.object) | Gets or sets the operand or main [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) for the operation. |
| [`UnaryMethod`](ExpressionPowerTools.Serialization.Serializers.Unary.UnaryMethod.prop.md) | [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) | Gets or sets the [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) this expression uses. |
| [`UnaryType`](ExpressionPowerTools.Serialization.Serializers.Unary.UnaryType.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the full type of the [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) . |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 11:34:48 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

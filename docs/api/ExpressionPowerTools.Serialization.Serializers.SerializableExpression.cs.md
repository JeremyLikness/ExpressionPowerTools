# SerializableExpression Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **SerializableExpression**

Class for serialization expressions.

```csharp
public class SerializableExpression
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **SerializableExpression**

Derived  [Constant](ExpressionPowerTools.Serialization.Serializers.Constant.cs.md) ,  [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) ,  [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) ,  [Parameter](ExpressionPowerTools.Serialization.Serializers.Parameter.cs.md) ,  [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [SerializableExpression()](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.ctor.md#serializableexpression) | Initializes a new instance of the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) class. |
| [SerializableExpression(Expression expression)](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.ctor.md#serializableexpressionexpression-expression) | Initializes a new instance of the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) class and captures            the [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) of the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) passed in. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Type`](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.Type.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the type of the expression. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

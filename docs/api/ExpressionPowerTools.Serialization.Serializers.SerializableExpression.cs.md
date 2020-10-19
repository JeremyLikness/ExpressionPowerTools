# SerializableExpression Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **SerializableExpression**

Class for serialization expressions.

```csharp
public class SerializableExpression
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **SerializableExpression**

Derived  [Binary](ExpressionPowerTools.Serialization.Serializers.Binary.cs.md) ,  [Constant](ExpressionPowerTools.Serialization.Serializers.Constant.cs.md) ,  [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) ,  [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) ,  [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) ,  [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) ,  [MemberInit](ExpressionPowerTools.Serialization.Serializers.MemberInit.cs.md) ,  [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) ,  [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) ,  [Parameter](ExpressionPowerTools.Serialization.Serializers.Parameter.cs.md) ,  [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [SerializableExpression()](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.ctor.md#serializableexpression) | Initializes a new instance of the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) class. |
| [SerializableExpression(Expression expression)](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.ctor.md#serializableexpressionexpression-expression) | Initializes a new instance of the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) class and captures            the [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) of the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) passed in. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Type`](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.Type.prop.md) | [Int32](https://docs.microsoft.com/dotnet/api/system.int32) | Gets or sets the type of the expression. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |

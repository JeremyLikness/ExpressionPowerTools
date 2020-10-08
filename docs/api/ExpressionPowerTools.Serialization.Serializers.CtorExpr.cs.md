# CtorExpr Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **CtorExpr**

Represents a serializable [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) .

```csharp
public class CtorExpr : SerializableExpression
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) → **CtorExpr**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [CtorExpr()](ExpressionPowerTools.Serialization.Serializers.CtorExpr.ctor.md#ctorexpr) | Initializes a new instance of the [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) class. |
| [CtorExpr(NewExpression ctor)](ExpressionPowerTools.Serialization.Serializers.CtorExpr.ctor.md#ctorexprnewexpression-ctor) | Initializes a new instance of the [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) class            initialized with a [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) . |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Arguments`](ExpressionPowerTools.Serialization.Serializers.CtorExpr.Arguments.prop.md) | [List&lt;Object>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the method's object. |
| [`CtorInfo`](ExpressionPowerTools.Serialization.Serializers.CtorExpr.CtorInfo.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the serializable [ConstructorInfo](https://docs.microsoft.com/dotnet/api/system.reflection.constructorinfo) . |
| [`MemberKeys`](ExpressionPowerTools.Serialization.Serializers.CtorExpr.MemberKeys.prop.md) | [List&lt;String>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the keys of members. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |

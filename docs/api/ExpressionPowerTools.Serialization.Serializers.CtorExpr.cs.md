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
| [`CtorInfo`](ExpressionPowerTools.Serialization.Serializers.CtorExpr.CtorInfo.prop.md) | [Ctor](ExpressionPowerTools.Serialization.Serializers.Ctor.cs.md) | Gets or sets the serializable [ConstructorInfo](https://docs.microsoft.com/dotnet/api/system.reflection.constructorinfo) . |
| [`Fields`](ExpressionPowerTools.Serialization.Serializers.CtorExpr.Fields.prop.md) | [List&lt;Field>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the field list. |
| [`Members`](ExpressionPowerTools.Serialization.Serializers.CtorExpr.Members.prop.md) | [List&lt;MemberBase>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the members. |
| [`MemberTypeList`](ExpressionPowerTools.Serialization.Serializers.CtorExpr.MemberTypeList.prop.md) | [List&lt;Int32>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the list of member types. |
| [`Properties`](ExpressionPowerTools.Serialization.Serializers.CtorExpr.Properties.prop.md) | [List&lt;Property>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the property list. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

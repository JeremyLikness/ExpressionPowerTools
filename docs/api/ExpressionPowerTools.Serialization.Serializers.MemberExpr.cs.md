# MemberExpr Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **MemberExpr**

Helper to serialize a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) .

```csharp
public class MemberExpr : SerializableExpression
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) → **MemberExpr**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [MemberExpr()](ExpressionPowerTools.Serialization.Serializers.MemberExpr.ctor.md#memberexpr) | Initializes a new instance of the [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) class. |
| [MemberExpr(MemberExpression member)](ExpressionPowerTools.Serialization.Serializers.MemberExpr.ctor.md#memberexprmemberexpression-member) | Initializes a new instance of the [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) class            initialized with a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) . |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Expression`](ExpressionPowerTools.Serialization.Serializers.MemberExpr.Expression.prop.md) | [Object](https://docs.microsoft.com/dotnet/api/system.object) | Gets or sets the method's object. |
| [`FieldInfo`](ExpressionPowerTools.Serialization.Serializers.MemberExpr.FieldInfo.prop.md) | [Field](ExpressionPowerTools.Serialization.Serializers.Field.cs.md) | Gets or sets the serializable [FieldInfo](ExpressionPowerTools.Serialization.Serializers.MemberExpr.FieldInfo.prop.md) . |
| [`MemberType`](ExpressionPowerTools.Serialization.Serializers.MemberExpr.MemberType.prop.md) | [Int32](https://docs.microsoft.com/dotnet/api/system.int32) | Gets or sets the member type. |
| [`PropertyInfo`](ExpressionPowerTools.Serialization.Serializers.MemberExpr.PropertyInfo.prop.md) | [Property](ExpressionPowerTools.Serialization.Serializers.Property.cs.md) | Gets or sets the serializable [PropertyInfo](ExpressionPowerTools.Serialization.Serializers.MemberExpr.PropertyInfo.prop.md) . |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

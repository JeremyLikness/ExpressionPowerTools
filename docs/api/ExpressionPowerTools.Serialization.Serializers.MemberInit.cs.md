# MemberInit Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **MemberInit**

Serializable representation of [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) .

```csharp
public class MemberInit : SerializableExpression
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) → **MemberInit**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [MemberInit()](ExpressionPowerTools.Serialization.Serializers.MemberInit.ctor.md#memberinit) | Initializes a new instance of the [MemberInit](ExpressionPowerTools.Serialization.Serializers.MemberInit.cs.md) class. |
| [MemberInit(MemberInitExpression memberInit)](ExpressionPowerTools.Serialization.Serializers.MemberInit.ctor.md#memberinitmemberinitexpression-memberinit) | Initializes a new instance of the [MemberInit](ExpressionPowerTools.Serialization.Serializers.MemberInit.cs.md) class with            the related [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) . |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Bindings`](ExpressionPowerTools.Serialization.Serializers.MemberInit.Bindings.prop.md) | [List&lt;MemberBindingExpr>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the list of bindings. |
| [`NewExpression`](ExpressionPowerTools.Serialization.Serializers.MemberInit.NewExpression.prop.md) | [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) | Gets or sets the expression to initialize. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

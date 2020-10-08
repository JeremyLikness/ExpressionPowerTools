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
| [`Indexer`](ExpressionPowerTools.Serialization.Serializers.MemberExpr.Indexer.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the indexer property. |
| [`IndexerTypeKey`](ExpressionPowerTools.Serialization.Serializers.MemberExpr.IndexerTypeKey.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the indexer type key. |
| [`MemberTypeKey`](ExpressionPowerTools.Serialization.Serializers.MemberExpr.MemberTypeKey.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the member type key. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

# MemberSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [MemberSerializer](ExpressionPowerTools.Serialization.Serializers.MemberSerializer.cs.md) > **Deserialize**

Deserialize a [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) to a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(MemberExpr member, SerializationState state)](#deserializememberexpr-member-serializationstate-state) | Deserialize a [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) to a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) . |
## Deserialize(MemberExpr member, SerializationState state)

Deserialize a [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) to a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) .

```csharp
public virtual MemberExpression Deserialize(MemberExpr member, SerializationState state)
```

### Return Type

 [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression)  - The [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) | The [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) to deserialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

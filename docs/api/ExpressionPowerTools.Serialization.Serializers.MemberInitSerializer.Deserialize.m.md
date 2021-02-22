# MemberInitSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [MemberInitSerializer](ExpressionPowerTools.Serialization.Serializers.MemberInitSerializer.cs.md) > **Deserialize**

Deserialize a [MemberInit](ExpressionPowerTools.Serialization.Serializers.MemberInit.cs.md) to a [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(MemberInit memberInit, SerializationState state)](#deserializememberinit-memberinit-serializationstate-state) | Deserialize a [MemberInit](ExpressionPowerTools.Serialization.Serializers.MemberInit.cs.md) to a [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) . |
## Deserialize(MemberInit memberInit, SerializationState state)

Deserialize a [MemberInit](ExpressionPowerTools.Serialization.Serializers.MemberInit.cs.md) to a [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) .

```csharp
public virtual MemberInitExpression Deserialize(MemberInit memberInit, SerializationState state)
```

### Return Type

 [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression)  - The [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `memberInit` | [MemberInit](ExpressionPowerTools.Serialization.Serializers.MemberInit.cs.md) | The [MemberInit](ExpressionPowerTools.Serialization.Serializers.MemberInit.cs.md) to deserialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

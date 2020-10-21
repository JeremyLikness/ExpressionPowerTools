# MemberInitSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [MemberInitSerializer](ExpressionPowerTools.Serialization.Serializers.MemberInitSerializer.cs.md) > **Serialize**

Serialize a [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(MemberInitExpression expression, SerializationState state)](#serializememberinitexpression-expression-serializationstate-state) | Serialize a [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) . |
## Serialize(MemberInitExpression expression, SerializationState state)

Serialize a [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) .

```csharp
public virtual MemberInit Serialize(MemberInitExpression expression, SerializationState state)
```

### Return Type

 [MemberInit](ExpressionPowerTools.Serialization.Serializers.MemberInit.cs.md)  - The serializable [MemberInit](ExpressionPowerTools.Serialization.Serializers.MemberInit.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) | The [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) to serialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

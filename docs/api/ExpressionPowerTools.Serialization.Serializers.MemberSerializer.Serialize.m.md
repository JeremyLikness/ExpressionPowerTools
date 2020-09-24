# MemberSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [MemberSerializer](ExpressionPowerTools.Serialization.Serializers.MemberSerializer.cs.md) > **Serialize**

Serialize a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(MemberExpression expression, SerializationState state)](#serializememberexpression-expression-serializationstate-state) | Serialize a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) . |
## Serialize(MemberExpression expression, SerializationState state)

Serialize a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) .

```csharp
public virtual MemberExpr Serialize(MemberExpression expression, SerializationState state)
```

### Return Type

 [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md)  - The serializable [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) | The [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) to serialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State, such as [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) , for the serialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

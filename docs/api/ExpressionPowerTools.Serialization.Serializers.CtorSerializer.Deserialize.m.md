# CtorSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [CtorSerializer](ExpressionPowerTools.Serialization.Serializers.CtorSerializer.cs.md) > **Deserialize**

Deserialize a [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) to a [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(CtorExpr ctorExpr, SerializationState state)](#deserializectorexpr-ctorexpr-serializationstate-state) | Deserialize a [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) to a [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) . |
## Deserialize(CtorExpr ctorExpr, SerializationState state)

Deserialize a [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) to a [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) .

```csharp
public virtual NewExpression Deserialize(CtorExpr ctorExpr, SerializationState state)
```

### Return Type

 [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression)  - The [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `ctorExpr` | [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) | The [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) to deserialize. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization or deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 5:26:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

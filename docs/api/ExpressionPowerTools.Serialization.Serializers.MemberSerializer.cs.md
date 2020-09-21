# MemberSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **MemberSerializer**

Serialization services for [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) .

```csharp
public class MemberSerializer : BaseSerializer<MemberExpression, MemberExpr>, IExpressionSerializer<MemberExpression, MemberExpr>, IBaseSerializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) → **MemberSerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [MemberSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.MemberSerializer.ctor.md#memberserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [MemberSerializer](ExpressionPowerTools.Serialization.Serializers.MemberSerializer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [MemberExpression Deserialize(JsonElement json, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.MemberSerializer.Deserialize.m.md) | Deserialize a [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) to a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) . |
| [MemberExpr Serialize(MemberExpression expression, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.MemberSerializer.Serialize.m.md) | Serialize a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/21/2020 19:07:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

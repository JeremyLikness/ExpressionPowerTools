# MemberInitSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **MemberInitSerializer**

Serialization services for [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) .

```csharp
public class MemberInitSerializer : BaseSerializer<MemberInitExpression, MemberInit>, IExpressionSerializer<MemberInitExpression, MemberInit>, IBaseSerializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) → **MemberInitSerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [MemberInitSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.MemberInitSerializer.ctor.md#memberinitserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [MemberInitSerializer](ExpressionPowerTools.Serialization.Serializers.MemberInitSerializer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [MemberInitExpression Deserialize(MemberInit memberInit, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.MemberInitSerializer.Deserialize.m.md) | Deserialize a [MemberInit](ExpressionPowerTools.Serialization.Serializers.MemberInit.cs.md) to a [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) . |
| [MemberInit Serialize(MemberInitExpression expression, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.MemberInitSerializer.Serialize.m.md) | Serialize a [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 18:50:36 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

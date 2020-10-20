# CtorSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **CtorSerializer**

Serialization services for [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) .

```csharp
public class CtorSerializer : BaseSerializer<NewExpression, CtorExpr>, IExpressionSerializer<NewExpression, CtorExpr>, IBaseSerializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) → **CtorSerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [CtorSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.CtorSerializer.ctor.md#ctorserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [CtorSerializer](ExpressionPowerTools.Serialization.Serializers.CtorSerializer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [NewExpression Deserialize(CtorExpr ctorExpr, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.CtorSerializer.Deserialize.m.md) | Deserialize a [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) to a [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) . |
| [CtorExpr Serialize(NewExpression expression, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.CtorSerializer.Serialize.m.md) | Serialize a [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

# MethodSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **MethodSerializer**

Serializer for [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

```csharp
public class MethodSerializer : BaseSerializer<MethodCallExpression, MethodExpr>, IExpressionSerializer<MethodCallExpression, MethodExpr>, IBaseSerializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) → **MethodSerializer**

Implements  [IBaseSerializer](ExpressionPowerTools.Serialization.Signatures.IBaseSerializer.i.md) ,  [IExpressionSerializer&lt;T, TSerializable>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [MethodSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.ctor.md#methodserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [MethodSerializer](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [MethodCallExpression Deserialize(JsonElement json, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.Deserialize.m.md) | Deserialize a [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) to a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) . |
| [MethodExpr Serialize(MethodCallExpression expression, SerializationState state)](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.Serialize.m.md) | Serialize a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

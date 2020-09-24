# AnonymousTypeAdapter Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **AnonymousTypeAdapter**

Class to work with anonymous types.

```csharp
public class AnonymousTypeAdapter : IAnonymousTypeAdapter
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **AnonymousTypeAdapter**

Implements  [IAnonymousTypeAdapter](ExpressionPowerTools.Serialization.Signatures.IAnonymousTypeAdapter.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [AnonymousTypeAdapter()](ExpressionPowerTools.Serialization.Serializers.AnonymousTypeAdapter.ctor.md#anonymoustypeadapter) | Initializes a new instance of the [AnonymousTypeAdapter](ExpressionPowerTools.Serialization.Serializers.AnonymousTypeAdapter.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [String MemberKeyTransformer(String memberToTransform)](ExpressionPowerTools.Serialization.Serializers.AnonymousTypeAdapter.MemberKeyTransformer.m.md) | Transforms members for serialization. |
| [AnonType TransformAnonymousObject(Object anonymous)](ExpressionPowerTools.Serialization.Serializers.AnonymousTypeAdapter.TransformAnonymousObject.m.md) | Transforms the object to an anonymous type. |
| [ConstantExpression TransformConstant(ConstantExpression expression)](ExpressionPowerTools.Serialization.Serializers.AnonymousTypeAdapter.TransformConstant.m.md) | Transform a [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) . |
| [LambdaExpression TransformLambda(LambdaExpression lambda)](ExpressionPowerTools.Serialization.Serializers.AnonymousTypeAdapter.TransformLambda.m.md) | Transform a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) that returns an anonymous type. |
| [NewExpression TransformNew(NewExpression expression)](ExpressionPowerTools.Serialization.Serializers.AnonymousTypeAdapter.TransformNew.m.md) | Transform anonymous initializer. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:57:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

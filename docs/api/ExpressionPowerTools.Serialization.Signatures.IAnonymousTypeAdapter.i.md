# IAnonymousTypeAdapter Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > **IAnonymousTypeAdapter**

Interface to work with anonymous types.

```csharp
public interface IAnonymousTypeAdapter
```

Derived  [AnonymousTypeAdapter](ExpressionPowerTools.Serialization.Serializers.AnonymousTypeAdapter.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [String MemberKeyTransformer(String memberToTransform)](ExpressionPowerTools.Serialization.Signatures.IAnonymousTypeAdapter.MemberKeyTransformer.m.md) | Parses a type to swap (i.e. anonymous to [ExpandoObject](https://docs.microsoft.com/dotnet/api/system.dynamic.expandoobject) ). |
| [AnonType TransformAnonymousObject(Object anonymous)](ExpressionPowerTools.Serialization.Signatures.IAnonymousTypeAdapter.TransformAnonymousObject.m.md) | Transforms the object to an anonymous type. |
| [ConstantExpression TransformConstant(ConstantExpression expression)](ExpressionPowerTools.Serialization.Signatures.IAnonymousTypeAdapter.TransformConstant.m.md) | Transform a [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) . |
| [LambdaExpression TransformLambda(LambdaExpression lambda)](ExpressionPowerTools.Serialization.Signatures.IAnonymousTypeAdapter.TransformLambda.m.md) | Transform a [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) that returns an anonymous type. |
| [NewExpression TransformNew(NewExpression expression)](ExpressionPowerTools.Serialization.Signatures.IAnonymousTypeAdapter.TransformNew.m.md) | Transform anonymous initializer. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:26:53 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

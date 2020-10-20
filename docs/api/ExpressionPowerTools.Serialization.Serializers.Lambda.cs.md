# Lambda Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **Lambda**

Serializable version of [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) .

```csharp
public class Lambda : SerializableExpression
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) → **Lambda**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Lambda()](ExpressionPowerTools.Serialization.Serializers.Lambda.ctor.md#lambda) | Initializes a new instance of the [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) class. |
| [Lambda(LambdaExpression expression)](ExpressionPowerTools.Serialization.Serializers.Lambda.ctor.md#lambdalambdaexpression-expression) | Initializes a new instance of the [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) class with            the provided [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) . |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Body`](ExpressionPowerTools.Serialization.Serializers.Lambda.Body.prop.md) | [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) | Gets or sets the body of the lambda. |
| [`LambdaTypeKey`](ExpressionPowerTools.Serialization.Serializers.Lambda.LambdaTypeKey.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the type of the lambda. |
| [`Name`](ExpressionPowerTools.Serialization.Serializers.Lambda.Name.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the name of the lambda. |
| [`Parameters`](ExpressionPowerTools.Serialization.Serializers.Lambda.Parameters.prop.md) | [List&lt;Parameter>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the list of parameters for the lambda. |
| [`ReturnTypeKey`](ExpressionPowerTools.Serialization.Serializers.Lambda.ReturnTypeKey.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the return type of the lambda. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

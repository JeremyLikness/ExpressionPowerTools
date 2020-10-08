# Constant Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **Constant**

Represents a serializable [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) .

```csharp
public class Constant : SerializableExpression
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) → **Constant**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Constant()](ExpressionPowerTools.Serialization.Serializers.Constant.ctor.md#constant) | Initializes a new instance of the [Constant](ExpressionPowerTools.Serialization.Serializers.Constant.cs.md) class. |
| [Constant(ConstantExpression expression)](ExpressionPowerTools.Serialization.Serializers.Constant.ctor.md#constantconstantexpression-expression) | Initializes a new instance of the [Constant](ExpressionPowerTools.Serialization.Serializers.Constant.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`ConstantTypeKey`](ExpressionPowerTools.Serialization.Serializers.Constant.ConstantTypeKey.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the value type. |
| [`Value`](ExpressionPowerTools.Serialization.Serializers.Constant.Value.prop.md) | [Object](https://docs.microsoft.com/dotnet/api/system.object) | Gets or sets the value. |
| [`ValueTypeKey`](ExpressionPowerTools.Serialization.Serializers.Constant.ValueTypeKey.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the value type. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

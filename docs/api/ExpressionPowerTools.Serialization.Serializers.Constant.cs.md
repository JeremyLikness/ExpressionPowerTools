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
| [static Constant()](ExpressionPowerTools.Serialization.Serializers.Constant.ctor.md#static-constant) | Initializes a new instance of the [Constant](ExpressionPowerTools.Serialization.Serializers.Constant.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`ConstantType`](ExpressionPowerTools.Serialization.Serializers.Constant.ConstantType.prop.md) | [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | Gets or sets the value type. |
| [`Value`](ExpressionPowerTools.Serialization.Serializers.Constant.Value.prop.md) | [Object](https://docs.microsoft.com/dotnet/api/system.object) | Gets or sets the value. |
| [`ValueType`](ExpressionPowerTools.Serialization.Serializers.Constant.ValueType.prop.md) | [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | Gets or sets the value type. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/8/2020 3:10:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.6-alpha |

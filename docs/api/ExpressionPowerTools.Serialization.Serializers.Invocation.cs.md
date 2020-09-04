# Invocation Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **Invocation**

A serializable version of [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) .

```csharp
public class Invocation : SerializableExpression
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) → **Invocation**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Invocation()](ExpressionPowerTools.Serialization.Serializers.Invocation.ctor.md#invocation) | Initializes a new instance of the [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) class. |
| [Invocation(InvocationExpression expression)](ExpressionPowerTools.Serialization.Serializers.Invocation.ctor.md#invocationinvocationexpression-expression) | Initializes a new instance of the [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) class            initialized with an [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) . |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Arguments`](ExpressionPowerTools.Serialization.Serializers.Invocation.Arguments.prop.md) | [List&lt;Object>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the arguments list. |
| [`Expression`](ExpressionPowerTools.Serialization.Serializers.Invocation.Expression.prop.md) | [Object](https://docs.microsoft.com/dotnet/api/system.object) | Gets or sets the target [Expression](ExpressionPowerTools.Serialization.Serializers.Invocation.Expression.prop.md) . |
| [`InvocationType`](ExpressionPowerTools.Serialization.Serializers.Invocation.InvocationType.prop.md) | [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | Gets or sets the type of the invocation. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/4/2020 7:10:41 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.5-alpha |

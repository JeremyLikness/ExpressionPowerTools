# MethodExpr Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **MethodExpr**

Serializable container for [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

```csharp
public class MethodExpr : SerializableExpression
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) → **MethodExpr**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [MethodExpr()](ExpressionPowerTools.Serialization.Serializers.MethodExpr.ctor.md#methodexpr) | Initializes a new instance of the [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) class. |
| [MethodExpr(MethodCallExpression methodCall)](ExpressionPowerTools.Serialization.Serializers.MethodExpr.ctor.md#methodexprmethodcallexpression-methodcall) | Initializes a new instance of the [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) class            initialized with a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) . |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Arguments`](ExpressionPowerTools.Serialization.Serializers.MethodExpr.Arguments.prop.md) | [List&lt;Object>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the list of arguments. |
| [`MethodInfo`](ExpressionPowerTools.Serialization.Serializers.MethodExpr.MethodInfo.prop.md) | [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) | Gets or sets the serializable [MethodInfo](ExpressionPowerTools.Serialization.Serializers.MethodExpr.MethodInfo.prop.md) . |
| [`MethodObject`](ExpressionPowerTools.Serialization.Serializers.MethodExpr.MethodObject.prop.md) | [Object](https://docs.microsoft.com/dotnet/api/system.object) | Gets or sets the method's object. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

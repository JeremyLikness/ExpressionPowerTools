# MethodSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [MethodSerializer](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.cs.md) > **Serialize**

Serialize a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(MethodCallExpression expression)](#serializemethodcallexpression-expression) | Serialize a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) . |
## Serialize(MethodCallExpression expression)

Serialize a [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) .

```csharp
public virtual MethodExpr Serialize(MethodCallExpression expression)
```

### Return Type

 [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md)  - The serializable [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) | The [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) to serialize. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/26/2020 6:58:17 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

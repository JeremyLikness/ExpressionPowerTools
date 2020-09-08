# SerializationState.GetOrCacheParameter Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) > **GetOrCacheParameter**

Retrieves a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) of the same type
            and name from cache, or inserts the new [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetOrCacheParameter(ParameterExpression expr)](#getorcacheparameterparameterexpression-expr) | Retrieves a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) of the same type            and name from cache, or inserts the new [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) . |
## GetOrCacheParameter(ParameterExpression expr)

Retrieves a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) of the same type
            and name from cache, or inserts the new [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) .

```csharp
public ParameterExpression GetOrCacheParameter(ParameterExpression expr)
```

### Return Type

 [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression)  - The [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) or its cached version.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expr` | [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) | The [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) to parse. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/8/2020 3:10:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.6-alpha |

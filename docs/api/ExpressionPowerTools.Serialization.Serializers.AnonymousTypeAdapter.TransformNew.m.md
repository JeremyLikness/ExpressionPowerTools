# AnonymousTypeAdapter.TransformNew Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [AnonymousTypeAdapter](ExpressionPowerTools.Serialization.Serializers.AnonymousTypeAdapter.cs.md) > **TransformNew**

Transform anonymous initializer.

## Overloads

| Overload | Description |
| :-- | :-- |
| [TransformNew(NewExpression expression)](#transformnewnewexpression-expression) | Transform anonymous initializer. |
## TransformNew(NewExpression expression)

Transform anonymous initializer.

```csharp
public virtual NewExpression TransformNew(NewExpression expression)
```

### Return Type

 [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression)  - A new expression that returns [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) | The [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/20/2020 6:32:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.9.0-alpha |

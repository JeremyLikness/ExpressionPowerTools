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
| 09/24/2020 22:50:49 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

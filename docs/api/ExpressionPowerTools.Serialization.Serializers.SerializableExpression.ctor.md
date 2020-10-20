# SerializableExpression Constructors

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) > **SerializableExpression()**

Initializes a new instance of the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [SerializableExpression()](#serializableexpression) | Initializes a new instance of the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) class. |
| [SerializableExpression(Expression expression)](#serializableexpressionexpression-expression) | Initializes a new instance of the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) class and captures            the [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) of the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) passed in. |

## SerializableExpression()

Initializes a new instance of the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) class.

```csharp
public SerializableExpression()
```



## SerializableExpression(Expression expression)

Initializes a new instance of the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) class and captures
            the [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) of the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) passed in.

```csharp
public SerializableExpression(Expression expression)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when expression is null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

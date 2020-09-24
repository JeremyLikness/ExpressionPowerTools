# SerializationRoot Constructors

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) > **SerializationRoot()**

Initializes a new instance of the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [SerializationRoot()](#serializationroot) | Initializes a new instance of the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) class. |
| [SerializationRoot(SerializableExpression expression)](#serializationrootserializableexpression-expression) | Initializes a new instance of the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) class and sets the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) property. |

## SerializationRoot()

Initializes a new instance of the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) class.

```csharp
public SerializationRoot()
```



## SerializationRoot(SerializableExpression expression)

Initializes a new instance of the [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) class and sets the [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) property.

```csharp
public SerializationRoot(SerializableExpression expression)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) | The expression. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when expression is null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:29:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

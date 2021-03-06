﻿# BaseSerializer&lt;TExpression, TSerializable> Constructors

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [BaseSerializer<TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) > **BaseSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)**

Initializes a new instance of the [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) class with a default serializer.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [BaseSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)](#baseserializeriexpressionserializerexpression-serializableexpression-serializer) | Initializes a new instance of the [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) class with a default serializer. |
| [static BaseSerializer()](#static-baseserializer) | Initializes static members of the [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) class.            Captures the key delegates for compression. |

## BaseSerializer(IExpressionSerializer&lt;Expression, SerializableExpression> serializer)

Initializes a new instance of the [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) class with a default serializer.

```csharp
public BaseSerializer(IExpressionSerializer<Expression, SerializableExpression> serializer)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `serializer` | [IExpressionSerializer&lt;Expression, SerializableExpression>](ExpressionPowerTools.Serialization.Signatures.IExpressionSerializer`2.i.md) | The default serializer. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when serializer is null. |


## static BaseSerializer()

Initializes static members of the [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) class.
            Captures the key delegates for compression.

```csharp
public static BaseSerializer()
```



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

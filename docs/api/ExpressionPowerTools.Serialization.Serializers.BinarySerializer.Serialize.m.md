﻿# BinarySerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [BinarySerializer](ExpressionPowerTools.Serialization.Serializers.BinarySerializer.cs.md) > **Serialize**

Serialize a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) to a [Binary](ExpressionPowerTools.Serialization.Serializers.Binary.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(BinaryExpression expression, SerializationState state)](#serializebinaryexpression-expression-serializationstate-state) | Serialize a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) to a [Binary](ExpressionPowerTools.Serialization.Serializers.Binary.cs.md) . |
## Serialize(BinaryExpression expression, SerializationState state)

Serialize a [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) to a [Binary](ExpressionPowerTools.Serialization.Serializers.Binary.cs.md) .

```csharp
public virtual Binary Serialize(BinaryExpression expression, SerializationState state)
```

### Return Type

 [Binary](ExpressionPowerTools.Serialization.Serializers.Binary.cs.md)  - The [Binary](ExpressionPowerTools.Serialization.Serializers.Binary.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) | The [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) . |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State for the serialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

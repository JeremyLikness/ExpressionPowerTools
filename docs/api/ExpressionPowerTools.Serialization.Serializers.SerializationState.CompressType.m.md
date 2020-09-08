# SerializationState.CompressType Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) > **CompressType**

Compresses a type to avoid repetition in the serialization payload.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CompressType(SerializableType type)](#compresstypeserializabletype-type) | Compresses a type to avoid repetition in the serialization payload. |
| [CompressType(Type type)](#compresstypetype-type) | Compresses a type to avoid repetition in the serialization payload. |
## CompressType(SerializableType type)

Compresses a type to avoid repetition in the serialization payload.

```csharp
public SerializableType CompressType(SerializableType type)
```

### Return Type

 [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md)  - The indexed [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `type` | [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | The [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) . |


## CompressType(Type type)

Compresses a type to avoid repetition in the serialization payload.

```csharp
public SerializableType CompressType(Type type)
```

### Return Type

 [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md)  - The indexed [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `type` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The [Type](https://docs.microsoft.com/dotnet/api/system.type) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/8/2020 3:10:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.6-alpha |

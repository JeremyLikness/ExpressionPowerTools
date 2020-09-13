# SerializationState.GetType Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) > **GetType**

Gets a type from the cache.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetType(SerializableType type)](#gettypeserializabletype-type) | Gets a type from the cache. |
## GetType(SerializableType type)

Gets a type from the cache.

```csharp
public Type GetType(SerializableType type)
```

### Return Type

 [Type](https://docs.microsoft.com/dotnet/api/system.type)  - The full type for an indexed type, or an indexed type for a full type.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `type` | [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | The [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) to cache or retrieve. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

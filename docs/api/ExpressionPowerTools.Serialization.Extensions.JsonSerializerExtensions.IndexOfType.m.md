# JsonSerializerExtensions.IndexOfType Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [JsonSerializerExtensions](ExpressionPowerTools.Serialization.Extensions.JsonSerializerExtensions.cs.md) > **IndexOfType**

Gets the index of the [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) in the list.

## Overloads

| Overload | Description |
| :-- | :-- |
| [IndexOfType(IList&lt;SerializableType> typeList, SerializableType type)](#indexoftypeilistserializabletype-typelist-serializabletype-type) | Gets the index of the [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) in the list. |
## IndexOfType(IList&lt;SerializableType> typeList, SerializableType type)

Gets the index of the [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) in the list.

```csharp
public static Int32 IndexOfType(IList<SerializableType> typeList, SerializableType type)
```

### Return Type

 [Int32](https://docs.microsoft.com/dotnet/api/system.int32)  - The index of the type.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `typeList` | [IList&lt;SerializableType>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ilist-1) | The list to parse. |
| `type` | [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | The type to index. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |

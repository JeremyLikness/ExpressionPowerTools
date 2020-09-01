# ReflectionHelper.GetFullTypeName Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) > **GetFullTypeName**

Gets the full type name of the serialized type.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetFullTypeName(SerializableType serializedType, StringBuilder builder, Int32 level)](#getfulltypenameserializabletype-serializedtype-stringbuilder-builder-int32-level) | Gets the full type name of the serialized type. |
## GetFullTypeName(SerializableType serializedType, StringBuilder builder, Int32 level)

Gets the full type name of the serialized type.

```csharp
public String GetFullTypeName(SerializableType serializedType, StringBuilder builder, Int32 level)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The full type name.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `serializedType` | [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | The [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) . |
| `builder` | [StringBuilder](https://docs.microsoft.com/dotnet/api/system.text.stringbuilder) | A [StringBuilder](https://docs.microsoft.com/dotnet/api/system.text.stringbuilder) . |
| `level` | [Int32](https://docs.microsoft.com/dotnet/api/system.int32) | The recurision level. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |

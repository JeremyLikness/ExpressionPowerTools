# Serializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [Serializer](ExpressionPowerTools.Serialization.Serializer.cs.md) > **Deserialize**

Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(String json, JsonSerializerOptions options)](#deserializestring-json-jsonserializeroptions-options) | Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree. |
| [Deserialize&lt;T>(String json, JsonSerializerOptions options)](#deserializetstring-json-jsonserializeroptions-options) | Overload to return a specific type. |
## Deserialize(String json, JsonSerializerOptions options)

Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

```csharp
public static Expression Deserialize(String json, JsonSerializerOptions options)
```

### Return Type

 [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression)  - The deserialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) or `null` .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The json text. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | Optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the json is `null` or whitespace. |

## Deserialize&lt;T>(String json, JsonSerializerOptions options)

Overload to return a specific type.

```csharp
public static T Deserialize<T>(String json, JsonSerializerOptions options)
```

### Return Type

 [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression)  - The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) or `null` .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The json. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | Optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

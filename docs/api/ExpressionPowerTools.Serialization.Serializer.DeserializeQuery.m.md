# Serializer.DeserializeQuery Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [Serializer](ExpressionPowerTools.Serialization.Serializer.cs.md) > **DeserializeQuery**

Deserializes a query from the raw json.

## Overloads

| Overload | Description |
| :-- | :-- |
| [DeserializeQuery(IQueryable host, String json, JsonSerializerOptions options)](#deserializequeryiqueryable-host-string-json-jsonserializeroptions-options) | Deserializes a query from the raw json. |
| [DeserializeQuery&lt;T>(IQueryable&lt;T> host, String json, JsonSerializerOptions options)](#deserializequerytiqueryablet-host-string-json-jsonserializeroptions-options) | Deserializes a query from the raw json. |
## DeserializeQuery(IQueryable host, String json, JsonSerializerOptions options)

Deserializes a query from the raw json.

```csharp
public static IQueryable DeserializeQuery(IQueryable host, String json, JsonSerializerOptions options)
```

### Return Type

 [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable)  - The deserialized [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `host` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The host to create the [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) . |
| `json` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The json text. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throws when host is null. |
| [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) | Throws when the json is empty or whitespace. |

## DeserializeQuery&lt;T>(IQueryable&lt;T> host, String json, JsonSerializerOptions options)

Deserializes a query from the raw json.

```csharp
public static IQueryable<T> DeserializeQuery<T>(IQueryable<T> host, String json, JsonSerializerOptions options)
```

### Return Type

 [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable)  - The deserialized [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `host` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) host to create the query. |
| `json` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The json text. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/4/2020 7:10:41 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.5-alpha |

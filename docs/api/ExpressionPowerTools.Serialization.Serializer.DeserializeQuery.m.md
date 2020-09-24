# Serializer.DeserializeQuery Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [Serializer](ExpressionPowerTools.Serialization.Serializer.cs.md) > **DeserializeQuery**

Deserializes a query from the raw json.

## Overloads

| Overload | Description |
| :-- | :-- |
| [DeserializeQuery(IQueryable host, String json, Action&lt;IConfigurationBuilder> config)](#deserializequeryiqueryable-host-string-json-actioniconfigurationbuilder-config) | Deserializes a query from the raw json. |
| [DeserializeQuery&lt;T>(String json, IQueryable&lt;T> host, Action&lt;IConfigurationBuilder> config)](#deserializequerytstring-json-iqueryablet-host-actioniconfigurationbuilder-config) | Deserializes a query from the raw json. |
## DeserializeQuery(IQueryable host, String json, Action&lt;IConfigurationBuilder> config)

Deserializes a query from the raw json.

```csharp
public static IQueryable DeserializeQuery(IQueryable host, String json, Action<IConfigurationBuilder> config)
```

### Return Type

 [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable)  - The deserialized [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `host` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The host to create the [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) . |
| `json` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The json text. |
| `config` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | Optional configuratoin. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throws when host is null. |
| [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) | Throws when the json is empty or whitespace. |

## DeserializeQuery&lt;T>(String json, IQueryable&lt;T> host, Action&lt;IConfigurationBuilder> config)

Deserializes a query from the raw json.

```csharp
public static IQueryable<T> DeserializeQuery<T>(String json, IQueryable<T> host, Action<IConfigurationBuilder> config)
```

### Return Type

 [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable)  - The deserialized [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The json text. |
| `host` | [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) | The [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) host to create the query. |
| `config` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | The optional configuration. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:02:13 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

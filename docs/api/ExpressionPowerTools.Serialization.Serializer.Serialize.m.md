# Serializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [Serializer](ExpressionPowerTools.Serialization.Serializer.cs.md) > **Serialize**

Serialize an expression tree.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(Expression root, JsonSerializerOptions options)](#serializeexpression-root-jsonserializeroptions-options) | Serialize an expression tree. |
| [Serialize(IQueryable query, JsonSerializerOptions options)](#serializeiqueryable-query-jsonserializeroptions-options) | Serialize an [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) . |
## Serialize(Expression root, JsonSerializerOptions options)

Serialize an expression tree.

```csharp
public static String Serialize(Expression root, JsonSerializerOptions options)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The serialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `root` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The root [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is `null` . |

## Serialize(IQueryable query, JsonSerializerOptions options)

Serialize an [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

```csharp
public static String Serialize(IQueryable query, JsonSerializerOptions options)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The serialized [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) to serialize. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throws when the query is null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

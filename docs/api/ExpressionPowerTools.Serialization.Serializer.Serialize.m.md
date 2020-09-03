# Serializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [Serializer](ExpressionPowerTools.Serialization.Serializer.cs.md) > **Serialize**

Serialize an expression tree.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(Expression root, JsonSerializerOptions options, Boolean compressTypes)](#serializeexpression-root-jsonserializeroptions-options-boolean-compresstypes) | Serialize an expression tree. |
| [Serialize(IQueryable query, JsonSerializerOptions options, Boolean compressTypes)](#serializeiqueryable-query-jsonserializeroptions-options-boolean-compresstypes) | Serialize an [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) . |
## Serialize(Expression root, JsonSerializerOptions options, Boolean compressTypes)

Serialize an expression tree.

```csharp
public static String Serialize(Expression root, JsonSerializerOptions options, Boolean compressTypes)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The serialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `root` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The root [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |
| `compressTypes` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Set to `true` to reduce footprint of type definitions. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is `null` . |

## Serialize(IQueryable query, JsonSerializerOptions options, Boolean compressTypes)

Serialize an [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

```csharp
public static String Serialize(IQueryable query, JsonSerializerOptions options, Boolean compressTypes)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The serialized [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) to serialize. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |
| `compressTypes` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Set to `true` to reduce the footprint of types in the payload. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throws when the query is null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/3/2020 10:27:04 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.4-alpha |

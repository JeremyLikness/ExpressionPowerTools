# Serializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [Serializer](ExpressionPowerTools.Serialization.Serializer.cs.md) > **Deserialize**

Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(String json, Expression queryRoot, JsonSerializerOptions options)](#deserializestring-json-expression-queryroot-jsonserializeroptions-options) | Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree. |
| [Deserialize&lt;T>(String json, Expression queryRoot, JsonSerializerOptions options)](#deserializetstring-json-expression-queryroot-jsonserializeroptions-options) | Overload to return a specific type. |
## Deserialize(String json, Expression queryRoot, JsonSerializerOptions options)

Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

```csharp
public static Expression Deserialize(String json, Expression queryRoot, JsonSerializerOptions options)
```

### Return Type

 [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression)  - The deserialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) or `null` .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The json text. |
| `queryRoot` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The root of the query to apply. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | Optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the json is `null` or whitespace. |

## Deserialize&lt;T>(String json, Expression queryRoot, JsonSerializerOptions options)

Overload to return a specific type.

```csharp
public static T Deserialize<T>(String json, Expression queryRoot, JsonSerializerOptions options)
```

### Return Type

 [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression)  - The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) or `null` .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The json. |
| `queryRoot` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The root of the query to apply. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | Optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |


## Remarks

Do not use this method to deserialize [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) or [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) .
            Themethod is provided for this.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |

# Serializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [Serializer](ExpressionPowerTools.Serialization.Serializer.cs.md) > **Deserialize**



## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(String json, JsonSerializerOptions options)](#deserializestring-json-jsonserializeroptions-options) |  |
| [Deserialize&lt;T>(String json, JsonSerializerOptions options)](#deserializetstring-json-jsonserializeroptions-options) |  |
## Deserialize(String json, JsonSerializerOptions options)



```csharp
public static Expression Deserialize(String json, JsonSerializerOptions options)
```

### Return Type

 [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [String](https://docs.microsoft.com/dotnet/api/system.string) |  |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) |  |


## Deserialize&lt;T>(String json, JsonSerializerOptions options)



```csharp
public static T Deserialize<T>(String json, JsonSerializerOptions options)
```

### Return Type

 [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [String](https://docs.microsoft.com/dotnet/api/system.string) |  |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

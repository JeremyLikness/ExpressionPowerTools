# Serializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [Serializer](ExpressionPowerTools.Serialization.Serializer.cs.md) > **Deserialize**

Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(String json, Expression queryRoot, Action&lt;IConfigurationBuilder> config)](#deserializestring-json-expression-queryroot-actioniconfigurationbuilder-config) | Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree. |
| [Deserialize&lt;T>(String json, Expression queryRoot, Action&lt;IConfigurationBuilder> config)](#deserializetstring-json-expression-queryroot-actioniconfigurationbuilder-config) | Overload to return a specific type. |
## Deserialize(String json, Expression queryRoot, Action&lt;IConfigurationBuilder> config)

Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

```csharp
public static Expression Deserialize(String json, Expression queryRoot, Action<IConfigurationBuilder> config)
```

### Return Type

 [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression)  - The deserialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) or `null` .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The json text. |
| `queryRoot` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The root of the query to apply. |
| `config` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | Optional configuration. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the json is `null` or whitespace. |

## Deserialize&lt;T>(String json, Expression queryRoot, Action&lt;IConfigurationBuilder> config)

Overload to return a specific type.

```csharp
public static T Deserialize<T>(String json, Expression queryRoot, Action<IConfigurationBuilder> config)
```

### Return Type

 [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression)  - The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) or `null` .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The json. |
| `queryRoot` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The root of the query to apply. |
| `config` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | Optional configuration. |


## Remarks

Do not use this method to deserialize [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) or [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) .
            Themethod is provided for this.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |

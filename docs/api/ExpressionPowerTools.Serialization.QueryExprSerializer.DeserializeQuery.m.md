# QueryExprSerializer.DeserializeQuery Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [QueryExprSerializer](ExpressionPowerTools.Serialization.QueryExprSerializer.cs.md) > **DeserializeQuery**

Deserializes a query from the raw json.

## Overloads

| Overload | Description |
| :-- | :-- |
| [DeserializeQuery(IQueryable host, SerializationRoot root, Action&lt;IConfigurationBuilder> config, Action&lt;SerializationState> stateCallback)](#deserializequeryiqueryable-host-serializationroot-root-actioniconfigurationbuilder-config-actionserializationstate-statecallback) | Deserializes a query from the raw json. |
| [DeserializeQuery&lt;T>(SerializationRoot root, IQueryable host, Action&lt;IConfigurationBuilder> config, Action&lt;SerializationState> stateCallback)](#deserializequerytserializationroot-root-iqueryable-host-actioniconfigurationbuilder-config-actionserializationstate-statecallback) | Deserializes a query from the raw json. |
## DeserializeQuery(IQueryable host, SerializationRoot root, Action&lt;IConfigurationBuilder> config, Action&lt;SerializationState> stateCallback)

Deserializes a query from the raw json.

```csharp
public static IQueryable DeserializeQuery(IQueryable host, SerializationRoot root, Action<IConfigurationBuilder> config, Action<SerializationState> stateCallback)
```

### Return Type

 [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable)  - The deserialized [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `host` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The host to create the [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) . |
| `root` | [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) | The root that was serialized. |
| `config` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | Optional configuratoin. |
| `stateCallback` | [Action&lt;SerializationState>](https://docs.microsoft.com/dotnet/api/system.action-1) | Register a callback to inspect the state. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throws when host is null. |
| [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) | Throws when the json is empty or whitespace. |

## DeserializeQuery&lt;T>(SerializationRoot root, IQueryable host, Action&lt;IConfigurationBuilder> config, Action&lt;SerializationState> stateCallback)

Deserializes a query from the raw json.

```csharp
public static IQueryable<T> DeserializeQuery<T>(SerializationRoot root, IQueryable host, Action<IConfigurationBuilder> config, Action<SerializationState> stateCallback)
```

### Return Type

 [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable)  - The deserialized [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `root` | [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) | The serialization root. |
| `host` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) host to create the query. |
| `config` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | The optional configuration. |
| `stateCallback` | [Action&lt;SerializationState>](https://docs.microsoft.com/dotnet/api/system.action-1) | Register a callback to inspect the state. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

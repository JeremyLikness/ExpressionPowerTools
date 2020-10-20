# QueryExprSerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [QueryExprSerializer](ExpressionPowerTools.Serialization.QueryExprSerializer.cs.md) > **Deserialize**

Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(SerializationRoot root, Expression queryRoot, Action&lt;IConfigurationBuilder> config, Action&lt;SerializationState> stateCallback)](#deserializeserializationroot-root-expression-queryroot-actioniconfigurationbuilder-config-actionserializationstate-statecallback) | Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree. |
| [Deserialize&lt;T>(SerializationRoot root, Expression queryRoot, Action&lt;IConfigurationBuilder> config, Action&lt;SerializationState> stateCallback)](#deserializetserializationroot-root-expression-queryroot-actioniconfigurationbuilder-config-actionserializationstate-statecallback) | Overload to return a specific type. |
## Deserialize(SerializationRoot root, Expression queryRoot, Action&lt;IConfigurationBuilder> config, Action&lt;SerializationState> stateCallback)

Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

```csharp
public static Expression Deserialize(SerializationRoot root, Expression queryRoot, Action<IConfigurationBuilder> config, Action<SerializationState> stateCallback)
```

### Return Type

 [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression)  - The deserialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) or `null` .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `root` | [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) | The root expression. |
| `queryRoot` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The root of the query to apply. |
| `config` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | Optional configuration. |
| `stateCallback` | [Action&lt;SerializationState>](https://docs.microsoft.com/dotnet/api/system.action-1) | Register a callback to inspect the state. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the json is `null` or whitespace. |

## Deserialize&lt;T>(SerializationRoot root, Expression queryRoot, Action&lt;IConfigurationBuilder> config, Action&lt;SerializationState> stateCallback)

Overload to return a specific type.

```csharp
public static T Deserialize<T>(SerializationRoot root, Expression queryRoot, Action<IConfigurationBuilder> config, Action<SerializationState> stateCallback)
```

### Return Type

 [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression)  - The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) or `null` .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `root` | [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) | The root for serialization. |
| `queryRoot` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The root of the query to apply. |
| `config` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | Optional configuration. |
| `stateCallback` | [Action&lt;SerializationState>](https://docs.microsoft.com/dotnet/api/system.action-1) | Register a callback to inspect the state. |


## Remarks

Do not use this method to deserialize [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) or [IQueryable&lt;out T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) .
            Themethod is provided for this.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:35:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

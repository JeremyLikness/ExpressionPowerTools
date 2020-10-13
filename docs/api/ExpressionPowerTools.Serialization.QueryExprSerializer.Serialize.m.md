# QueryExprSerializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [QueryExprSerializer](ExpressionPowerTools.Serialization.QueryExprSerializer.cs.md) > **Serialize**

Serialize an expression tree.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(Expression root, Action&lt;IConfigurationBuilder> config)](#serializeexpression-root-actioniconfigurationbuilder-config) | Serialize an expression tree. |
| [Serialize(IQueryable query, Action&lt;IConfigurationBuilder> config)](#serializeiqueryable-query-actioniconfigurationbuilder-config) | Serialize an [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) . |
## Serialize(Expression root, Action&lt;IConfigurationBuilder> config)

Serialize an expression tree.

```csharp
public static SerializationRoot Serialize(Expression root, Action<IConfigurationBuilder> config)
```

### Return Type

 [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md)  - The serialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `root` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The root [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `config` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | Optional configuration. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is `null` . |

## Serialize(IQueryable query, Action&lt;IConfigurationBuilder> config)

Serialize an [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

```csharp
public static SerializationRoot Serialize(IQueryable query, Action<IConfigurationBuilder> config)
```

### Return Type

 [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md)  - The serialized [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `query` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) to serialize. |
| `config` | [Action&lt;IConfigurationBuilder>](https://docs.microsoft.com/dotnet/api/system.action-1) | Option configuration. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throws when the query is null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 5:26:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

﻿# QueryExprSerializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > **QueryExprSerializer**

Class for serialization and de-deserialization of [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) trees.

```csharp
public static class QueryExprSerializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **QueryExprSerializer**

## Remarks

By default, the serializer will compress types and ignore null and readonly values. You can override the configuration for a session
            by using the [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md) . You can also set defaults for all sessions using.
            For permissions, use theoption. By default, perimssions are given for: [Math](https://docs.microsoft.com/dotnet/api/system.math) , [Enumerable](https://docs.microsoft.com/dotnet/api/system.linq.enumerable) , [Queryable](https://docs.microsoft.com/dotnet/api/system.linq.queryable) and [String](https://docs.microsoft.com/dotnet/api/system.string) types (all methods and properties are allowed).
            See the [RulesEngine](ExpressionPowerTools.Serialization.Rules.RulesEngine.cs.md) documentation for more on rules.

## Constructors

| Ctor | Description |
| :-- | :-- |
| [static QueryExprSerializer()](ExpressionPowerTools.Serialization.QueryExprSerializer.ctor.md#static-queryexprserializer) | Initializes a new instance of the [QueryExprSerializer](ExpressionPowerTools.Serialization.QueryExprSerializer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Void ConfigureDefaults(Action&lt;IConfigurationBuilder> config)](ExpressionPowerTools.Serialization.QueryExprSerializer.ConfigureDefaults.m.md) | Configure default settings. |
| [Void ConfigureRules(Action&lt;IRulesConfiguration> rules, Boolean noDefaults)](ExpressionPowerTools.Serialization.QueryExprSerializer.ConfigureRules.m.md) | Configures the rule set for serialization. |
| [Expression Deserialize(SerializationRoot root, Expression queryRoot, Action&lt;IConfigurationBuilder> config, Action&lt;SerializationState> stateCallback)](ExpressionPowerTools.Serialization.QueryExprSerializer.Deserialize.m.md) | Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree. |
| [IQueryable DeserializeQuery(IQueryable host, SerializationRoot root, Action&lt;IConfigurationBuilder> config, Action&lt;SerializationState> stateCallback)](ExpressionPowerTools.Serialization.QueryExprSerializer.DeserializeQuery.m.md) | Deserializes a query from the raw json. |
| [SerializationRoot Serialize(Expression root, Action&lt;IConfigurationBuilder> config)](ExpressionPowerTools.Serialization.QueryExprSerializer.Serialize.m.md) | Serialize an expression tree. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

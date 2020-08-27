# Serializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > **Serializer**

Class for serialization and de-deserialization of [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) trees.

```csharp
public static class Serializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **Serializer**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [static Serializer()](ExpressionPowerTools.Serialization.Serializer.ctor.md#static-serializer) | Initializes a new instance of the [Serializer](ExpressionPowerTools.Serialization.Serializer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Expression Deserialize(String json, Expression queryRoot, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Serializer.Deserialize.m.md) | Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree. |
| [IQueryable DeserializeQuery(IQueryable host, String json, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Serializer.DeserializeQuery.m.md) | Deserializes a query from the raw json. |
| [String Serialize(Expression root, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Serializer.Serialize.m.md) | Serialize an expression tree. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

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
| [Expression Deserialize(String json, JsonSerializerOptions options)](Serializer-Deserialize.m.md) | Deserialize to an [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree. |
| [String Serialize(Expression root, JsonSerializerOptions options)](Serializer-Serialize.m.md) | Serialize an expression tree. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

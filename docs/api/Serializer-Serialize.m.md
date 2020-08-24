# Serializer.Serialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.n.md) > [Serializer](ExpressionPowerTools.Serialization.Serializer.cs.md) > **Serialize**

Serialize an expression tree.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Serialize(Expression root, JsonSerializerOptions options)](#serializeexpression-root-jsonserializeroptions-options) | Serialize an expression tree. |
## Serialize(Expression root, JsonSerializerOptions options)

Serialize an expression tree.

```csharp
public static String Serialize(Expression root, JsonSerializerOptions options)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The serialized [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) tree.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `root` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The root [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) is `null` . |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

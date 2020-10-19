# MemberBindingExprConverter Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > **MemberBindingExprConverter**

Converter for member bindings.

```csharp
public class MemberBindingExprConverter : JsonConverter<MemberBindingExpr>
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [JsonConverter](https://docs.microsoft.com/dotnet/api/system.text.json.serialization.jsonconverter) → [JsonConverter&lt;T>](https://docs.microsoft.com/dotnet/api/system.text.json.serialization.jsonconverter-1) → **MemberBindingExprConverter**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [MemberBindingExprConverter()](ExpressionPowerTools.Serialization.Json.MemberBindingExprConverter.ctor.md#memberbindingexprconverter) | Initializes a new instance of the [MemberBindingExprConverter](ExpressionPowerTools.Serialization.Json.MemberBindingExprConverter.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [MemberBindingExpr Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Json.MemberBindingExprConverter.Read.m.md) | Read the [MemberBindingExpr](ExpressionPowerTools.Serialization.Serializers.MemberBindingExpr.cs.md) . |
| [Void Write(Utf8JsonWriter writer, MemberBindingExpr value, JsonSerializerOptions options)](ExpressionPowerTools.Serialization.Json.MemberBindingExprConverter.Write.m.md) | Write the [MemberBindingExpr](ExpressionPowerTools.Serialization.Serializers.MemberBindingExpr.cs.md) . |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |

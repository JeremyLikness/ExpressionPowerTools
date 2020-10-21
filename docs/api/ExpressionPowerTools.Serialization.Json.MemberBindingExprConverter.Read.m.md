# MemberBindingExprConverter.Read Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Json](ExpressionPowerTools.Serialization.Json.n.md) > [MemberBindingExprConverter](ExpressionPowerTools.Serialization.Json.MemberBindingExprConverter.cs.md) > **Read**

Read the [MemberBindingExpr](ExpressionPowerTools.Serialization.Serializers.MemberBindingExpr.cs.md) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)](#readutf8jsonreader&-reader-type-typetoconvert-jsonserializeroptions-options) | Read the [MemberBindingExpr](ExpressionPowerTools.Serialization.Serializers.MemberBindingExpr.cs.md) . |
## Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)

Read the [MemberBindingExpr](ExpressionPowerTools.Serialization.Serializers.MemberBindingExpr.cs.md) .

```csharp
public virtual MemberBindingExpr Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)
```

### Return Type

 [MemberBindingExpr](ExpressionPowerTools.Serialization.Serializers.MemberBindingExpr.cs.md)  - The [MemberBindingExpr](ExpressionPowerTools.Serialization.Serializers.MemberBindingExpr.cs.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `reader` | [Utf8JsonReader&](https://docs.microsoft.com/dotnet/api/system.text.json.utf8jsonreader&) | The reader. |
| `typeToConvert` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The type. |
| `options` | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | The options. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

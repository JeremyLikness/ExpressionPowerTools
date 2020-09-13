# SerializationState Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **SerializationState**

State info passed recurisvely through the serialization process.

```csharp
public class SerializationState
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **SerializationState**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [SerializationState()](ExpressionPowerTools.Serialization.Serializers.SerializationState.ctor.md#serializationstate) | Initializes a new instance of the [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`CompressTypes`](ExpressionPowerTools.Serialization.Serializers.SerializationState.CompressTypes.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether or not types are compressed. Default is `true` . |
| [`Options`](ExpressionPowerTools.Serialization.Serializers.SerializationState.Options.prop.md) | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | Gets or sets the optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |
| [`QueryRoot`](ExpressionPowerTools.Serialization.Serializers.SerializationState.QueryRoot.prop.md) | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | Gets or sets the query root to build the query from. |
| [`TypeIndex`](ExpressionPowerTools.Serialization.Serializers.SerializationState.TypeIndex.prop.md) | [List&lt;SerializableType>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the index of types. |

## Methods

| Method | Description |
| :-- | :-- |
| [Void CompressMemberTypes(MemberBase member)](ExpressionPowerTools.Serialization.Serializers.SerializationState.CompressMemberTypes.m.md) | Compresses the types on a [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) . |
| [SerializableType CompressType(SerializableType type)](ExpressionPowerTools.Serialization.Serializers.SerializationState.CompressType.m.md) | Compresses a type to avoid repetition in the serialization payload. |
| [Void DecompressMemberTypes(MemberBase member)](ExpressionPowerTools.Serialization.Serializers.SerializationState.DecompressMemberTypes.m.md) | Decompress the types on a [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) . |
| [SerializableType DecompressType(SerializableType type)](ExpressionPowerTools.Serialization.Serializers.SerializationState.DecompressType.m.md) | Decompresses a type. |
| [ParameterExpression GetOrCacheParameter(ParameterExpression expr)](ExpressionPowerTools.Serialization.Serializers.SerializationState.GetOrCacheParameter.m.md) | Retrieves a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) of the same type            and name from cache, or inserts the new [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) . |
| [Type GetType(SerializableType type)](ExpressionPowerTools.Serialization.Serializers.SerializationState.GetType.m.md) | Gets a type from the cache. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

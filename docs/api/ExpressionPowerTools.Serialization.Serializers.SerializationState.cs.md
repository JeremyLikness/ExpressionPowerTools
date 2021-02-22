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
| [`CompressExpression`](ExpressionPowerTools.Serialization.Serializers.SerializationState.CompressExpression.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether the expression should be            compressed. This will take anything not parameterized and invoke it            for transport over the wire. |
| [`CompressTypes`](ExpressionPowerTools.Serialization.Serializers.SerializationState.CompressTypes.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether or not types are compressed. Default is `true` . |
| [`LastExpression`](ExpressionPowerTools.Serialization.Serializers.SerializationState.LastExpression.prop.md) | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | Gets or sets the last [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) serialized. |
| [`QueryRoot`](ExpressionPowerTools.Serialization.Serializers.SerializationState.QueryRoot.prop.md) | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | Gets or sets the query root to build the query from. |
| [`TypeIndex`](ExpressionPowerTools.Serialization.Serializers.SerializationState.TypeIndex.prop.md) | [List&lt;String>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the index of types. |

## Methods

| Method | Description |
| :-- | :-- |
| [String CompressTypesforKey(String keyToCompress)](ExpressionPowerTools.Serialization.Serializers.SerializationState.CompressTypesforKey.m.md) | Compress a single key. |
| [Void CompressTypesForKeys(ValueTuple keys)](ExpressionPowerTools.Serialization.Serializers.SerializationState.CompressTypesForKeys.m.md) |  |
| [String DecompressTypesForKey(String keyToDecompress)](ExpressionPowerTools.Serialization.Serializers.SerializationState.DecompressTypesForKey.m.md) | Decompress a single key. |
| [Void DecompressTypesForKeys(ValueTuple keys)](ExpressionPowerTools.Serialization.Serializers.SerializationState.DecompressTypesForKeys.m.md) |  |
| [Void Done()](ExpressionPowerTools.Serialization.Serializers.SerializationState.Done.m.md) | Called at the end of serialization. |
| [String GetExpressionTree(Boolean preventReset)](ExpressionPowerTools.Serialization.Serializers.SerializationState.GetExpressionTree.m.md) | Gets the expression tree that was deserialized. |
| [ParameterExpression GetOrCacheParameter(ParameterExpression expr)](ExpressionPowerTools.Serialization.Serializers.SerializationState.GetOrCacheParameter.m.md) | Retrieves a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) of the same type            and name from cache, or inserts the new [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) . |
| [ParameterExpression[] GetParameters()](ExpressionPowerTools.Serialization.Serializers.SerializationState.GetParameters.m.md) | Gets the parameters that were built. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

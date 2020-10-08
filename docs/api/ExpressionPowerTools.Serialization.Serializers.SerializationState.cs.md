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
| [`Options`](ExpressionPowerTools.Serialization.Serializers.SerializationState.Options.prop.md) | [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) | Gets or sets the optional [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) . |
| [`QueryRoot`](ExpressionPowerTools.Serialization.Serializers.SerializationState.QueryRoot.prop.md) | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | Gets or sets the query root to build the query from. |
| [`TypeIndex`](ExpressionPowerTools.Serialization.Serializers.SerializationState.TypeIndex.prop.md) | [List&lt;String>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) | Gets or sets the index of types. |

## Methods

| Method | Description |
| :-- | :-- |
| [String GetExpressionTree()](ExpressionPowerTools.Serialization.Serializers.SerializationState.GetExpressionTree.m.md) | Gets the expression tree that was deserialized. |
| [ParameterExpression GetOrCacheParameter(ParameterExpression expr)](ExpressionPowerTools.Serialization.Serializers.SerializationState.GetOrCacheParameter.m.md) | Retrieves a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) of the same type            and name from cache, or inserts the new [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) . |
| [ParameterExpression[] GetParameters()](ExpressionPowerTools.Serialization.Serializers.SerializationState.GetParameters.m.md) | Gets the parameters that were built. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

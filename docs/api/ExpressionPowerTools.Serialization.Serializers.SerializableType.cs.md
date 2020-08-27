# SerializableType Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **SerializableType**

Represents a serializable type. Handles recursive generic arguments.

```csharp
public class SerializableType : ValueType
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/dotnet/api/system.valuetype) → **SerializableType**

## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`GenericTypeArguments`](ExpressionPowerTools.Serialization.Serializers.SerializableType.GenericTypeArguments.prop.md) | [SerializableType[]](https://docs.microsoft.com/dotnet/api/expressionpowertools.serialization.serializers.serializabletype[]) | Gets or sets the list of generic type arguments for the type. |
| [`TypeName`](ExpressionPowerTools.Serialization.Serializers.SerializableType.TypeName.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the full name of the type. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

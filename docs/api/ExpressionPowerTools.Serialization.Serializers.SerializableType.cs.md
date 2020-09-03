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
| [`FullTypeName`](ExpressionPowerTools.Serialization.Serializers.SerializableType.FullTypeName.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the full type name. |
| [`GenericTypeArguments`](ExpressionPowerTools.Serialization.Serializers.SerializableType.GenericTypeArguments.prop.md) | [SerializableType[]](https://docs.microsoft.com/dotnet/api/expressionpowertools.serialization.serializers.serializabletype[]) | Gets or sets the list of generic type arguments for the type. |
| [`TypeName`](ExpressionPowerTools.Serialization.Serializers.SerializableType.TypeName.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the full name of the type. |
| [`TypeParamName`](ExpressionPowerTools.Serialization.Serializers.SerializableType.TypeParamName.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the type parameter name. |

## Methods

| Method | Description |
| :-- | :-- |
| [Boolean Equals(Object obj)](ExpressionPowerTools.Serialization.Serializers.SerializableType.Equals.m.md) | Gets equality for serializable type. |
| [Int32 GetHashCode()](ExpressionPowerTools.Serialization.Serializers.SerializableType.GetHashCode.m.md) | Gets the hash code for the type. |
| [String ToString()](ExpressionPowerTools.Serialization.Serializers.SerializableType.ToString.m.md) | Overload to show type. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/3/2020 10:27:04 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.4-alpha |

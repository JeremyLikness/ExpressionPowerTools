# Ctor Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **Ctor**

Serializable version of [ConstructorInfo](https://docs.microsoft.com/dotnet/api/system.reflection.constructorinfo) .

```csharp
public class Ctor : MemberBase
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) → **Ctor**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Ctor()](ExpressionPowerTools.Serialization.Serializers.Ctor.ctor.md#ctor) | Initializes a new instance of the [Ctor](ExpressionPowerTools.Serialization.Serializers.Ctor.cs.md) class. |
| [Ctor(ConstructorInfo info)](ExpressionPowerTools.Serialization.Serializers.Ctor.ctor.md#ctorconstructorinfo-info) | Initializes a new instance of the [Ctor](ExpressionPowerTools.Serialization.Serializers.Ctor.cs.md) class and            initializes it with a [ConstructorInfo](https://docs.microsoft.com/dotnet/api/system.reflection.constructorinfo) . |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`IsStatic`](ExpressionPowerTools.Serialization.Serializers.Ctor.IsStatic.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether the method is static. |
| [`MemberType`](ExpressionPowerTools.Serialization.Serializers.Ctor.MemberType.prop.md) | [Int32](https://docs.microsoft.com/dotnet/api/system.int32) | Gets or sets the type of the member. |
| [`Name`](ExpressionPowerTools.Serialization.Serializers.Ctor.Name.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the name of the method. |
| [`Parameters`](ExpressionPowerTools.Serialization.Serializers.Ctor.Parameters.prop.md) | [Dictionary&lt;String, SerializableType>](https://docs.microsoft.com/dotnet/api/system.collections.generic.dictionary-2) | Gets or sets the list of parameters with parameter name mapped to the            full name of the type. |

## Methods

| Method | Description |
| :-- | :-- |
| [String CalculateKey()](ExpressionPowerTools.Serialization.Serializers.Ctor.CalculateKey.m.md) | Gets the unique key for the method. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

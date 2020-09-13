# Property Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **Property**

A serializable property.

```csharp
public class Property : MemberBase
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) → **Property**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Property()](ExpressionPowerTools.Serialization.Serializers.Property.ctor.md#property) | Initializes a new instance of the [Property](ExpressionPowerTools.Serialization.Serializers.Property.cs.md) class. |
| [Property(PropertyInfo info)](ExpressionPowerTools.Serialization.Serializers.Property.ctor.md#propertypropertyinfo-info) | Initializes a new instance of the [Property](ExpressionPowerTools.Serialization.Serializers.Property.cs.md) class and            populates values based on the [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) passed in. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`IsStatic`](ExpressionPowerTools.Serialization.Serializers.Property.IsStatic.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether the method is static. |
| [`MemberType`](ExpressionPowerTools.Serialization.Serializers.Property.MemberType.prop.md) | [Int32](https://docs.microsoft.com/dotnet/api/system.int32) | Gets or sets the member type. |
| [`Name`](ExpressionPowerTools.Serialization.Serializers.Property.Name.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the name of the method. |

## Methods

| Method | Description |
| :-- | :-- |
| [String CalculateKey()](ExpressionPowerTools.Serialization.Serializers.Property.CalculateKey.m.md) | Gets the unique key for the method. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

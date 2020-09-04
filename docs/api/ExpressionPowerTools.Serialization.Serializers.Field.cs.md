# Field Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **Field**

A serializable field.

```csharp
public class Field : MemberBase
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) → **Field**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Field()](ExpressionPowerTools.Serialization.Serializers.Field.ctor.md#field) | Initializes a new instance of the [Field](ExpressionPowerTools.Serialization.Serializers.Field.cs.md) class. |
| [Field(FieldInfo info)](ExpressionPowerTools.Serialization.Serializers.Field.ctor.md#fieldfieldinfo-info) | Initializes a new instance of the [Field](ExpressionPowerTools.Serialization.Serializers.Field.cs.md) class and            populates values based on the [FieldInfo](https://docs.microsoft.com/dotnet/api/system.reflection.fieldinfo) passed in. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`IsStatic`](ExpressionPowerTools.Serialization.Serializers.Field.IsStatic.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether the method is static. |
| [`MemberType`](ExpressionPowerTools.Serialization.Serializers.Field.MemberType.prop.md) | [Int32](https://docs.microsoft.com/dotnet/api/system.int32) | Gets or sets the member type. |
| [`Name`](ExpressionPowerTools.Serialization.Serializers.Field.Name.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the name of the method. |

## Methods

| Method | Description |
| :-- | :-- |
| [String CalculateKey()](ExpressionPowerTools.Serialization.Serializers.Field.CalculateKey.m.md) | Gets the unique key for the method. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/4/2020 7:10:41 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.5-alpha |

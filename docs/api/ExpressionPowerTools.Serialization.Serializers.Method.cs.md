# Method Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **Method**

Represents [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) for serialization.

```csharp
public class Method : MemberBase
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [MemberBase](ExpressionPowerTools.Serialization.Serializers.MemberBase.cs.md) → **Method**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Method()](ExpressionPowerTools.Serialization.Serializers.Method.ctor.md#method) | Initializes a new instance of the [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) class. |
| [Method(MethodInfo info)](ExpressionPowerTools.Serialization.Serializers.Method.ctor.md#methodmethodinfo-info) | Initializes a new instance of the [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) class and            populates values based on the [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) passed in. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`GenericArguments`](ExpressionPowerTools.Serialization.Serializers.Method.GenericArguments.prop.md) | [SerializableType[]](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | Gets or sets the generic arguments to the method. |
| [`GenericMethodDefinition`](ExpressionPowerTools.Serialization.Serializers.Method.GenericMethodDefinition.prop.md) | [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) | Gets or sets the generic method definition that the method inherits from. |
| [`IsStatic`](ExpressionPowerTools.Serialization.Serializers.Method.IsStatic.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether the method is static. |
| [`MemberType`](ExpressionPowerTools.Serialization.Serializers.Method.MemberType.prop.md) | [Int32](https://docs.microsoft.com/dotnet/api/system.int32) | Gets or sets the member type. |
| [`Name`](ExpressionPowerTools.Serialization.Serializers.Method.Name.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the name of the method. |
| [`Parameters`](ExpressionPowerTools.Serialization.Serializers.Method.Parameters.prop.md) | [Dictionary&lt;String, SerializableType>](https://docs.microsoft.com/dotnet/api/system.collections.generic.dictionary-2) | Gets or sets the list of parameters with parameter name mapped to the            full name of the type. |

## Methods

| Method | Description |
| :-- | :-- |
| [String CalculateKey()](ExpressionPowerTools.Serialization.Serializers.Method.CalculateKey.m.md) | Gets the unique key for the method. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 7:35:36 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

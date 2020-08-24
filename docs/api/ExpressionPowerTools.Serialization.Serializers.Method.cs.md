# Method Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **Method**

Represents [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) for serialization.

```csharp
public class Method
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **Method**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [Method()](ExpressionPowerTools.Serialization.Serializers.Method.ctor.md#method) | Initializes a new instance of the [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) class. |
| [Method(MethodInfo info)](ExpressionPowerTools.Serialization.Serializers.Method.ctor.md#methodmethodinfo-info) | Initializes a new instance of the [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) class and            populates values based on the [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) passed in. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`DeclaringType`](ExpressionPowerTools.Serialization.Serializers.Method.DeclaringType.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the full name of the declaring type. |
| [`IsStatic`](ExpressionPowerTools.Serialization.Serializers.Method.IsStatic.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets or sets a value indicating whether the method is static. |
| [`Name`](ExpressionPowerTools.Serialization.Serializers.Method.Name.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the name of the method. |
| [`Parameters`](ExpressionPowerTools.Serialization.Serializers.Method.Parameters.prop.md) | [Dictionary&lt;String, String>](https://docs.microsoft.com/dotnet/api/system.collections.generic.dictionary-2) | Gets or sets the list of parameters with parameter name mapped to the            full name of the type. |
| [`ReturnType`](ExpressionPowerTools.Serialization.Serializers.Method.ReturnType.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the full name of the return type. |

## Methods

| Method | Description |
| :-- | :-- |
| [Int32 GetHashCode()](Method-GetHashCode.m.md) | Generates a hash code based on the full method signature. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 8:28:46 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

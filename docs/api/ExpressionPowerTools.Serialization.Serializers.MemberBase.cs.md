# MemberBase Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **MemberBase**

Base class to serialize a member.

```csharp
public abstract class MemberBase
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **MemberBase**

Derived  [Ctor](ExpressionPowerTools.Serialization.Serializers.Ctor.cs.md) ,  [Field](ExpressionPowerTools.Serialization.Serializers.Field.cs.md) ,  [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) ,  [Property](ExpressionPowerTools.Serialization.Serializers.Property.cs.md) 

## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`DeclaringType`](ExpressionPowerTools.Serialization.Serializers.MemberBase.DeclaringType.prop.md) | [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | Gets or sets the declaring type. |
| [`MemberType`](ExpressionPowerTools.Serialization.Serializers.MemberBase.MemberType.prop.md) | [Int32](https://docs.microsoft.com/dotnet/api/system.int32) | Gets or sets the type of the member. See [MemberTypes](https://docs.microsoft.com/dotnet/api/system.reflection.membertypes) for options. |
| [`MemberValueType`](ExpressionPowerTools.Serialization.Serializers.MemberBase.MemberValueType.prop.md) | [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | Gets or sets the return type. |
| [`ReflectedType`](ExpressionPowerTools.Serialization.Serializers.MemberBase.ReflectedType.prop.md) | [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | Gets or sets the reflected type. Used for a unique key calculation. |

## Methods

| Method | Description |
| :-- | :-- |
| [String CalculateKey()](ExpressionPowerTools.Serialization.Serializers.MemberBase.CalculateKey.m.md) | Calculate the unique key. |
| [String GetKey()](ExpressionPowerTools.Serialization.Serializers.MemberBase.GetKey.m.md) | Gets the unique key for the member. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/3/2020 10:27:04 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.4-alpha |

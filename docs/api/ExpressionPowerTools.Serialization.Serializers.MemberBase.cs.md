# MemberBase Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **MemberBase**

Base class to serialize a member.

```csharp
public abstract class MemberBase
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **MemberBase**

Derived  [Method](ExpressionPowerTools.Serialization.Serializers.Method.cs.md) 

## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`DeclaringType`](ExpressionPowerTools.Serialization.Serializers.MemberBase.DeclaringType.prop.md) | [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | Gets or sets the declaring type. |
| [`MemberType`](ExpressionPowerTools.Serialization.Serializers.MemberBase.MemberType.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets or sets the type of the member. See [MemberTypes](https://docs.microsoft.com/dotnet/api/system.reflection.membertypes) for options. |
| [`MemberValueType`](ExpressionPowerTools.Serialization.Serializers.MemberBase.MemberValueType.prop.md) | [SerializableType](ExpressionPowerTools.Serialization.Serializers.SerializableType.cs.md) | Gets or sets the return type. |

## Methods

| Method | Description |
| :-- | :-- |
| [String CalculateKey()](ExpressionPowerTools.Serialization.Serializers.MemberBase.CalculateKey.m.md) | Calculate the unique key. |
| [String GetKey()](ExpressionPowerTools.Serialization.Serializers.MemberBase.GetKey.m.md) | Gets the unique key for the member. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

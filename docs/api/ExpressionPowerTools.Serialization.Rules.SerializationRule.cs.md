﻿# SerializationRule Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Rules](ExpressionPowerTools.Serialization.Rules.n.md) > **SerializationRule**

A rule for serialization.

```csharp
public class SerializationRule : ISerializationRule
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **SerializationRule**

Implements  [ISerializationRule](ExpressionPowerTools.Serialization.Signatures.ISerializationRule.i.md) 

## Remarks

This is a container for the rule and ultimately gets resolved to a key for a [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) and a boolean (authorized or not).

## Constructors

| Ctor | Description |
| :-- | :-- |
| [SerializationRule(Boolean allow, MemberInfo info)](ExpressionPowerTools.Serialization.Rules.SerializationRule.ctor.md#serializationruleboolean-allow-memberinfo-info) | Initializes a new instance of the [SerializationRule](ExpressionPowerTools.Serialization.Rules.SerializationRule.cs.md) class            with the options to allow and the match. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Allow`](ExpressionPowerTools.Serialization.Rules.SerializationRule.Allow.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the target is allowed. |
| [`MemberType`](ExpressionPowerTools.Serialization.Rules.SerializationRule.MemberType.prop.md) | [MemberTypes](https://docs.microsoft.com/dotnet/api/system.reflection.membertypes) | Gets the [MemberTypes](https://docs.microsoft.com/dotnet/api/system.reflection.membertypes) for the rule. |
| [`Target`](ExpressionPowerTools.Serialization.Rules.SerializationRule.Target.prop.md) | [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) | Gets the target. |
| [`TargetKey`](ExpressionPowerTools.Serialization.Rules.SerializationRule.TargetKey.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the target key. |

## Methods

| Method | Description |
| :-- | :-- |
| [Int32 GetHashCode()](ExpressionPowerTools.Serialization.Rules.SerializationRule.GetHashCode.m.md) | Gets the hash code of the key. |
| [String ToString()](ExpressionPowerTools.Serialization.Rules.SerializationRule.ToString.m.md) | Gets the member signature. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

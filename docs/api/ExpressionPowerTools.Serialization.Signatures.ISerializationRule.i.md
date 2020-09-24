# ISerializationRule Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > **ISerializationRule**

Represents a rule to allow or disallow a serialization.

```csharp
public interface ISerializationRule
```

Derived  [SerializationRule](ExpressionPowerTools.Serialization.Rules.SerializationRule.cs.md) 

## Remarks

The default for all methods is to not allow. The default configuration
            adds a set of rules for basic query functionality including [Enumerable](https://docs.microsoft.com/dotnet/api/system.linq.enumerable) and [Queryable](https://docs.microsoft.com/dotnet/api/system.linq.queryable) . An allow allows the
            full hierarchy of types. A disallow prohibits the full hierarchy. These
            can then be overridden.

## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Allow`](ExpressionPowerTools.Serialization.Signatures.ISerializationRule.Allow.prop.md) | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Gets a value indicating whether the rule is an allow. |
| [`TargetKey`](ExpressionPowerTools.Serialization.Signatures.ISerializationRule.TargetKey.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the unique key for the rule. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:02:13 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

# AnonInitializer Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > **AnonInitializer**

Wrapper for newing an anonymous expression.

```csharp
public class AnonInitializer
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **AnonInitializer**

## Remarks

This type exists so that an existing anonymous type initialization can be intercepted for serialization. On deserialization
            it is turned into an [ExpandoObject](https://docs.microsoft.com/dotnet/api/system.dynamic.expandoobject) .

## Constructors

| Ctor | Description |
| :-- | :-- |
| [AnonInitializer()](ExpressionPowerTools.Serialization.Serializers.AnonInitializer.ctor.md#anoninitializer) | Initializes a new instance of the [AnonInitializer](ExpressionPowerTools.Serialization.Serializers.AnonInitializer.cs.md) class. |
| [AnonInitializer(String typeName, String[] propertyNames, AnonValue[] values)](ExpressionPowerTools.Serialization.Serializers.AnonInitializer.ctor.md#anoninitializerstring-typename-string[]-propertynames-anonvalue[]-values) | Initializes a new instance of the [AnonInitializer](ExpressionPowerTools.Serialization.Serializers.AnonInitializer.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`AnonValue`](ExpressionPowerTools.Serialization.Serializers.AnonInitializer.AnonValue.prop.md) | [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) | Gets the anonymous type. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

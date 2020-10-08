# AnonType Constructors

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) > **AnonType()**

Initializes a new instance of the [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [AnonType()](#anontype) | Initializes a new instance of the [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) class. |
| [AnonType(Object anonymous, Func&lt;Type, String> getKey)](#anontypeobject-anonymous-functype-string-getkey) | Initializes a new instance of the [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) class            with an anonymous type. |

## AnonType()

Initializes a new instance of the [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) class.

```csharp
public AnonType()
```



## AnonType(Object anonymous, Func&lt;Type, String> getKey)

Initializes a new instance of the [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) class
            with an anonymous type.

```csharp
public AnonType(Object anonymous, Func<Type, String> getKey)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `anonymous` | [Object](https://docs.microsoft.com/dotnet/api/system.object) | The anonymous type. |
| `getKey` | [Func&lt;Type, String>](https://docs.microsoft.com/dotnet/api/system.func-2) | Function to get key for type. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 14:35:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

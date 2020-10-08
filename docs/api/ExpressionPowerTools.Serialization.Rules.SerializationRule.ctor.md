# SerializationRule Constructors

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Rules](ExpressionPowerTools.Serialization.Rules.n.md) > [SerializationRule](ExpressionPowerTools.Serialization.Rules.SerializationRule.cs.md) > **SerializationRule(Boolean allow, MemberInfo info)**

Initializes a new instance of the [SerializationRule](ExpressionPowerTools.Serialization.Rules.SerializationRule.cs.md) class
            with the options to allow and the match.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [SerializationRule(Boolean allow, MemberInfo info)](#serializationruleboolean-allow-memberinfo-info) | Initializes a new instance of the [SerializationRule](ExpressionPowerTools.Serialization.Rules.SerializationRule.cs.md) class            with the options to allow and the match. |

## SerializationRule(Boolean allow, MemberInfo info)

Initializes a new instance of the [SerializationRule](ExpressionPowerTools.Serialization.Rules.SerializationRule.cs.md) class
            with the options to allow and the match.

```csharp
public SerializationRule(Boolean allow, MemberInfo info)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `allow` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the rule is allowed. |
| `info` | [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) | The [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) the rule applies to. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) | Thrown when the type of member is not [Type](https://docs.microsoft.com/dotnet/api/system.type) , [ConstructorInfo](https://docs.microsoft.com/dotnet/api/system.reflection.constructorinfo) , [PropertyInfo](https://docs.microsoft.com/dotnet/api/system.reflection.propertyinfo) or [FieldInfo](https://docs.microsoft.com/dotnet/api/system.reflection.fieldinfo) . |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

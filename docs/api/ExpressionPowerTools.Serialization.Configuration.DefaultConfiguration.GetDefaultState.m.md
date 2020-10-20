# DefaultConfiguration.GetDefaultState Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Configuration](ExpressionPowerTools.Serialization.Configuration.n.md) > [DefaultConfiguration](ExpressionPowerTools.Serialization.Configuration.DefaultConfiguration.cs.md) > **GetDefaultState**

Gets a new [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) with default options.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetDefaultState()](#getdefaultstate) | Gets a new [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) with default options. |
## GetDefaultState()

Gets a new [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) with default options.

```csharp
public virtual SerializationState GetDefaultState()
```

### Return Type

 [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md)  - The [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) .


## Remarks

The default configuration is transferred to a new instance of [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) to prevent side effects (i.e. manipulation of the state affecting the default).


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

# Expression Power Tools Release Notes

[Back to README](./README.md)

- [0.8 Alpha](#08-Alpha)

## 0.8 Alpha

- [0.8.6-alpha](#086-alpha)
- [0.8.5-alpha](#085-alpha)
- [0.8.4-alpha](#084-alpha)
- [0.8.3-alpha](#083-alpha)
- [0.8.2-alpha](#082-alpha)
- [0.8.1-alpha](#081-alpha)
- [0.8.0-alpha](#080-alpha)

### 0.8.6-alpha

**_Breaking Change_**

An overload of the [`Serializer`](./docs/api/ExpressionPowerTools.Serialization.Serializer.cs.md) was changed. The non-typed `Deserialize` requires a
`IQueryHost` to understand the type being deserialized, but the typed overload can default to LINQ-to-objects.

**Serialization**

- Added [`ConfigurationBuilder`](./docs/api/ExpressionPowerTools.Serialization.Configuration.ConfigurationBuilder.cs.md) as the
optimal way to build configurations.
- Added [`DefaultConfiguration`](./docs/api/ExpressionPowerTools.Serialization.Configuration.DefaultConfiguration.cs.md) to 
allow default configurations. 

### 0.8.5-alpha

**Core**

- [#4](https://github.com/JeremyLikness/ExpressionPowerTools/issues/4) Added support for serialization and deserialization of `BinaryExpression` including as part of queries.

**Serialization**

- Refactored 

**Documentation**

- Fixed long names in [serialization reference](./docs/api/ExpressionPowerTools.Serialization.Serializers.ser.md) table. 
- Fixed issue in documentation with incorrect link for array types.
- Added these release notes.

### 0.8.4-alpha

**Core**

- Added equivalency and similarity support for `MemberInitExpression`.
- Added [`IDependentServiceRegistration`](./docs/api/ExpressionPowerTools.Core.Signatures.IDependentServiceRegistration.i.md) to enable registration from satellite assemblies. 

**Serialization**

- [#3](https://github.com/JeremyLikness/ExpressionPowerTools/issues/3) Added support for serialization and deserialization of `NewExpression` including as part of queries.
- Refactored [`ReflectionHelper`](./docs/api/ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) to use dependency injection instead of singleton.

**Documentation**

- Added a [serialization reference](./docs/api/ExpressionPowerTools.Serialization.Serializers.ser.md) with supported expression types.

### 0.8.3-alpha

**Serialization**

- Added the [`SerializationState`](./docs/api/ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) to pass options and support type compression.
- Added the [`CompressTypes`](./docs/api/ExpressionPowerTools.Serialization.Serializers.SerializationState.CompressTypes.prop.md) option.
- Implemented the [`TypeIndex`](./docs/api/ExpressionPowerTools.Serialization.Serializers.SerializationState.TypeIndex.prop.md) for type compression.

### 0.8.2-alpha

**Serialization**

- Added serialization support for `InvocationExpression`.
- Added serialization support for `LambdaExpression`.

### 0.8.1-alpha

- Automated workflows and added NuGet packages.

### 0.8.0-alpha

- Initialize release with documentation

# Expression Power Tools Release Notes

[Back to README](./README.md)

- [0.9 Beta](#09-Beta)
- [0.9 Alpha](#09-Alpha)
- [0.8 Alpha](#08-Alpha)

## 0.9 Beta

- [0.9.8-beta](#098-beta)
- [0.9.7-beta](#097-beta)
- [0.9.6-beta](#096-beta)
- [0.9.5-beta](#095-beta)

### 0.9.8-beta

**Serialization**

- Added custom rules, both "ordinary" that act as gateways (short circuit on failure, otherwise run other rules) and overrides that immediately set the result

**Samples**

- Added MVVM example that shows how to use a query pattern to test and apply queries

### 0.9.7-beta

**Serialization**

- Fixed bug when attaching query root: expressions should be directly applied and not wrapped in constant expressions 

### 0.9.6-beta

**Serialization**

- Fixed a bug when dealing with `null` constant expressions

### 0.9.5-beta 

**Breaking Changes**

- The call to `Deserialize` will now throw a `NotSupportedException` when the expression type is not supported
- The `Serializer` has been renamed to `QueryExprSerializer`
- Serialization is now decoupled from transport - the main serializers simply translate between expressions and serializable
classes that hold the data to recreate the expressions

**Core**

- Improved performance of `ParameterCount` in `MemberAdapter`
- Fixed equivalency of `NewExpression` to include members
- Added `SafeGetTypes` to `ServiceHost`

**Serialization**

- Re-introduced compressed types
- Simplified the serializers
- Added attribute to tag compressable key and logic to compress and decompress
- Modified Deserialize to tag an `ExpressionType` because that is already parsed anyway
- Implemented `IBaseSerializer` in `BaseSerializer` so that derived classes no longer require a redundant implementation

**EF Core AspNETCore Middleware**

- Changed to use new `JsonWrapper` service
- Added a registration for `Func<JsonSerializerOptions>` that can be overridden to provide defaults

**EF Core HTTP Client**

- Changed to return `List<T>` instead of `IList<T>`
- Modified to use new serializer

**Samples**

- Updated sample to show compiled and serialized query text, compressed types, and updated the UI

## 0.9 Alpha

- [0.9.4-alpha](#094-alpha)
- [0.9.3-alpha](#093-alpha)
- [0.9.2-alpha](#092-alpha)
- [0.9.1-alpha](#091-alpha)
- [0.9.0-alpha](#090-alpha)

### 0.9.4-alpha

**Serialization**

- Quick fix to catch `TypeLoadInitializationException` when scanning for repositories to register.

### 0.9.3-alpha

**Core**

- Simplified code and updated tests for test coverage
- Added anonymous comparers to `ExpressionEquivalency`
- Added `IsOrContainsAnonymousType` extension method
- Added handling for events to `MemberAdapter`
- Added tree view override for `EnumerableExpression`
- Added comparison support for `ElementInit` types
- Completely overhauled anonymous type handling (now expects anonymous types, will look at generating soon)
- Fixed `RecurseTypes` in `MemberAdapter` to handle extremely complex method closures
- Hopefully improved parsing speed by providing a method to parse out parameter counts

**Serialization**

- Fixed some test paths with constants and anonymous types
- Fixed the typed deserialization to allow a differently typed host (in => out)
- Added support for `MemberInitExpression`
- Added primitives, guid to default ruleset
- Removed compression of "new" expressions
- Moved compression into the serializer and added the option to configuration
- Added logic to capture default rules in the rules engine to easily capture and reset for tests
- Added primitives and collection types to default rules

**AspNetCore Middleware**

- Added default registrations for more EF Core functions

**Sample**

- Refactored sample app to multiple collections
- Added group by and select many examples

**Test**

- Added project and script to build test with code coverage and generated badges and reports. Manual (for now).

### 0.9.2-alpha

**Core**

- Enhanced member adapter to handle closed generic methods
- Added reset to member adapter for end-to-end testing

**ASP.NET Core Middelware**

- Added additional logging

### 0.9.1-alpha

Documentation-only release.

### 0.9.0-alpha

**Core**

- Added "member adapter" to manage members

**Serialization**

- Completely ripped out and refactored the type system. No more `SerializableType`.
- Removed overhead of "compile" from rules engine, switched to "just-in time" approach and 
improved performance several orders of magnitude
- Added `AnonInitializer`
- Added `AnonymousTypeAdapter` to handle round trip of anonymous types and convert to dynamic
- Test coverage

**Documentation**

- Added errors/warnings code
- Show when description is not found
- Use `MemberAdapter` to resolve types

## 0.8 Alpha

- [0.8.8-alpha](#088-alpha)
- [0.8.7-alpha](#087-alpha)
- [0.8.6-alpha](#086-alpha)
- [0.8.5-alpha](#085-alpha)
- [0.8.4-alpha](#084-alpha)
- [0.8.3-alpha](#083-alpha)
- [0.8.2-alpha](#082-alpha)
- [0.8.1-alpha](#081-alpha)
- [0.8.0-alpha](#080-alpha)

### 0.8.8-alpha

- Refactored serialization to support the option of a single result or count in addition to list.
- Created classes to compress/compile expressions so that variables are resolved to constants before transport over the wire.
- Added default rules for EF Core extensions.
- Added client code for registering an HttpClient.
- Added Blazor WebAssembly end-to-end sample.

### 0.8.7-alpha

- Added entire [ASP.NET Core Middleware](docs/api/ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) with tests.

### 0.8.6-alpha

**_Breaking Change_**

An overload of the [`Serializer`](./docs/api/ExpressionPowerTools.Serialization.Serializer.cs.md) was changed. The non-typed `Deserialize` requires a
`IQueryHost` to understand the type being deserialized, but the typed overload can default to LINQ-to-objects.

**Serialization**

- Added [`ConfigurationBuilder`](./docs/api/ExpressionPowerTools.Serialization.Configuration.ConfigurationBuilder.cs.md) as the
optimal way to build configurations.
- Added [`DefaultConfiguration`](./docs/api/ExpressionPowerTools.Serialization.Configuration.DefaultConfiguration.cs.md) to 
allow default configurations. 
- Extended [`ReflectionHelper`](./docs/api/ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) 
to provide ability to match closed members by [finding generic counterparts](./docs/api/ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.FindGenericVersion.m.md).
- Added [`SerializationRule`](./docs/api/ExpressionPowerTools.Serialization.Rules.SerializationRule.cs.md) and 
the [`RulesEngine`](./docs/api/ExpressionPowerTools.Serialization.Rules.RulesEngine.cs.md) to build/host/analyze rules.
- Added `TypeBase` for easy key calculation for types.
- Added [`MemberSelector`](./docs/api/ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) to provide 
ways to specify members when configuring rules using [`SelectorExtensions`](./docs/api/ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.cs.md)
- Added lazy service requests to [`ServiceHost`](./docs/api/ExpressionPowerTools.Core.Dependencies.ServiceHost.cs.md)
- Modified the expressions with methods and members (`BinaryExpression`, `NewExpression`, `MethodCallExpression` and 
`MemberAccessExpression`) to make authorization checks
- Added the [`ConfigureRules`](./docs/api/ExpressionPowerTools.Serialization.Serializer.ConfigureRules.m.md) method

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

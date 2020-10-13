# ExpressionExtensions.AsParameterExpression Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionExtensions](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.cs.md) > **AsParameterExpression**

Creates a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) based on the
            type of the object.

## Overloads

| Overload | Description |
| :-- | :-- |
| [AsParameterExpression(Object obj, String name, Boolean byRef)](#asparameterexpressionobject-obj-string-name-boolean-byref) | Creates a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) based on the            type of the object. |
| [AsParameterExpression(Type type, String name, Boolean byRef)](#asparameterexpressiontype-type-string-name-boolean-byref) | Creates a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) based on the [Type](https://docs.microsoft.com/dotnet/api/system.type) . |
## AsParameterExpression(Object obj, String name, Boolean byRef)

Creates a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) based on the
            type of the object.

```csharp
public static ParameterExpression AsParameterExpression(Object obj, String name, Boolean byRef)
```

### Return Type

 [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression)  - The [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `obj` | [Object](https://docs.microsoft.com/dotnet/api/system.object) | The object to inspect. |
| `name` | [String](https://docs.microsoft.com/dotnet/api/system.string) | Optional name for the parameter. |
| `byRef` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Set to `true` when parameter is by reference. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when object is null. |

## Examples

For example:

```csharp

var target = this.AsParameterExpression(nameof(parameter));
// target.Type == this.GetType(), target.Name == "parameter"
            
```

## AsParameterExpression(Type type, String name, Boolean byRef)

Creates a [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) based on the [Type](https://docs.microsoft.com/dotnet/api/system.type) .

```csharp
public static ParameterExpression AsParameterExpression(Type type, String name, Boolean byRef)
```

### Return Type

 [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression)  - The [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `type` | [Type](https://docs.microsoft.com/dotnet/api/system.type) | The [Type](https://docs.microsoft.com/dotnet/api/system.type) to use. |
| `name` | [String](https://docs.microsoft.com/dotnet/api/system.string) | Optional name for the parameter. |
| `byRef` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | Set to `true` when parameter is by reference. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when type is null. |

## Examples

For example:

```csharp

var target = GetType().AsParameterExpression();
// target.Type == GetType()
            
```


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 5:26:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

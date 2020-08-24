# Get started with Expression Power Tools

This library is designed to make it easier to work with expression trees and `IQueryable` in your .NET projects. The majority of capabilities are in the
[ExpressionPowerTools.Core](./api/ExpressionPowerTools.Core.a.md) package.

You can install it from:

[![NuGet Package](https://badgen.net/nuget/v/ExpressionPowerTools.Core)](https://www.nuget.org/packages/ExpressionPowerTools.Core/)

[Back to Main Documentation](../README.md)

**Table of Contents**

- [Create expressions](#create-expressions)
- [Parse expressions](#parse-expressions)
- [Enumerate expressions](#enumerate-and-filter-expressions)
- [Compare expressions](#compare-expressions)
- [Enumerate queries](#enumerate-queries)
- [Compare queries](#compare-queries)
- [Capture queries at execution time](#capture-queries-at-execution-time)
- [Intercept and modify queries](#intercept-and-modify-queries)

> This documentation is incomplete and will be updated over time.

## Create expressions

A few extension methods are designed to make it easier to build expressions.

### Constants

Any variable can be turned into a `ConstantExpression` by using [`AsConstantExpression()`](./api/ExpressionExtensions-AsConstantExpression.m.md).

```csharp
var age = 45;
var ageExpression = age.AsConstantExpression();
// same as Expression.Constant(45);
```

### Parameters

Turn types into parameters with or without names using [`AsParameterExpression()`](./api/ExpressionExtensions-AsParameterExpression.m.md).

```csharp
// create a parameter of type int
var parameter = typeof(int).AsParameterExpression();
// Expression.Parameter(typeof(int));

// create a string parameter with the name "name"
var parameter = typeof(int).AsParameterExpression("name");
// Expression.Parameter(typeof(int), "name");
```

## Parse expressions

A few helper methods help parse data out of expressions. For example, if you have a lambda that looks like this:

```csharp
Expression<Func<T>> member = () => foo;
```

You can [extract the member name](./api/ExpressionExtensions-MemberName.m.md) like this:

```csharp
var foo = member.MemberName();
// foo == "foo"
```

You can also [build parameters](./api/ExpressionExtensions-CreateParameterExpression.m.md) based on the type and name of a property.

```csharp
public class Foo
{
    public string Bar { get; set; }
}

var parameter = ExpressionExtensions.CreateParameterExpression<Foo, string>(
    foo => foo.Bar
);

// Expression.Parameter(typeof(string), nameof(Bar));
```

## Enumerate and filter expressions

The [`AsEnumerable()`](./api/ExpressionExtensions-AsEnumerable.m.md) extension "flattens" an expression tree so you can traverse it using a simple `foreach` loop. It is used internally by the comparison extensions that are described later. For example:

```csharp
var expr = Expression.GreaterThan(
    1.AsConstant(),
    2.AsConstant());
var flat = expr.AsEnumerable().ToList();
// [ BinaryExpression, ConstantExpression, ConstantExpression ]
```

### Filter expressions

Large expression trees can be complex and cumbersome to parse. Expression Power Tools contains several helper methods
for filitering and inspecting the trees.

**Extract constants**

```csharp
var expr = Expression.GreaterThan(
    1.AsConstant(),
    ((long)2).AsConstant());
var flat = expr.AsEnumerable();

var constants = flat.ConstantsOfType<long>().ToList();
// [ 2 ]
```

**Extract expressions of a type**

```csharp
var expr = Expression.GreaterThan(
    1.AsConstant(),
    ((long)2).AsConstant());
var flat = expr.AsEnumerable();

var binaryExpressions = flat.OfExpressionType(typeof(BinaryExpression)).ToList();
// [ GreaterThan ]
```

## Compare expressions

### Equivalency

### Similarity

## Enumerate queries

## Compare queries

## Capture queries at execution time

## Intercept and modify queries

# Get started with Expression Power Tools

This library is designed to make it easier to work with expression trees and `IQueryable` in your .NET projects. The majority of capabilities are in the
[ExpressionPowerTools.Core](./api/ExpressionPowerTools.Core.a.md) package.

[Click here](./endtoend.md) for an end-to-end quickstart using Blazor WebAssembly.

[Click here](./index.md) for the API documentation.

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

var objExpression = new object().AsConstantExpression();
```

### Parameters

Turn types into parameters with or without names using [`AsParameterExpression()`](./api/ExpressionExtensions-AsParameterExpression.m.md).

```csharp
// create a parameter of type int
var parameter = typeof(int).AsParameterExpression();
// Expression.Parameter(typeof(int));

// create a string parameter with the name "name"
int name = 5;
var parameter = typeof(int).AsParameterExpression(nameof(name));
// Expression.Parameter(typeof(int), "name");
```

You can also extend from instances:

```csharp
int name = 5;
var parameter = name.AsParameterExpression();
// Expression.Parameter(typeof(int), "name");
```

### Invocations

You can turn a lambda expression into an `InvocationExpression` by using 
[`AsInvocationExpression()`](./api/ExpressionExtensions-AsInvocationExpression.m.md).

```csharp
Expression<Func<int, int, long>> multiply = (a, b) => a * b;
var invocation = multiply.AsInvocationExpression();
```

## Parse expressions

A few helper methods help parse data out of expressions. For example, if you have a lambda that 
looks like this:

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

**Extract method call expressions**

There are several ways to extract methods from the expression tree. You can do it by name, by name for type,
or by using a template.

```csharp

var query = context.Products.Where(p => p.IsActive 
    && p.Created > DateTime.Now.AddDays(-5))
    .Take(5);

// `AsEnumerable` is explained below, but essentially it expands
// the expression tree behind the query
var expressions = query.Expression.AsEnumerable(); 

var methodByName = expressions
    .MethodsWithName(nameof(Queryable.Take))
    .Single();

// more explicit
var methodByType = expressions
    .MethodsWithNameForType<DateTime>(
        nameof(DateTime.AddDays))
    .First();

// or if you don't have an explicit type
var type = typeof(Queryable); // assume this can be 1..N types
var methodByVariableType = expressions
    .MethodsWithNameForType(
        type,
        nameof(Queryable.Take))
    .First();

// finally, use a template
var methodByTemplate = expressions 
    .MethodsFromTemplate<DateTime>(
        dt => dt.AddDays(1)) // value passed is ignored
    .First();
```

## Compare expressions

Using patterns like MVVM coupled with data access layers like EF Core allows your code to manpulate
queryables independent of the backend implementation. To validate the view model is applying filters
correctly, you often need to inspect the resulting queryable. In the past, I'd use hacks like creating
a known list of things then compare the filtered result to the expected. What I _really_ want is to 
inspect the shape of the query. This is possible with Expression Power Tools.

### Equivalency

Equivalency is a strict comparison of expression trees and expects all nodes and values to be the same.
It is effective for scenarios that the expression might be recreated or copied or must follow an exact
template. This feature is used exhaustively in the [Serialization]((./api/ExpressionPowerTools.Serialization.a.md)) tests.

```csharp
var expr = Expression.GreaterThan(
    1.AsConstantExpression(), 
    2.AsConstantExpression());

var expr1 = Expression.GreaterThan(
    1.AsConstantExpression(), 
    2.AsConstantExpression());

var expr2 = Expression.GreaterThan(
    2.AsConstantExpression(), 
    1.AsConstantExpression());

Assert.True(expr.IsEquivalentTo(expr1));
Assert.False(expr.IsEquivalentTo(expr2));
```

The specific rules for each expression are documented in [`DefaultComparisonRules`](./api/ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules.cs.md). Click through each rule to see
the related remarks.

### Similarity

Similarity is more flexible for checking on the presence of expressions within a tree. A few guiding principles
behind "similarity":

- Types are similar when they are assignable to each other
- Expression sub-trees are similar if they are part of a larger tree
- Names and primitives must still be exact matches

```csharp
var source = new List<int?> { 1, null, 3 }.AsConstantExpression();
var target = new List<int?> { 1, null, 3 }.AsConstantExpression();
Assert.True(eq.AreSimilar(source, target));

// int? not assignable to int
var source = new List<int?> { 1, null, 3 }.AsConstantExpression();
var target = new List<int> { 1, 3 }.AsConstantExpression();
Assert.False(eq.AreSimilar(source, target));

// list size doesn't matter for similarity
source = new[] { 1, 2, 3 }.AsConstantExpression();
target = new[] { 1, 2 }.AsConstantExpression();
Assert.True(eq.AreSimilar(source, target));

// one type derived from the other. Either direction is fine.
source = typeof(StringWrapper).AsParameterExpression();
target = typeof(DerivedStringWrapper).AsParameterExpression();
Assert.True(eq.AreSimilar(source, target));
Assert.True(eq.AreSimilar(target, source));

// different types are not similar
source = typeof(SomethingDifferent).AsParameterExpression();
target = typeof(StringWrapper).AsParameterExpression();
Assert.False(eq.AreSimilar(source, target));
```

You can also check if an expression tree is part of another expression tree. The 
[`IsPartOf()`](./api/ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.IsPartOf.m.md) call
uses similarity rules.

```csharp
var greaterThan = Expression.GreaterThan(
    1.AsConstantExpression(),
    2.AsConstantExpression());
Assert.True(1.AsConstantExpression().IsPartOf(greaterThan));

var query = context.Products
    .Where(p => p.IsActive)
    .OrderBy(p => p.Name)
    .Take(5);

var queryTakeMatch = context.Products.Take(5);

Assert.True(ExpressionSimiliarity
    .IsPartOf(queryTakeMatch.Expression, query.Expression));

// note that the larger tree is not part of the smaller tree
Assert.False(ExpressionSimilarity
    .IsPartOf(query.Expression, queryTakeMatch.Expression));

// values matter!
var queryTakeNoMatch = context.Products.Take(6);

Assert.False(ExpressionSimiliarity
    .IsPartOf(queryTakeNoMatch.Expression, query.Expression));
```

## Enumerate queries

As shown earlier, you can use the `AsEnumerableExpression()` extension method to turn a query into an
[`ExpressionEnumerator`](./api/ExpressionPowerTools.Core.ExpressionEnumerator.cs.md) (it calls `AsEnumerable()` 
on the query expression). The
`IQueryable` [extension methods](./api/ExpressionPowerTools.Core.Extensions.IQueryableExtensions.cs.md)
use this heavily.

## Compare queries

You can compare queries using both equivalency and similarity.

```csharp
var source = context.Products.Take(5);
var target = context.Products.Take(5);
Assert.True(source.IsEquivalentTo(target));

// use the query template helper to make a new blank query (does not inherit filters)
target = source.CreateQueryTemplate().Take(5);
Assert.True(source.IsSimilarTo(target));

// another way to create a fragment
target = IQueryableExtensions.CreateQueryTemplate<Product>()
    .Take(6);
Assert.False(source.IsSimilarTo(target)); // different take value
```

A common test is to check if a "fragment" or query subset is part of the source query. For example:

```csharp
var source = context.Products.Where(p => p.IsActive).Take(5);
var target = context.Products.Take(5);
Assert.False(source.IsSimilarTo(target));

// however, this works ...
Assert.True(source.HasFragment(q => q.Where(p => p.IsActive)));
Assert.True(source.HasFragment(q => q.Take(5)));
Assert.False(source.HasFragment(q => q.Take(6)));
Assert.False(source.HasFragment(q => q.Skip(2)));
```

## Capture queries at execution time

You can use the [`QuerySnapshotHost`](./api/ExpressionPowerTools.Core.Hosts.QuerySnapshotHost%601.cs.md) to wrap a query and receive a callback when it is executed. This is
useful for logging, telemetry, debugging, etc. An extension method is provided for this:

```csharp
var source = context.Products.Where(p => p.IsActive).OrderBy(p => p.Name);
var snapshot = target.CreateSnapshotQueryable(e => Console.WriteLine(e));
var firstFive = snapshot.Take(5).ToList();
// writes the full query including the "take" to the console            

static void CheckExpression(Expression expression)
{
   if (!expression.AsEnumerable()
       .MethodsWithName(nameof(Queryable.Take)).Any())
   {
       Logger.LogWarning($"Query detected without take: {expression}.");
   }
}
Expression expression = null;
var source = context.Products.Where(p => p.IsActive).OrderBy(p => p.Name);
var snapshot = target.CreateSnapshotQueryable(CheckExpression);
var all = snapshot.ToList(); // warning triggered
var firstFive = snapshot.Take(5).ToList(); // no warning
```

## Intercept and modify queries

Although a snapshot is useful, sometimes you want to intercept the query before it fires and
ensure the expression tree is appropriate. The intercepted queryable will do this.

```csharp
var query = context.Products.OrderBy(p => p.Name);
var intercepted = query.CreateInterceptedQueryable(e =>
{
    // always add a take 2
    var newQuery = query.Provider.CreateQuery<Product>(e)
                    .Take(2);
    return newQuery.Expression;
});
var result = intercepted.Skip(1).ToList();
Assert.Equal(2, result.Count);
var expected = query.Skip(1).Take(2).ToList();
Assert.Equal(expected, result);
# ExpressionPowerTools

![.NET Core](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/.NET%20Core/badge.svg)
![.NET Core Tests](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/.NET%20Core%20Tests/badge.svg)
![Generate and Publish Documentation](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/Generate%20and%20Publish%20Documentation/badge.svg)
![Pack and Publish NuGet](https://github.com/JeremyLikness/ExpressionPowerTools/workflows/Pack%20and%20Publish%20NuGet/badge.svg)

[Skip ahead to documentation](#documentation)

## What Expression Power Tools does

Expression Power Tools is an experiment I created to better understand and more easily work with expressions. The project started with a vision: the goal to be able to write a query on a client (like Blazor WebAssembly) and execute it remotely but securely on the server, like this:

```csharp
var list = await DbClientContext<ThingContext>.Query(context => context.Things)
    .Where(t => t.IsActive == ActiveFlag &&
        EF.Functions.Like(t.Name, $"%{nameFilter}%"))
    .OrderBy(t => EF.Property<DateTime>(t, nameof(Thing.Created)))
    .ExecuteRemote()
    .ToListAsync();
```

You can learn more about the implementation of this in the [Blazor Web Assembly quickstart](./docs/endtoend.md).

The central feature of the [Core library](docs/api/ExpressionPowerTools.Core.a.md) is a set of extensions for working with queries and expressions. For example, the following code uses an extension to create the `ConstantExpression` parameters for the `BinaryExpression` then uses `IExpressionEnumerable` to display the expression tree:

```csharp
var expr = Expression.GreaterThan(
    Expression.Constant(40),
    Expression.Constant(2));
var tree = expr.AsEnumerable(); // casts to IExpressionEnumerable
var treeDisplay = tree.ToString();
```

The example sets `treeDisplay` to:

```text
[LogicalBinaryExpression:GreaterThan] : Boolean => (40 > 2)
  [ConstantExpression:Constant] : Int32 => 40
  [ConstantExpression:Constant] : Int32 => 2
```

[See the Jupyter notebook example](./docs/notebooks/displayexpressiontree.ipynb)

A more involved example uses queries. Here is a query and its tree display:

```csharp
var query = querySource
    .Where(e => e.Id.StartsWith("a"))
    .Select(e => new { CapturedId = e.Id })
    .OrderBy(anonType => anonType.CapturedId)
    .Take(5);

var tree = query.AsEnumerableExpression();
```

Calling `tree.ToString()` will result in:

```text
[MethodCallExpression2:Call] : IQueryable`1 => System.Collections.Generic.List`1[Submission#8+Example].Where(e => e.Id.StartsWith("a")).Select(e => new <>f__AnonymousType0#1`1(CapturedId = e.Id)).OrderBy(anonType => anonType.CapturedId).Take(5)
  [MethodCallExpression2:Call] : IOrderedQueryable`1 => System.Collections.Generic.List`1[Submission#8+Example].Where(e => e.Id.StartsWith("a")).Select(e => new <>f__AnonymousType0#1`1(CapturedId = e.Id)).OrderBy(anonType => anonType.CapturedId)
    [MethodCallExpression2:Call] : IQueryable`1 => System.Collections.Generic.List`1[Submission#8+Example].Where(e => e.Id.StartsWith("a")).Select(e => new <>f__AnonymousType0#1`1(CapturedId = e.Id))
      [MethodCallExpression2:Call] : IQueryable`1 => System.Collections.Generic.List`1[Submission#8+Example].Where(e => e.Id.StartsWith("a"))
        [ConstantExpression:Constant] : EnumerableQuery`1 => System.Collections.Generic.List`1[Submission#8+Example]
        [UnaryExpression:Quote] : Expression`1 => e => e.Id.StartsWith("a")
          [Expression1`1:Lambda] : Func`2 => e => e.Id.StartsWith("a")
            [TypedParameterExpression:Parameter] : Example => e
            [InstanceMethodCallExpression1:Call] : Boolean => e.Id.StartsWith("a")
              [PropertyExpression:MemberAccess] : String => e.Id
                [TypedParameterExpression:Parameter] : Example => e
              [ConstantExpression:Constant] : String => "a"
      [UnaryExpression:Quote] : Expression`1 => e => new <>f__AnonymousType0#1`1(CapturedId = e.Id)
        [Expression1`1:Lambda] : Func`2 => e => new <>f__AnonymousType0#1`1(CapturedId = e.Id)
          [TypedParameterExpression:Parameter] : Example => e
          [NewExpression:New] : <>f__AnonymousType0#1`1 => new <>f__AnonymousType0#1`1(CapturedId = e.Id)
            [PropertyExpression:MemberAccess] : String => e.Id
              [TypedParameterExpression:Parameter] : Example => e
    [UnaryExpression:Quote] : Expression`1 => anonType => anonType.CapturedId
      [Expression1`1:Lambda] : Func`2 => anonType => anonType.CapturedId
        [TypedParameterExpression:Parameter] : <>f__AnonymousType0#1`1 => anonType
        [PropertyExpression:MemberAccess] : String => anonType.CapturedId
          [TypedParameterExpression:Parameter] : <>f__AnonymousType0#1`1 => anonType
  [ConstantExpression:Constant] : Int32 => 5
```

To get the "Take" value (results in `take` with value of `5`):

```csharp
var take = tree.MethodsWithName(nameof(Queryable.Take))
    .SelectMany(m => m.AsEnumerable().ConstantsOfType<int>())
    .First().Value; // 5
```

You can inspect branches of the expression tree:

```csharp
var skip = query.HasFragment(q => q.Skip(5)); // false
var take5 = query.HasFragment(q => q.Take(5)); // true
var take10 = query.HasFragment(q => q.Take(10)); // false
```

And even make comparisons:

```csharp
var query1 = querySource
    .Where(e => e.Id.StartsWith("a"))
    .Select(e => new { CapturedId = e.Id })
    .OrderBy(anonType => anonType.CapturedId)
    .Take(6);

var query2 = querySource
    .Where(e => e.Id.StartsWith("b"))
    .Select(e => new { CapturedId = e.Id })
    .OrderBy(anonType => anonType.CapturedId)
    .Take(5);

var query3 = querySource
    .Where(e => e.Id.StartsWith("a"))
    .Select(e => new { CapturedId = e.Id })
    .OrderBy(anonType => anonType.CapturedId)
    .Take(5);

var query1eq = query1.IsEquivalentTo(query); // false: Take(6) != Take(5)
var query2eq = query2.IsEquivalentTo(query); // false: StartsWith("b") != StartsWith("a")
var query3eq = query3.IsEquivalentTo(query); // true
```

[See these examples in a Jupyter notebook](.docs/notebooks/displayiqueryable.ipynb)

There are many more features so be sure to check out the documentation!

## Documentation

There are a few options for documentation, including:

- [API Documentation](docs/index.md)
- [Quick Start](docs/quickstart.md)
- [Release Notes](./Releases.md)
- [Test Reports](docs/test/index.md)

**Documentation Tip** Because the documentation is stored in this repo, you can use the GitHub "Go to file" feature to quickly find documentation for a type or member. Just click _Go to File_ and type the name of the method or type and look for the markdown file. You can infer the type of documentation from the extension:

- `.a.md` - assemblies
- `.ns.md` - namespaces
- `.cs.md` - types (classes)
- `.i.md` - types (interfaces)
- `.ctor.md` - constructors
- `.m.md` - methods
- `.prop.md` - properties

### Libraries

The following libraries are available to use.

### Core

[![NuGet Badge](https://buildstats.info/nuget/ExpressionPowerTools.Core?includePreReleases=true)](https://www.nuget.org/packages/ExpressionPowerTools.Core)
[![Tests](docs/test/ExpressionPowerTools.Core.Tests.svg)](docs/test//ExpressionPowerTools.Core.test.md)
[![Coverage](docs/test/ExpressionPowerTools.Core.Coverage.svg)](docs/test//ExpressionPowerTools.Core.coverage.md)

```powershell
Install-Package ExpressionPowerTools.Core -Version 0.9.2-alpha
```

Power tools for working with `IQueryable` and Expression trees. Enables enumeration of the tree, comparisons ("similar" and "equivalent") and interception to take snapshots and/or mutate expressions.  

[API Documentation](docs/api/ExpressionPowerTools.Core.a.md)

### Serialization

[![NuGet Badge](https://buildstats.info/nuget/ExpressionPowerTools.Serialization?includePreReleases=true)](https://www.nuget.org/packages/ExpressionPowerTools.Serialization)
[![Tests](docs/test/ExpressionPowerTools.Serialization.Tests.svg)](docs/test//ExpressionPowerTools.Serialization.test.md)
[![Coverage](docs/test/ExpressionPowerTools.Serialization.Coverage.svg)](docs/test//ExpressionPowerTools.Serialization.coverage.md)

```powershell
Install-Package ExpressionPowerTools.Serialization -Version 0.9.2-alpha
```

Power tools for writing client-side queries that can be safely serialized to run on the server.

[API Documentation](docs/api/ExpressionPowerTools.Serialization.a.md)

### ASP.NET Core Middleware for EF Core

[![NuGet Badge](https://buildstats.info/nuget/ExpressionPowerTools.Serialization.EFCore.AspNetCore?includePreReleases=true)](https://www.nuget.org/packages/ExpressionPowerTools.Serialization.EFCore.AspNetCore)
[![Tests](docs/test/ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.svg)](docs/test//ExpressionPowerTools.Serialization.EFCore.AspNetCore.test.md)
[![Coverage](docs/test/ExpressionPowerTools.Serialization.EFCore.AspNetCore.Coverage.svg)](docs/test//ExpressionPowerTools.Serialization.EFCore.AspNetCore.coverage.md)

```powershell
Install-Package ExpressionPowerTools.Serialization.EFCore.AspNetCore -Version 0.9.2-alpha
```

Power tools for deserializing queries initiated by remote clients.

[API Documentation](docs/api/ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md)

### Http Client

[![NuGet Badge](https://buildstats.info/nuget/ExpressionPowerTools.Serialization.EFCore.Http?includePreReleases=true)](https://www.nuget.org/packages/ExpressionPowerTools.Serialization.EFCore.Http)
[![Tests](docs/test/ExpressionPowerTools.Serialization.EFCore.Http.Tests.svg)](docs/test//ExpressionPowerTools.Serialization.EFCore.Http.test.md)
[![Coverage](docs/test/ExpressionPowerTools.Serialization.EFCore.Http.Coverage.svg)](docs/test//ExpressionPowerTools.Serialization.EFCore.Http.coverage.md)


```powershell
Install-Package ExpressionPowerTools.Serialization.EFCore.Http -Version 0.9.2-alpha
```

Power tools for running remote queries over HTTP, for example a Blazor WebAssembly client.

[API Documentation](docs/api/ExpressionPowerTools.Serialization.EFCore.Http.a.md)

### Documentation Generator

The documentation generator is an internal utility that auto-generates API documentation based on comments and reflection. IT directly generates markdown. Also self-documents.

[API Documentation](docs/api/ExpressionPowerTools.Utilities.DocumentGenerator.a.md)

# MiddlewareExtensions Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore](ExpressionPowerTools.Serialization.EFCore.AspNetCore.a.md) > [ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions.n.md) > **MiddlewareExtensions**

Extensions to configure the middleware.

```csharp
public static class MiddlewareExtensions
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **MiddlewareExtensions**

## Examples

For example, to set up a default route for a `DbContext` named `ThingContext` your code should look like:

```csharp
app.UseEndpoints(endpoints =>
            {
               endpoints.MapPowerToolsEFCore<ThingContext>();
               endpoints.MapRazorPages();
            });
            
```

Be sure the context is registered with dependency injection. This is how the tools instantiate the instance to
            run queries against.
            The example will listen on the path `/efcore/ThingContext/collection` where collection is the name of the `DbSet` property. You can customize the path:

```csharp
endpoints.MapPowerToolsEFCore<ThingContext>(pattern: "/queries/{context}/set/{collection}");
            
```

It is also possible to customize rules. If you have a class named `MyClass` that has methods for the query
            to run, you can add it:

```csharp
endpoints.MapPowerToolsEFCore<ThingContext>(rules: rule => rule.RuleForType<MyClass>().Allow());
            
```

See documentation for the [RulesEngine](ExpressionPowerTools.Serialization.Rules.RulesEngine.cs.md) to understand the rules engine.

## Remarks

After referencing the project or NuGet package, you can add the middleware using endpoint routing. This should happen
            in the `Configure` method in `Startup.cs` . First, make sure you have `app.UseRouting()` . Next, use
            the extension to set up the endpoint.

## Methods

| Method | Description |
| :-- | :-- |
| [IEndpointConventionBuilder MapPowerToolsEFCore&lt;T1Context, T2Context>(IEndpointRouteBuilder endpointRouteBuilder, String pattern, Action&lt;IRulesConfiguration> rules, Boolean noDefaultRules, Action&lt;IConfigurationBuilder> options)](ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions.MiddlewareExtensions.MapPowerToolsEFCore.m.md) | Map a route and allow two [DbContext](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.dbcontext) instances. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:57:42 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

# Blazor WebAssembly End-to-End

This documentation covers how to execute remote queries for EF Core from Blazor WebAssembly.

[Back to basic quickstart](./quickstart.md)

[Back to API index](./index.md)

## Create Your Project

Create the project. You can either create a Blazor WebAssembly project that is ASP .NET Core hosted, or have a separate ASP .NET Core project for the server.

## Add and Configure the Middleware

Install the middleware NuGet package in your ASP .NET Core project:

```powershell
Install-Package ExpressionPowerTools.Serialization.EFCore.AspNetCore -Version 0.8.8-alpha
```

In `Startup.cs` add the middleware. This examle expects a `DbContext` named `ThingContext`:

```csharp
app.UseEndpoints(endpoints =>
{
   endpoints.MapPowerToolsEFCore<ThingContext>();
   endpoints.MapRazorPages();
})
```

See [MiddlewareExtensions](api/ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions.MiddlewareExtensions.cs.md) for more details.

## Add and Configure the Client Serializer

Install the power tools client in your Blazor WebAssembly project. For the scenario to work, your Blazor WebAssembly project must have a reference to the `DbContext`.

```powershell
Install-Package ExpressionPowerTools.Serialization.EFCore.Http -Version 0.8.8-alpha
```

In your `Program.cs` initialize the client with the base URI:

```csharp
builder.Services.AddExpressionPowerToolsEFCore(new Uri(builder.HostEnvironment.BaseAddress));
```

See [ClientExtensions](api/ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.cs.md) for more information on options for configuration.

## Execute your Query

The tool works by allowing you to build a query like one you would run on the server. You use an extension method to serialize the query, run it remotely, and 
grab the results. You can even use EF Core extension methods! Start with the [DbClientContext&lt;TContext>](api/ExpressionPowerTools.Serialization.EFCore.Http.Queryable.DbClientContext`1.cs.md) and
specify the root collection to start from. 

```csharp
var query = DbClientContext<ThingContext>.Query(context => context.Things)
    .Where(t => t.IsActive == ActiveFlag &&
        EF.Functions.Like(t.Name, $"%{nameFilter}%"))
    .OrderBy(t => EF.Property<DateTime>(t, nameof(Thing.Created)));   
```

Now ... how to get the results? Use the [ExecuteRemote](api/ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.ExecuteRemote.m.md) extension:

```csharp
var results = await query.ExecuteRemote().ToListAsync();
```

You can also fetch a single item or get a count. All operations are run remotely on the server and by the database.

For a working example, check out the [Simple Blazor WebAssembly sample](https://github.com/JeremyLikness/ExpressionPowerTools/tree/master/samples/Blazor/SimpleBlazorWasm).
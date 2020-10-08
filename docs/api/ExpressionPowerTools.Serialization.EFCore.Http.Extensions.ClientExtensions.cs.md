# ClientExtensions Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Extensions](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.n.md) > **ClientExtensions**

Client extensions for remote queries.

```csharp
public static class ClientExtensions
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ClientExtensions**

## Examples

The first step is to register the client. The client uses [IHttpClientFactory](https://docs.microsoft.com/dotnet/api/system.net.http.ihttpclientfactory) to register a
            typed instance of [IRemoteQueryClient](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryClient.i.md) for processing. This requires a base address to make calls.

```csharp
builder.Services.AddExpressionPowerToolsEFCore(new Uri(builder.HostEnvironment.BaseAddress));
            
```

This is typically done in the `Program.cs` for Blazor WebAssembly. It should be part of initialization as it
            configures the internal dependency injection service ( [ServiceHost](ExpressionPowerTools.Core.Dependencies.ServiceHost.cs.md) ). You must have a reference to the `DbContext` (it is used for the shape of the query and never run on the client). Use the [DbClientContext&lt;TContext>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.DbClientContext`1.cs.md) to start your query by referencing a root collection to use.

```csharp
var query = DbClientContext<ThingContext>.Query(context => context.Things)
                .Where(t => t.IsActive == ActiveFlag &&
                    EF.Functions.Like(t.Name, $"%{nameFilter}%"))
                .OrderBy(t => EF.Property<DateTime>(t, nameof(Thing.Created)));
            
```

When you are ready to execute the query remotely, use the `ExecuteRemote` extension
            and specify the collection type, a single item, or count.

```csharp
var result = await query.ExecuteRemote().ToListAsync();
            
```

## Remarks

There are a few steps involved to run and resolve a remote query. See examples for more information.

## Methods

| Method | Description |
| :-- | :-- |
| [Void AddExpressionPowerToolsEFCore(IServiceCollection collection, Uri baseAddress, Action&lt;IClientHttpConfiguration> configure)](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.AddExpressionPowerToolsEFCore.m.md) | Adds the client and provides the opportunity to configure it. |
| [Task&lt;IEnumerable&lt;T>> AsEnumerableAsync&lt;T>(IRemoteQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.AsEnumerableAsync.m.md) | Grabs the enumerable. |
| [IQueryable&lt;T> AsRemoteQueryable&lt;T>(IEnumerable&lt;T> source, RemoteContext context)](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.AsRemoteQueryable.m.md) | Takes an enumerable and builds a host for remote processing. |
| [Task&lt;Int32> CountAsync&lt;T>(IRemoteQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.CountAsync.m.md) | Provides a count of the query. |
| [IRemoteQueryable&lt;T> ExecuteRemote&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.ExecuteRemote.m.md) | Use this to indicate you are about to run a remote query. |
| [Task&lt;T> FirstOrSingleAsync&lt;T>(IRemoteQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.FirstOrSingleAsync.m.md) | Grabs the first item, or the single item, from the result. |
| [Task&lt;T[]> ToArrayAsync&lt;T>(IRemoteQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.ToArrayAsync.m.md) | Grabs the array. |
| [Task&lt;HashSet&lt;T>> ToHashSetAsync&lt;T>(IRemoteQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.ToHashSetAsync.m.md) | Grabs the hash set. |
| [Task&lt;IList&lt;T>> ToListAsync&lt;T>(IRemoteQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Extensions.ClientExtensions.ToListAsync.m.md) | Grabs the list. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 17:35:59 | (c) Copyright 2020 Jeremy Likness. | 0.9.4-alpha |

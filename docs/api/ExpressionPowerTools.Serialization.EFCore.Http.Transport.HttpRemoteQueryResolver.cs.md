# HttpRemoteQueryResolver Class

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Transport](ExpressionPowerTools.Serialization.EFCore.Http.Transport.n.md) > **HttpRemoteQueryResolver**

Handles remote requests.

```csharp
public class HttpRemoteQueryResolver : IRemoteQueryResolver
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **HttpRemoteQueryResolver**

Implements  [IRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [HttpRemoteQueryResolver()](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.ctor.md#httpremotequeryresolver) | Initializes a new instance of the [HttpRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Task&lt;IEnumerable&lt;T>> AsEnumerableAsync&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.AsEnumerableAsync.m.md) | Execute the remote query and materialize the results. |
| [Task&lt;Int32> CountAsync&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.CountAsync.m.md) | Execute the remote query and materialize the count. |
| [Task&lt;T> FirstOrSingleAsync&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.FirstOrSingleAsync.m.md) | Execute the remote query and materialize the single item. |
| [Task&lt;T[]> ToArrayAsync&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.ToArrayAsync.m.md) | Execute the remote query and materialize the results. |
| [Task&lt;HashSet&lt;T>> ToHashSetAsync&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.ToHashSetAsync.m.md) | Execute the remote query and materialize the results. |
| [Task&lt;List&lt;T>> ToListAsync&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.ToListAsync.m.md) | Execute the remote query and materialize the results. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |

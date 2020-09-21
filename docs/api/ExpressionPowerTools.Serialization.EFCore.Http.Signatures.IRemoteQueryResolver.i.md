# IRemoteQueryResolver Interface

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Signatures](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.n.md) > **IRemoteQueryResolver**

Responsible for resolving remote queries.

```csharp
public interface IRemoteQueryResolver
```

Derived  [HttpRemoteQueryResolver](ExpressionPowerTools.Serialization.EFCore.Http.Transport.HttpRemoteQueryResolver.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [Task&lt;IEnumerable&lt;T>> AsEnumerableAsync&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.AsEnumerableAsync.m.md) | Resolves to an enumerable. |
| [Task&lt;Int32> CountAsync&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.CountAsync.m.md) | Resolves to a count.. |
| [Task&lt;T> FirstOrSingleAsync&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.FirstOrSingleAsync.m.md) | Returns a single entity. |
| [Task&lt;T[]> ToArrayAsync&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.ToArrayAsync.m.md) | Resolves to an array. |
| [Task&lt;HashSet&lt;T>> ToHashSetAsync&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.ToHashSetAsync.m.md) | Resolves to a hash set. |
| [Task&lt;IList&lt;T>> ToListAsync&lt;T>(IQueryable&lt;T> query)](ExpressionPowerTools.Serialization.EFCore.Http.Signatures.IRemoteQueryResolver.ToListAsync.m.md) | Resolves to a list. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/21/2020 19:07:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

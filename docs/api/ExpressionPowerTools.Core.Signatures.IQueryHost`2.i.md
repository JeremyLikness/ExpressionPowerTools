# IQueryHost&lt;T, TProvider> Interface

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IQueryHost&lt;T, TProvider>**

Interface for custom query host.

```csharp
public interface IQueryHost<T, TProvider> : IOrderedQueryable<T>
   where TProvider : ICustomQueryProvider<T>
```

## Type Parameters

**`T`**
The type of entity.

**`TProvider`**
The [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) to handle logic.

---

Implements  [IOrderedQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable-1) ,  [IQueryable&lt;T>](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1) ,  [IEnumerable&lt;T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1) ,  [IEnumerable](https://docs.microsoft.com/dotnet/api/system.collections.ienumerable) ,  [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) ,  [IOrderedQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iorderedqueryable) 

## Examples


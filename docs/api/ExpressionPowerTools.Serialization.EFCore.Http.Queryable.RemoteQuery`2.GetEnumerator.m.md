# RemoteQuery&lt;T, TProvider>.GetEnumerator Method

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Queryable](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.n.md) > [RemoteQuery<T, TProvider>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQuery`2.cs.md) > **GetEnumerator**

Gets the enumerator of the result. Overridden to prevent issues trying to execute
            a database query directly.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetEnumerator()](#getenumerator) | Gets the enumerator of the result. Overridden to prevent issues trying to execute            a database query directly. |
## GetEnumerator()

Gets the enumerator of the result. Overridden to prevent issues trying to execute
            a database query directly.

```csharp
public virtual IEnumerator<T> GetEnumerator()
```

### Return Type

 [IEnumerator&lt;T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerator-1)  - An empty enumerator.



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/20/2020 6:32:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.9.0-alpha |

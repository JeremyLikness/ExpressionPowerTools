﻿# IQueryInterceptingProvider&lt;T> Interface

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IQueryInterceptingProvider<T>**

Interface for provider that intercepts the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) when run.

```csharp
public interface IQueryInterceptingProvider<T> : IQueryInterceptor, ICustomQueryProvider<T>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | None. | The type. |

Implements  [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) ,  [IQueryInterceptor](ExpressionPowerTools.Core.Signatures.IQueryInterceptor.i.md) ,  [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) 

Derived  [QueryInterceptingProvider&lt;T>](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.cs.md) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

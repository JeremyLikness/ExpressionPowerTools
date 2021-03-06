﻿# QueryInterceptingProvider&lt;T>.Execute Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > [QueryInterceptingProvider<T>](ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.cs.md) > **Execute**

Execute with transformation.

## Overloads

| Overload | Description |
| :-- | :-- |
| [Execute(Expression expression)](#executeexpression-expression) | Execute with transformation. |
## Execute(Expression expression)

Execute with transformation.

```csharp
public virtual Object Execute(Expression expression)
```

### Return Type

 [Object](https://docs.microsoft.com/dotnet/api/system.object)  - Result of executing the transformed expression.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The base [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when expression is null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

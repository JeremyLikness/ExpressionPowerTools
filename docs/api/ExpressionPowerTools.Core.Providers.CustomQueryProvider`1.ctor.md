# CustomQueryProvider&lt;T> Constructors

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > [CustomQueryProvider<T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) > **CustomQueryProvider(IQueryable sourceQuery)**

Initializes a new instance of the [CustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [CustomQueryProvider(IQueryable sourceQuery)](#customqueryprovideriqueryable-sourcequery) | Initializes a new instance of the [CustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) class. |

## CustomQueryProvider(IQueryable sourceQuery)

Initializes a new instance of the [CustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) class.

```csharp
public CustomQueryProvider(IQueryable sourceQuery)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `sourceQuery` | [IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The query to snapshot. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throw when query is null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/25/2020 00:25:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

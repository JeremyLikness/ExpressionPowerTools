# CustomQueryProvider&lt;T> Constructors

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Providers](ExpressionPowerTools.Core.Providers.n.md) > [CustomQueryProvider<T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) > **CustomQueryProvider&lt;T>(IQueryable sourceQuery)**

Initializes a new instance of the [CustomQueryProvider<T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [CustomQueryProvider&lt;T>(IQueryable sourceQuery)](#ctor-0) | Initializes a new instance of the [CustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) class. |

<a name="#ctor-0"></a>
## CustomQueryProvider&lt;T>(IQueryable sourceQuery)

Initializes a new instance of the [CustomQueryProvider<T>](ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.cs.md) class.

```csharp
public CustomQueryProvider<T>(IQueryable sourceQuery)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `sourceQuery` | [System.Linq.IQueryable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable) | The query to snapshot. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [System.ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Throw when query is null. |


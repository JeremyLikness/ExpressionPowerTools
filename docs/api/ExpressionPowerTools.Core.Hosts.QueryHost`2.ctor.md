# QueryHost&lt;T, TProvider> Constructors

[ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) > **QueryHost&lt;T, TProvider>(Expression expression, TProvider provider)**

Initializes a new instance of the [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [QueryHost&lt;T, TProvider>(Expression expression, TProvider provider)](#ctor-0) |

<a name="#ctor-0"></a>
## QueryHost&lt;T, TProvider>(Expression expression, TProvider provider)

Initializes a new instance of the [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) class.

```csharp
public QueryHost<T, TProvider>(Expression expression, TProvider provider)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `provider` | [TProvider](https://docs.microsoft.com/dotnet/api/expressionpowertools.core.hosts.tprovider) | The [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when expression or provider are null. |


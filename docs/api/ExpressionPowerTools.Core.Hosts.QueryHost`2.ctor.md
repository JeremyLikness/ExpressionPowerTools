# QueryHost&lt;T, TProvider> Constructors

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Hosts](ExpressionPowerTools.Core.Hosts.n.md) > [QueryHost<T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) > **QueryHost(Expression expression, TProvider provider)**

Initializes a new instance of the [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [QueryHost(Expression expression, TProvider provider)](#queryhostexpression-expression-tprovider-provider) | Initializes a new instance of the [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) class. |

## QueryHost(Expression expression, TProvider provider)

Initializes a new instance of the [QueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Hosts.QueryHost`2.cs.md) class.

```csharp
public QueryHost(Expression expression, TProvider provider)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) . |
| `provider` | TProvider | The [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) . |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when expression or provider are null. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:50:49 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

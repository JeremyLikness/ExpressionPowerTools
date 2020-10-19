# RemoteQuery&lt;T, TProvider> Constructors

[Index](../index.md) > [ExpressionPowerTools.Serialization.EFCore.Http](ExpressionPowerTools.Serialization.EFCore.Http.a.md) > [ExpressionPowerTools.Serialization.EFCore.Http.Queryable](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.n.md) > [RemoteQuery<T, TProvider>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQuery`2.cs.md) > **RemoteQuery(Expression expression, TProvider provider)**

Initializes a new instance of the [RemoteQuery&lt;T, TProvider>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQuery`2.cs.md) class.

## Overloads

| Ctor | Description |
| :-- | :-- |
| [RemoteQuery(Expression expression, TProvider provider)](#remotequeryexpression-expression-tprovider-provider) | Initializes a new instance of the [RemoteQuery&lt;T, TProvider>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQuery`2.cs.md) class. |

## RemoteQuery(Expression expression, TProvider provider)

Initializes a new instance of the [RemoteQuery&lt;T, TProvider>](ExpressionPowerTools.Serialization.EFCore.Http.Queryable.RemoteQuery`2.cs.md) class.

```csharp
public RemoteQuery(Expression expression, TProvider provider)
```

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expression` | [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) | The [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) to parse. |
| `provider` | TProvider | The [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) . |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |

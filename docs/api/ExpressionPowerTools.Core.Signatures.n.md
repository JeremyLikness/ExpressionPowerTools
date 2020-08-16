# ExpressionPowerTools.Core.Signatures Namespace

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > **ExpressionPowerTools.Core.Signatures**

## Interfaces

| Interface | Description |
| :-- | :-- |
| [ICustomQueryProvider&lt;T>](ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.i.md) | Interface for a custom implementation of [IQueryProvider](https://docs.microsoft.com/dotnet/api/system.linq.iqueryprovider) . |
| [IExpressionComparisonRuleProvider](ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider.i.md) | Interface for a class that provides rules for comparisons. |
| [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) | Enables recursing over an expression tree. |
| [IExpressionEvaluator](ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.i.md) | Evaluator as facade to equivalency and similarity. |
| [IQueryHost&lt;T, TProvider>](ExpressionPowerTools.Core.Signatures.IQueryHost`2.i.md) | Interface for custom query host. |
| [IQueryInterceptingProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQueryInterceptingProvider`1.i.md) | Interface for provider that intercepts the [Expression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression) when run. |
| [IQueryInterceptor](ExpressionPowerTools.Core.Signatures.IQueryInterceptor.i.md) | Exposes a method to register a transformation. |
| [IQuerySnapshot](ExpressionPowerTools.Core.Signatures.IQuerySnapshot.i.md) | Non-generic interface for snapshot host. |
| [IQuerySnapshotHost&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.i.md) | Host to snapshot a query. Will raise an event when it is executed            to allow inspecting the expression. |
| [IQuerySnapshotProvider&lt;T>](ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1.i.md) | Provider to intercept query execution for inspection. |
| [IServiceRegistration](ExpressionPowerTools.Core.Signatures.IServiceRegistration.i.md) | Interface for service registration. |
| [IServices](ExpressionPowerTools.Core.Signatures.IServices.i.md) | Service registration and resolution. |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/16/2020 4:18:46 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

﻿# ExpressionRulesExtensions.ExpressionsMustBeSimilar Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionRulesExtensions](ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions.cs.md) > **ExpressionsMustBeSimilar**



## Overloads

| Overload | Description |
| :-- | :-- |
| [ExpressionsMustBeSimilar&lt;T>(Func&lt;T, Expression> member)](#expressionsmustbesimilartfunct-expression-member) |  |
## ExpressionsMustBeSimilar&lt;T>(Func&lt;T, Expression> member)



```csharp
public static Expression<Func<T, T, Boolean>> ExpressionsMustBeSimilar<T>(Func<T, Expression> member)
```

### Return Type

 [Expression&lt;Func&lt;T, T, Boolean>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [Func&lt;T, Expression>](https://docs.microsoft.com/dotnet/api/system.func-2) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/16/2020 4:18:46 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |
# IExpressionEnumeratorExtensions Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > **IExpressionEnumeratorExtensions**

Extensions for filtering [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) .

```csharp
public static class IExpressionEnumeratorExtensions
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **IExpressionEnumeratorExtensions**

## Methods

| Method | Description |
| :-- | :-- |
| [IEnumerable&lt;ConstantExpression> ConstantsOfType&lt;T>(IExpressionEnumerator expressionEnumerator)](ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.ConstantsOfType.m.md) | Helper extension to extract constants from an expression tree. |
| [IEnumerable&lt;MethodCallExpression> MethodsFromTemplate&lt;T>(IExpressionEnumerator expressionEnumerator, Expression&lt;Action&lt;T>> method)](ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.MethodsFromTemplate.m.md) | Use a template to specify the method to search for. |
| [IEnumerable&lt;MethodCallExpression> MethodsWithName(IExpressionEnumerator expressionEnumerator, String name)](ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.MethodsWithName.m.md) | Helper extension to extract methods with a particular name. |
| [IEnumerable&lt;MethodCallExpression> MethodsWithNameForType(IExpressionEnumerator expressionEnumerator, Type type, String name)](ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.MethodsWithNameForType.m.md) | Extracts instances of expressions that represent a method            on a type. |
| [IEnumerable&lt;Expression> OfExpressionType(IExpressionEnumerator expressionEnumerator, ExpressionType type)](ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.OfExpressionType.m.md) | Helper extension to extract nodes with a specific [ExpressionType](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expressiontype) value. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/4/2020 7:10:41 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.5-alpha |

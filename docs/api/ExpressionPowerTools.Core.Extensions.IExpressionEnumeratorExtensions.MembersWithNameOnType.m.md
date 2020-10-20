# IExpressionEnumeratorExtensions.MembersWithNameOnType Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [IExpressionEnumeratorExtensions](ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.cs.md) > **MembersWithNameOnType**

Helper method to extract members with a name.

## Overloads

| Overload | Description |
| :-- | :-- |
| [MembersWithNameOnType&lt;T>(IExpressionEnumerator expressionEnumerator, String name)](#memberswithnameontypetiexpressionenumerator-expressionenumerator-string-name) | Helper method to extract members with a name. |
## MembersWithNameOnType&lt;T>(IExpressionEnumerator expressionEnumerator, String name)

Helper method to extract members with a name.

```csharp
public static IEnumerable<MemberExpression> MembersWithNameOnType<T>(IExpressionEnumerator expressionEnumerator, String name)
```

### Return Type

 [IEnumerable&lt;MemberExpression>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1)  - The instances of [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) that refer to it.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `expressionEnumerator` | [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) | The [IExpressionEnumerator](ExpressionPowerTools.Core.Signatures.IExpressionEnumerator.i.md) . |
| `name` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The name of the member. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/20/2020 22:39:56 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

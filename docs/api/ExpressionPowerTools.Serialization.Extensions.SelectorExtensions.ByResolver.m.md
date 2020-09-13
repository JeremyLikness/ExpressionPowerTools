# SelectorExtensions.ByResolver Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [SelectorExtensions](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.cs.md) > **ByResolver**



## Overloads

| Overload | Description |
| :-- | :-- |
| [ByResolver&lt;T, TTarget>(MemberSelector&lt;T> memberSelector, Expression&lt;Action&lt;TTarget>> resolver)](#byresolvert-ttargetmemberselectort-memberselector-expressionactionttarget-resolver) |  |
| [ByResolver&lt;T, TTarget>(MemberSelector&lt;T> memberSelector, Expression&lt;Func&lt;TTarget, Object>> resolver)](#byresolvert-ttargetmemberselectort-memberselector-expressionfuncttarget-object-resolver) |  |
## ByResolver&lt;T, TTarget>(MemberSelector&lt;T> memberSelector, Expression&lt;Action&lt;TTarget>> resolver)



```csharp
public static Void ByResolver<T, TTarget>(MemberSelector<T> memberSelector, Expression<Action<TTarget>> resolver)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `memberSelector` | [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) |  |
| `resolver` | [Expression&lt;Action&lt;TTarget>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |


## ByResolver&lt;T, TTarget>(MemberSelector&lt;T> memberSelector, Expression&lt;Func&lt;TTarget, Object>> resolver)



```csharp
public static Void ByResolver<T, TTarget>(MemberSelector<T> memberSelector, Expression<Func<TTarget, Object>> resolver)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `memberSelector` | [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) |  |
| `resolver` | [Expression&lt;Func&lt;TTarget, Object>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) |  |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/13/2020 12:41:49 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.8-alpha |

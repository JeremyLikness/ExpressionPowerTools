# SelectorExtensions.ByResolver Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > [SelectorExtensions](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.cs.md) > **ByResolver**

Gets the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using a lambda expression
            as a template. The lambda is never invoked and is inspected
            to find the matching type.

## Overloads

| Overload | Description |
| :-- | :-- |
| [ByResolver&lt;T, TTarget>(MemberSelector&lt;T> memberSelector, Expression&lt;Action&lt;TTarget>> resolver)](#byresolvert-ttargetmemberselectort-memberselector-expressionactionttarget-resolver) | Gets the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using a lambda expression            as a template. The lambda is never invoked and is inspected            to find the matching type. |
| [ByResolver&lt;T, TTarget>(MemberSelector&lt;T> memberSelector, Expression&lt;Func&lt;TTarget, Object>> resolver)](#byresolvert-ttargetmemberselectort-memberselector-expressionfuncttarget-object-resolver) | Gets the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using a lambda expression            as a template. The lambda is never invoked and is inspected            to find the matching type. |
## ByResolver&lt;T, TTarget>(MemberSelector&lt;T> memberSelector, Expression&lt;Action&lt;TTarget>> resolver)

Gets the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using a lambda expression
            as a template. The lambda is never invoked and is inspected
            to find the matching type.

```csharp
public static Void ByResolver<T, TTarget>(MemberSelector<T> memberSelector, Expression<Action<TTarget>> resolver)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `memberSelector` | [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) | The [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) . |
| `resolver` | [Expression&lt;Action&lt;TTarget>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The  expression template. |


## ByResolver&lt;T, TTarget>(MemberSelector&lt;T> memberSelector, Expression&lt;Func&lt;TTarget, Object>> resolver)

Gets the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using a lambda expression
            as a template. The lambda is never invoked and is inspected
            to find the matching type.

```csharp
public static Void ByResolver<T, TTarget>(MemberSelector<T> memberSelector, Expression<Func<TTarget, Object>> resolver)
```

### Return Type

 [Void](https://docs.microsoft.com/dotnet/api/system.void) 

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `memberSelector` | [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) | The [MemberSelector&lt;T>](ExpressionPowerTools.Serialization.Rules.MemberSelector`1.cs.md) . |
| `resolver` | [Expression&lt;Func&lt;TTarget, Object>>](https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression-1) | The  expression template. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:50:49 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

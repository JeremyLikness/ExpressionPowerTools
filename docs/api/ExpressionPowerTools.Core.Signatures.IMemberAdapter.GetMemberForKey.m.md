# IMemberAdapter.GetMemberForKey Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > [IMemberAdapter](ExpressionPowerTools.Core.Signatures.IMemberAdapter.i.md) > **GetMemberForKey**

Uses the key to build the proper [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) reference.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetMemberForKey(String key)](#getmemberforkeystring-key) | Uses the key to build the proper [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) reference. |
| [GetMemberForKey&lt;TMemberInfo>(String key)](#getmemberforkeytmemberinfostring-key) | Translate key to specific type. |
## GetMemberForKey(String key)

Uses the key to build the proper [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) reference.

```csharp
public virtual MemberInfo GetMemberForKey(String key)
```

### Return Type

 [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo)  - The [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `key` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The key. |


## GetMemberForKey&lt;TMemberInfo>(String key)

Translate key to specific type.

```csharp
public virtual TMemberInfo GetMemberForKey<TMemberInfo>(String key)
```

### Return Type

 [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo)  - The [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `key` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The key to use. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:02:13 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

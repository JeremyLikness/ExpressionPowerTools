# IMemberAdapter.GetKeyForMember Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > [IMemberAdapter](ExpressionPowerTools.Core.Signatures.IMemberAdapter.i.md) > **GetKeyForMember**

Gets a unique string that identifies the member.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetKeyForMember(MemberInfo member)](#getkeyformembermemberinfo-member) | Gets a unique string that identifies the member. |
## GetKeyForMember(MemberInfo member)

Gets a unique string that identifies the member.

```csharp
public virtual String GetKeyForMember(MemberInfo member)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - the unique string.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) | The [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) to parse. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/25/2020 00:25:51 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

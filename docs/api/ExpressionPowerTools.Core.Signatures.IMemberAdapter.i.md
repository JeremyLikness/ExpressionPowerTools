# IMemberAdapter Interface

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Signatures](ExpressionPowerTools.Core.Signatures.n.md) > **IMemberAdapter**

Adapter to convert members to text and vice versa. Uses the XML comments algorithm.

```csharp
public interface IMemberAdapter
```

Derived  [MemberAdapter](ExpressionPowerTools.Core.Members.MemberAdapter.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [Int32 ClosedGenericsCount(String key)](ExpressionPowerTools.Core.Signatures.IMemberAdapter.ClosedGenericsCount.m.md) | Counts closed generics to provide a good type name. |
| [String GetKeyForMember(MemberInfo member)](ExpressionPowerTools.Core.Signatures.IMemberAdapter.GetKeyForMember.m.md) | Gets a unique string that identifies the member. |
| [MemberInfo GetMemberForKey(String key)](ExpressionPowerTools.Core.Signatures.IMemberAdapter.GetMemberForKey.m.md) | Uses the key to build the proper [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) reference. |
| [Type MakeAnonymousType(ValueTuple types)](ExpressionPowerTools.Core.Signatures.IMemberAdapter.MakeAnonymousType.m.md) |  |
| [Void Reset()](ExpressionPowerTools.Core.Signatures.IMemberAdapter.Reset.m.md) | Primarily for testing. Clears the cache. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 18:50:36 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

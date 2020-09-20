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

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/20/2020 6:32:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.9.0-alpha |

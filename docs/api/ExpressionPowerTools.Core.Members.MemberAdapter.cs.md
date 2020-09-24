# MemberAdapter Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Members](ExpressionPowerTools.Core.Members.n.md) > **MemberAdapter**

Handles translation and comparison of members.

```csharp
public class MemberAdapter : IMemberAdapter
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **MemberAdapter**

Implements  [IMemberAdapter](ExpressionPowerTools.Core.Signatures.IMemberAdapter.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [MemberAdapter()](ExpressionPowerTools.Core.Members.MemberAdapter.ctor.md#memberadapter) | Initializes a new instance of the [MemberAdapter](ExpressionPowerTools.Core.Members.MemberAdapter.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Int32 ClosedGenericsCount(String key)](ExpressionPowerTools.Core.Members.MemberAdapter.ClosedGenericsCount.m.md) | Counts closed generics to provide a good type name. |
| [String GetKeyForMember(MemberInfo member)](ExpressionPowerTools.Core.Members.MemberAdapter.GetKeyForMember.m.md) | Gets a unique string that identifies the member. |
| [MemberInfo GetMemberForKey(String key)](ExpressionPowerTools.Core.Members.MemberAdapter.GetMemberForKey.m.md) | Uses the key to build the proper [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) reference. |
| [Void Reset()](ExpressionPowerTools.Core.Members.MemberAdapter.Reset.m.md) | Clears all caches. Primary for testing. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 22:50:49 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

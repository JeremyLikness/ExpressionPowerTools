# ReflectionHelper.GetMemberFromCache Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) > **GetMemberFromCache**

Gets the specified member. Will add to cache if not found.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetMemberFromCache&lt;TMemberInfo, TMemberBase>(TMemberBase member)](#getmemberfromcachetmemberinfo-tmemberbasetmemberbase-member) | Gets the specified member. Will add to cache if not found. |
## GetMemberFromCache&lt;TMemberInfo, TMemberBase>(TMemberBase member)

Gets the specified member. Will add to cache if not found.

```csharp
public TMemberInfo GetMemberFromCache<TMemberInfo, TMemberBase>(TMemberBase member)
```

### Return Type

TMemberInfo - The cached item.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `member` | TMemberBase | The key for the item. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/27/2020 11:30:52 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

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
| 9/1/2020 9:40:36 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.3-alpha |

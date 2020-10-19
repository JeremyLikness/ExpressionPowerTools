# SerializationState.GetExpressionTree Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) > **GetExpressionTree**

Gets the expression tree that was deserialized.

## Overloads

| Overload | Description |
| :-- | :-- |
| [GetExpressionTree(Boolean preventReset)](#getexpressiontreeboolean-preventreset) | Gets the expression tree that was deserialized. |
## GetExpressionTree(Boolean preventReset)

Gets the expression tree that was deserialized.

```csharp
public String GetExpressionTree(Boolean preventReset)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The expression tree.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `preventReset` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | A value indicating whether the expression should be reset or ont. |


## Remarks

Used mainly for troubleshooting.


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |

# IConfigurationBuilder.CompressExpressionTree Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Signatures](ExpressionPowerTools.Serialization.Signatures.n.md) > [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md) > **CompressExpressionTree**

Sets the flag to indicate whether expression trees should be partially
            evaluated so that local variable references aren't serialized.

## Overloads

| Overload | Description |
| :-- | :-- |
| [CompressExpressionTree(Boolean compressExpressionTree)](#compressexpressiontreeboolean-compressexpressiontree) | Sets the flag to indicate whether expression trees should be partially            evaluated so that local variable references aren't serialized. |
## CompressExpressionTree(Boolean compressExpressionTree)

Sets the flag to indicate whether expression trees should be partially
            evaluated so that local variable references aren't serialized.

```csharp
public virtual IConfigurationBuilder CompressExpressionTree(Boolean compressExpressionTree)
```

### Return Type

 [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md)  - The chainable [IConfigurationBuilder](ExpressionPowerTools.Serialization.Signatures.IConfigurationBuilder.i.md) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `compressExpressionTree` | [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) | The flag indicating whether the tree            should be compressed. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 16:18:15 | (c) Copyright 2020 Jeremy Likness. | 0.9.6-beta |

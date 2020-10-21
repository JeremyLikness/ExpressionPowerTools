# ConfigurationBuilder.CompressExpressionTree Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Configuration](ExpressionPowerTools.Serialization.Configuration.n.md) > [ConfigurationBuilder](ExpressionPowerTools.Serialization.Configuration.ConfigurationBuilder.cs.md) > **CompressExpressionTree**

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
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

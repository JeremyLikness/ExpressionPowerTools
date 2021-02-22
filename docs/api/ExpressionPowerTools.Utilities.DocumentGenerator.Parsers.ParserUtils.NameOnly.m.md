# ParserUtils.NameOnly Method

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Parsers](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.n.md) > [ParserUtils](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.ParserUtils.cs.md) > **NameOnly**

Strips the namespace qualification and normalizes the name.

## Overloads

| Overload | Description |
| :-- | :-- |
| [NameOnly(String fullName)](#nameonlystring-fullname) | Strips the namespace qualification and normalizes the name. |
## NameOnly(String fullName)

Strips the namespace qualification and normalizes the name.

```csharp
public static String NameOnly(String fullName)
```

### Return Type

 [String](https://docs.microsoft.com/dotnet/api/system.string)  - The name by itself.

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `fullName` | [String](https://docs.microsoft.com/dotnet/api/system.string) | The source name. |


## Examples

For example, the name `Sytem.Foo.IBar`2` would get transformed to:

```csharp
IBar<>
            
```


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 02/22/2021 21:59:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

# MemberUtils Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Parsers](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.n.md) > **MemberUtils**

Utilities for [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) .

```csharp
public static class MemberUtils
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **MemberUtils**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [static MemberUtils()](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.MemberUtils.ctor.md#static-memberutils) | Initializes a new instance of the [MemberUtils](ExpressionPowerTools.Utilities.DocumentGenerator.Parsers.MemberUtils.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [String GenerateCodeFor(MemberInfo memberInfo)](MemberUtils-GenerateCodeFor.m.md) | Generates the code declaration for documentation. |
| [String GetSelector(MemberInfo member)](MemberUtils-GetSelector.m.md) | Gets the selector in XML docs for the provided member. |
| [Void ParseGenericTypeConstraints(Type type, DocTypeParameter docType)](MemberUtils-ParseGenericTypeConstraints.m.md) | Returns a list of generic type constraints. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 8:28:46 PM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

# ExceptionHelper Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Resources](ExpressionPowerTools.Core.Resources.n.md) > **ExceptionHelper**

Helper for localized exceptions.

```csharp
public static class ExceptionHelper
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **ExceptionHelper**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [static ExceptionHelper()](ExpressionPowerTools.Core.Resources.ExceptionHelper.ctor.md#static-exceptionhelper) | Initializes a new instance of the [ExceptionHelper](ExpressionPowerTools.Core.Resources.ExceptionHelper.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [InvalidOperationException AsInvalidOperationException(String message, String[] parameters)](ExceptionHelper-AsInvalidOperationException.m.md) | Invalid operation messages. |
| [ArgumentException MethodCallOnTypeRequiredException(String parameterName)](ExceptionHelper-MethodCallOnTypeRequiredException.m.md) | Generates a [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) for invalid expression. |
| [NullReferenceException NullReferenceNotAllowedException(String memberName)](ExceptionHelper-NullReferenceNotAllowedException.m.md) | Null reference exception. |
| [ArgumentException WhitespaceNotAllowedException(String parameterName)](ExceptionHelper-WhitespaceNotAllowedException.m.md) | Generates a [ArgumentException](https://docs.microsoft.com/dotnet/api/system.argumentexception) for empty string. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:53:14 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

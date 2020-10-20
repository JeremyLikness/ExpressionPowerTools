# ExpressionTransformer Class

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.n.md) > **ExpressionTransformer**

Transform one expression to another.

```csharp
public class ExpressionTransformer : MulticastDelegate, ICloneable, ISerializable
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [Delegate](https://docs.microsoft.com/dotnet/api/system.delegate) → [MulticastDelegate](https://docs.microsoft.com/dotnet/api/system.multicastdelegate) → **ExpressionTransformer**

Implements  [ICloneable](https://docs.microsoft.com/dotnet/api/system.icloneable) ,  [ISerializable](https://docs.microsoft.com/dotnet/api/system.runtime.serialization.iserializable) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [ExpressionTransformer(Object object, IntPtr method)](ExpressionPowerTools.Core.ExpressionTransformer.ctor.md#expressiontransformerobject-object-intptr-method) | Initializes a new instance of the [ExpressionTransformer](ExpressionPowerTools.Core.ExpressionTransformer.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [IAsyncResult BeginInvoke(Expression source, AsyncCallback callback, Object object)](ExpressionPowerTools.Core.ExpressionTransformer.BeginInvoke.m.md) |  |
| [Expression EndInvoke(IAsyncResult result)](ExpressionPowerTools.Core.ExpressionTransformer.EndInvoke.m.md) |  |
| [Expression Invoke(Expression source)](ExpressionPowerTools.Core.ExpressionTransformer.Invoke.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/19/2020 18:50:36 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

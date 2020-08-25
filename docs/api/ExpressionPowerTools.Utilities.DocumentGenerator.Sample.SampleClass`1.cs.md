# SampleClass&lt;T> Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Sample](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.n.md) > **SampleClass<T>**

An implementation of the [SampleBaseClass&lt;T1, T2>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.cs.md) .

```csharp
public class SampleClass<T> : SampleBaseClass<TypeRef, T>, ISampleInterface<TypeRef, IEnumerator<TypeRef>, T>, IComparable<SampleClass<T>>
   where T : IComparable<IEnumerator<TypeRef>>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | [IComparable&lt;IEnumerator&lt;TypeRef>>](https://docs.microsoft.com/dotnet/api/system.icomparable-1) | The type to implement. |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [SampleBaseClass&lt;T1, T2>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.cs.md) → **SampleClass&lt;T>**

Implements  [IComparable&lt;in T>](https://docs.microsoft.com/dotnet/api/system.icomparable-1) ,  [ISampleInterface&lt;in T1, out T2, T3>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.ISampleInterface`3.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [SampleClass()](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.ctor.md#sampleclass) | Initializes a new instance of the [SampleClass&lt;T>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.cs.md) class. |
| [static SampleClass()](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.ctor.md#static-sampleclass) | Initializes static members of the [SampleClass&lt;T>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.cs.md) class. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`CrossAssemblyReference`](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.CrossAssemblyReference.prop.md) | [ExpressionEnumerator](ExpressionPowerTools.Core.ExpressionEnumerator.cs.md) | Gets a cross-assembly reference. |
| [`TypedInstance`](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.TypedInstance.prop.md) | [SampleBaseClass&lt;TypeRef, IComparable&lt;IEnumerator&lt;TypeRef>>>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.cs.md) | Gets the typed instance. |

## Methods

| Method | Description |
| :-- | :-- |
| [Int32 CompareTo(SampleClass&lt;T> other)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.CompareTo.m.md) | Compare to. |
| [IEnumerator&lt;TypeRef> GetEnumerableFor(TypeRef entity)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.GetEnumerableFor.m.md) | Get the enumerator. |
| [Boolean IsReady&lt;T5>(T5 test)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.IsReady.m.md) | Is it ready test. |
| [T ProcessComparable&lt;T4>(T4 parameter)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.ProcessComparable.m.md) | Processes a comparable. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/25/2020 6:00:34 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.2-alpha |

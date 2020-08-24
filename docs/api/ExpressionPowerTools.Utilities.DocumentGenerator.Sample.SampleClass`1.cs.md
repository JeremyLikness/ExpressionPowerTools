# SampleClass&lt;T> Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Sample](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.n.md) > **SampleClass<T>**



```csharp
public class SampleClass<T> : SampleBaseClass<TypeRef, T>, ISampleInterface<TypeRef, IEnumerator<TypeRef>, T>, IComparable<SampleClass<T>>
   where T : IComparable<IEnumerator<TypeRef>>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T` | [IComparable&lt;IEnumerator&lt;TypeRef>>](https://docs.microsoft.com/dotnet/api/system.icomparable-1) |  |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → [SampleBaseClass&lt;T1, T2>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.cs.md) → **SampleClass&lt;T>**

Implements  [IComparable&lt;in T>](https://docs.microsoft.com/dotnet/api/system.icomparable-1) ,  [ISampleInterface&lt;in T1, out T2, T3>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.ISampleInterface`3.i.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [SampleClass()](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.ctor.md#sampleclass) |  |
| [static SampleClass()](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.ctor.md#static-sampleclass) |  |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`CrossAssemblyReference`](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.CrossAssemblyReference.prop.md) | [ExpressionEnumerator](ExpressionPowerTools.Core.ExpressionEnumerator.cs.md) |  |
| [`TypedInstance`](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.TypedInstance.prop.md) | [SampleBaseClass&lt;TypeRef, IComparable&lt;IEnumerator&lt;TypeRef>>>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.cs.md) |  |

## Methods

| Method | Description |
| :-- | :-- |
| [Int32 CompareTo(SampleClass&lt;T> other)](SampleClass`1-CompareTo.m.md) |  |
| [IEnumerator&lt;TypeRef> GetEnumerableFor(TypeRef entity)](SampleClass`1-GetEnumerableFor.m.md) |  |
| [Boolean IsReady&lt;T5>(T5 test)](SampleClass`1-IsReady.m.md) |  |
| [T ProcessComparable&lt;T4>(T4 parameter)](SampleClass`1-ProcessComparable.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

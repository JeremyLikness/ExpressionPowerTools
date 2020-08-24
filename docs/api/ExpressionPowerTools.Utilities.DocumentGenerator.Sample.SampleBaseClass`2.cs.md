# SampleBaseClass&lt;T1, T2> Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Sample](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.n.md) > **SampleBaseClass<T1, T2>**



```csharp
public abstract class SampleBaseClass<T1, T2> : ISampleInterface<T1, IEnumerator<T1>, T2>
   where T2 : IComparable<IEnumerator<T1>>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T1` | The parameter must have a default parameterless constructor. The parameter must be a reference type. |  |
| `T2` | [IComparable&lt;IEnumerator&lt;T1>>](https://docs.microsoft.com/dotnet/api/system.icomparable-1) |  |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **SampleBaseClass&lt;T1, T2>**

Implements  [ISampleInterface&lt;in T1, out T2, T3>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.ISampleInterface`3.i.md) 

Derived  [SampleClass&lt;T>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.cs.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [SampleBaseClass()](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.ctor.md#samplebaseclass) |  |
| [SampleBaseClass(T1 entity, String id)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.ctor.md#samplebaseclasst1-entity-string-id) |  |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Entity`](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.Entity.prop.md) | T1 |  |
| [`Id`](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.Id.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) |  |
| [`Instance`](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.Instance.prop.md) | [SampleBaseClass&lt;T1, T2>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.cs.md) |  |

## Methods

| Method | Description |
| :-- | :-- |
| [Int32 ConvertLongToInt(Int64 x)](SampleBaseClass`2-ConvertLongToInt.m.md) |  |
| [Void DoStuff()](SampleBaseClass`2-DoStuff.m.md) |  |
| [IEnumerator&lt;T1> GetEnumerableFor(T1 entity)](SampleBaseClass`2-GetEnumerableFor.m.md) |  |
| [Boolean IsReady&lt;T5>(T5 test)](SampleBaseClass`2-IsReady.m.md) |  |
| [T2 ProcessComparable&lt;T4>(T4 parameter)](SampleBaseClass`2-ProcessComparable.m.md) |  |
| [Void SetInstance(SampleBaseClass&lt;T1, T2> instance)](SampleBaseClass`2-SetInstance.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 8/24/2020 5:39:06 AM | (c) Copyright 2020 Jeremy Likness. | **v0.8.0.0** |

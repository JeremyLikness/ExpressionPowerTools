# SampleBaseClass&lt;T1, T2> Class

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Sample](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.n.md) > **SampleBaseClass<T1, T2>**

A sample base class.

```csharp
public abstract class SampleBaseClass<T1, T2> : ISampleInterface<T1, IEnumerator<T1>, T2>
   where T2 : IComparable<IEnumerator<T1>>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `T1` | The parameter must have a default parameterless constructor. The parameter must be a reference type. | The first type. |
| `T2` | [IComparable&lt;IEnumerator&lt;T1>>](https://docs.microsoft.com/dotnet/api/system.icomparable-1) | The second type. |

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **SampleBaseClass&lt;T1, T2>**

Implements  [ISampleInterface&lt;in T1, out T2, T3>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.ISampleInterface`3.i.md) 

Derived  [SampleClass&lt;T>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.cs.md) 

## Constructors

| Ctor | Description |
| :-- | :-- |
| [SampleBaseClass()](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.ctor.md#samplebaseclass) | Initializes a new instance of the [SampleBaseClass&lt;T1, T2>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.cs.md) class. |
| [SampleBaseClass(T1 entity, String id)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.ctor.md#samplebaseclasst1-entity-string-id) | Initializes a new instance of the [SampleBaseClass&lt;T1, T2>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.cs.md) class.            Saves an entity and identifier. |
## Properties

| Property | Type | Description |
| :-- | :-- | :-- |
| [`Entity`](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.Entity.prop.md) | T1 | Gets the entity. |
| [`Id`](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.Id.prop.md) | [String](https://docs.microsoft.com/dotnet/api/system.string) | Gets the identity. |
| [`Instance`](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.Instance.prop.md) | [SampleBaseClass&lt;T1, T2>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.cs.md) | Gets a static instance. |

## Methods

| Method | Description |
| :-- | :-- |
| [Int32 ConvertLongToInt(Int64 x)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.ConvertLongToInt.m.md) | Just another method. |
| [Void DoStuff()](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.DoStuff.m.md) | Does stuff. |
| [IEnumerator&lt;T1> GetEnumerableFor(T1 entity)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.GetEnumerableFor.m.md) | The abstract enumerator. |
| [Boolean IsReady&lt;T5>(T5 test)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.IsReady.m.md) | Test for readiness. |
| [T2 ProcessComparable&lt;T4>(T4 parameter)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.ProcessComparable.m.md) | Test for comparability. |
| [Void SetInstance(SampleBaseClass&lt;T1, T2> instance)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.SetInstance.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/24/2020 23:59:31 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

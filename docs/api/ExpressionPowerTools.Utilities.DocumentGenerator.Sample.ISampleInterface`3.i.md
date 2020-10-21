# ISampleInterface&lt;in T1, out T2, T3> Interface

[Index](../index.md) > [ExpressionPowerTools.Utilities.DocumentGenerator](ExpressionPowerTools.Utilities.DocumentGenerator.a.md) > [ExpressionPowerTools.Utilities.DocumentGenerator.Sample](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.n.md) > **ISampleInterface<in T1, out T2, T3>**

Sample interface for testing.

```csharp
public interface ISampleInterface<in T1, out T2, T3>
   where T2 : IEnumerator<in T1>
   where T3 : IComparable<out T2>
```

### Type Parameters

| Parameter Name | Constraints | Description |
| :-- | :-- | :-- |
| `out T1` | The parameter must have a default parameterless constructor. The parameter must be a reference type. The parameter is contravariant. You may use a type that `T1` derives from. | The main type. |
| `T2` | The parameter is covariant. You may use a type that derives from `T2`.  [IEnumerator&lt;in T1>](https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerator-1) | The enumerator. |
| `T3` | [IComparable&lt;out T2>](https://docs.microsoft.com/dotnet/api/system.icomparable-1) | The comparable. |

Derived  [SampleBaseClass&lt;T1, T2>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleBaseClass`2.cs.md) ,  [SampleClass&lt;T>](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.SampleClass`1.cs.md) 

## Methods

| Method | Description |
| :-- | :-- |
| [Void DoStuff()](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.ISampleInterface`3.DoStuff.m.md) | Do stuff. |
| [T2 GetEnumerableFor(T1 entity)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.ISampleInterface`3.GetEnumerableFor.m.md) | Gets an enumerable for the entity. |
| [Boolean IsReady&lt;T5>(T5 test)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.ISampleInterface`3.IsReady.m.md) | Is it ready test. |
| [T3 ProcessComparable&lt;T4>(T4 parameter)](ExpressionPowerTools.Utilities.DocumentGenerator.Sample.ISampleInterface`3.ProcessComparable.m.md) | Process a comparable item. |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/21/2020 18:58:20 | (c) Copyright 2020 Jeremy Likness. | 0.9.7-beta |

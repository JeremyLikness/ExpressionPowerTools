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


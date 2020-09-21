# SerializationState.TypeIndex Property

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) > **TypeIndex**

Gets or sets the index of types.

```csharp
public List<String> TypeIndex { get; set; }
```

## Remarks

This table is used to build a master index of types. For example, if [String](https://docs.microsoft.com/dotnet/api/system.string) is
            referenced multiple times, the intial entry may be `System.String` and subsequent entries
            will reference `^0` .

### Property Value

 [List&lt;String>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 09/21/2020 19:07:57 | (c) Copyright 2020 Jeremy Likness. | 0.9.2-alpha |

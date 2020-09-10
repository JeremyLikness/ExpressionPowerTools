# SerializationState.TypeIndex Property

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) > **TypeIndex**

Gets or sets the index of types.

```csharp
public List<SerializableType> TypeIndex { get; set; }
```

## Remarks

This table is used to build a master index of types. For example, if [String](https://docs.microsoft.com/dotnet/api/system.string) is
            referenced multiple times, the intial entry may be `System.String` and subsequent entries
            will reference `^0` .

### Property Value

 [List&lt;SerializableType>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/10/2020 10:31:18 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.7-alpha |

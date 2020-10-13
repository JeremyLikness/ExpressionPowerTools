# SerializationState.CompressTypes Property

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) > **CompressTypes**

Gets or sets a value indicating whether or not types are compressed. Default is `true` .

```csharp
public Boolean CompressTypes { get; set; }
```

## Remarks

When this flag is set, instead of serializing long types, each type is indexed in a master
            "type index" the first time it is encountered. Subsequent references will use `^x` where `x` is the index of the type. Set this to `false` if you need to debug the
            serialization payload. This flag is ignored during deserialization as compressed types are
            automatically detected and decompressed when present.

### Property Value

 [Boolean](https://docs.microsoft.com/dotnet/api/system.boolean) 


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/13/2020 17:10:06 | (c) Copyright 2020 Jeremy Likness. | 0.9.5-beta |

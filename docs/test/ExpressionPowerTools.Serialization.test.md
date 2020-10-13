# Summary of Test Runs for ExpressionPowerTools.Serialization

Jump to group:

- [BinarySerializerTest](#binaryserializertest-495-ms)
- [CompressionTest](#compressiontest-20-ms)
- [ConfigurationBuilderTest](#configurationbuildertest-2-ms)
- [ConstantSerializerTest](#constantserializertest-38-ms)
- [CtorSerializerTest](#ctorserializertest-41-ms)
- [DefaultConfigurationTest](#defaultconfigurationtest-13-ms)
- [ExpressionSerializerTest](#expressionserializertest-14-ms)
- [InvocationSerializerTest](#invocationserializertest-21-ms)
- [JsonWrapperTest](#jsonwrappertest-565-ms)
- [LambdaSerializerTest](#lambdaserializertest-40-ms)
- [MemberInitSerializerTest](#memberinitserializertest-62-ms)
- [MemberSerializerTest](#memberserializertest-28-ms)
- [MethodSerializerTest](#methodserializertest-23-ms)
- [NewArraySerializerTest](#newarrayserializertest-10-ms)
- [ParameterSerializerTest](#parameterserializertest-4-ms)
- [QueryExprSerializerTest](#queryexprserializertest-45-s)
- [ReflectionHelperTest](#reflectionhelpertest-35-ms)
- [RulesEngineTest](#rulesenginetest-31-ms)
- [SelectorTest](#selectortest-4-ms)
- [SerializableExpressionTest](#serializableexpressiontest-14-ms)
- [SerializationPayloadTest](#serializationpayloadtest-1-ms)
- [SerializationRuleTest](#serializationruletest-2-ms)
- [SerializationStateTest](#serializationstatetest-8-ms)
- [TypesCompressorTest](#typescompressortest-177-ms)
- [UnarySerializerTest](#unaryserializertest-84-ms)

The slowest test was 'Given Query When Serialize Called Then Should Deserialize For Type (query: {}, type: IdOnly)' at 316 ms.

## QueryExprSerializerTest (4.5 s)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Query When Serialize Called Then Should Deserialize For Type**| |**2.6 s**|
| |(query: {}, type: IdOnly)|316 ms|
| |(query: {}, type: MemberInit)|297 ms|
| |(query: {}, type: WhereIdContainsAA)|295 ms|
| |(query: {}, type: MemberInit)|287 ms|
| |(query: {}, type: Skip1Take1)|279 ms|
| |(query: {}, type: OrderByCreatedThenByDescendingId)|242 ms|
| |(query: {}, type: MemberInit)|232 ms|
| |(query: {}, type: SelectMany)|227 ms|
| |(query: {}, type: Filtered)|222 ms|
| |(query: {}, type: CustomGenericProperty)|219 ms|
|Multiple Select Many Projection Works| |143 ms|
|Group By Works| |87 ms|
|**Given Query When Serialize Called Then Should Deserialize**| |**566 ms**|
| |(query: {}, type: MemberInit)|75 ms|
| |(query: {}, type: IdAnonymousType)|59 ms|
| |(query: {}, type: MemberInit)|54 ms|
| |(query: {}, type: IdOnly)|53 ms|
| |(query: {}, type: OrderByCreatedThenByDescendingId)|53 ms|
| |(query: {}, type: MemberInit)|53 ms|
| |(query: {}, type: Filtered)|40 ms|
| |(query: {}, type: SelectMany)|39 ms|
| |(query: {}, type: CustomGenericProperty)|39 ms|
| |(query: {}, type: IdProjection)|37 ms|
| |(query: {}, type: WhereIdContainsAA)|29 ms|
| |(query: {}, type: Skip1Take1)|29 ms|
|State Captures Expression Tree| |35 ms|
|**Given New Expression When Serialized Then Should Deserialize**| |**126 ms**|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: null)|21 ms|
| |(info: Void .ctor(), args: null, members: null)|17 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: null)|17 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: {Int32 Prop, System.String field})|17 ms|
| |(info: Void .ctor(Int32), args: {1}, members: null)|14 ms|
| |(info: Void .ctor(Int32), args: {1}, members: {Int32 Prop})|11 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: {ExpressionPowerTools.Serialization.Tests.CtorSerializerTests Thing})|11 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests, System.String), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), "CtorSerializerTests"}, members: null)|10 ms|
| |(info: Void .ctor(Int32), args: {2}, members: null)|5 ms|
|**Given Method Call Expression When Serialized Then Should Deserialize**| |**60 ms**|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnIntDoubled(2))|19 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).DoNothing())|16 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnInt())|6 ms|
| |(method: StaticReturnIntDoubled(2))|6 ms|
| |(method: StaticDoNothing())|5 ms|
| |(method: StaticReturnInt())|5 ms|
|**Given Expression When Serialized Then Should Deserialize**| |**62 ms**|
| |(constant: 5)|18 ms|
| |(constant: { foo = bar, bar = { bar = foo } })|17 ms|
| |(constant: { foo = bar, id = 42 })|5 ms|
| |(constant: { foo = bar, bar =  })|5 ms|
| |(constant: System.IComparable^1{T})|2 ms|
| |(constant: 5)|2 ms|
| |(constant: value(System.Int32{}))|2 ms|
| |(constant: 5)|2 ms|
| |(constant: value(System.Int32{}))|2 ms|
| |(constant: null)|2 ms|
|**Given Unary Expression When Serialized Then Should Deserialize**| |**212 ms**|
| |(unary: Convert(5, String))|16 ms|
| |(unary: ++value)|16 ms|
| |(unary: Decrement(5))|15 ms|
| |(unary: +5)|15 ms|
| |(unary: Not(True))|15 ms|
| |(unary: () =} Invoke(() =} True))|11 ms|
| |(unary: ConvertChecked(5, String))|6 ms|
| |(unary: -5)|6 ms|
| |(unary: Increment(5))|6 ms|
| |(unary: value--)|6 ms|
| |(unary: -5)|6 ms|
| |(unary: --value)|6 ms|
| |(unary: value++)|6 ms|
| |(unary: Decrement(5))|5 ms|
| |(unary: ++value)|5 ms|
| |(unary: Not(True))|4 ms|
| |(unary: throw())|4 ms|
| |(unary: Unbox(5))|4 ms|
| |(unary: throw(System.ArgumentNullException: Value cannot be null.))|4 ms|
| |(unary: ArrayLength(value(System.Int32{})))|4 ms|
| |(unary: ConvertChecked(5, Int64))|4 ms|
| |(unary: Convert(5, Int64))|3 ms|
| |(unary: (5 As Object))|3 ms|
| |(unary: -5)|3 ms|
| |(unary: --value)|3 ms|
| |(unary: -5)|3 ms|
| |(unary: throw(System.InvalidCastException: Specified cast is not valid.))|3 ms|
| |(unary: Increment(5))|3 ms|
| |(unary: +5)|3 ms|
| |(unary: value++)|3 ms|
| |(unary: value--)|3 ms|
| |(unary: throw())|2 ms|
|**Given Member Expression When Serialized Then Should Deserialize**| |**40 ms**|
| |(member: MemberSerializerTests.staticField)|12 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).instanceField)|9 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).InstanceProperty)|6 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).ReadOnlyProperty)|6 ms|
| |(member: MemberSerializerTests.StaticProperty)|5 ms|
|Given Configure Rules No Defaults Then Should Configure No Default Rule| |10 ms|
|**Given Binary Expression When Serialized Then Should Deserialize**| |**469 ms**|
| |(binary: (Param_0 $= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|9 ms|
| |(binary: (Param_0 ^= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|9 ms|
| |(binary: (Param_0 }}= 2))|9 ms|
| |(binary: (Param_0 %= 1))|9 ms|
| |(binary: (Param_0 &= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|9 ms|
| |(binary: (Param_0 **= 1))|8 ms|
| |(binary: (Param_0 /= 1))|8 ms|
| |(binary: (Param_0 {{= 2))|8 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|8 ms|
| |(binary: (Param_0 }}= 2))|7 ms|
| |(binary: (True ^ True))|7 ms|
| |(binary: (Param_0 %= 1))|6 ms|
| |(binary: (1 + 2))|6 ms|
| |(binary: (1 * 2))|6 ms|
| |(binary: (Param_0 }}= 2))|6 ms|
| |(binary: (1 {= 2))|5 ms|
| |(binary: (1 * 2))|5 ms|
| |(binary: (1 ** 2))|5 ms|
| |(binary: (1 - 2))|5 ms|
| |(binary: (Param_0 -= 2))|5 ms|
| |(binary: (1 - 2))|5 ms|
| |(binary: (1 % 2))|5 ms|
| |(binary: (True And True))|5 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) ^ value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|5 ms|
| |(binary: (Param_0 /= 1))|5 ms|
| |(binary: (Param_0 **= 1))|5 ms|
| |(binary: (1 }} 2))|5 ms|
| |(binary: (Param_0 **= 1))|5 ms|
| |(binary: (Param_0 -= 2))|5 ms|
| |(binary: (1 {{ 2))|5 ms|
| |(binary: (True Or True))|5 ms|
| |(binary: (True == True))|5 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) OrElse value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|5 ms|
| |(binary: (True != True))|5 ms|
| |(binary: (1 ** 2))|5 ms|
| |(binary: (1 * 2))|5 ms|
| |(binary: (1 { 2))|5 ms|
| |(binary: (Param_0 += 2))|5 ms|
| |(binary: (Param_0 $$= True))|5 ms|
| |(binary: (Param_0 *= 2))|5 ms|
| |(binary: (Param_0 {{= 2))|5 ms|
| |(binary: (1 / 2))|5 ms|
| |(binary: (1 } 2))|5 ms|
| |(binary: (Param_0 ^= True))|5 ms|
| |(binary: (Param_0 &&= True))|5 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) AndAlso value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|5 ms|
| |(binary: (Param_0 *= 2))|5 ms|
| |(binary: (Param_0 %= 1))|5 ms|
| |(binary: (1 }= 2))|5 ms|
| |(binary: (1 + 2))|5 ms|
| |(binary: (Param_0 += 2))|4 ms|
| |(binary: (True != True))|4 ms|
| |(binary: (1 { 2))|4 ms|
| |(binary: (Param_0 += 2))|4 ms|
| |(binary: (1 - 2))|4 ms|
| |(binary: (1 - 2))|4 ms|
| |(binary: (1 }} 2))|4 ms|
| |(binary: (1 / 2))|4 ms|
| |(binary: (True Or True))|4 ms|
| |(binary: (1 } 2))|4 ms|
| |(binary: (1 {= 2))|4 ms|
| |(binary: (Param_0 $$= True))|4 ms|
| |(binary: (Param_0 &&= True))|4 ms|
| |(binary: (1 % 2))|4 ms|
| |(binary: (Param_0 *= 2))|4 ms|
| |(binary: (1 }= 2))|4 ms|
| |(binary: (Param_0 ^= True))|4 ms|
| |(binary: (True OrElse True))|4 ms|
| |(binary: (Param_0 = value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|4 ms|
| |(binary: (1 * 2))|4 ms|
| |(binary: (True AndAlso True))|4 ms|
| |(binary: (1 {{ 2))|4 ms|
| |(binary: (True == True))|4 ms|
| |(binary: (Param_0 /= 1))|4 ms|
| |(binary: (Param_0 -= 2))|4 ms|
| |(binary: (Param_0 {{= 2))|4 ms|
| |(binary: (Param_0 -= 2))|4 ms|
| |(binary: (Param_0 *= 2))|4 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|4 ms|
| |(binary: (Param_0 += 2))|4 ms|
| |(binary: (1 + 2))|4 ms|
| |(binary: (1 + 2))|4 ms|
| |(binary: (True And True))|4 ms|
|**Given Lambda Expression When Serialized Then Should Deserialize**| |**16 ms**|
| |(lambda: (target, pattern) =} target.Contains(pattern))|9 ms|
| |(lambda: () =} 1)|6 ms|
|**Given Invocation Expression When Serialized Then Should Deserialize**| |**18 ms**|
| |(invocation: Invoke(i =} True, i))|7 ms|
| |(invocation: Invoke(() =} True))|5 ms|
| |(invocation: Invoke(() =} "FuncString"))|4 ms|
|Given Configure Rules Then Should Configure Defaults| |7 ms|
|Given Rules Config Then Replaces Existing Rules| |6 ms|
|Given An Array With Expressions When Serialized Then Should Deserialize| |6 ms|
|**Given Parameter Expression When Serialized Then Should Deserialize**| |**4 ms**|
| |(parameter: Param_0)|2 ms|
| |(parameter: GetParameterExpressions)|2 ms|
|Deserialize With Configuration Uses Configuration| |2 ms|
|**Parameter Expression Should Serialize**| |**1 ms**|
| |(parameter: Param_0)|759 ns|
| |(parameter: GetParameterExpressions)|637 ns|
|Given Serialize When Called With Null Expression Then Should Throw Argument Null| |485 ns|
|Given Serialize When Called With Null Query Then Should Throw Argument Null| |447 ns|
|**Given Serializer When Serialize Called With Null Then Should Return Null**| |**104 ns**|
| |(serializer: BinarySerializer { })|68 ns|
| |(serializer: ConstantSerializer { })|5 ns|
| |(serializer: MemberInitSerializer { })|4 ns|
| |(serializer: MemberSerializer { })|4 ns|
| |(serializer: UnarySerializer { })|4 ns|
| |(serializer: CtorSerializer { })|3 ns|
| |(serializer: MethodSerializer { })|2 ns|
| |(serializer: InvocationSerializer { })|2 ns|
| |(serializer: NewArraySerializer { })|2 ns|
| |(serializer: ParameterSerializer { })|2 ns|
| |(serializer: LambdaSerializer { })|2 ns|
## JsonWrapperTest (565 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Multiple Select Many Projection Works| |110 ms|
|**Given Query Can Serialize And Deserialize**| |**418 ms**|
| |(query: {}, queryType: MemberInit)|79 ms|
| |(query: {}, queryType: Filtered)|43 ms|
| |(query: {}, queryType: IdAnonymousType)|42 ms|
| |(query: {}, queryType: MemberInit)|40 ms|
| |(query: {}, queryType: OrderByCreatedThenByDescendingId)|37 ms|
| |(query: {}, queryType: MemberInit)|36 ms|
| |(query: {}, queryType: IdOnly)|33 ms|
| |(query: {}, queryType: CustomGenericProperty)|25 ms|
| |(query: {}, queryType: WhereIdContainsAA)|24 ms|
| |(query: {}, queryType: SelectMany)|21 ms|
| |(query: {}, queryType: IdProjection)|20 ms|
| |(query: {}, queryType: Skip1Take1)|12 ms|
|Handles Element Inits| |17 ms|
|Handles Interfaces| |6 ms|
|Handles Null Anonymous Types| |4 ms|
|**Invocation Expression Should Serialize**| |**7 ms**|
| |(invocation: Invoke(() =} True))|2 ms|
| |(invocation: Invoke(i =} True, i))|2 ms|
| |(invocation: Invoke(() =} "FuncString"))|1 ms|
## BinarySerializerTest (495 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Binary Expression Should Serialize**| |**214 ms**|
| |(binary: (1 + 2))|26 ms|
| |(binary: (Param_0 &= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|10 ms|
| |(binary: (True == True))|9 ms|
| |(binary: (1 + 2))|5 ms|
| |(binary: (Param_0 ^= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|4 ms|
| |(binary: (Param_0 {{= 2))|4 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|3 ms|
| |(binary: (Param_0 $= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|3 ms|
| |(binary: (Param_0 **= 1))|3 ms|
| |(binary: (Param_0 /= 1))|3 ms|
| |(binary: (Param_0 %= 1))|3 ms|
| |(binary: (Param_0 }}= 2))|3 ms|
| |(binary: (1 } 2))|2 ms|
| |(binary: (Param_0 += 2))|2 ms|
| |(binary: (True == True))|2 ms|
| |(binary: (True And True))|2 ms|
| |(binary: (Param_0 {{= 2))|2 ms|
| |(binary: (1 }= 2))|2 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) AndAlso value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (1 {{ 2))|2 ms|
| |(binary: (1 ** 2))|2 ms|
| |(binary: (1 }= 2))|1 ms|
| |(binary: (1 ** 2))|1 ms|
| |(binary: (1 { 2))|1 ms|
| |(binary: (1 {{ 2))|1 ms|
| |(binary: (1 / 2))|1 ms|
| |(binary: (1 } 2))|1 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) ^ value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (1 }} 2))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) OrElse value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (1 % 2))|1 ms|
| |(binary: (True AndAlso True))|1 ms|
| |(binary: (1 {= 2))|1 ms|
| |(binary: (True != True))|1 ms|
| |(binary: (Param_0 /= 1))|1 ms|
| |(binary: (True Or True))|1 ms|
| |(binary: (1 + 2))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (True ^ True))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (Param_0 ^= True))|1 ms|
| |(binary: (Param_0 &&= True))|1 ms|
| |(binary: (Param_0 += 2))|1 ms|
| |(binary: (1 { 2))|1 ms|
| |(binary: (1 }} 2))|1 ms|
| |(binary: (Param_0 **= 1))|1 ms|
| |(binary: (Param_0 %= 1))|1 ms|
| |(binary: (Param_0 {{= 2))|1 ms|
| |(binary: (True OrElse True))|1 ms|
| |(binary: (1 / 2))|1 ms|
| |(binary: (Param_0 = value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (Param_0 /= 1))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (1 + 2))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (Param_0 **= 1))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (True And True))|1 ms|
| |(binary: (True != True))|1 ms|
| |(binary: (Param_0 += 2))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (Param_0 }}= 2))|1 ms|
| |(binary: (Param_0 $$= True))|1 ms|
| |(binary: (1 % 2))|1 ms|
| |(binary: (True Or True))|1 ms|
| |(binary: (1 {= 2))|1 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (Param_0 &&= True))|1 ms|
| |(binary: (Param_0 }}= 2))|1 ms|
| |(binary: (Param_0 ^= True))|1 ms|
| |(binary: (Param_0 $$= True))|1 ms|
| |(binary: (Param_0 += 2))|1 ms|
| |(binary: (Param_0 %= 1))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
|**Binary Expression Should Deserialize**| |**277 ms**|
| |(binary: (1 + 2))|9 ms|
| |(binary: (Param_0 &= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|8 ms|
| |(binary: (Param_0 ^= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|6 ms|
| |(binary: (Param_0 {{= 2))|6 ms|
| |(binary: (Param_0 $= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|6 ms|
| |(binary: (Param_0 ^= True))|6 ms|
| |(binary: (Param_0 %= 1))|6 ms|
| |(binary: (Param_0 -= 2))|5 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|5 ms|
| |(binary: (Param_0 }}= 2))|5 ms|
| |(binary: (Param_0 /= 1))|5 ms|
| |(binary: (Param_0 -= 2))|5 ms|
| |(binary: (Param_0 **= 1))|5 ms|
| |(binary: (1 ** 2))|5 ms|
| |(binary: (Param_0 -= 2))|4 ms|
| |(binary: (1 + 2))|4 ms|
| |(binary: (1 - 2))|3 ms|
| |(binary: (1 - 2))|3 ms|
| |(binary: (1 * 2))|3 ms|
| |(binary: (1 / 2))|3 ms|
| |(binary: (1 { 2))|3 ms|
| |(binary: (Param_0 {{= 2))|3 ms|
| |(binary: (1 - 2))|3 ms|
| |(binary: (1 % 2))|3 ms|
| |(binary: (1 } 2))|3 ms|
| |(binary: (1 {= 2))|3 ms|
| |(binary: (1 }} 2))|3 ms|
| |(binary: (Param_0 -= 2))|3 ms|
| |(binary: (1 {{ 2))|3 ms|
| |(binary: (1 }= 2))|3 ms|
| |(binary: (True == True))|3 ms|
| |(binary: (Param_0 *= 2))|3 ms|
| |(binary: (Param_0 %= 1))|2 ms|
| |(binary: (1 * 2))|2 ms|
| |(binary: (True != True))|2 ms|
| |(binary: (1 + 2))|2 ms|
| |(binary: (True And True))|2 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) ^ value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (Param_0 += 2))|2 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) AndAlso value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (True Or True))|2 ms|
| |(binary: (1 ** 2))|2 ms|
| |(binary: (Param_0 ^= True))|2 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) OrElse value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (Param_0 /= 1))|2 ms|
| |(binary: (Param_0 += 2))|2 ms|
| |(binary: (Param_0 **= 1))|2 ms|
| |(binary: (Param_0 $$= True))|2 ms|
| |(binary: (Param_0 += 2))|2 ms|
| |(binary: (Param_0 }}= 2))|2 ms|
| |(binary: (Param_0 **= 1))|2 ms|
| |(binary: (Param_0 &&= True))|2 ms|
| |(binary: (Param_0 *= 2))|2 ms|
| |(binary: (1 {= 2))|2 ms|
| |(binary: (1 {{ 2))|2 ms|
| |(binary: (1 { 2))|2 ms|
| |(binary: (1 - 2))|2 ms|
| |(binary: (Param_0 /= 1))|2 ms|
| |(binary: (1 * 2))|2 ms|
| |(binary: (1 } 2))|2 ms|
| |(binary: (1 }= 2))|2 ms|
| |(binary: (1 % 2))|2 ms|
| |(binary: (True ^ True))|2 ms|
| |(binary: (True AndAlso True))|2 ms|
| |(binary: (True And True))|2 ms|
| |(binary: (1 + 2))|2 ms|
| |(binary: (Param_0 %= 1))|2 ms|
| |(binary: (Param_0 *= 2))|2 ms|
| |(binary: (True Or True))|2 ms|
| |(binary: (True == True))|2 ms|
| |(binary: (Param_0 {{= 2))|2 ms|
| |(binary: (True != True))|2 ms|
| |(binary: (1 }} 2))|2 ms|
| |(binary: (1 / 2))|2 ms|
| |(binary: (Param_0 $$= True))|2 ms|
| |(binary: (True OrElse True))|2 ms|
| |(binary: (1 * 2))|2 ms|
| |(binary: (Param_0 }}= 2))|2 ms|
| |(binary: (Param_0 += 2))|2 ms|
| |(binary: (Param_0 *= 2))|2 ms|
| |(binary: (Param_0 &&= True))|2 ms|
| |(binary: (Param_0 = value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
|Given Authorized Method When Deserialize Called Then Should Deserialize| |4 ms|
## TypesCompressorTest (177 ms)

|Test Name|Duration|
|:--|--:|
|Given Members Compressed Then Should Decompress|100 ms|
|Given Keys When Compress Types Called Then Should Compress Types In Keys|74 ms|
|Given Null Type Index When Compress Type Index Called Then Should Throw Argument Null|441 ns|
|Given Compressed Type Index When Decompressed Then Should Restore Types|433 ns|
|To Get Expression Tree Returns Last Expression|422 ns|
|Given Null Type Index When Decompress Types Called Then Should Throw Argument Null|379 ns|
|Given Empty Key When Decompress Types Called Then Returns Key|370 ns|
|Given Null Type Index When Compress Types Called Then Should Throw Argument Null|329 ns|
|Given Null Keys When Compress Types Called Then Should Do Nothing|257 ns|
|Given Null Keys When Decompress Types Called Then Should Not Throw|211 ns|
## MemberInitSerializerTest (62 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Member Init Expression Then Should Deserialize**| |**57 ms**|
| |(expression: new MemberInitSerializerTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}})|9 ms|
| |(expression: new TestData() {Name = "Hello"})|8 ms|
| |(expression: new MemberInitSerializerTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}})|7 ms|
| |(expression: new TestData("Hello") {Name = "GoodBye"})|6 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = {Name = "MemberInitSerializerTests"}})|5 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = new TestData()})|5 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = null})|5 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = new TestData()})|5 ms|
| |(expression: new TestData() {Name = "Hello"})|5 ms|
|**Lambda Expression Should Serialize**| |**4 ms**|
| |(lambda: (target, pattern) =} target.Contains(pattern))|3 ms|
| |(lambda: () =} 1)|1 ms|
## UnarySerializerTest (84 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Unary Expression Should Deserialize**| |**48 ms**|
| |(unary: () =} Invoke(() =} True))|3 ms|
| |(unary: -5)|1 ms|
| |(unary: Increment(5))|1 ms|
| |(unary: value++)|1 ms|
| |(unary: Unbox(5))|1 ms|
| |(unary: -5)|1 ms|
| |(unary: ConvertChecked(5, String))|1 ms|
| |(unary: Convert(5, Int64))|1 ms|
| |(unary: Convert(5, String))|1 ms|
| |(unary: Decrement(5))|1 ms|
| |(unary: Not(True))|1 ms|
| |(unary: +5)|1 ms|
| |(unary: ++value)|1 ms|
| |(unary: --value)|1 ms|
| |(unary: value--)|1 ms|
| |(unary: ArrayLength(value(System.Int32{})))|1 ms|
| |(unary: +5)|1 ms|
| |(unary: -5)|1 ms|
| |(unary: Not(True))|1 ms|
| |(unary: (5 As Object))|1 ms|
| |(unary: ConvertChecked(5, Int64))|1 ms|
| |(unary: throw(System.ArgumentNullException: Value cannot be null.))|1 ms|
| |(unary: -5)|1 ms|
| |(unary: Increment(5))|1 ms|
| |(unary: throw(System.InvalidCastException: Specified cast is not valid.))|1 ms|
| |(unary: Decrement(5))|1 ms|
| |(unary: value--)|1 ms|
| |(unary: --value)|1 ms|
| |(unary: ++value)|1 ms|
| |(unary: value++)|1 ms|
| |(unary: throw())|673 ns|
| |(unary: throw())|482 ns|
|**Unary Expression Should Serialize**| |**34 ms**|
| |(unary: -5)|2 ms|
| |(unary: () =} Invoke(() =} True))|2 ms|
| |(unary: Convert(5, String))|1 ms|
| |(unary: Not(True))|1 ms|
| |(unary: ArrayLength(value(System.Int32{})))|1 ms|
| |(unary: Convert(5, Int64))|1 ms|
| |(unary: Increment(5))|1 ms|
| |(unary: -5)|1 ms|
| |(unary: throw(System.ArgumentNullException: Value cannot be null.))|1 ms|
| |(unary: Not(True))|1 ms|
| |(unary: Decrement(5))|1 ms|
| |(unary: ConvertChecked(5, String))|1 ms|
| |(unary: Unbox(5))|1 ms|
| |(unary: throw(System.InvalidCastException: Specified cast is not valid.))|1 ms|
| |(unary: -5)|1 ms|
| |(unary: value++)|1 ms|
| |(unary: +5)|972 ns|
| |(unary: -5)|913 ns|
| |(unary: Decrement(5))|913 ns|
| |(unary: --value)|910 ns|
| |(unary: ConvertChecked(5, Int64))|907 ns|
| |(unary: value--)|905 ns|
| |(unary: ++value)|904 ns|
| |(unary: --value)|901 ns|
| |(unary: Increment(5))|900 ns|
| |(unary: (5 As Object))|814 ns|
| |(unary: +5)|799 ns|
| |(unary: value--)|786 ns|
| |(unary: ++value)|778 ns|
| |(unary: value++)|776 ns|
| |(unary: throw())|660 ns|
| |(unary: throw())|409 ns|
|Given Types When Compress Type Index Called Then Should Compress Type Keys| |1 ms|
## CtorSerializerTest (41 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**New Expression Should Deserialize**| |**36 ms**|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: {Int32 Prop, System.String field})|5 ms|
| |(info: Void .ctor(Int32), args: {1}, members: {Int32 Prop})|5 ms|
| |(info: Void .ctor(Int32), args: {2}, members: null)|5 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: null)|4 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests, System.String), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), "CtorSerializerTests"}, members: null)|4 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: {ExpressionPowerTools.Serialization.Tests.CtorSerializerTests Thing})|3 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: null)|3 ms|
| |(info: Void .ctor(Int32), args: {1}, members: null)|3 ms|
| |(info: Void .ctor(), args: null, members: null)|1 ms|
|Given Ctor Not Allowed When Deserialize Called Then Should Throw Unauthorized Access| |2 ms|
|Given Ctor Allowed When Deserialize Called Then Should Deserialize| |2 ms|
|Given Enumerable Query When Query Root Is Null Then Should Return Null Constant| |950 ns|
## ReflectionHelperTest (35 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|State Captures Parameters| |34 ms|
|**Given Non Generic Member When Get Generic Version Called Then Finds Generic Version**| |**612 ns**|
| |(closed: Void .ctor(Int32), generic: Void .ctor(T))|267 ns|
| |(closed: Void .ctor(), generic: Void .ctor())|191 ns|
| |(closed: typeof(ExpressionPowerTools.Serialization.Tests.ReflectionHelperTests+Tester{int, ExpressionPowerTools.Serialization.Tests.ReflectionHelperTests+Test{int}}), generic: typeof(ExpressionPowerTools.Serialization.Tests.ReflectionHelperTests+Tester{,}))|71 ns|
| |(closed: Int32 ProcessType(Test^1), generic: T ProcessType(TTest))|18 ns|
| |(closed: System.String Id, generic: System.String Id)|18 ns|
| |(closed: Void .ctor(Test^1), generic: Void .ctor(TTest))|15 ns|
| |(closed: Test^1 Prop, generic: TTest Prop)|11 ns|
| |(closed: Int32 field, generic: Int32 field)|7 ns|
| |(closed: Void ProcessType(System.String), generic: Void ProcessType(System.String))|7 ns|
| |(closed: System.String Field, generic: System.String Field)|4 ns|
|Given Generic Member Not Found When Get Generic Version Called Then Should Return Null| |154 ns|
## LambdaSerializerTest (40 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Serializes And Deserializes Anonymous Types| |27 ms|
|Given Object When Lambda Expression That References Property Is Deserialized Then Should Resolve Property| |6 ms|
|**Lambda Expression Should Deserialize**| |**7 ms**|
| |(lambda: (target, pattern) =} target.Contains(pattern))|5 ms|
| |(lambda: () =} 1)|2 ms|
## ConstantSerializerTest (38 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Constant Expression Should Deserialize**| |**23 ms**|
| |(constant: { foo = bar, bar = { bar = foo } })|9 ms|
| |(constant: 5)|6 ms|
| |(constant: { foo = bar, id = 42 })|1 ms|
| |(constant: { foo = bar, bar =  })|1 ms|
| |(constant: System.IComparable^1{T})|1 ms|
| |(constant: 5)|806 ns|
| |(constant: 5)|717 ns|
| |(constant: value(System.Int32{}))|713 ns|
| |(constant: value(System.Int32{}))|682 ns|
| |(constant: null)|592 ns|
|**Constant Expression Should Serialize**| |**12 ms**|
| |(constant: { foo = bar, bar = { bar = foo } })|4 ms|
| |(constant: 5)|1 ms|
| |(constant: { foo = bar, id = 42 })|1 ms|
| |(constant: 5)|1 ms|
| |(constant: { foo = bar, bar =  })|1 ms|
| |(constant: System.IComparable^1{T})|849 ns|
| |(constant: value(System.Int32{}))|549 ns|
| |(constant: value(System.Int32{}))|537 ns|
| |(constant: 5)|521 ns|
| |(constant: null)|461 ns|
|Given Enumerable Query When Query Root Is Non Constant Expression Then Should Be Set| |1 ms|
|Given Enumerable Query When Query Root Is Constant Expression Then Should Be Set| |1 ms|
|Given Configure Called When Configuring Then Should Throw Invalid Operation| |303 ns|
## MemberSerializerTest (28 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Member Init Expression Then Should Serialize**| |**19 ms**|
| |(expression: new MemberInitSerializerTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}})|2 ms|
| |(expression: new MemberInitSerializerTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}})|2 ms|
| |(expression: new TestData("Hello") {Name = "GoodBye"})|2 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = {Name = "MemberInitSerializerTests"}})|2 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = new TestData()})|2 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = new TestData()})|1 ms|
| |(expression: new TestData() {Name = "Hello"})|1 ms|
| |(expression: new TestData() {Name = "Hello"})|1 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = null})|1 ms|
|**Member Expression Should Deserialize**| |**8 ms**|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).InstanceProperty)|2 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).instanceField)|2 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).ReadOnlyProperty)|2 ms|
| |(member: MemberSerializerTests.staticField)|907 ns|
| |(member: MemberSerializerTests.StaticProperty)|891 ns|
## DefaultConfigurationTest (13 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**New Expression Should Serialize**| |**13 ms**|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests, System.String), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), "CtorSerializerTests"}, members: null)|1 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: {Int32 Prop, System.String field})|1 ms|
| |(info: Void .ctor(Int32), args: {2}, members: null)|1 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: null)|1 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: null)|1 ms|
| |(info: Void .ctor(Int32), args: {1}, members: null)|1 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: {ExpressionPowerTools.Serialization.Tests.CtorSerializerTests Thing})|1 ms|
| |(info: Void .ctor(Int32), args: {1}, members: {Int32 Prop})|1 ms|
| |(info: Void .ctor(), args: null, members: null)|595 ns|
|Given Default Configuration When Configure Requested Then Should Return Configuration Builder| |437 ns|
|Given Default Configuration When State Requested Then Should Return New Instance| |122 ns|
## MethodSerializerTest (23 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Method Call Expression Should Deserialize**| |**13 ms**|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnIntDoubled(2))|3 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).DoNothing())|2 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnInt())|2 ms|
| |(method: StaticReturnIntDoubled(2))|2 ms|
| |(method: StaticDoNothing())|1 ms|
| |(method: StaticReturnInt())|1 ms|
|Given Method Not Allowed When Deserialize Called Then Should Throw Unauthorized Access| |2 ms|
|Given Method Allowed When Deserialize Called Then Should Deserialize| |2 ms|
|**Member Expression Should Serialize**| |**5 ms**|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).InstanceProperty)|1 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).ReadOnlyProperty)|1 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).instanceField)|1 ms|
| |(member: MemberSerializerTests.staticField)|608 ns|
| |(member: MemberSerializerTests.StaticProperty)|604 ns|
## InvocationSerializerTest (21 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Expression Has Serializer When Serialize Called Then Should Serialize| |11 ms|
|**Invocation Expression Should Deserialize**| |**10 ms**|
| |(invocation: Invoke(i =} True, i))|4 ms|
| |(invocation: Invoke(() =} True))|3 ms|
| |(invocation: Invoke(() =} "FuncString"))|2 ms|
## RulesEngineTest (31 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Generic Rules When Reset Called Then Should Reset All| |10 ms|
|**Given No Config When Member Is Allowed Then Should Return Default**| |**6 ms**|
| |(memberInfo: T Thing, allowed: True)|1 ms|
| |(memberInfo: Int32 field, allowed: True)|857 ns|
| |(memberInfo: Void .ctor(ExpressionPowerTools.Serialization.Tests.RulesEngineTests), allowed: False)|840 ns|
| |(memberInfo: ExpressionPowerTools.Serialization.Tests.RulesEngineTests Thing, allowed: True)|660 ns|
| |(memberInfo: typeof(ExpressionPowerTools.Serialization.Tests.RulesEngineTests+RuleClass{ExpressionPowerTools.Serialization.Tests.RulesEngineTests}), allowed: False)|553 ns|
| |(memberInfo: Void SetOtherProp(System.String), allowed: False)|548 ns|
| |(memberInfo: Void .ctor(T), allowed: False)|429 ns|
| |(memberInfo: typeof(ExpressionPowerTools.Serialization.Tests.RulesEngineTests+RuleClass{}), allowed: False)|368 ns|
| |(memberInfo: Void SetOtherProp(System.String), allowed: False)|289 ns|
| |(memberInfo: Int32 field, allowed: True)|279 ns|
|Given Generic Rules When Rule Set For Closed Type Ctor Then Should Override| |1 ms|
|Given Generic Rules When Closed Access Requested For Ctor Then Should Default To Generic Return Result| |1 ms|
|Given Rule For Ctor Allowed When Member Is Allowed Called Then Should Return True| |1 ms|
|Given Generic Rules When Closed Access Requested Then Should Default To Generic Return Result| |910 ns|
|Given Type Allowed And Member Denied When Member Is Allowed Then Should Return False| |875 ns|
|Given Type Denied And Ctor Allowed When Member Is Allowed Called Then Should Return True| |872 ns|
|Given Type Allowed And Ctor Denied When Member Is Allowed Then Should Return False| |871 ns|
|Given Generic Rules When Rule Set For Closed Type Then Should Override| |851 ns|
|Given Generic Type Allowed When Member Is Allowed For Closed Type Then Should Return True| |782 ns|
|Given Type Denied And Member Allowed When Member Is Allowed Called Then Should Return True| |767 ns|
|Given Config Calling Compile Multiple Times Yields Same Results| |704 ns|
|Given Field Denied When Member Requested Then Should Return False| |700 ns|
|Given Closed Type Allowed When Member Is Allowed Then Should Return Return| |675 ns|
|Given Type Denied When Property Or Field Requested Then Should Return False| |488 ns|
|Given Type Allowed When Method Requested Then Should Return True| |470 ns|
|Given Property Denied When Member Is Allowed Then Should Return False| |436 ns|
|Given Method Allowed When Member Requested Then Should Return True| |434 ns|
|**Given No Rule When Allow Or Deny Called Then Should Throw Invalid Operation**| |**412 ns**|
| |(allow: True)|380 ns|
| |(allow: False)|32 ns|
|Given Anonymous Denied When Anonymous Ctor Is Requested Then Should Return False| |227 ns|
|Given Type Not Found When Find Generic Version Called Then Should Return Null| |152 ns|
|Given Non Config When Anonymous Ctor Is Requested Then Should Return True| |100 ns|
## ExpressionSerializerTest (14 ms)

|Test Name|Duration|
|:--|--:|
|Given Expression Has Serializer When Deserialize Called Then Should Deserialize|9 ms|
|Given Expression Has No Serializer When Serialize Called Then Should Return Serializable Expression|4 ms|
|Given No Configuration When Default Configuration Requested Then Should Use System Defaults|153 ns|
## NewArraySerializerTest (10 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|New Array Expression Should Deserialize| |3 ms|
|**Method Call Expression Should Serialize**| |**7 ms**|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnIntDoubled(2))|2 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).DoNothing())|1 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnInt())|1 ms|
| |(method: StaticReturnIntDoubled(2))|1 ms|
| |(method: StaticDoNothing())|595 ns|
| |(method: StaticReturnInt())|585 ns|
## CompressionTest (20 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Unauthorized Method When Deserialize Called Then Should Throw Unauthorized Access| |4 ms|
|Given Filter With Variable When Visited Then Extracts Values| |3 ms|
|Given Expression Against String And Date When Visited Will Compress| |2 ms|
|**Given Conditional If Test Can Be Evaluated Then Should Transform To Test Result**| |**5 ms**|
| |(scenario: 1)|2 ms|
| |(scenario: 2)|2 ms|
| |(scenario: 0)|706 ns|
|Given Expression That Can Resolve When Visited Then Extracts Values| |1 ms|
|Given Nested Methods Then Will Compress| |1 ms|
|**Given Or Or Or Else When Node Is Evaluated Then Will Compress Node**| |**1 ms**|
| |(node: ((t.Id.Contains("aa") OrElse (t.Created { DateTime.Now)) OrElse (t.Value { 5)), expectedBinaryCount: 4)|614 ns|
| |(node: (False OrElse (t.Value { 2)), expectedBinaryCount: 1)|175 ns|
| |(node: (False Or True), expectedBinaryCount: 0)|162 ns|
| |(node: (True OrElse (t.Value { 2)), expectedBinaryCount: 0)|158 ns|
| |(node: ((t.Value { 2) OrElse False), expectedBinaryCount: 1)|158 ns|
| |(node: ((t.Value { 2) OrElse True), expectedBinaryCount: 0)|157 ns|
|**Given And Or And Also When Node Is Evaluated Then Will Compress Node**| |**1 ms**|
| |(node: ((t.Id.Contains("aa") AndAlso (t.Created { DateTime.Now)) AndAlso (t.Value { 5)), expectedBinaryCount: 4)|371 ns|
| |(node: (False AndAlso (t.Value { 2)), expectedBinaryCount: 0)|173 ns|
| |(node: (True And False), expectedBinaryCount: 0)|170 ns|
| |(node: ((t.Value { 2) AndAlso True), expectedBinaryCount: 1)|159 ns|
| |(node: (True AndAlso (t.Value { 2)), expectedBinaryCount: 1)|150 ns|
| |(node: ((t.Value { 2) AndAlso False), expectedBinaryCount: 0)|146 ns|
## ParameterSerializerTest (4 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|New Array Expression Should Serialize| |3 ms|
|**Parameter Expression Should Deserialize**| |**1 ms**|
| |(parameter: Param_0)|858 ns|
| |(parameter: GetParameterExpressions)|640 ns|
## SerializationStateTest (8 ms)

|Test Name|Duration|
|:--|--:|
|Done Compresses Type Index|3 ms|
|Decompress Types Decompresses Types|2 ms|
|Compress Types Compresses Types|1 ms|
|Given Serialization Rule When To String Called Then Should Include Permission And Member Key|443 ns|
|Given Compress Types False When Compress Type Index Called Then Does Nothing|346 ns|
|Given Compress Types False When Compress Types Called Then Does Nothing|244 ns|
|Get Expression Tree Resets Expression|230 ns|
|Given Override When To String Called Then Should Keep Expression|223 ns|
|Given Serialization State When Instantiated Then Should Initialize Type Index|180 ns|
|Given Parameters Of Same Name When Get Or Cache Called Then Should Return Same Instance|141 ns|
## SerializableExpressionTest (14 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Lambda Expression When Lambda Created Then Should Set Lambda Properties| |2 ms|
|Given Mixed Fields And Properties When Ctor Expr Created Then Should Map Appropriately| |2 ms|
|Given Binary Expression With Method When Binary Instantiated Then Should Set Method| |927 ns|
|Given New Array Expression When New Array Created Then Should Set Array Type| |720 ns|
|Given Property Selector When By Resolve Then Should Set Property Info| |711 ns|
|**Given Unary Expression When Unary Created Then Should Set Unary Type And Method**| |**1 ms**|
| |(unary: Convert(5, String))|681 ns|
| |(unary: ArrayLength(value(System.Int32{})))|572 ns|
|**Given Constructor When Ctor Expr Created Then Should Set Properties**| |**1 ms**|
| |(info: Void .ctor(Int32), arg: 1, member: Int32 Prop)|670 ns|
| |(info: Void .ctor(), arg: null, member: null)|606 ns|
| |(info: Void .ctor(Int32), arg: 1, member: null)|426 ns|
|Given Constant Expression When Constant Created Then Should Set Constant Type And Value And Value Type| |560 ns|
|Given Parameter Expression When Parameter Created Then Should Set Name And Parameter Type| |560 ns|
|Given Method Call Expression When Method Expr Created Then Should Set Properties| |552 ns|
|**Get Member From Key Resolves**| |**696 ns**|
| |(typed: False)|459 ns|
| |(typed: True)|237 ns|
|Given New Array Expression When New Array Created Then Should Initialize Expressions List| |419 ns|
|Given Null Expression When Constructor Called Then Should Throw Argument Null| |341 ns|
|Given Non Null Expression When Constructor Called Then Should Set Type| |241 ns|
|**Default Ctor Works For Serialization**| |**200 ns**|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.NewArray))|69 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.MethodExpr))|65 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.MemberInit))|9 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Binary))|6 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.SerializableExpression))|6 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.MemberExpr))|6 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Unary))|6 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.CtorExpr))|6 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Parameter))|6 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Lambda))|6 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Invocation))|5 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Constant))|4 ns|
## SerializationRuleTest (2 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given New Serialization Rule Then Should Initialize Properties| |2 ms|
|Given Get Hash Code When Called Then Should Return Hash Of Target Key| |445 ns|
|**Given Payload When Initialized Then Sets Payload Value**| |**84 ns**|
| |(type: Count)|78 ns|
| |(type: Array)|3 ns|
| |(type: Single)|2 ns|
## ConfigurationBuilderTest (2 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Configuration Builder Then Options Can Be Chained Configurable**| |**1 ms**|
| |(setting: True)|1 ms|
| |(setting: False)|24 ns|
|Given Skip Or Take With Variable When Visited Then Extracts Constants| |869 ns|
|**Given Configuration Builder When Compress Types Called Then Should Set Flag**| |**94 ns**|
| |(setting: True)|89 ns|
| |(setting: False)|5 ns|
|Given Configuration Builder When Configure Called Then Should Set Default Options| |63 ns|
## SerializationPayloadTest (1 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Payload When Initialized Then Get Query Type Gets Payload Value**| |**1 ms**|
| |(type: Array)|1 ms|
| |(type: Count)|19 ns|
| |(type: Single)|3 ns|
|When Ctor Expr Created Then Should Initialize Lists| |109 ns|
## SelectorTest (4 ms)

|Test Name|Duration|
|:--|--:|
|Given Method Selector When By Resolve Then Should Set Constructor Info|1 ms|
|Given Method Selector When By Resolve Then Should Set Method Info|506 ns|
|Given Field Selector When By Resolve Then Should Set Field Info|480 ns|
|Given Method Selector When By Name For Type Then Should Throw Invalid Operation|335 ns|
|Given Method Selector When By Name For Type Typed Then Should Throw Invalid Operation|267 ns|
|Given Method Selector When By Name For Type Typed Then Should Set Method Info|201 ns|
|Given Property Selector When By Property Info Then Should Set Property Info|197 ns|
|Given Property Selector When By Name For Type Typed Then Should Set Property Info|172 ns|
|Given Field Selector When By Name For Type Typed Then Should Set Field Info|162 ns|
|Given Field Selector When By Field Info Then Should Set Field Info|151 ns|
|Given Method Selector When By Method Info Then Should Set Method Info|144 ns|
|Given Method Selector When By Constructor Info Then Should Set Constructor Info|139 ns|
|Given Method Selector When By Name For Type Then Should Set Method Info|135 ns|
|Given Field Selector When By Name For Type Then Should Set Field Info|134 ns|
|Given Property Selector When By Name For Type Then Should Set Property Info|134 ns|
|Null Member Is Allowed|63 ns|

[Go Back](./index.md)

# Summary of Test Runs for ExpressionPowerTools.Serialization

Jump to group:

- [BinarySerializerTest](#binaryserializertest-384-ms)
- [CompressionTest](#compressiontest-19-ms)
- [ConfigurationBuilderTest](#configurationbuildertest-5-ms)
- [ConstantSerializerTest](#constantserializertest-55-ms)
- [CtorSerializerTest](#ctorserializertest-28-ms)
- [DefaultConfigurationTest](#defaultconfigurationtest-11-ms)
- [ExpressionSerializerTest](#expressionserializertest-18-ms)
- [InvocationSerializerTest](#invocationserializertest-13-ms)
- [LambdaSerializerTest](#lambdaserializertest-25-ms)
- [MemberInitSerializerTest](#memberinitserializertest-71-ms)
- [MemberSerializerTest](#memberserializertest-20-ms)
- [MethodSerializerTest](#methodserializertest-27-ms)
- [NewArraySerializerTest](#newarrayserializertest-15-ms)
- [ParameterSerializerTest](#parameterserializertest-9-ms)
- [ReflectionHelperTest](#reflectionhelpertest-2-ms)
- [RulesEngineTest](#rulesenginetest-33-ms)
- [SelectorTest](#selectortest-5-ms)
- [SerializableExpressionTest](#serializableexpressiontest-24-ms)
- [SerializationPayloadTest](#serializationpayloadtest-2-ms)
- [SerializationRuleTest](#serializationruletest-53-ms)
- [SerializationStateTest](#serializationstatetest-614-ns)
- [SerializerTest](#serializertest-39-s)
- [UnarySerializerTest](#unaryserializertest-74-ms)

The slowest test was 'Given Query When Serialize Called Then Should Deserialize For Type (query: {}, type: MemberInit)' at 257 ms.

## SerializerTest (3.9 s)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Query When Serialize Called Then Should Deserialize For Type**| |**2.2 s**|
| |(query: {}, type: MemberInit)|257 ms|
| |(query: {}, type: SelectMany)|244 ms|
| |(query: {}, type: IdOnly)|242 ms|
| |(query: {}, type: CustomGenericProperty)|242 ms|
| |(query: {}, type: MemberInit)|228 ms|
| |(query: {}, type: MemberInit)|228 ms|
| |(query: {}, type: Filtered)|227 ms|
| |(query: {}, type: OrderByCreatedThenByDescendingId)|224 ms|
| |(query: {}, type: Skip1Take1)|200 ms|
| |(query: {}, type: WhereIdContainsAA)|195 ms|
|Multiple Select Many Projection Works| |68 ms|
|**Given Query When Serialize Called Then Should Deserialize**| |**366 ms**|
| |(query: {}, type: MemberInit)|60 ms|
| |(query: {}, type: IdAnonymousType)|41 ms|
| |(query: {}, type: MemberInit)|40 ms|
| |(query: {}, type: IdOnly)|35 ms|
| |(query: {}, type: MemberInit)|32 ms|
| |(query: {}, type: WhereIdContainsAA)|29 ms|
| |(query: {}, type: Filtered)|26 ms|
| |(query: {}, type: OrderByCreatedThenByDescendingId)|25 ms|
| |(query: {}, type: CustomGenericProperty)|20 ms|
| |(query: {}, type: SelectMany)|19 ms|
| |(query: {}, type: Skip1Take1)|18 ms|
| |(query: {}, type: IdProjection)|16 ms|
|Group By Works| |40 ms|
|**Given Default Configuration When No Config Provided Then Should Use Default**| |**48 ms**|
| |(configOverride: True)|35 ms|
| |(configOverride: False)|13 ms|
|**Given Binary Expression When Serialized Then Should Deserialize**| |**633 ms**|
| |(binary: (1 + 2))|29 ms|
| |(binary: (Param_0 %= 1))|18 ms|
| |(binary: (1 }} 2))|15 ms|
| |(binary: (True == True))|14 ms|
| |(binary: (Param_0 &= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|13 ms|
| |(binary: (Param_0 {{= 2))|13 ms|
| |(binary: (Param_0 &&= True))|12 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) OrElse value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|12 ms|
| |(binary: (1 {{ 2))|11 ms|
| |(binary: (Param_0 $= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|11 ms|
| |(binary: (Param_0 ^= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|10 ms|
| |(binary: (Param_0 {{= 2))|10 ms|
| |(binary: (Param_0 {{= 2))|9 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|9 ms|
| |(binary: (Param_0 }}= 2))|9 ms|
| |(binary: (Param_0 **= 1))|9 ms|
| |(binary: (Param_0 /= 1))|8 ms|
| |(binary: (Param_0 *= 2))|8 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) AndAlso value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|8 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) ^ value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|7 ms|
| |(binary: (True OrElse True))|7 ms|
| |(binary: (Param_0 += 2))|7 ms|
| |(binary: (Param_0 += 2))|7 ms|
| |(binary: (Param_0 %= 1))|7 ms|
| |(binary: (Param_0 *= 2))|7 ms|
| |(binary: (Param_0 **= 1))|7 ms|
| |(binary: (1 * 2))|7 ms|
| |(binary: (1 ** 2))|7 ms|
| |(binary: (Param_0 }}= 2))|7 ms|
| |(binary: (Param_0 $$= True))|7 ms|
| |(binary: (1 + 2))|7 ms|
| |(binary: (1 * 2))|7 ms|
| |(binary: (1 {= 2))|7 ms|
| |(binary: (Param_0 ^= True))|7 ms|
| |(binary: (1 }= 2))|7 ms|
| |(binary: (1 } 2))|7 ms|
| |(binary: (True Or True))|7 ms|
| |(binary: (True != True))|7 ms|
| |(binary: (True And True))|7 ms|
| |(binary: (1 { 2))|7 ms|
| |(binary: (Param_0 -= 2))|6 ms|
| |(binary: (1 % 2))|6 ms|
| |(binary: (Param_0 = value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|6 ms|
| |(binary: (Param_0 /= 1))|6 ms|
| |(binary: (Param_0 -= 2))|6 ms|
| |(binary: (1 - 2))|6 ms|
| |(binary: (1 - 2))|6 ms|
| |(binary: (1 / 2))|6 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|6 ms|
| |(binary: (Param_0 %= 1))|6 ms|
| |(binary: (Param_0 **= 1))|6 ms|
| |(binary: (1 ** 2))|6 ms|
| |(binary: (1 + 2))|5 ms|
| |(binary: (True Or True))|5 ms|
| |(binary: (True AndAlso True))|5 ms|
| |(binary: (1 * 2))|5 ms|
| |(binary: (Param_0 += 2))|5 ms|
| |(binary: (Param_0 &&= True))|5 ms|
| |(binary: (Param_0 *= 2))|5 ms|
| |(binary: (Param_0 }}= 2))|5 ms|
| |(binary: (Param_0 += 2))|5 ms|
| |(binary: (Param_0 ^= True))|5 ms|
| |(binary: (1 } 2))|5 ms|
| |(binary: (True != True))|5 ms|
| |(binary: (1 }} 2))|5 ms|
| |(binary: (1 {{ 2))|5 ms|
| |(binary: (Param_0 -= 2))|5 ms|
| |(binary: (Param_0 *= 2))|5 ms|
| |(binary: (1 + 2))|5 ms|
| |(binary: (1 }= 2))|5 ms|
| |(binary: (1 * 2))|5 ms|
| |(binary: (1 - 2))|5 ms|
| |(binary: (True And True))|5 ms|
| |(binary: (1 % 2))|5 ms|
| |(binary: (1 { 2))|5 ms|
| |(binary: (1 - 2))|5 ms|
| |(binary: (1 {= 2))|5 ms|
| |(binary: (True ^ True))|5 ms|
| |(binary: (Param_0 /= 1))|5 ms|
| |(binary: (Param_0 $$= True))|5 ms|
| |(binary: (True == True))|4 ms|
| |(binary: (Param_0 -= 2))|4 ms|
| |(binary: (1 / 2))|4 ms|
|**Given Expression When Serialized Then Should Deserialize**| |**58 ms**|
| |(constant: { foo = bar, bar = { bar = foo } })|18 ms|
| |(constant: { foo = bar, id = 42 })|6 ms|
| |(constant: { foo = bar, bar =  })|6 ms|
| |(constant: 5)|5 ms|
| |(constant: System.IComparable^1{T})|3 ms|
| |(constant: 5)|3 ms|
| |(constant: value(System.Int32{}))|3 ms|
| |(constant: value(System.Int32{}))|3 ms|
| |(constant: null)|3 ms|
| |(constant: 5)|3 ms|
|**Given Unary Expression When Serialized Then Should Deserialize**| |**197 ms**|
| |(unary: Convert(5, String))|18 ms|
| |(unary: -5)|11 ms|
| |(unary: +5)|11 ms|
| |(unary: () =} Invoke(() =} True))|8 ms|
| |(unary: ArrayLength(value(System.Int32{})))|8 ms|
| |(unary: -5)|6 ms|
| |(unary: Not(True))|6 ms|
| |(unary: ConvertChecked(5, String))|6 ms|
| |(unary: Decrement(5))|6 ms|
| |(unary: Increment(5))|6 ms|
| |(unary: -5)|6 ms|
| |(unary: value--)|5 ms|
| |(unary: throw(System.ArgumentNullException: Value cannot be null.))|5 ms|
| |(unary: value++)|5 ms|
| |(unary: (5 As Object))|5 ms|
| |(unary: ++value)|5 ms|
| |(unary: --value)|5 ms|
| |(unary: throw())|5 ms|
| |(unary: Not(True))|5 ms|
| |(unary: throw(System.InvalidCastException: Specified cast is not valid.))|5 ms|
| |(unary: ConvertChecked(5, Int64))|4 ms|
| |(unary: Convert(5, Int64))|4 ms|
| |(unary: Decrement(5))|4 ms|
| |(unary: Increment(5))|4 ms|
| |(unary: -5)|4 ms|
| |(unary: +5)|4 ms|
| |(unary: Unbox(5))|4 ms|
| |(unary: value--)|4 ms|
| |(unary: value++)|4 ms|
| |(unary: --value)|3 ms|
| |(unary: ++value)|3 ms|
| |(unary: throw())|2 ms|
|**Given Method Call Expression When Serialized Then Should Deserialize**| |**46 ms**|
| |(method: StaticReturnIntDoubled(2))|14 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).DoNothing())|7 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnIntDoubled(2))|7 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnInt())|6 ms|
| |(method: StaticReturnInt())|5 ms|
| |(method: StaticDoNothing())|4 ms|
|**Given New Expression When Serialized Then Should Deserialize**| |**76 ms**|
| |(info: Void .ctor(), args: null, members: null)|10 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests, System.String), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), "CtorSerializerTests"}, members: null)|10 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: {Int32 Prop, System.String field})|9 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: null)|8 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: null)|8 ms|
| |(info: Void .ctor(Int32), args: {1}, members: {Int32 Prop})|7 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: {ExpressionPowerTools.Serialization.Tests.CtorSerializerTests Thing})|7 ms|
| |(info: Void .ctor(Int32), args: {1}, members: null)|7 ms|
| |(info: Void .ctor(Int32), args: {2}, members: null)|6 ms|
|Given Rules Config Then Replaces Existing Rules| |9 ms|
|Given Configure Rules No Defaults Then Should Configure No Default Rule| |8 ms|
|**Given Lambda Expression When Serialized Then Should Deserialize**| |**14 ms**|
| |(lambda: (target, pattern) =} target.Contains(pattern))|8 ms|
| |(lambda: () =} 1)|5 ms|
|**Given Member Expression When Serialized Then Should Deserialize**| |**31 ms**|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).InstanceProperty)|8 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).instanceField)|7 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).ReadOnlyProperty)|6 ms|
| |(member: MemberSerializerTests.StaticProperty)|4 ms|
| |(member: MemberSerializerTests.staticField)|4 ms|
|Given Configure Rules Then Should Configure Defaults| |7 ms|
|**Given Invocation Expression When Serialized Then Should Deserialize**| |**20 ms**|
| |(invocation: Invoke(i =} True, i))|7 ms|
| |(invocation: Invoke(() =} True))|6 ms|
| |(invocation: Invoke(() =} "FuncString"))|6 ms|
|Given An Array With Expressions When Serialized Then Should Deserialize| |6 ms|
|**Given Parameter Expression When Serialized Then Should Deserialize**| |**5 ms**|
| |(parameter: Param_0)|2 ms|
| |(parameter: GetParameterExpressions)|2 ms|
|**Given Deserialize When Called With Null Or Empty String Then Should Throw Argument**| |**1 ms**|
| |(json: "")|1 ms|
| |(json: null)|231 ns|
| |(json: " ")|210 ns|
|**When Deserialize Query Called With Empty Or Null Json Then Should Throw Argument**| |**1 ms**|
| |(json: "")|787 ns|
| |(json: "  ")|555 ns|
| |(json: null)|370 ns|
|**When Deserialize Query For Type Called With Empty Or Null Json Then Should Throw Argument**| |**1 ms**|
| |(json: "  ")|612 ns|
| |(json: "")|374 ns|
| |(json: null)|352 ns|
|When Deserialize Query Called With Null Host Then Should Throw Argument Null| |475 ns|
|When Deserialize Called With Empty Json Then Should Return Null| |416 ns|
|Given Serialize When Called With Null Expression Then Should Throw Argument Null| |406 ns|
|Given Serialize When Called With Null Query Then Should Throw Argument Null| |403 ns|
|Given Serialization State When Instantiated Then Should Initialize Type Index| |113 ns|
|**Given Serializer When Serialize Called With Null Then Should Return Null**| |**147 ns**|
| |(serializer: BinarySerializer { })|79 ns|
| |(serializer: ParameterSerializer { })|11 ns|
| |(serializer: ConstantSerializer { })|9 ns|
| |(serializer: NewArraySerializer { })|9 ns|
| |(serializer: CtorSerializer { })|6 ns|
| |(serializer: InvocationSerializer { })|5 ns|
| |(serializer: UnarySerializer { })|5 ns|
| |(serializer: LambdaSerializer { })|5 ns|
| |(serializer: MethodSerializer { })|5 ns|
| |(serializer: MemberSerializer { })|4 ns|
| |(serializer: MemberInitSerializer { })|4 ns|
## BinarySerializerTest (384 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Binary Expression Should Deserialize**| |**227 ms**|
| |(binary: (1 + 2))|22 ms|
| |(binary: (Param_0 &= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|10 ms|
| |(binary: (Param_0 *= 2))|5 ms|
| |(binary: (1 + 2))|5 ms|
| |(binary: (Param_0 %= 1))|4 ms|
| |(binary: (Param_0 ^= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|4 ms|
| |(binary: (1 ** 2))|4 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|4 ms|
| |(binary: (Param_0 $= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|4 ms|
| |(binary: (Param_0 }}= 2))|4 ms|
| |(binary: (Param_0 {{= 2))|3 ms|
| |(binary: (Param_0 /= 1))|3 ms|
| |(binary: (1 + 2))|3 ms|
| |(binary: (Param_0 **= 1))|3 ms|
| |(binary: (Param_0 %= 1))|3 ms|
| |(binary: (Param_0 += 2))|3 ms|
| |(binary: (1 - 2))|3 ms|
| |(binary: (True == True))|3 ms|
| |(binary: (Param_0 ^= True))|2 ms|
| |(binary: (Param_0 += 2))|2 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) AndAlso value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) OrElse value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) ^ value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (True And True))|2 ms|
| |(binary: (1 }= 2))|2 ms|
| |(binary: (1 {{ 2))|2 ms|
| |(binary: (Param_0 }}= 2))|2 ms|
| |(binary: (1 * 2))|2 ms|
| |(binary: (Param_0 += 2))|2 ms|
| |(binary: (Param_0 {{= 2))|2 ms|
| |(binary: (1 { 2))|2 ms|
| |(binary: (1 - 2))|2 ms|
| |(binary: (1 }} 2))|2 ms|
| |(binary: (Param_0 /= 1))|2 ms|
| |(binary: (1 {= 2))|2 ms|
| |(binary: (1 * 2))|2 ms|
| |(binary: (True != True))|2 ms|
| |(binary: (Param_0 -= 2))|2 ms|
| |(binary: (1 / 2))|2 ms|
| |(binary: (True And True))|2 ms|
| |(binary: (Param_0 -= 2))|2 ms|
| |(binary: (1 ** 2))|2 ms|
| |(binary: (1 % 2))|2 ms|
| |(binary: (1 + 2))|2 ms|
| |(binary: (True Or True))|2 ms|
| |(binary: (1 } 2))|2 ms|
| |(binary: (Param_0 *= 2))|2 ms|
| |(binary: (Param_0 += 2))|2 ms|
| |(binary: (Param_0 **= 1))|2 ms|
| |(binary: (Param_0 $$= True))|2 ms|
| |(binary: (Param_0 &&= True))|2 ms|
| |(binary: (Param_0 %= 1))|2 ms|
| |(binary: (Param_0 **= 1))|2 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (1 {= 2))|1 ms|
| |(binary: (Param_0 = value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (1 }= 2))|1 ms|
| |(binary: (True ^ True))|1 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (Param_0 ^= True))|1 ms|
| |(binary: (1 { 2))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (1 }} 2))|1 ms|
| |(binary: (1 % 2))|1 ms|
| |(binary: (1 {{ 2))|1 ms|
| |(binary: (True == True))|1 ms|
| |(binary: (1 / 2))|1 ms|
| |(binary: (1 } 2))|1 ms|
| |(binary: (True AndAlso True))|1 ms|
| |(binary: (True Or True))|1 ms|
| |(binary: (True != True))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (True OrElse True))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (Param_0 }}= 2))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (Param_0 {{= 2))|1 ms|
| |(binary: (Param_0 /= 1))|1 ms|
| |(binary: (Param_0 &&= True))|1 ms|
| |(binary: (Param_0 $$= True))|1 ms|
|**Binary Expression Should Serialize**| |**149 ms**|
| |(binary: (1 {{ 2))|10 ms|
| |(binary: (1 + 2))|6 ms|
| |(binary: (1 + 2))|5 ms|
| |(binary: (Param_0 &= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|4 ms|
| |(binary: (Param_0 **= 1))|3 ms|
| |(binary: (Param_0 {{= 2))|2 ms|
| |(binary: (Param_0 %= 1))|2 ms|
| |(binary: (Param_0 /= 1))|2 ms|
| |(binary: (Param_0 {{= 2))|2 ms|
| |(binary: (Param_0 }}= 2))|2 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (Param_0 ^= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (Param_0 $= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (1 ** 2))|2 ms|
| |(binary: (1 }} 2))|2 ms|
| |(binary: (1 % 2))|1 ms|
| |(binary: (1 {= 2))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (1 / 2))|1 ms|
| |(binary: (Param_0 **= 1))|1 ms|
| |(binary: (Param_0 **= 1))|1 ms|
| |(binary: (1 % 2))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (True Or True))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (True AndAlso True))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) AndAlso value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (1 {= 2))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (1 ** 2))|1 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) OrElse value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (1 { 2))|1 ms|
| |(binary: (Param_0 $$= True))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (1 } 2))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (Param_0 += 2))|1 ms|
| |(binary: (True != True))|1 ms|
| |(binary: (True == True))|1 ms|
| |(binary: (True And True))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (Param_0 %= 1))|1 ms|
| |(binary: (1 }} 2))|1 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) ^ value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (Param_0 ^= True))|1 ms|
| |(binary: (1 } 2))|1 ms|
| |(binary: (1 { 2))|1 ms|
| |(binary: (1 }= 2))|1 ms|
| |(binary: (1 + 2))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (True != True))|1 ms|
| |(binary: (True OrElse True))|1 ms|
| |(binary: (True Or True))|1 ms|
| |(binary: (Param_0 %= 1))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (Param_0 $$= True))|1 ms|
| |(binary: (Param_0 {{= 2))|1 ms|
| |(binary: (Param_0 &&= True))|1 ms|
| |(binary: (Param_0 += 2))|1 ms|
| |(binary: (True == True))|1 ms|
| |(binary: (1 }= 2))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (1 / 2))|1 ms|
| |(binary: (Param_0 }}= 2))|1 ms|
| |(binary: (1 {{ 2))|1 ms|
| |(binary: (True ^ True))|1 ms|
| |(binary: (Param_0 += 2))|1 ms|
| |(binary: (Param_0 /= 1))|1 ms|
| |(binary: (1 + 2))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (True And True))|1 ms|
| |(binary: (Param_0 ^= True))|1 ms|
| |(binary: (Param_0 += 2))|1 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (Param_0 }}= 2))|1 ms|
| |(binary: (Param_0 = value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (Param_0 &&= True))|1 ms|
| |(binary: (Param_0 /= 1))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
|Given Options Ignore Null When Binary Serialized Then Should Deserialize| |4 ms|
|Given Authorized Method When Deserialize Called Then Should Deserialize| |3 ms|
## MemberInitSerializerTest (71 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Member Init Expression Then Should Deserialize**| |**68 ms**|
| |(expression: new MemberInitSerializerTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}})|21 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = null})|7 ms|
| |(expression: new MemberInitSerializerTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}})|7 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = new TestData()})|6 ms|
| |(expression: new TestData("Hello") {Name = "GoodBye"})|5 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = {Name = "MemberInitSerializerTests"}})|5 ms|
| |(expression: new TestData() {Name = "Hello"})|5 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = new TestData()})|4 ms|
| |(expression: new TestData() {Name = "Hello"})|4 ms|
|**Lambda Expression Should Serialize**| |**3 ms**|
| |(lambda: (target, pattern) =} target.Contains(pattern))|1 ms|
| |(lambda: () =} 1)|1 ms|
## SerializationRuleTest (53 ms)

|Test Name|Duration|
|:--|--:|
|Given Serialization Payload When Serialized Then Should Deserialize|50 ms|
|Given New Serialization Rule Then Should Initialize Properties|2 ms|
|Given Get Hash Code When Called Then Should Return Hash Of Target Key|451 ns|
## UnarySerializerTest (74 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Unary Expression Should Deserialize**| |**42 ms**|
| |(unary: throw(System.ArgumentNullException: Value cannot be null.))|2 ms|
| |(unary: () =} Invoke(() =} True))|2 ms|
| |(unary: throw(System.InvalidCastException: Specified cast is not valid.))|2 ms|
| |(unary: ArrayLength(value(System.Int32{})))|1 ms|
| |(unary: +5)|1 ms|
| |(unary: Decrement(5))|1 ms|
| |(unary: Convert(5, String))|1 ms|
| |(unary: ConvertChecked(5, String))|1 ms|
| |(unary: Not(True))|1 ms|
| |(unary: -5)|1 ms|
| |(unary: -5)|1 ms|
| |(unary: Increment(5))|1 ms|
| |(unary: value++)|1 ms|
| |(unary: --value)|1 ms|
| |(unary: value--)|1 ms|
| |(unary: +5)|1 ms|
| |(unary: ++value)|1 ms|
| |(unary: Unbox(5))|1 ms|
| |(unary: Decrement(5))|1 ms|
| |(unary: Convert(5, Int64))|1 ms|
| |(unary: -5)|1 ms|
| |(unary: Not(True))|1 ms|
| |(unary: (5 As Object))|1 ms|
| |(unary: ConvertChecked(5, Int64))|1 ms|
| |(unary: Increment(5))|1 ms|
| |(unary: -5)|1 ms|
| |(unary: value--)|1 ms|
| |(unary: value++)|983 ns|
| |(unary: --value)|976 ns|
| |(unary: ++value)|975 ns|
| |(unary: throw())|567 ns|
| |(unary: throw())|558 ns|
|Given Options Ignore Null When Unary Serialized Then Should Deserialize| |2 ms|
|**Unary Expression Should Serialize**| |**27 ms**|
| |(unary: () =} Invoke(() =} True))|1 ms|
| |(unary: Increment(5))|1 ms|
| |(unary: Convert(5, String))|1 ms|
| |(unary: -5)|1 ms|
| |(unary: Not(True))|1 ms|
| |(unary: Decrement(5))|1 ms|
| |(unary: ConvertChecked(5, String))|1 ms|
| |(unary: +5)|943 ns|
| |(unary: -5)|938 ns|
| |(unary: ArrayLength(value(System.Int32{})))|912 ns|
| |(unary: ++value)|876 ns|
| |(unary: throw(System.InvalidCastException: Specified cast is not valid.))|862 ns|
| |(unary: Decrement(5))|847 ns|
| |(unary: (5 As Object))|836 ns|
| |(unary: value++)|830 ns|
| |(unary: Not(True))|823 ns|
| |(unary: throw(System.ArgumentNullException: Value cannot be null.))|821 ns|
| |(unary: ConvertChecked(5, Int64))|820 ns|
| |(unary: --value)|815 ns|
| |(unary: value--)|814 ns|
| |(unary: Unbox(5))|814 ns|
| |(unary: +5)|814 ns|
| |(unary: -5)|808 ns|
| |(unary: Increment(5))|808 ns|
| |(unary: -5)|807 ns|
| |(unary: Convert(5, Int64))|770 ns|
| |(unary: value--)|705 ns|
| |(unary: ++value)|685 ns|
| |(unary: value++)|682 ns|
| |(unary: --value)|678 ns|
| |(unary: throw())|427 ns|
| |(unary: throw())|422 ns|
|When Deserialize Query For Type Called With Null Host Then Should Throw Argument Null| |1 ms|
## ConstantSerializerTest (55 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Constant Expression Should Deserialize**| |**36 ms**|
| |(constant: { foo = bar, bar = { bar = foo } })|17 ms|
| |(constant: 5)|5 ms|
| |(constant: value(System.Int32{}))|2 ms|
| |(constant: { foo = bar, bar =  })|2 ms|
| |(constant: value(System.Int32{}))|2 ms|
| |(constant: { foo = bar, id = 42 })|2 ms|
| |(constant: System.IComparable^1{T})|1 ms|
| |(constant: 5)|1 ms|
| |(constant: 5)|879 ns|
| |(constant: null)|712 ns|
|**Constant Expression Should Serialize**| |**13 ms**|
| |(constant: { foo = bar, bar = { bar = foo } })|5 ms|
| |(constant: { foo = bar, id = 42 })|1 ms|
| |(constant: 5)|1 ms|
| |(constant: 5)|1 ms|
| |(constant: { foo = bar, bar =  })|1 ms|
| |(constant: System.IComparable^1{T})|867 ns|
| |(constant: value(System.Int32{}))|572 ns|
| |(constant: 5)|572 ns|
| |(constant: value(System.Int32{}))|565 ns|
| |(constant: null)|491 ns|
|Given Enumerable Query When Query Root Is Constant Expression Then Should Be Set| |2 ms|
|Given Enumerable Query When Query Root Is Non Constant Expression Then Should Be Set| |1 ms|
|Given Enumerable Query When Query Root Is Null Then Should Return Null Constant| |1 ms|
|Given Configure Called When Configuring Then Should Throw Invalid Operation| |221 ns|
## CtorSerializerTest (28 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**New Expression Should Deserialize**| |**22 ms**|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: {ExpressionPowerTools.Serialization.Tests.CtorSerializerTests Thing})|3 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: {Int32 Prop, System.String field})|3 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests, System.String), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), "CtorSerializerTests"}, members: null)|2 ms|
| |(info: Void .ctor(Int32), args: {1}, members: {Int32 Prop})|2 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: null)|2 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: null)|2 ms|
| |(info: Void .ctor(Int32), args: {2}, members: null)|1 ms|
| |(info: Void .ctor(Int32), args: {1}, members: null)|1 ms|
| |(info: Void .ctor(), args: null, members: null)|1 ms|
|Given Ctor Not Allowed When Deserialize Called Then Should Throw Unauthorized Access| |2 ms|
|Given Ctor Allowed When Deserialize Called Then Should Deserialize| |1 ms|
|Given Option Ignore Null Values When Constant Expression Serialized Then Should Deserialize| |1 ms|
## MethodSerializerTest (27 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Method Call Expression Should Deserialize**| |**15 ms**|
| |(method: StaticReturnInt())|4 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnIntDoubled(2))|2 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).DoNothing())|2 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnInt())|2 ms|
| |(method: StaticReturnIntDoubled(2))|1 ms|
| |(method: StaticDoNothing())|1 ms|
|Given Options Ignore Null When Method Call Serialized Then Should Deserialize| |2 ms|
|Given Method Not Allowed When Deserialize Called Then Should Throw Unauthorized Access| |2 ms|
|Given Method Allowed When Deserialize Called Then Should Deserialize| |1 ms|
|**Member Expression Should Serialize**| |**4 ms**|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).InstanceProperty)|1 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).ReadOnlyProperty)|928 ns|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).instanceField)|893 ns|
| |(member: MemberSerializerTests.StaticProperty)|815 ns|
| |(member: MemberSerializerTests.staticField)|517 ns|
## MemberSerializerTest (20 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Member Expression Should Deserialize**| |**7 ms**|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).InstanceProperty)|2 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).ReadOnlyProperty)|1 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).instanceField)|1 ms|
| |(member: MemberSerializerTests.StaticProperty)|998 ns|
| |(member: MemberSerializerTests.staticField)|982 ns|
|**Given Member Init Expression Then Should Serialize**| |**12 ms**|
| |(expression: new MemberInitSerializerTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}})|2 ms|
| |(expression: new MemberInitSerializerTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}})|1 ms|
| |(expression: new TestData("Hello") {Name = "GoodBye"})|1 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = new TestData()})|1 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = {Name = "MemberInitSerializerTests"}})|1 ms|
| |(expression: new TestData() {Name = "Hello"})|1 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = new TestData()})|1 ms|
| |(expression: new TestData() {Name = "Hello"})|1 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = null})|1 ms|
## RulesEngineTest (33 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Generic Rules When Reset Called Then Should Reset All| |10 ms|
|Given Rule For Ctor Allowed When Member Is Allowed Called Then Should Return True| |2 ms|
|Given Generic Rules When Closed Access Requested For Ctor Then Should Default To Generic Return Result| |1 ms|
|Given Generic Rules When Rule Set For Closed Type Ctor Then Should Override| |1 ms|
|Given Generic Rules When Closed Access Requested Then Should Default To Generic Return Result| |1 ms|
|Given Generic Rules When Rule Set For Closed Type Then Should Override| |1 ms|
|Given Type Allowed And Member Denied When Member Is Allowed Then Should Return False| |949 ns|
|Given Type Allowed And Ctor Denied When Member Is Allowed Then Should Return False| |927 ns|
|**Given No Config When Member Is Allowed Then Should Return Default**| |**5 ms**|
| |(memberInfo: Void .ctor(ExpressionPowerTools.Serialization.Tests.RulesEngineTests), allowed: False)|899 ns|
| |(memberInfo: ExpressionPowerTools.Serialization.Tests.RulesEngineTests Thing, allowed: True)|868 ns|
| |(memberInfo: Int32 field, allowed: True)|683 ns|
| |(memberInfo: typeof(ExpressionPowerTools.Serialization.Tests.RulesEngineTests+RuleClass{ExpressionPowerTools.Serialization.Tests.RulesEngineTests}), allowed: False)|637 ns|
| |(memberInfo: Void SetOtherProp(System.String), allowed: False)|557 ns|
| |(memberInfo: Void .ctor(T), allowed: False)|477 ns|
| |(memberInfo: T Thing, allowed: True)|435 ns|
| |(memberInfo: typeof(ExpressionPowerTools.Serialization.Tests.RulesEngineTests+RuleClass{}), allowed: False)|381 ns|
| |(memberInfo: Void SetOtherProp(System.String), allowed: False)|288 ns|
| |(memberInfo: Int32 field, allowed: True)|272 ns|
|Given Type Denied And Ctor Allowed When Member Is Allowed Called Then Should Return True| |890 ns|
|Given Generic Type Allowed When Member Is Allowed For Closed Type Then Should Return True| |799 ns|
|Given Type Denied And Member Allowed When Member Is Allowed Called Then Should Return True| |763 ns|
|Given Method Allowed When Member Requested Then Should Return True| |723 ns|
|Given Field Denied When Member Requested Then Should Return False| |701 ns|
|Given Config Calling Compile Multiple Times Yields Same Results| |700 ns|
|Given Closed Type Allowed When Member Is Allowed Then Should Return Return| |665 ns|
|Given Property Denied When Member Is Allowed Then Should Return False| |631 ns|
|Given Type Allowed When Method Requested Then Should Return True| |627 ns|
|**Given No Rule When Allow Or Deny Called Then Should Throw Invalid Operation**| |**473 ns**|
| |(allow: True)|441 ns|
| |(allow: False)|32 ns|
|Given Anonymous Denied When Anonymous Ctor Is Requested Then Should Return False| |243 ns|
|Given Non Config When Anonymous Ctor Is Requested Then Should Return True| |141 ns|
|Given Type Not Found When Find Generic Version Called Then Should Return Null| |135 ns|
## DefaultConfigurationTest (11 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**New Expression Should Serialize**| |**10 ms**|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: {Int32 Prop, System.String field})|1 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests, System.String), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), "CtorSerializerTests"}, members: null)|1 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: null)|1 ms|
| |(info: Void .ctor(Int32), args: {1}, members: {Int32 Prop})|1 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: {ExpressionPowerTools.Serialization.Tests.CtorSerializerTests Thing})|1 ms|
| |(info: Void .ctor(Int32), args: {2}, members: null)|1 ms|
| |(info: Void .ctor(Int32), args: {1}, members: null)|1 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: null)|1 ms|
| |(info: Void .ctor(), args: null, members: null)|610 ns|
|Given Default Configuration When Configure Requested Then Should Return Configuration Builder| |423 ns|
|Given Default Configuration When State Requested Then Should Return New Instance| |120 ns|
## NewArraySerializerTest (15 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|New Array Expression Should Deserialize| |9 ms|
|**Method Call Expression Should Serialize**| |**5 ms**|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnIntDoubled(2))|1 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnInt())|1 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).DoNothing())|1 ms|
| |(method: StaticReturnIntDoubled(2))|918 ns|
| |(method: StaticDoNothing())|631 ns|
| |(method: StaticReturnInt())|549 ns|
## SerializableExpressionTest (24 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Lambda Expression When Lambda Created Then Should Set Lambda Properties| |8 ms|
|Given Mixed Fields And Properties When Ctor Expr Created Then Should Map Appropriately| |3 ms|
|Given Property Selector When By Resolve Then Should Set Property Info| |3 ms|
|Given Binary Expression With Method When Binary Instantiated Then Should Set Method| |1 ms|
|**Given Unary Expression When Unary Created Then Should Set Unary Type And Method**| |**1 ms**|
| |(unary: Convert(5, String))|799 ns|
| |(unary: ArrayLength(value(System.Int32{})))|764 ns|
|**Given Constructor When Ctor Expr Created Then Should Set Properties**| |**1 ms**|
| |(info: Void .ctor(Int32), arg: 1, member: Int32 Prop)|749 ns|
| |(info: Void .ctor(), arg: null, member: null)|665 ns|
| |(info: Void .ctor(Int32), arg: 1, member: null)|523 ns|
|Given Method Call Expression When Method Expr Created Then Should Set Properties| |732 ns|
|Given New Array Expression When New Array Created Then Should Set Array Type| |676 ns|
|Given Parameter Expression When Parameter Created Then Should Set Name And Parameter Type| |578 ns|
|Given Constant Expression When Constant Created Then Should Set Constant Type And Value And Value Type| |572 ns|
|Given New Array Expression When New Array Created Then Should Initialize Expressions List| |547 ns|
|Given Null Expression When Constructor Called Then Should Throw Argument Null| |449 ns|
|**Get Member From Key Resolves**| |**724 ns**|
| |(typed: False)|412 ns|
| |(typed: True)|311 ns|
|Given Non Null Expression When Constructor Called Then Should Set Type| |235 ns|
|**Default Ctor Works For Serialization**| |**642 ns**|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.MethodExpr))|129 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.CtorExpr))|82 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.NewArray))|63 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.MemberInit))|60 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Lambda))|59 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Unary))|48 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.MemberExpr))|47 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Constant))|45 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Parameter))|44 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Binary))|44 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.SerializableExpression))|8 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Invocation))|8 ns|
## LambdaSerializerTest (25 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Null Options When Lambda Serialized Then Should Deserialize| |7 ms|
|Given Object When Lambda Expression That References Property Is Deserialized Then Should Resolve Property| |6 ms|
|**Lambda Expression Should Deserialize**| |**6 ms**|
| |(lambda: (target, pattern) =} target.Contains(pattern))|4 ms|
| |(lambda: () =} 1)|1 ms|
|**Invocation Expression Should Serialize**| |**5 ms**|
| |(invocation: Invoke(() =} True))|2 ms|
| |(invocation: Invoke(i =} True, i))|1 ms|
| |(invocation: Invoke(() =} "FuncString"))|1 ms|
## ParameterSerializerTest (9 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|New Array Expression Should Serialize| |6 ms|
|Given Options Ignore Null When Parameter Serialized Then Should Deserialize| |1 ms|
|**Parameter Expression Should Deserialize**| |**1 ms**|
| |(parameter: Param_0)|965 ns|
| |(parameter: GetParameterExpressions)|601 ns|
## InvocationSerializerTest (13 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Options Ignore Null When Invocation Expression Serialized Then Should Deserialize| |5 ms|
|Given Expression Has Serializer When Serialize Called Then Should Serialize| |2 ms|
|**Invocation Expression Should Deserialize**| |**6 ms**|
| |(invocation: Invoke(i =} True, i))|2 ms|
| |(invocation: Invoke(() =} True))|2 ms|
| |(invocation: Invoke(() =} "FuncString"))|1 ms|
## CompressionTest (19 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Unauthorized Method When Deserialize Called Then Should Throw Unauthorized Access| |3 ms|
|Given Filter With Variable When Visited Then Extracts Values| |3 ms|
|Given Expression Against String And Date When Visited Will Compress| |2 ms|
|**Given Conditional If Test Can Be Evaluated Then Should Transform To Test Result**| |**5 ms**|
| |(scenario: 2)|2 ms|
| |(scenario: 1)|2 ms|
| |(scenario: 0)|634 ns|
|Given Expression That Can Resolve When Visited Then Extracts Values| |1 ms|
|Given Nested Methods Then Will Compress| |964 ns|
|**Given Or Or Or Else When Node Is Evaluated Then Will Compress Node**| |**1 ms**|
| |(node: ((t.Id.Contains("aa") OrElse (t.Created { DateTime.Now)) OrElse (t.Value { 5)), expectedBinaryCount: 4)|553 ns|
| |(node: (False OrElse (t.Value { 2)), expectedBinaryCount: 1)|178 ns|
| |(node: ((t.Value { 2) OrElse False), expectedBinaryCount: 1)|163 ns|
| |(node: ((t.Value { 2) OrElse True), expectedBinaryCount: 0)|162 ns|
| |(node: (False Or True), expectedBinaryCount: 0)|158 ns|
| |(node: (True OrElse (t.Value { 2)), expectedBinaryCount: 0)|155 ns|
|**Given And Or And Also When Node Is Evaluated Then Will Compress Node**| |**1 ms**|
| |(node: ((t.Id.Contains("aa") AndAlso (t.Created { DateTime.Now)) AndAlso (t.Value { 5)), expectedBinaryCount: 4)|335 ns|
| |(node: (False AndAlso (t.Value { 2)), expectedBinaryCount: 0)|174 ns|
| |(node: ((t.Value { 2) AndAlso False), expectedBinaryCount: 0)|170 ns|
| |(node: ((t.Value { 2) AndAlso True), expectedBinaryCount: 1)|160 ns|
| |(node: (True And False), expectedBinaryCount: 0)|156 ns|
| |(node: (True AndAlso (t.Value { 2)), expectedBinaryCount: 1)|155 ns|
## ExpressionSerializerTest (18 ms)

|Test Name|Duration|
|:--|--:|
|Given Expression Has No Serializer When Deserialize Called Then Should Return Null|4 ms|
|Given Expression Has Serializer When Deserialize Called Then Should Deserialize|4 ms|
|Given Expression Has No Serializer When Serialize Called Then Should Return Serializable Expression|3 ms|
|Given Expression Has No Type When Deserialize Called Then Should Return Null|3 ms|
|Given Expression Has Null Type When Deserialize Called Then Should Return Null|2 ms|
|Given No Configuration When Default Configuration Requested Then Should Use System Defaults|438 ns|
## ConfigurationBuilderTest (5 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Skip Or Take With Variable When Visited Then Extracts Constants| |3 ms|
|**Given Configuration Builder Then Options Can Be Chained Configurable**| |**2 ms**|
| |(setting: True)|2 ms|
| |(setting: False)|176 ns|
|Given Configuration Builder When Json Options Set Then Should Configure Options| |160 ns|
|**Given Configuration Builder When Compress Types Called Then Should Set Flag**| |**89 ns**|
| |(setting: True)|82 ns|
| |(setting: False)|6 ns|
|Given Configuration Builder When Configure Called Then Should Set Default Options| |75 ns|
## SerializationPayloadTest (2 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Payload When Initialized Then Get Query Type Gets Payload Value**| |**1 ms**|
| |(type: Array)|1 ms|
| |(type: Count)|19 ns|
| |(type: Single)|3 ns|
|When Ctor Expr Created Then Should Initialize Lists| |175 ns|
|**Given Payload When Initialized Then Sets Payload Value**| |**87 ns**|
| |(type: Count)|80 ns|
| |(type: Array)|4 ns|
| |(type: Single)|3 ns|
## ReflectionHelperTest (2 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Parameter Expression Should Serialize**| |**1 ms**|
| |(parameter: GetParameterExpressions)|969 ns|
| |(parameter: Param_0)|820 ns|
|**Given Non Generic Member When Get Generic Version Called Then Finds Generic Version**| |**624 ns**|
| |(closed: Void .ctor(Int32), generic: Void .ctor(T))|286 ns|
| |(closed: Void .ctor(), generic: Void .ctor())|187 ns|
| |(closed: typeof(ExpressionPowerTools.Serialization.Tests.ReflectionHelperTests+Tester{int, ExpressionPowerTools.Serialization.Tests.ReflectionHelperTests+Test{int}}), generic: typeof(ExpressionPowerTools.Serialization.Tests.ReflectionHelperTests+Tester{,}))|73 ns|
| |(closed: Void .ctor(Test^1), generic: Void .ctor(TTest))|18 ns|
| |(closed: System.String Id, generic: System.String Id)|17 ns|
| |(closed: Int32 ProcessType(Test^1), generic: T ProcessType(TTest))|10 ns|
| |(closed: Test^1 Prop, generic: TTest Prop)|10 ns|
| |(closed: Void ProcessType(System.String), generic: Void ProcessType(System.String))|7 ns|
| |(closed: Int32 field, generic: Int32 field)|6 ns|
| |(closed: System.String Field, generic: System.String Field)|5 ns|
|Given Generic Member Not Found When Get Generic Version Called Then Should Return Null| |216 ns|
## SelectorTest (5 ms)

|Test Name|Duration|
|:--|--:|
|Given Method Selector When By Resolve Then Should Set Constructor Info|1 ms|
|Given Method Selector When By Resolve Then Should Set Method Info|870 ns|
|Given Type Denied When Property Or Field Requested Then Should Return False|756 ns|
|Given Field Selector When By Resolve Then Should Set Field Info|433 ns|
|Given Method Selector When By Name For Type Then Should Throw Invalid Operation|325 ns|
|Given Method Selector When By Name For Type Typed Then Should Throw Invalid Operation|284 ns|
|Given Property Selector When By Name For Type Typed Then Should Set Property Info|276 ns|
|Given Method Selector When By Name For Type Typed Then Should Set Method Info|242 ns|
|Given Field Selector When By Field Info Then Should Set Field Info|232 ns|
|Given Field Selector When By Name For Type Typed Then Should Set Field Info|228 ns|
|Given Method Selector When By Method Info Then Should Set Method Info|195 ns|
|Given Property Selector When By Property Info Then Should Set Property Info|163 ns|
|Given Method Selector When By Name For Type Then Should Set Method Info|147 ns|
|Given Property Selector When By Name For Type Then Should Set Property Info|144 ns|
|Given Method Selector When By Constructor Info Then Should Set Constructor Info|143 ns|
|Given Field Selector When By Name For Type Then Should Set Field Info|138 ns|
## SerializationStateTest (614 ns)

|Test Name|Duration|
|:--|--:|
|Given Serialization Rule When To String Called Then Should Include Permission And Member Key|466 ns|
|Given Parameters Of Same Name When Get Or Cache Called Then Should Return Same Instance|148 ns|

[Go Back](./index.md)

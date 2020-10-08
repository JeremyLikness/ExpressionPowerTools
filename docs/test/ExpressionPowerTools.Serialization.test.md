# Summary of Test Runs for ExpressionPowerTools.Serialization

Jump to group:

- [BinarySerializerTest](#binaryserializertest-345-ms)
- [CompressionTest](#compressiontest-17-ms)
- [ConfigurationBuilderTest](#configurationbuildertest-5-ms)
- [ConstantSerializerTest](#constantserializertest-47-ms)
- [CtorSerializerTest](#ctorserializertest-26-ms)
- [DefaultConfigurationTest](#defaultconfigurationtest-11-ms)
- [ExpressionSerializerTest](#expressionserializertest-15-ms)
- [InvocationSerializerTest](#invocationserializertest-12-ms)
- [LambdaSerializerTest](#lambdaserializertest-24-ms)
- [MemberInitSerializerTest](#memberinitserializertest-68-ms)
- [MemberSerializerTest](#memberserializertest-19-ms)
- [MethodSerializerTest](#methodserializertest-26-ms)
- [NewArraySerializerTest](#newarrayserializertest-13-ms)
- [ParameterSerializerTest](#parameterserializertest-8-ms)
- [ReflectionHelperTest](#reflectionhelpertest-2-ms)
- [RulesEngineTest](#rulesenginetest-31-ms)
- [SelectorTest](#selectortest-4-ms)
- [SerializableExpressionTest](#serializableexpressiontest-22-ms)
- [SerializationPayloadTest](#serializationpayloadtest-2-ms)
- [SerializationRuleTest](#serializationruletest-41-ms)
- [SerializationStateTest](#serializationstatetest-611-ns)
- [SerializerTest](#serializertest-4-s)
- [UnarySerializerTest](#unaryserializertest-77-ms)

The slowest test was 'Given Query When Serialize Called Then Should Deserialize For Type (query: {}, type: MemberInit)' at 284 ms.

## SerializerTest (4 s)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Query When Serialize Called Then Should Deserialize For Type**| |**2.4 s**|
| |(query: {}, type: MemberInit)|284 ms|
| |(query: {}, type: OrderByCreatedThenByDescendingId)|259 ms|
| |(query: {}, type: MemberInit)|256 ms|
| |(query: {}, type: Skip1Take1)|256 ms|
| |(query: {}, type: MemberInit)|252 ms|
| |(query: {}, type: Filtered)|233 ms|
| |(query: {}, type: SelectMany)|227 ms|
| |(query: {}, type: IdOnly)|219 ms|
| |(query: {}, type: CustomGenericProperty)|219 ms|
| |(query: {}, type: WhereIdContainsAA)|189 ms|
|Multiple Select Many Projection Works| |67 ms|
|**Given Query When Serialize Called Then Should Deserialize**| |**345 ms**|
| |(query: {}, type: MemberInit)|57 ms|
| |(query: {}, type: MemberInit)|39 ms|
| |(query: {}, type: IdAnonymousType)|34 ms|
| |(query: {}, type: IdOnly)|34 ms|
| |(query: {}, type: MemberInit)|30 ms|
| |(query: {}, type: WhereIdContainsAA)|29 ms|
| |(query: {}, type: Filtered)|27 ms|
| |(query: {}, type: OrderByCreatedThenByDescendingId)|23 ms|
| |(query: {}, type: CustomGenericProperty)|20 ms|
| |(query: {}, type: SelectMany)|18 ms|
| |(query: {}, type: IdProjection)|16 ms|
| |(query: {}, type: Skip1Take1)|12 ms|
|Group By Works| |47 ms|
|**Given Default Configuration When No Config Provided Then Should Use Default**| |**56 ms**|
| |(configOverride: True)|45 ms|
| |(configOverride: False)|10 ms|
|State Captures Parameters| |20 ms|
|State Captures Expression Tree| |20 ms|
|**Given Binary Expression When Serialized Then Should Deserialize**| |**636 ms**|
| |(binary: (Param_0 *= 2))|19 ms|
| |(binary: (Param_0 ^= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|19 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|18 ms|
| |(binary: (1 - 2))|14 ms|
| |(binary: (Param_0 &= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|14 ms|
| |(binary: (1 + 2))|13 ms|
| |(binary: (1 {= 2))|12 ms|
| |(binary: (1 + 2))|12 ms|
| |(binary: (1 ** 2))|12 ms|
| |(binary: (Param_0 $= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|10 ms|
| |(binary: (Param_0 {{= 2))|9 ms|
| |(binary: (Param_0 %= 1))|9 ms|
| |(binary: (Param_0 **= 1))|9 ms|
| |(binary: (1 ** 2))|9 ms|
| |(binary: (Param_0 }}= 2))|9 ms|
| |(binary: (1 {= 2))|8 ms|
| |(binary: (Param_0 /= 1))|8 ms|
| |(binary: (1 } 2))|8 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|8 ms|
| |(binary: (Param_0 &&= True))|8 ms|
| |(binary: (1 {{ 2))|8 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) ^ value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|8 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) OrElse value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|7 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) AndAlso value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|7 ms|
| |(binary: (Param_0 += 2))|7 ms|
| |(binary: (Param_0 *= 2))|7 ms|
| |(binary: (Param_0 %= 1))|7 ms|
| |(binary: (Param_0 += 2))|7 ms|
| |(binary: (Param_0 **= 1))|7 ms|
| |(binary: (1 + 2))|7 ms|
| |(binary: (1 * 2))|7 ms|
| |(binary: (Param_0 }}= 2))|7 ms|
| |(binary: (Param_0 {{= 2))|7 ms|
| |(binary: (Param_0 = value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|7 ms|
| |(binary: (True Or True))|7 ms|
| |(binary: (Param_0 ^= True))|7 ms|
| |(binary: (1 }} 2))|7 ms|
| |(binary: (True != True))|7 ms|
| |(binary: (1 / 2))|7 ms|
| |(binary: (1 % 2))|7 ms|
| |(binary: (1 { 2))|7 ms|
| |(binary: (1 }= 2))|7 ms|
| |(binary: (1 * 2))|6 ms|
| |(binary: (Param_0 $$= True))|6 ms|
| |(binary: (True And True))|6 ms|
| |(binary: (1 - 2))|6 ms|
| |(binary: (1 + 2))|6 ms|
| |(binary: (Param_0 -= 2))|6 ms|
| |(binary: (Param_0 /= 1))|6 ms|
| |(binary: (Param_0 -= 2))|6 ms|
| |(binary: (Param_0 **= 1))|6 ms|
| |(binary: (True == True))|6 ms|
| |(binary: (1 / 2))|6 ms|
| |(binary: (1 * 2))|5 ms|
| |(binary: (Param_0 += 2))|5 ms|
| |(binary: (Param_0 &&= True))|5 ms|
| |(binary: (1 } 2))|5 ms|
| |(binary: (Param_0 {{= 2))|5 ms|
| |(binary: (1 {{ 2))|5 ms|
| |(binary: (Param_0 *= 2))|5 ms|
| |(binary: (Param_0 $$= True))|5 ms|
| |(binary: (True != True))|5 ms|
| |(binary: (Param_0 %= 1))|5 ms|
| |(binary: (Param_0 += 2))|5 ms|
| |(binary: (True And True))|5 ms|
| |(binary: (True OrElse True))|5 ms|
| |(binary: (Param_0 }}= 2))|5 ms|
| |(binary: (1 }} 2))|5 ms|
| |(binary: (Param_0 *= 2))|5 ms|
| |(binary: (Param_0 ^= True))|5 ms|
| |(binary: (True AndAlso True))|5 ms|
| |(binary: (True Or True))|5 ms|
| |(binary: (1 * 2))|5 ms|
| |(binary: (Param_0 /= 1))|5 ms|
| |(binary: (Param_0 -= 2))|5 ms|
| |(binary: (1 { 2))|5 ms|
| |(binary: (1 % 2))|5 ms|
| |(binary: (True ^ True))|5 ms|
| |(binary: (1 }= 2))|4 ms|
| |(binary: (Param_0 -= 2))|4 ms|
| |(binary: (1 - 2))|4 ms|
| |(binary: (True == True))|4 ms|
| |(binary: (1 - 2))|4 ms|
|**Given Unary Expression When Serialized Then Should Deserialize**| |**192 ms**|
| |(unary: Convert(5, String))|18 ms|
| |(unary: Decrement(5))|11 ms|
| |(unary: ++value)|10 ms|
| |(unary: () =} Invoke(() =} True))|9 ms|
| |(unary: ArrayLength(value(System.Int32{})))|8 ms|
| |(unary: Decrement(5))|6 ms|
| |(unary: -5)|6 ms|
| |(unary: ConvertChecked(5, String))|6 ms|
| |(unary: Increment(5))|6 ms|
| |(unary: -5)|6 ms|
| |(unary: Not(True))|6 ms|
| |(unary: ++value)|6 ms|
| |(unary: throw(System.ArgumentNullException: Value cannot be null.))|5 ms|
| |(unary: +5)|5 ms|
| |(unary: value--)|5 ms|
| |(unary: --value)|5 ms|
| |(unary: value++)|5 ms|
| |(unary: throw(System.InvalidCastException: Specified cast is not valid.))|5 ms|
| |(unary: Convert(5, Int64))|4 ms|
| |(unary: Increment(5))|4 ms|
| |(unary: ConvertChecked(5, Int64))|4 ms|
| |(unary: -5)|4 ms|
| |(unary: Not(True))|4 ms|
| |(unary: -5)|4 ms|
| |(unary: Unbox(5))|4 ms|
| |(unary: +5)|4 ms|
| |(unary: (5 As Object))|4 ms|
| |(unary: value--)|4 ms|
| |(unary: --value)|3 ms|
| |(unary: value++)|3 ms|
| |(unary: throw())|2 ms|
| |(unary: throw())|2 ms|
|**Given Expression When Serialized Then Should Deserialize**| |**58 ms**|
| |(constant: { foo = bar, bar =  })|15 ms|
| |(constant: { foo = bar, bar = { bar = foo } })|7 ms|
| |(constant: { foo = bar, id = 42 })|6 ms|
| |(constant: 5)|6 ms|
| |(constant: 5)|4 ms|
| |(constant: value(System.Int32{}))|3 ms|
| |(constant: value(System.Int32{}))|3 ms|
| |(constant: System.IComparable^1{T})|3 ms|
| |(constant: null)|3 ms|
| |(constant: 5)|3 ms|
|**Given Method Call Expression When Serialized Then Should Deserialize**| |**48 ms**|
| |(method: StaticDoNothing())|13 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnIntDoubled(2))|7 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnInt())|7 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).DoNothing())|6 ms|
| |(method: StaticReturnIntDoubled(2))|6 ms|
| |(method: StaticReturnInt())|5 ms|
|**Given New Expression When Serialized Then Should Deserialize**| |**72 ms**|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: null)|13 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: {ExpressionPowerTools.Serialization.Tests.CtorSerializerTests Thing})|9 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: {Int32 Prop, System.String field})|8 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: null)|8 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests, System.String), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), "CtorSerializerTests"}, members: null)|7 ms|
| |(info: Void .ctor(Int32), args: {1}, members: {Int32 Prop})|7 ms|
| |(info: Void .ctor(Int32), args: {1}, members: null)|6 ms|
| |(info: Void .ctor(), args: null, members: null)|5 ms|
| |(info: Void .ctor(Int32), args: {2}, members: null)|5 ms|
|Given Rules Config Then Replaces Existing Rules| |9 ms|
|Given Configure Rules No Defaults Then Should Configure No Default Rule| |8 ms|
|**Given Lambda Expression When Serialized Then Should Deserialize**| |**13 ms**|
| |(lambda: (target, pattern) =} target.Contains(pattern))|8 ms|
| |(lambda: () =} 1)|5 ms|
|Given Configure Rules Then Should Configure Defaults| |8 ms|
|**Given Invocation Expression When Serialized Then Should Deserialize**| |**19 ms**|
| |(invocation: Invoke(i =} True, i))|7 ms|
| |(invocation: Invoke(() =} "FuncString"))|6 ms|
| |(invocation: Invoke(() =} True))|6 ms|
|**Given Member Expression When Serialized Then Should Deserialize**| |**31 ms**|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).ReadOnlyProperty)|7 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).InstanceProperty)|7 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).instanceField)|7 ms|
| |(member: MemberSerializerTests.staticField)|5 ms|
| |(member: MemberSerializerTests.StaticProperty)|4 ms|
|Given An Array With Expressions When Serialized Then Should Deserialize| |7 ms|
|**Given Parameter Expression When Serialized Then Should Deserialize**| |**5 ms**|
| |(parameter: GetParameterExpressions)|2 ms|
| |(parameter: Param_0)|2 ms|
|**Given Deserialize When Called With Null Or Empty String Then Should Throw Argument**| |**1 ms**|
| |(json: "")|1 ms|
| |(json: null)|219 ns|
| |(json: " ")|204 ns|
|**When Deserialize Query Called With Empty Or Null Json Then Should Throw Argument**| |**1 ms**|
| |(json: "  ")|558 ns|
| |(json: null)|360 ns|
| |(json: "")|349 ns|
|Given Serialize When Called With Null Expression Then Should Throw Argument Null| |550 ns|
|**When Deserialize Query For Type Called With Empty Or Null Json Then Should Throw Argument**| |**1 ms**|
| |(json: "  ")|478 ns|
| |(json: null)|313 ns|
| |(json: "")|305 ns|
|When Deserialize Called With Empty Json Then Should Return Null| |453 ns|
|Given Serialize When Called With Null Query Then Should Throw Argument Null| |416 ns|
|When Deserialize Query Called With Null Host Then Should Throw Argument Null| |370 ns|
|Given Serialization State When Instantiated Then Should Initialize Type Index| |110 ns|
|**Given Serializer When Serialize Called With Null Then Should Return Null**| |**142 ns**|
| |(serializer: BinarySerializer { })|82 ns|
| |(serializer: ConstantSerializer { })|10 ns|
| |(serializer: NewArraySerializer { })|9 ns|
| |(serializer: CtorSerializer { })|5 ns|
| |(serializer: MethodSerializer { })|5 ns|
| |(serializer: InvocationSerializer { })|5 ns|
| |(serializer: ParameterSerializer { })|5 ns|
| |(serializer: MemberInitSerializer { })|4 ns|
| |(serializer: UnarySerializer { })|4 ns|
| |(serializer: LambdaSerializer { })|4 ns|
| |(serializer: MemberSerializer { })|4 ns|
## BinarySerializerTest (345 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Binary Expression Should Deserialize**| |**203 ms**|
| |(binary: (1 + 2))|18 ms|
| |(binary: (Param_0 &= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|9 ms|
| |(binary: (Param_0 *= 2))|5 ms|
| |(binary: (1 + 2))|4 ms|
| |(binary: (Param_0 ^= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|4 ms|
| |(binary: (Param_0 $= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|4 ms|
| |(binary: (1 ** 2))|4 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|3 ms|
| |(binary: (Param_0 }}= 2))|3 ms|
| |(binary: (1 + 2))|3 ms|
| |(binary: (Param_0 %= 1))|3 ms|
| |(binary: (Param_0 /= 1))|3 ms|
| |(binary: (Param_0 {{= 2))|3 ms|
| |(binary: (Param_0 **= 1))|3 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) AndAlso value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (True And True))|2 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) OrElse value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) ^ value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (True != True))|2 ms|
| |(binary: (1 }} 2))|2 ms|
| |(binary: (Param_0 += 2))|2 ms|
| |(binary: (1 {{ 2))|2 ms|
| |(binary: (1 - 2))|2 ms|
| |(binary: (1 - 2))|2 ms|
| |(binary: (1 % 2))|2 ms|
| |(binary: (Param_0 }}= 2))|2 ms|
| |(binary: (1 * 2))|2 ms|
| |(binary: (True And True))|2 ms|
| |(binary: (Param_0 -= 2))|2 ms|
| |(binary: (Param_0 -= 2))|2 ms|
| |(binary: (1 / 2))|2 ms|
| |(binary: (1 ** 2))|2 ms|
| |(binary: (1 * 2))|2 ms|
| |(binary: (True Or True))|2 ms|
| |(binary: (1 }= 2))|2 ms|
| |(binary: (Param_0 ^= True))|2 ms|
| |(binary: (1 {= 2))|2 ms|
| |(binary: (1 { 2))|2 ms|
| |(binary: (True == True))|2 ms|
| |(binary: (1 } 2))|2 ms|
| |(binary: (Param_0 += 2))|2 ms|
| |(binary: (Param_0 += 2))|2 ms|
| |(binary: (Param_0 %= 1))|2 ms|
| |(binary: (Param_0 &&= True))|1 ms|
| |(binary: (Param_0 **= 1))|1 ms|
| |(binary: (Param_0 /= 1))|1 ms|
| |(binary: (Param_0 {{= 2))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (Param_0 $$= True))|1 ms|
| |(binary: (Param_0 **= 1))|1 ms|
| |(binary: (Param_0 }}= 2))|1 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (1 {= 2))|1 ms|
| |(binary: (True ^ True))|1 ms|
| |(binary: (Param_0 = value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (True Or True))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (1 % 2))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (1 + 2))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (1 }= 2))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (1 }} 2))|1 ms|
| |(binary: (1 / 2))|1 ms|
| |(binary: (True == True))|1 ms|
| |(binary: (1 { 2))|1 ms|
| |(binary: (1 } 2))|1 ms|
| |(binary: (True AndAlso True))|1 ms|
| |(binary: (True != True))|1 ms|
| |(binary: (1 {{ 2))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (True OrElse True))|1 ms|
| |(binary: (Param_0 /= 1))|1 ms|
| |(binary: (Param_0 %= 1))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (Param_0 {{= 2))|1 ms|
| |(binary: (Param_0 += 2))|1 ms|
| |(binary: (Param_0 ^= True))|1 ms|
| |(binary: (Param_0 &&= True))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (Param_0 $$= True))|1 ms|
|**Binary Expression Should Serialize**| |**134 ms**|
| |(binary: (1 {{ 2))|8 ms|
| |(binary: (1 + 2))|6 ms|
| |(binary: (1 + 2))|5 ms|
| |(binary: (Param_0 &= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|4 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|3 ms|
| |(binary: (Param_0 ^= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (Param_0 %= 1))|2 ms|
| |(binary: (True And True))|2 ms|
| |(binary: (Param_0 $= value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|2 ms|
| |(binary: (Param_0 /= 1))|2 ms|
| |(binary: (Param_0 {{= 2))|2 ms|
| |(binary: (Param_0 **= 1))|2 ms|
| |(binary: (Param_0 }}= 2))|2 ms|
| |(binary: (1 % 2))|1 ms|
| |(binary: (True And True))|1 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) AndAlso value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (True AndAlso True))|1 ms|
| |(binary: (1 } 2))|1 ms|
| |(binary: (1 }} 2))|1 ms|
| |(binary: (True Or True))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (Param_0 += 2))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (1 ** 2))|1 ms|
| |(binary: (1 ** 2))|1 ms|
| |(binary: (1 / 2))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) OrElse value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (True != True))|1 ms|
| |(binary: (True == True))|1 ms|
| |(binary: (1 { 2))|1 ms|
| |(binary: (1 }= 2))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (1 + 2))|1 ms|
| |(binary: (Param_0 ^= True))|1 ms|
| |(binary: (1 {= 2))|1 ms|
| |(binary: (True OrElse True))|1 ms|
| |(binary: (value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests) ^ value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (1 * 2))|1 ms|
| |(binary: (True Or True))|1 ms|
| |(binary: (Param_0 %= 1))|1 ms|
| |(binary: (Param_0 += 2))|1 ms|
| |(binary: (True != True))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (Param_0 **= 1))|1 ms|
| |(binary: (1 / 2))|1 ms|
| |(binary: (Param_0 += 2))|1 ms|
| |(binary: (1 } 2))|1 ms|
| |(binary: (Param_0 &&= True))|1 ms|
| |(binary: (1 {= 2))|1 ms|
| |(binary: (Param_0 /= 1))|1 ms|
| |(binary: (1 }} 2))|1 ms|
| |(binary: (1 }= 2))|1 ms|
| |(binary: (True ^ True))|1 ms|
| |(binary: (1 % 2))|1 ms|
| |(binary: (True == True))|1 ms|
| |(binary: (1 {{ 2))|1 ms|
| |(binary: (Param_0 %= 1))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (Param_0 }}= 2))|1 ms|
| |(binary: (Param_0 {{= 2))|1 ms|
| |(binary: (Param_0 {{= 2))|1 ms|
| |(binary: (1 { 2))|1 ms|
| |(binary: (1 - 2))|1 ms|
| |(binary: (Param_0 $$= True))|1 ms|
| |(binary: (1 + 2))|1 ms|
| |(binary: (Param_0 **= 1))|1 ms|
| |(binary: (Param_0 = value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (Param_0 &&= True))|1 ms|
| |(binary: (Param_0 += 2))|1 ms|
| |(binary: (Param_0 *= 2))|1 ms|
| |(binary: (Param_0 ^= True))|1 ms|
| |(binary: (Param_0 ?? value(ExpressionPowerTools.Serialization.Tests.BinarySerializerTests)))|1 ms|
| |(binary: (Param_0 }}= 2))|1 ms|
| |(binary: (Param_0 $$= True))|1 ms|
| |(binary: (Param_0 /= 1))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
| |(binary: (Param_0 -= 2))|1 ms|
|Given Options Ignore Null When Binary Serialized Then Should Deserialize| |4 ms|
|Given Authorized Method When Deserialize Called Then Should Deserialize| |3 ms|
## MemberInitSerializerTest (68 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Member Init Expression Then Should Deserialize**| |**65 ms**|
| |(expression: new MemberInitSerializerTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}})|27 ms|
| |(expression: new MemberInitSerializerTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}})|7 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = {Name = "MemberInitSerializerTests"}})|5 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = null})|4 ms|
| |(expression: new TestData("Hello") {Name = "GoodBye"})|4 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = new TestData()})|4 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = new TestData()})|4 ms|
| |(expression: new TestData() {Name = "Hello"})|3 ms|
| |(expression: new TestData() {Name = "Hello"})|3 ms|
|**Lambda Expression Should Serialize**| |**3 ms**|
| |(lambda: (target, pattern) =} target.Contains(pattern))|1 ms|
| |(lambda: () =} 1)|1 ms|
## UnarySerializerTest (77 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Unary Expression Should Deserialize**| |**44 ms**|
| |(unary: throw(System.ArgumentNullException: Value cannot be null.))|3 ms|
| |(unary: () =} Invoke(() =} True))|2 ms|
| |(unary: throw(System.InvalidCastException: Specified cast is not valid.))|2 ms|
| |(unary: ArrayLength(value(System.Int32{})))|2 ms|
| |(unary: Not(True))|1 ms|
| |(unary: Unbox(5))|1 ms|
| |(unary: value++)|1 ms|
| |(unary: -5)|1 ms|
| |(unary: -5)|1 ms|
| |(unary: Decrement(5))|1 ms|
| |(unary: value--)|1 ms|
| |(unary: Not(True))|1 ms|
| |(unary: +5)|1 ms|
| |(unary: value--)|1 ms|
| |(unary: Convert(5, String))|1 ms|
| |(unary: ++value)|1 ms|
| |(unary: Increment(5))|1 ms|
| |(unary: ConvertChecked(5, String))|1 ms|
| |(unary: --value)|1 ms|
| |(unary: -5)|1 ms|
| |(unary: (5 As Object))|1 ms|
| |(unary: Convert(5, Int64))|1 ms|
| |(unary: Decrement(5))|1 ms|
| |(unary: Increment(5))|1 ms|
| |(unary: +5)|1 ms|
| |(unary: -5)|1 ms|
| |(unary: ConvertChecked(5, Int64))|1 ms|
| |(unary: --value)|985 ns|
| |(unary: ++value)|967 ns|
| |(unary: value++)|948 ns|
| |(unary: throw())|621 ns|
| |(unary: throw())|610 ns|
|**Unary Expression Should Serialize**| |**29 ms**|
| |(unary: Decrement(5))|3 ms|
| |(unary: () =} Invoke(() =} True))|1 ms|
| |(unary: Not(True))|1 ms|
| |(unary: Increment(5))|1 ms|
| |(unary: Convert(5, String))|1 ms|
| |(unary: ArrayLength(value(System.Int32{})))|1 ms|
| |(unary: -5)|1 ms|
| |(unary: ++value)|963 ns|
| |(unary: ConvertChecked(5, String))|945 ns|
| |(unary: Decrement(5))|918 ns|
| |(unary: -5)|910 ns|
| |(unary: +5)|896 ns|
| |(unary: Convert(5, Int64))|857 ns|
| |(unary: value--)|828 ns|
| |(unary: Not(True))|821 ns|
| |(unary: value++)|814 ns|
| |(unary: Unbox(5))|803 ns|
| |(unary: ConvertChecked(5, Int64))|802 ns|
| |(unary: throw(System.ArgumentNullException: Value cannot be null.))|800 ns|
| |(unary: --value)|798 ns|
| |(unary: Increment(5))|796 ns|
| |(unary: -5)|791 ns|
| |(unary: -5)|785 ns|
| |(unary: +5)|767 ns|
| |(unary: (5 As Object))|738 ns|
| |(unary: ++value)|731 ns|
| |(unary: value--)|710 ns|
| |(unary: throw(System.InvalidCastException: Specified cast is not valid.))|699 ns|
| |(unary: --value)|692 ns|
| |(unary: value++)|671 ns|
| |(unary: throw())|410 ns|
| |(unary: throw())|403 ns|
|Given Options Ignore Null When Unary Serialized Then Should Deserialize| |2 ms|
|When Deserialize Query For Type Called With Null Host Then Should Throw Argument Null| |917 ns|
## SerializationRuleTest (41 ms)

|Test Name|Duration|
|:--|--:|
|Given Serialization Payload When Serialized Then Should Deserialize|39 ms|
|Given New Serialization Rule Then Should Initialize Properties|2 ms|
|Given Get Hash Code When Called Then Should Return Hash Of Target Key|487 ns|
## ConstantSerializerTest (47 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Constant Expression Should Deserialize**| |**29 ms**|
| |(constant: { foo = bar, bar = { bar = foo } })|12 ms|
| |(constant: 5)|5 ms|
| |(constant: value(System.Int32{}))|2 ms|
| |(constant: { foo = bar, bar =  })|1 ms|
| |(constant: { foo = bar, id = 42 })|1 ms|
| |(constant: value(System.Int32{}))|1 ms|
| |(constant: System.IComparable^1{T})|1 ms|
| |(constant: 5)|915 ns|
| |(constant: 5)|759 ns|
| |(constant: null)|675 ns|
|**Constant Expression Should Serialize**| |**12 ms**|
| |(constant: { foo = bar, bar = { bar = foo } })|4 ms|
| |(constant: { foo = bar, id = 42 })|1 ms|
| |(constant: 5)|1 ms|
| |(constant: 5)|1 ms|
| |(constant: { foo = bar, bar =  })|1 ms|
| |(constant: System.IComparable^1{T})|894 ns|
| |(constant: 5)|579 ns|
| |(constant: value(System.Int32{}))|578 ns|
| |(constant: value(System.Int32{}))|563 ns|
| |(constant: null)|474 ns|
|Given Enumerable Query When Query Root Is Constant Expression Then Should Be Set| |2 ms|
|Given Enumerable Query When Query Root Is Non Constant Expression Then Should Be Set| |1 ms|
|Given Enumerable Query When Query Root Is Null Then Should Return Null Constant| |1 ms|
|Given Configure Called When Configuring Then Should Throw Invalid Operation| |220 ns|
## CtorSerializerTest (26 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**New Expression Should Deserialize**| |**20 ms**|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: {Int32 Prop, System.String field})|3 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests, System.String), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), "CtorSerializerTests"}, members: null)|2 ms|
| |(info: Void .ctor(Int32), args: {1}, members: {Int32 Prop})|2 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: null)|2 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: {ExpressionPowerTools.Serialization.Tests.CtorSerializerTests Thing})|2 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: null)|2 ms|
| |(info: Void .ctor(Int32), args: {2}, members: null)|2 ms|
| |(info: Void .ctor(Int32), args: {1}, members: null)|1 ms|
| |(info: Void .ctor(), args: null, members: null)|1 ms|
|Given Ctor Not Allowed When Deserialize Called Then Should Throw Unauthorized Access| |2 ms|
|Given Ctor Allowed When Deserialize Called Then Should Deserialize| |1 ms|
|Given Option Ignore Null Values When Constant Expression Serialized Then Should Deserialize| |1 ms|
## MethodSerializerTest (26 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Method Call Expression Should Deserialize**| |**16 ms**|
| |(method: StaticReturnInt())|4 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).DoNothing())|4 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnIntDoubled(2))|2 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnInt())|1 ms|
| |(method: StaticReturnIntDoubled(2))|1 ms|
| |(method: StaticDoNothing())|1 ms|
|Given Options Ignore Null When Method Call Serialized Then Should Deserialize| |2 ms|
|Given Method Not Allowed When Deserialize Called Then Should Throw Unauthorized Access| |2 ms|
|Given Method Allowed When Deserialize Called Then Should Deserialize| |1 ms|
|**Member Expression Should Serialize**| |**3 ms**|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).InstanceProperty)|1 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).ReadOnlyProperty)|903 ns|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).instanceField)|894 ns|
| |(member: MemberSerializerTests.StaticProperty)|540 ns|
| |(member: MemberSerializerTests.staticField)|519 ns|
## MemberSerializerTest (19 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Member Expression Should Deserialize**| |**7 ms**|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).InstanceProperty)|2 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).instanceField)|1 ms|
| |(member: value(ExpressionPowerTools.Serialization.Tests.MemberSerializerTests).ReadOnlyProperty)|1 ms|
| |(member: MemberSerializerTests.StaticProperty)|948 ns|
| |(member: MemberSerializerTests.staticField)|794 ns|
|**Given Member Init Expression Then Should Serialize**| |**12 ms**|
| |(expression: new MemberInitSerializerTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}})|1 ms|
| |(expression: new MemberInitSerializerTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}})|1 ms|
| |(expression: new TestData("Hello") {Name = "GoodBye"})|1 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = {Name = "MemberInitSerializerTests"}})|1 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = new TestData()})|1 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = new TestData()})|1 ms|
| |(expression: new TestData() {Name = "Hello"})|1 ms|
| |(expression: new TestData() {Name = "Hello"})|1 ms|
| |(expression: new MemberInitSerializerTests() {TestProp = null})|1 ms|
## DefaultConfigurationTest (11 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**New Expression Should Serialize**| |**10 ms**|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: {Int32 Prop, System.String field})|1 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests, System.String), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), "CtorSerializerTests"}, members: null)|1 ms|
| |(info: Void .ctor(Int32, System.String), args: {1, "intPropField"}, members: null)|1 ms|
| |(info: Void .ctor(Int32), args: {1}, members: {Int32 Prop})|1 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: {ExpressionPowerTools.Serialization.Tests.CtorSerializerTests Thing})|1 ms|
| |(info: Void .ctor(Int32), args: {1}, members: null)|1 ms|
| |(info: Void .ctor(Int32), args: {2}, members: null)|1 ms|
| |(info: Void .ctor(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests), args: {value(ExpressionPowerTools.Serialization.Tests.CtorSerializerTests)}, members: null)|993 ns|
| |(info: Void .ctor(), args: null, members: null)|602 ns|
|Given Default Configuration When Configure Requested Then Should Return Configuration Builder| |398 ns|
|Given Default Configuration When State Requested Then Should Return New Instance| |115 ns|
## RulesEngineTest (31 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Generic Rules When Reset Called Then Should Reset All| |10 ms|
|Given Rule For Ctor Allowed When Member Is Allowed Called Then Should Return True| |2 ms|
|Given Generic Rules When Rule Set For Closed Type Ctor Then Should Override| |1 ms|
|Given Generic Rules When Closed Access Requested For Ctor Then Should Default To Generic Return Result| |1 ms|
|Given Type Allowed And Member Denied When Member Is Allowed Then Should Return False| |1 ms|
|Given Generic Rules When Rule Set For Closed Type Then Should Override| |1 ms|
|Given Generic Type Allowed When Member Is Allowed For Closed Type Then Should Return True| |925 ns|
|Given Type Denied And Ctor Allowed When Member Is Allowed Called Then Should Return True| |913 ns|
|Given Type Allowed And Ctor Denied When Member Is Allowed Then Should Return False| |880 ns|
|Given Generic Rules When Closed Access Requested Then Should Default To Generic Return Result| |863 ns|
|**Given No Config When Member Is Allowed Then Should Return Default**| |**5 ms**|
| |(memberInfo: Void .ctor(ExpressionPowerTools.Serialization.Tests.RulesEngineTests), allowed: False)|845 ns|
| |(memberInfo: Int32 field, allowed: True)|658 ns|
| |(memberInfo: ExpressionPowerTools.Serialization.Tests.RulesEngineTests Thing, allowed: True)|656 ns|
| |(memberInfo: typeof(ExpressionPowerTools.Serialization.Tests.RulesEngineTests+RuleClass{ExpressionPowerTools.Serialization.Tests.RulesEngineTests}), allowed: False)|543 ns|
| |(memberInfo: Void SetOtherProp(System.String), allowed: False)|543 ns|
| |(memberInfo: Void .ctor(T), allowed: False)|443 ns|
| |(memberInfo: typeof(ExpressionPowerTools.Serialization.Tests.RulesEngineTests+RuleClass{}), allowed: False)|423 ns|
| |(memberInfo: T Thing, allowed: True)|410 ns|
| |(memberInfo: Void SetOtherProp(System.String), allowed: False)|275 ns|
| |(memberInfo: Int32 field, allowed: True)|273 ns|
|Given Field Denied When Member Requested Then Should Return False| |706 ns|
|Given Config Calling Compile Multiple Times Yields Same Results| |684 ns|
|Given Method Allowed When Member Requested Then Should Return True| |672 ns|
|Given Closed Type Allowed When Member Is Allowed Then Should Return Return| |650 ns|
|Given Type Denied And Member Allowed When Member Is Allowed Called Then Should Return True| |596 ns|
|Given Property Denied When Member Is Allowed Then Should Return False| |538 ns|
|Given Type Allowed When Method Requested Then Should Return True| |511 ns|
|**Given No Rule When Allow Or Deny Called Then Should Throw Invalid Operation**| |**411 ns**|
| |(allow: True)|379 ns|
| |(allow: False)|32 ns|
|Given Anonymous Denied When Anonymous Ctor Is Requested Then Should Return False| |266 ns|
|Given Type Not Found When Find Generic Version Called Then Should Return Null| |129 ns|
|Given Non Config When Anonymous Ctor Is Requested Then Should Return True| |101 ns|
## NewArraySerializerTest (13 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|New Array Expression Should Deserialize| |7 ms|
|**Method Call Expression Should Serialize**| |**5 ms**|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnIntDoubled(2))|1 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).DoNothing())|1 ms|
| |(method: value(ExpressionPowerTools.Serialization.Tests.MethodSerializerTests).ReturnInt())|907 ns|
| |(method: StaticReturnIntDoubled(2))|878 ns|
| |(method: StaticDoNothing())|523 ns|
| |(method: StaticReturnInt())|513 ns|
## SerializableExpressionTest (22 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Lambda Expression When Lambda Created Then Should Set Lambda Properties| |7 ms|
|Given Mixed Fields And Properties When Ctor Expr Created Then Should Map Appropriately| |2 ms|
|Given Property Selector When By Resolve Then Should Set Property Info| |2 ms|
|Given Binary Expression With Method When Binary Instantiated Then Should Set Method| |973 ns|
|**Given Unary Expression When Unary Created Then Should Set Unary Type And Method**| |**1 ms**|
| |(unary: Convert(5, String))|792 ns|
| |(unary: ArrayLength(value(System.Int32{})))|742 ns|
|**Given Constructor When Ctor Expr Created Then Should Set Properties**| |**1 ms**|
| |(info: Void .ctor(Int32), arg: 1, member: Int32 Prop)|717 ns|
| |(info: Void .ctor(), arg: null, member: null)|639 ns|
| |(info: Void .ctor(Int32), arg: 1, member: null)|423 ns|
|**Get Member From Key Resolves**| |**907 ns**|
| |(typed: False)|675 ns|
| |(typed: True)|232 ns|
|Given Method Call Expression When Method Expr Created Then Should Set Properties| |616 ns|
|Given New Array Expression When New Array Created Then Should Set Array Type| |574 ns|
|Given Parameter Expression When Parameter Created Then Should Set Name And Parameter Type| |571 ns|
|Given Constant Expression When Constant Created Then Should Set Constant Type And Value And Value Type| |550 ns|
|Given Null Expression When Constructor Called Then Should Throw Argument Null| |445 ns|
|Given New Array Expression When New Array Created Then Should Initialize Expressions List| |405 ns|
|Given Non Null Expression When Constructor Called Then Should Set Type| |230 ns|
|**Default Ctor Works For Serialization**| |**614 ns**|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.MethodExpr))|129 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.CtorExpr))|67 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.NewArray))|60 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.MemberInit))|60 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Lambda))|57 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Unary))|48 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.MemberExpr))|45 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Binary))|44 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Parameter))|43 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Constant))|42 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.SerializableExpression))|8 ns|
| |(serializableType: typeof(ExpressionPowerTools.Serialization.Serializers.Invocation))|7 ns|
## LambdaSerializerTest (24 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Null Options When Lambda Serialized Then Should Deserialize| |6 ms|
|Given Object When Lambda Expression That References Property Is Deserialized Then Should Resolve Property| |6 ms|
|**Lambda Expression Should Deserialize**| |**6 ms**|
| |(lambda: (target, pattern) =} target.Contains(pattern))|4 ms|
| |(lambda: () =} 1)|1 ms|
|**Invocation Expression Should Serialize**| |**5 ms**|
| |(invocation: Invoke(i =} True, i))|2 ms|
| |(invocation: Invoke(() =} True))|2 ms|
| |(invocation: Invoke(() =} "FuncString"))|1 ms|
## InvocationSerializerTest (12 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Options Ignore Null When Invocation Expression Serialized Then Should Deserialize| |4 ms|
|Given Expression Has Serializer When Serialize Called Then Should Serialize| |2 ms|
|**Invocation Expression Should Deserialize**| |**5 ms**|
| |(invocation: Invoke(i =} True, i))|2 ms|
| |(invocation: Invoke(() =} True))|2 ms|
| |(invocation: Invoke(() =} "FuncString"))|1 ms|
## ParameterSerializerTest (8 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|New Array Expression Should Serialize| |5 ms|
|Given Options Ignore Null When Parameter Serialized Then Should Deserialize| |1 ms|
|**Parameter Expression Should Deserialize**| |**1 ms**|
| |(parameter: Param_0)|824 ns|
| |(parameter: GetParameterExpressions)|577 ns|
## CompressionTest (17 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Unauthorized Method When Deserialize Called Then Should Throw Unauthorized Access| |3 ms|
|Given Filter With Variable When Visited Then Extracts Values| |2 ms|
|**Given Conditional If Test Can Be Evaluated Then Should Transform To Test Result**| |**4 ms**|
| |(scenario: 1)|2 ms|
| |(scenario: 2)|1 ms|
| |(scenario: 0)|621 ns|
|Given Expression Against String And Date When Visited Will Compress| |2 ms|
|Given Expression That Can Resolve When Visited Then Extracts Values| |1 ms|
|Given Nested Methods Then Will Compress| |863 ns|
|**Given Or Or Or Else When Node Is Evaluated Then Will Compress Node**| |**1 ms**|
| |(node: ((t.Id.Contains("aa") OrElse (t.Created { DateTime.Now)) OrElse (t.Value { 5)), expectedBinaryCount: 4)|604 ns|
| |(node: (False OrElse (t.Value { 2)), expectedBinaryCount: 1)|177 ns|
| |(node: ((t.Value { 2) OrElse False), expectedBinaryCount: 1)|170 ns|
| |(node: (True OrElse (t.Value { 2)), expectedBinaryCount: 0)|162 ns|
| |(node: ((t.Value { 2) OrElse True), expectedBinaryCount: 0)|159 ns|
| |(node: (False Or True), expectedBinaryCount: 0)|158 ns|
|**Given And Or And Also When Node Is Evaluated Then Will Compress Node**| |**1 ms**|
| |(node: ((t.Id.Contains("aa") AndAlso (t.Created { DateTime.Now)) AndAlso (t.Value { 5)), expectedBinaryCount: 4)|356 ns|
| |(node: (False AndAlso (t.Value { 2)), expectedBinaryCount: 0)|173 ns|
| |(node: (True And False), expectedBinaryCount: 0)|155 ns|
| |(node: (True AndAlso (t.Value { 2)), expectedBinaryCount: 1)|154 ns|
| |(node: ((t.Value { 2) AndAlso True), expectedBinaryCount: 1)|154 ns|
| |(node: ((t.Value { 2) AndAlso False), expectedBinaryCount: 0)|152 ns|
## ExpressionSerializerTest (15 ms)

|Test Name|Duration|
|:--|--:|
|Given Expression Has No Type When Deserialize Called Then Should Return Null|4 ms|
|Given Expression Has Serializer When Deserialize Called Then Should Deserialize|4 ms|
|Given Expression Has No Serializer When Serialize Called Then Should Return Serializable Expression|2 ms|
|Given Expression Has Null Type When Deserialize Called Then Should Return Null|2 ms|
|Given Expression Has No Serializer When Deserialize Called Then Should Return Null|2 ms|
|Given No Configuration When Default Configuration Requested Then Should Use System Defaults|435 ns|
## ConfigurationBuilderTest (5 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Skip Or Take With Variable When Visited Then Extracts Constants| |2 ms|
|**Given Configuration Builder Then Options Can Be Chained Configurable**| |**2 ms**|
| |(setting: True)|2 ms|
| |(setting: False)|36 ns|
|Given Configuration Builder When Json Options Set Then Should Configure Options| |151 ns|
|**Given Configuration Builder When Compress Types Called Then Should Set Flag**| |**86 ns**|
| |(setting: True)|80 ns|
| |(setting: False)|5 ns|
|Given Configuration Builder When Configure Called Then Should Set Default Options| |72 ns|
## SerializationPayloadTest (2 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Payload When Initialized Then Get Query Type Gets Payload Value**| |**1 ms**|
| |(type: Array)|1 ms|
| |(type: Count)|62 ns|
| |(type: Single)|3 ns|
|When Ctor Expr Created Then Should Initialize Lists| |398 ns|
|**Given Payload When Initialized Then Sets Payload Value**| |**97 ns**|
| |(type: Count)|89 ns|
| |(type: Array)|4 ns|
| |(type: Single)|2 ns|
## ReflectionHelperTest (2 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Parameter Expression Should Serialize**| |**1 ms**|
| |(parameter: Param_0)|783 ns|
| |(parameter: GetParameterExpressions)|724 ns|
|**Given Non Generic Member When Get Generic Version Called Then Finds Generic Version**| |**753 ns**|
| |(closed: Void .ctor(Int32), generic: Void .ctor(T))|337 ns|
| |(closed: Void .ctor(), generic: Void .ctor())|237 ns|
| |(closed: typeof(ExpressionPowerTools.Serialization.Tests.ReflectionHelperTests+Tester{int, ExpressionPowerTools.Serialization.Tests.ReflectionHelperTests+Test{int}}), generic: typeof(ExpressionPowerTools.Serialization.Tests.ReflectionHelperTests+Tester{,}))|95 ns|
| |(closed: Test^1 Prop, generic: TTest Prop)|17 ns|
| |(closed: Void .ctor(Test^1), generic: Void .ctor(TTest))|17 ns|
| |(closed: System.String Id, generic: System.String Id)|16 ns|
| |(closed: Int32 ProcessType(Test^1), generic: T ProcessType(TTest))|12 ns|
| |(closed: Void ProcessType(System.String), generic: Void ProcessType(System.String))|7 ns|
| |(closed: Int32 field, generic: Int32 field)|7 ns|
| |(closed: System.String Field, generic: System.String Field)|4 ns|
|Given Generic Member Not Found When Get Generic Version Called Then Should Return Null| |217 ns|
## SelectorTest (4 ms)

|Test Name|Duration|
|:--|--:|
|Given Method Selector When By Resolve Then Should Set Constructor Info|1 ms|
|Given Method Selector When By Resolve Then Should Set Method Info|629 ns|
|Given Type Denied When Property Or Field Requested Then Should Return False|563 ns|
|Given Field Selector When By Resolve Then Should Set Field Info|393 ns|
|Given Method Selector When By Name For Type Then Should Throw Invalid Operation|250 ns|
|Given Method Selector When By Name For Type Typed Then Should Throw Invalid Operation|211 ns|
|Given Method Selector When By Name For Type Typed Then Should Set Method Info|184 ns|
|Given Property Selector When By Name For Type Typed Then Should Set Property Info|171 ns|
|Given Field Selector When By Name For Type Typed Then Should Set Field Info|163 ns|
|Given Field Selector When By Field Info Then Should Set Field Info|158 ns|
|Given Property Selector When By Property Info Then Should Set Property Info|150 ns|
|Given Method Selector When By Method Info Then Should Set Method Info|144 ns|
|Given Method Selector When By Constructor Info Then Should Set Constructor Info|138 ns|
|Given Property Selector When By Name For Type Then Should Set Property Info|136 ns|
|Given Method Selector When By Name For Type Then Should Set Method Info|135 ns|
|Given Field Selector When By Name For Type Then Should Set Field Info|130 ns|
## SerializationStateTest (611 ns)

|Test Name|Duration|
|:--|--:|
|Given Serialization Rule When To String Called Then Should Include Permission And Member Key|466 ns|
|Given Parameters Of Same Name When Get Or Cache Called Then Should Return Same Instance|145 ns|

[Go Back](./index.md)

# Summary of Test Runs for ExpressionPowerTools.Core

Jump to group:

- [CustomQueryProviderTest](#customqueryprovidertest-8-ms)
- [DefaultComparisonRulesTest](#defaultcomparisonrulestest-326-ms)
- [DefaultHighPerformanceRulesTest](#defaulthighperformancerulestest-332-ms)
- [EnsureTest](#ensuretest-34-ms)
- [ExceptionHelperTest](#exceptionhelpertest-3-ms)
- [ExpressionEnumeratorTest](#expressionenumeratortest-12-ms)
- [ExpressionEquivalencyTest](#expressionequivalencytest-92-ms)
- [ExpressionEquivalencyTestsWithoutRule](#expressionequivalencytestswithoutrule-67-ms)
- [ExpressionEvaluatorTest](#expressionevaluatortest-58-ms)
- [ExpressionExtensionsTest](#expressionextensionstest-22-ms)
- [ExpressionRulesExtensionsTest](#expressionrulesextensionstest-24-ms)
- [ExpressionSimilarityTest](#expressionsimilaritytest-106-ms)
- [ExpressionSimilarityTestsWithoutRule](#expressionsimilaritytestswithoutrule-93-ms)
- [IExpressionEnumeratorExtensionsTest](#iexpressionenumeratorextensionstest-13-ms)
- [IQueryableExtensionsTest](#iqueryableextensionstest-167-ms)
- [MemberAdapterTest](#memberadaptertest-456-ms)
- [QueryHostTest](#queryhosttest-16-ms)
- [QueryInterceptingProviderTest](#queryinterceptingprovidertest-15-ms)
- [QuerySnapshotHostTest](#querysnapshothosttest-29-ms)
- [QuerySnapshotProviderTest](#querysnapshotprovidertest-10-ms)
- [ServiceHostTest](#servicehosttest-197-ms)
- [ServicesTest](#servicestest-26-ms)

The slowest test was 'Given Non Supported Expression Then Typed Similarity Should Return False' at 36 ms.

## MemberAdapterTest (456 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Key When Get Member For Key Called Then Should Return Key**| |**185 ms**|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: Int32 Result{MemberAdapterTests,Int32}(ExpressionPowerTools.Core.Tests.MemberAdapterTests, System.String))|22 ms|
| |(key: "E:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: System.EventHandler eventRaised)|13 ms|
| |(key: "M:System.Linq.Queryable.SelectMany^^3(System.Linq."..., expected: System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.MemberAdapterTests+RelatedThing} SelectMany{{}f__AnonymousType8^3,SimpleThing,RelatedThing}(System.Linq.IQueryable^1{{}f__AnonymousType8^3{System.String,System.String,System.String}}, System.Linq.Expressions.Expression^1{System.Func^2{{}f__AnonymousType8^3{System.String,System.String,System.String},System.Collections.Generic.IEnumerable^1{ExpressionPowerTools.Core.Tests.MemberAdapterTests+SimpleThing}}}, System.Linq.Expressions.Expression^1{System.Func^3{{}f__AnonymousType8^3{System.String,System.String,System.String},ExpressionPowerTools.Core.Tests.MemberAdapterTests+SimpleThing,ExpressionPowerTools.Core.Tests.MemberAdapterTests+RelatedThing}}))|11 ms|
| |(key: "M:ExpressionPowerTools.Core.Members.MemberAdapter."..., expected: Boolean TryGetMemberInfo(System.String, System.Reflection.MemberInfo ByRef))|10 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: Int32 Compare{Z}(ThingImplementation, Z))|10 ms|
| |(key: "T:{}f__AnonymousType9{Id=System.Int32,SubAnon={}f_"..., expected: typeof({}f__AnonymousType9{int, {}f__AnonymousType10{int, string}}))|10 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: TProperty Property{TProperty}(System.Object, System.String))|10 ms|
| |(key: "M:System.Linq.Queryable.Select^^2(System.Linq.IQue"..., expected: System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.IdType} Select{IdType,IdType}(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.IdType}, System.Linq.Expressions.Expression^1{System.Func^2{ExpressionPowerTools.Core.Tests.TestHelpers.IdType,ExpressionPowerTools.Core.Tests.TestHelpers.IdType}}))|7 ms|
| |(key: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{,,}))|6 ms|
| |(key: "P:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: Int32 Item {System.String})|6 ms|
| |(key: "T:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., expected: typeof(ExpressionPowerTools.Core.Dependencies.ServiceHost))|6 ms|
| |(key: "M:ExpressionPowerTools.Core.Extensions.ExpressionE"..., expected: System.Linq.Expressions.ParameterExpression CreateParameterExpression{Object,String}(System.Linq.Expressions.Expression^1{System.Func^2{System.Object,System.String}}))|5 ms|
| |(key: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: Boolean CheckEquivalency{ConstantExpression}(System.Linq.Expressions.ConstantExpression, System.Linq.Expressions.Expression))|4 ms|
| |(key: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation, System.IComparable{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation}, char}))|3 ms|
| |(key: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: Void .ctor())|3 ms|
| |(key: "M:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., expected: Void .cctor())|3 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: TResult Result{T,TResult}(T, System.String))|3 ms|
| |(key: "M:System.Collections.Generic.List{ExpressionPowerT"..., expected: Void Add(ExpressionPowerTools.Core.Tests.MemberAdapterTests))|3 ms|
| |(key: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: Boolean CheckEquivalency(System.Linq.Expressions.Expression, System.Linq.Expressions.Expression))|3 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: Int32 Compare{Z}(T, Z))|3 ms|
| |(key: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation))|3 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: System.String Property{String}(System.Object, System.String))|3 ms|
| |(key: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: Boolean CheckEquivalency{T}(T, System.Linq.Expressions.Expression))|3 ms|
| |(key: "T:System.Linq.IQueryable^1", expected: typeof(System.Linq.IQueryable{}))|3 ms|
| |(key: "P:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: U Value)|2 ms|
| |(key: "M:ExpressionPowerTools.Core.Extensions.ExpressionE"..., expected: System.Linq.Expressions.ParameterExpression CreateParameterExpression{T,TValue}(System.Linq.Expressions.Expression^1{System.Func^2{T,TValue}}))|2 ms|
| |(key: "M:ExpressionPowerTools.Core.Hosts.QueryHost^2.#cto"..., expected: Void .ctor(System.Linq.Expressions.Expression, TProvider))|2 ms|
| |(key: "P:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: System.Linq.Expressions.Expression^1{System.Func^3{System.Linq.Expressions.ConstantExpression,System.Linq.Expressions.ConstantExpression,System.Boolean}} DefaultConstantRules)|2 ms|
| |(key: "T:System.Int32{}", expected: typeof(int{}))|2 ms|
| |(key: "M:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., expected: T GetService{T}(System.Object{}))|2 ms|
| |(key: "T:System.String", expected: typeof(string))|2 ms|
| |(key: "F:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: System.Collections.Generic.IDictionary^2{System.Type,ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules+ExpressionComparer} cache)|2 ms|
| |(key: "T:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: typeof(ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules))|2 ms|
|Given Bad Key When Get Member Not Found Then Should Throw Argument Exception| |13 ms|
|Given Null Properties When Make Anonymous Type Called Then Should Through Argument Null| |9 ms|
|Get Member For Key Typed Returns Correct Result| |7 ms|
|**Given Member When Get Key For Member Called Then Should Return Key**| |**88 ms**|
| |(expected: "T:{}f__AnonymousType9{Id=System.Int32,SubAnon={}f_"..., member: typeof({}f__AnonymousType9{int, {}f__AnonymousType10{int, string}}))|7 ms|
| |(expected: "T:System.String", member: typeof(string))|6 ms|
| |(expected: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation, System.IComparable{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation}, char}))|5 ms|
| |(expected: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation))|3 ms|
| |(expected: "T:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: typeof(ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: Int32 Result{MemberAdapterTests,Int32}(ExpressionPowerTools.Core.Tests.MemberAdapterTests, System.String))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Extensions.ExpressionE"..., member: System.Linq.Expressions.ParameterExpression CreateParameterExpression{T,TValue}(System.Linq.Expressions.Expression^1{System.Func^2{T,TValue}}))|2 ms|
| |(expected: "M:System.Linq.Queryable.SelectMany^^3(System.Linq."..., member: System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.MemberAdapterTests+RelatedThing} SelectMany{{}f__AnonymousType8^3,SimpleThing,RelatedThing}(System.Linq.IQueryable^1{{}f__AnonymousType8^3{System.String,System.String,System.String}}, System.Linq.Expressions.Expression^1{System.Func^2{{}f__AnonymousType8^3{System.String,System.String,System.String},System.Collections.Generic.IEnumerable^1{ExpressionPowerTools.Core.Tests.MemberAdapterTests+SimpleThing}}}, System.Linq.Expressions.Expression^1{System.Func^3{{}f__AnonymousType8^3{System.String,System.String,System.String},ExpressionPowerTools.Core.Tests.MemberAdapterTests+SimpleThing,ExpressionPowerTools.Core.Tests.MemberAdapterTests+RelatedThing}}))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: System.String Property{String}(System.Object, System.String))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., member: Void .cctor())|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: TProperty Property{TProperty}(System.Object, System.String))|2 ms|
| |(expected: "M:System.Collections.Generic.List{ExpressionPowerT"..., member: Void Add(ExpressionPowerTools.Core.Tests.MemberAdapterTests))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Extensions.ExpressionE"..., member: System.Linq.Expressions.ParameterExpression CreateParameterExpression{Object,String}(System.Linq.Expressions.Expression^1{System.Func^2{System.Object,System.String}}))|2 ms|
| |(expected: "F:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: System.Collections.Generic.IDictionary^2{System.Type,ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules+ExpressionComparer} cache)|2 ms|
| |(expected: "T:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., member: typeof(ExpressionPowerTools.Core.Dependencies.ServiceHost))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: Void .ctor())|2 ms|
| |(expected: "P:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: U Value)|2 ms|
| |(expected: "P:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: Int32 Item {System.String})|2 ms|
| |(expected: "E:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: System.EventHandler eventRaised)|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Hosts.QueryHost^2.#cto"..., member: Void .ctor(System.Linq.Expressions.Expression, TProvider))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: Boolean CheckEquivalency(System.Linq.Expressions.Expression, System.Linq.Expressions.Expression))|2 ms|
| |(expected: "P:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: System.Linq.Expressions.Expression^1{System.Func^3{System.Linq.Expressions.ConstantExpression,System.Linq.Expressions.ConstantExpression,System.Boolean}} DefaultConstantRules)|2 ms|
| |(expected: "M:System.Linq.Queryable.Select^^2(System.Linq.IQue"..., member: System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.IdType} Select{IdType,IdType}(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.IdType}, System.Linq.Expressions.Expression^1{System.Func^2{ExpressionPowerTools.Core.Tests.TestHelpers.IdType,ExpressionPowerTools.Core.Tests.TestHelpers.IdType}}))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: Boolean CheckEquivalency{T}(T, System.Linq.Expressions.Expression))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., member: T GetService{T}(System.Object{}))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: Boolean CheckEquivalency{ConstantExpression}(System.Linq.Expressions.ConstantExpression, System.Linq.Expressions.Expression))|2 ms|
| |(expected: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{,,}))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: Int32 Compare{Z}(ThingImplementation, Z))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: TResult Result{T,TResult}(T, System.String))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Members.MemberAdapter."..., member: Boolean TryGetMemberInfo(System.String, System.Reflection.MemberInfo ByRef))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: Int32 Compare{Z}(T, Z))|2 ms|
| |(expected: "T:System.Linq.IQueryable^1", member: typeof(System.Linq.IQueryable{}))|2 ms|
| |(expected: "T:System.Int32{}", member: typeof(int{}))|1 ms|
|**Can Recreate All Members**| |**118 ms**|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IExpressionEvaluator), key: "T:ExpressionPowerTools.Core.Signatures.IExpression"...)|6 ms|
| |(expected: System.Object DynamicInvoke(System.Object{}), key: "M:System.Delegate.DynamicInvoke(System.Object{})")|6 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions), key: "T:ExpressionPowerTools.Core.Extensions.ExpressionR"...)|5 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions), key: "T:ExpressionPowerTools.Core.Extensions.IExpression"...)|4 ms|
| |(expected: System.Object Clone(), key: "M:System.Delegate.Clone")|3 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IMemberAdapter), key: "T:ExpressionPowerTools.Core.Signatures.IMemberAdap"...)|3 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules), key: "T:ExpressionPowerTools.Core.Comparisons.DefaultCom"...)|3 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Contract.Ensure), key: "T:ExpressionPowerTools.Core.Contract.Ensure")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Providers.CustomQueryProvider{}), key: "T:ExpressionPowerTools.Core.Providers.CustomQueryP"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IServiceRegistration), key: "T:ExpressionPowerTools.Core.Signatures.IServiceReg"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules), key: "T:ExpressionPowerTools.Core.Comparisons.DefaultHig"...)|2 ms|
| |(expected: Boolean Equals(System.Object), key: "M:System.Object.Equals(System.Object)")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator), key: "T:ExpressionPowerTools.Core.Signatures.IExpression"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Providers.QuerySnapshotProvider{}), key: "T:ExpressionPowerTools.Core.Providers.QuerySnapsho"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IDependentServiceRegistration), key: "T:ExpressionPowerTools.Core.Signatures.IDependentS"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.ExpressionEnumerator), key: "T:ExpressionPowerTools.Core.ExpressionEnumerator")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency), key: "T:ExpressionPowerTools.Core.Comparisons.Expression"...)|2 ms|
| |(expected: System.Type GetType(), key: "M:System.Object.GetType")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQueryInterceptor), key: "T:ExpressionPowerTools.Core.Signatures.IQueryInter"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Providers.QueryInterceptingProvider{}), key: "T:ExpressionPowerTools.Core.Providers.QueryInterce"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IServices), key: "T:ExpressionPowerTools.Core.Signatures.IServices")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator), key: "T:ExpressionPowerTools.Core.Comparisons.Expression"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQueryHost{,}), key: "T:ExpressionPowerTools.Core.Signatures.IQueryHost^"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider), key: "T:ExpressionPowerTools.Core.Signatures.IExpression"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.ExpressionTransformer), key: "T:ExpressionPowerTools.Core.ExpressionTransformer")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Resources.ExceptionHelper), key: "T:ExpressionPowerTools.Core.Resources.ExceptionHel"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Extensions.IQueryableExtensions), key: "T:ExpressionPowerTools.Core.Extensions.IQueryableE"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs), key: "T:ExpressionPowerTools.Core.Providers.QuerySnapsho"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Members.MemberAdapter), key: "T:ExpressionPowerTools.Core.Members.MemberAdapter")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost{}), key: "T:ExpressionPowerTools.Core.Signatures.IQuerySnaps"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Hosts.QuerySnapshotHost{}), key: "T:ExpressionPowerTools.Core.Hosts.QuerySnapshotHos"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Extensions.ExpressionExtensions), key: "T:ExpressionPowerTools.Core.Extensions.ExpressionE"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.ICustomQueryProvider{}), key: "T:ExpressionPowerTools.Core.Signatures.ICustomQuer"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity), key: "T:ExpressionPowerTools.Core.Comparisons.Expression"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Dependencies.ServiceHost), key: "T:ExpressionPowerTools.Core.Dependencies.ServiceHo"...)|2 ms|
| |(expected: System.Object Target, key: "P:System.Delegate.Target")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQueryInterceptingProvider{}), key: "T:ExpressionPowerTools.Core.Signatures.IQueryInter"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider{}), key: "T:ExpressionPowerTools.Core.Signatures.IQuerySnaps"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Dependencies.Services), key: "T:ExpressionPowerTools.Core.Dependencies.Services")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQuerySnapshot), key: "T:ExpressionPowerTools.Core.Signatures.IQuerySnaps"...)|2 ms|
| |(expected: Int32 GetHashCode(), key: "M:System.Object.GetHashCode")|2 ms|
| |(expected: System.Reflection.MethodInfo Method, key: "P:System.Delegate.Method")|2 ms|
| |(expected: Void GetObjectData(System.Runtime.Serialization.SerializationInfo, System.Runtime.Serialization.StreamingContext), key: "M:System.MulticastDelegate.GetObjectData(System.Ru"...)|2 ms|
| |(expected: System.Delegate{} GetInvocationList(), key: "M:System.MulticastDelegate.GetInvocationList")|1 ms|
|**Given Null Or Empty String When Called Then Should Throw Argument Exception**| |**10 ms**|
| |(key: "")|6 ms|
| |(key: null)|2 ms|
| |(key: "\t\t\n")|2 ms|
|Given Empty Properties When Make Anonymous Type Called Then Should Throw Argument| |5 ms|
|Given Bad Properties When Make Anonymous Type Called Then Should Return Null| |4 ms|
|Given Bad Key Type When Get Member For Key Called Then Should Throw Argument| |3 ms|
|Given Invalid String When Called Then Should Throw Exception With String| |2 ms|
|Given Null Member When Get Key For Member Called Then Should Throw Argument Null Exception| |2 ms|
|Given Anonymous Type Signature When Make Anonymous Type Called Then Should Return Anonymous Type| |2 ms|
|When Null Then As Enumerable Expression Should Throw Argument Null| |347 ns|
## IQueryableExtensionsTest (167 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Fragment Is Not In Query When Has Fragment Called Then Should Return False**| |**68 ms**|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_1(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|22 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_0(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|21 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_4(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|10 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_2(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|7 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_3(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|7 ms|
|Given Not Similar Queries Is Similar To Should Return False| |16 ms|
|Given Not Similar Typed Queries Is Similar To Should Return False| |14 ms|
|**Given Fragment Is In Query When Has Fragment Called Then Should Return True**| |**15 ms**|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_1(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|6 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_0(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|4 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_4(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|2 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_2(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|1 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_3(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|1 ms|
|Given Similar Queries Is Similar To Should Return True| |6 ms|
|Given Queryable When Create Intercepted Query Called Then Should Apply Transformation| |5 ms|
|Given Queryable When Create Snapshot Host Called Then Should Return Snapshot Registered For Callback| |5 ms|
|Given Not Equivalent Typed Queries Is Equivalent To Should Return False| |5 ms|
|Given Not Equivalent Queries Is Equivalent To Should Return False| |4 ms|
|Given Similar Typed Queries Is Similar To Should Return True| |4 ms|
|Given Equivalent Typed Queries Is Equivalent To Should Return True| |4 ms|
|Given Equivalent Queries Is Equivalent To Should Return True| |4 ms|
|Given Queryable When Create Snapshot Host Called Then Should Return Snapshot Host| |4 ms|
|Given Queryable When Create Intercepted Query Called Then Should Return Query Host| |1 ms|
|Given Queryable When Create Intercepted Query Called Then Should Register Transformation| |1 ms|
|As Enumerable Should Return I Expression Enumerator For Query Expression| |1 ms|
|When Null Of Expression Type Should Throw Argument Null| |952 ns|
|Create Query Template Uses Empty List| |721 ns|
|Create Query Template From Query Uses Empty List| |391 ns|
|Given Null Is Similar To Should Return False| |238 ns|
|Given Null Is Equivalent To Should Return False| |226 ns|
## DefaultComparisonRulesTest (326 ms)

|Test Name|Duration|
|:--|--:|
|Given Non Supported Expression Then Typed Similarity Should Return False|36 ms|
|Given Similar Expressions Then Non Generic Check Similarity Should Compare|32 ms|
|Given Equivalent Expressions Then Non Generic Check Equivalency Should Compare|31 ms|
|Given Rules For Type Exist When Get Rule For Equivalency Called Then Should Return Ruleset|30 ms|
|Given Rules For Type Do Not Exist When Get Rule For Similarity Called Then Should Return Null|29 ms|
|Given No Rule Then Check Similarity Should Return False|29 ms|
|Given Rules For Type Do Not Exist When Get Rule For Equivalency Called Then Should Return Null|29 ms|
|Given No Rule Then Check Equivalency Should Return False|27 ms|
|Given Non Supported Expression Then Typed Equivalency Should Return False|27 ms|
|Given Supported Expression Then Typed Equivalency Should Return True|26 ms|
|Given Rules For Type Exist When Get Rule For Similarity Called Then Should Return Ruleset|26 ms|
|Given Null Queryable When Custom Query Provider Created Then Should Throw Argument Null|415 ns|
## DefaultHighPerformanceRulesTest (332 ms)

|Test Name|Duration|
|:--|--:|
|Given Equivalent Expressions Then Non Generic Check Equivalency Should Compare|30 ms|
|Given Supported Expression Then Typed Similarity Should Return True|28 ms|
|Given Non Supported Expression Then Typed Equivalency Should Return False|28 ms|
|Given No Rule Then Check Equivalency Should Return False|28 ms|
|Given Rules For Type Do Not Exist When Get Rule For Equivalency Called Then Should Return Null|28 ms|
|Given Rules For Type Do Not Exist When Get Rule For Similarity Called Then Should Return Null|27 ms|
|Given No Rule Then Check Similarity Should Return False|27 ms|
|Given Similar Expressions Then Non Generic Check Similarity Should Compare|27 ms|
|Given Supported Expression Then Typed Equivalency Should Return True|26 ms|
|Given Non Supported Expression Then Typed Similarity Should Return False|26 ms|
|Given Rules For Type Exist When Get Rule For Equivalency Called Then Should Return Ruleset|26 ms|
|Given Rules For Type Exist When Get Rule For Similarity Called Then Should Return Ruleset|26 ms|
## EnsureTest (34 ms)

|Test Name|Duration|
|:--|--:|
|Given Supported Expression Then Typed Similarity Should Return True|30 ms|
|Given Argument Null Thrown Then Should Have Target Name|982 ns|
|Given Expression That Resolves To Whitespace When Not Null Or Whitespace Called Then Should Throw Argument|639 ns|
|Given Expression That Resolves To Null When Variable Not Null Called Then Should Throw Null Reference|547 ns|
|Given Expression That Resolves To Null When Not Null Called Then Should Throw Argument Null|374 ns|
|Given Expression That Resolves To Null When Not Null Or Whitespace Called Then Should Throw Argument|361 ns|
|Given Expression That Does Not Resolve To Null When Variable Not Null Called Then Should Return|320 ns|
|Given Expression That Does Not Resolve To Null When Not Null Called Then Should Return|307 ns|
|Given Expression That Resolves To Value When Not Null Or Whitespace Called Then Should Return|300 ns|
|Given Expression Is Not Null When Variable Not Null Called Then Should Do Nothing|292 ns|
## ServiceHostTest (197 ms)

|Test Name|Duration|
|:--|--:|
|Additional Initialization After Reset Is Fine|30 ms|
|Reset Sets To Default|17 ms|
|Default Query Intercepting Provider Is Query Intercepting Provider|16 ms|
|Default Query Snapshot Provider Is Query Snapshot Provider|15 ms|
|Given Registered Satellite Service When Initialize Called Then Will Override|14 ms|
|Default Query Snapshot Host Is Query Snapshot Host|14 ms|
|Default Evaluator Is Singleton Of Expression Evaluator|14 ms|
|Initialize Includes Default Services|13 ms|
|Get Lazy Defers Resolution Until Value Acccessed|12 ms|
|Default Expression Enumerator Is Expression Enumerator|9 ms|
|Given Registered Satellite Service When Initialize Called Then After Registered Called|9 ms|
|Default Rules Provider Is Singleton Of Default Comparison Rules|8 ms|
|Default Query Host Is Query Host|8 ms|
|Given Satellite Implementation Of I Dependent Service Registration When Reset Called Then Should Register Service|4 ms|
|Creates A Default Instance Of Services|4 ms|
|Query With Projection Triggers Snapshot|3 ms|
## ServicesTest (26 ms)

|Test Name|Duration|
|:--|--:|
|Second Call To Initialize Should Throw Invalid Operation|20 ms|
|Given Generic Registration When Get Service Called Then Should Implement Type|1 ms|
|Given Registered Generic Type When Same Generic Type Registered With Then Should Replace Implementation|816 ns|
|Given Registered Singleton When Same Type Registered With Singleton Then Should Replace Instance|562 ns|
|Given Registered Singleton When Get Service Called Then Should Return Singleton|472 ns|
|Given Configured When Get Service Called With Non Registered Service Then Should Throw Invalid Operation|453 ns|
|Given Registered Type When Singleton Registered Then Should Replace Type|380 ns|
|Given Null Instance When Register Singleton Called Then Should Throw Argument Null|366 ns|
|Given Registered Singleton When Type Registered Then Should Replace Singleton|362 ns|
|Given Configured When Get Service Called With Non Argument With Resolve Set Then Should Return With Argument|285 ns|
|Given Configured When Register Service Called Then Should Throw Invalid Operation|247 ns|
|Given Registered Type When Same Type Registered Then Should Replace Type|224 ns|
|Given Not Configured When Get Service Called Then Should Throw Invalid Operation|224 ns|
|Given Generic Registration When Signature Is Not Assignable From Implementation Then Should Throw Invalid Operation|218 ns|
|Given Not Configured When Get Service Called For Generic Type Then Should Throw Invalid Operation|201 ns|
|Given Configured When Get Service Called With Registered Service Then Should Return Instance|172 ns|
|Given Generic Registration When Signature Is Assignable From Implementation Then Should Not Throw Invalid Operation|120 ns|
|Given Generic Registration When Signature Base Class Of Implementation Then Should Not Throw Invalid Operation|81 ns|
## QueryHostTest (16 ms)

|Test Name|Duration|
|:--|--:|
|Keys Are Unique|12 ms|
|Given Null Provider Then Throws Argument Null|1 ms|
|Given Query Host Created With Expression Then Returns Same Expression|495 ns|
|Given Query Host Of Type Then Element Type Should Return Type|481 ns|
|Given Query Host Provider And Custom Provider Should Be Same|381 ns|
|Given Query Host Created With Provider Then Returns Same Provider|368 ns|
|Given Null Expression Then Throws Argument Null|319 ns|
## ExpressionEvaluatorTest (58 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Non Similar Queryable When Are Similar Called Then Should Return False| |12 ms|
|Given Query That Is Not Part Of Other Query When Is Part Of Called Then Should Return False| |8 ms|
|Given Equivalent Queryable When Are Equivalent Called Then Should Return True| |8 ms|
|Given Non Equivalent Queryable When Are Equivalent Called Then Should Return False| |6 ms|
|Given Query That Is Part Of Other Query When Is Part Of Called Then Should Return True| |3 ms|
|Given Similar Enumerable When Are Similar Called Then Should Return True| |2 ms|
|Given Equivalent Enumerable When Are Equivalent Called Then Should Return True| |2 ms|
|Given Non Similar Expressions When Are Similar Called Then Should Return False| |1 ms|
|Given Non Equivalent Enumerable When Are Equivalent Called Then Should Return False| |1 ms|
|Given Non Similar Enumerable When Are Similar Called Then Should Return False| |1 ms|
|Given Similar Expressions When Are Similar Called Then Should Return True| |1 ms|
|Given Equivalent Expressions When Are Equivalent Called Then Should Return True| |1 ms|
|Given Expression That Is Not Part Of Other Expression When Is Part Of Called Then Should Return False| |1 ms|
|Given Non Equivalent Expressions When Are Equivalent Called Then Should Return False| |1 ms|
|Given Expression That Is Part Of Other Expression When Is Part Of Called Then Should Return True| |1 ms|
|Given Unary Expressions With Same Node Type Method And Operands Then Are Equivalent Should Return True| |856 ns|
|**Given Null And Not Null Query When Is Part Of Called Then Should Return False**| |**105 ns**|
| |(source: null, target: {})|101 ns|
| |(source: {}, target: null)|4 ns|
|**Given Null And Not Null Query When Are Similar Called Then Should Return False**| |**82 ns**|
| |(source: null, target: {})|76 ns|
| |(source: {}, target: null)|5 ns|
|**Given Null And Not Null Query When Are Equivalent Called Then Should Return False**| |**80 ns**|
| |(source: null, target: {})|74 ns|
| |(source: {}, target: null)|5 ns|
## ExpressionSimilarityTest (106 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Two Queries When Not Similar Then Are Similar Should Return False| |12 ms|
|Given Target With Query Parts Not Similiar When Is Part Of Called Then Should Return False| |7 ms|
|Given Two Queries When Similar Then Are Similar Should Return True| |7 ms|
|Given Member Expression When Type Declaring Type Member Name And Expressions Match Then Are Similar Should Return True| |2 ms|
|Given Two Inits When Constructors Are Different Then Are Similar Should Return False| |2 ms|
|Given Invocation Expression When Signatures Match Then Are Similar Should Return True| |2 ms|
|Given Lambda Expression When Bodies Are Not Similar Are Similar Then Should Return False| |2 ms|
|Given Lambda Expression When Parameters Are Different Types Then Are Similar Should Return False| |1 ms|
|Given Member Binding Lists Of Different Lengths When Member Bindings Are Similar Called Then Should Return False| |1 ms|
|Given Lambda Expression When Similar Then Are Similar Should Return True| |1 ms|
|Given Invocation Expression When Similar Then Are Similar Should Return True| |1 ms|
|Given Lambda Expression When Parameter Count Differs Then Are Similar Should Return False| |1 ms|
|**Given Member Inits When Compared Then Are Similar Should Return Result**| |**9 ms**|
| |(source: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, target: new SimilarHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(null)}}, areSimilar: False)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = new SimilarClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = new SimilarClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new InheritedHost() {SimClass = new InheritedClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = null}, areSimilar: False)|978 ns|
| |(source: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, target: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, areSimilar: True)|977 ns|
| |(source: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, target: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, areSimilar: True)|832 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost(new SimilarClass()) {SimClass = new SimilarClass()}, areSimilar: False)|728 ns|
| |(source: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, target: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, areSimilar: False)|692 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new Different() {Name = "Different"}, areSimilar: False)|282 ns|
|Given Lambda Expression When Singatures Match Then Are Similar Should Return True| |1 ms|
|Given Method Call Expression With Matching Expression And Arguments When Are Similar Called Then Should Return True| |1 ms|
|Given Method Call Expression With Different Arguments When Are Similar Called Then Should Return False| |1 ms|
|Given Two Inits When Arguments Are Different Then Are Similar Should Return False| |1 ms|
|Given Lambda Expression When Tail Call Is Different Then Are Similar Should Return True| |1 ms|
|Given Lambda Expression When Type Is Different Then Are Similar Should Return False| |1 ms|
|Given Method Call Expression With Static Method When Are Similar Called Then Should Return True| |1 ms|
|Given Enumerable Constant With Same Type Then Are Similar Should Return True| |1 ms|
|Given Method Call Expression With Different Declaring Types When Are Similar Called Then Should Return False| |1 ms|
|Given Target With Similar Query Parts When Is Part Of Called Then Should Return True| |1 ms|
|Given Method Call Expression With Different Expression When Are Similar Called Then Should Return False| |1 ms|
|Given Member Expression When Expressions Differ Then Are Similar Should Return True| |1 ms|
|Given Method Call Expression With Different Argument Count When Are Similar Called Then Should Return False| |1 ms|
|**Given Binary Expressions With Same Node Type When Are Similar Called Then Should Evaluate Left And Right On Equivalency**| |**2 ms**|
| |(source: (5 + 6), target: (5 + 5), areSimilar: False)|1 ms|
| |(source: (5 + 6), target: (5 + 6), areSimilar: True)|860 ns|
| |(source: (5 + 6), target: (6 + 6), areSimilar: False)|587 ns|
|Given Method Call Expression With Different Names When Are Similar Called Then Should Return False| |1 ms|
|Given Unary Expression When Operands Are Different Then Are Similar Should Return False| |972 ns|
|Given Binary Expressions When Node Types Are Different Then Are Similar Should Return False| |950 ns|
|Given Parameter With Derived Type Then Are Similar Should Return True| |947 ns|
|Given Invocation Expression When Parameters Are Different Types Then Are Similar Should Return False| |908 ns|
|Given Constant With Object Type And Other Type Then Are Similar Should Return False| |882 ns|
|Given List Of Different Type Then Are Similar Should Return False| |875 ns|
|**Given Constant With Expression Then Are Similar Should Recursively Compare**| |**2 ms**|
| |(left: 5, right: 5, Similar: True)|842 ns|
| |(left: 5, right: 5, Similar: False)|662 ns|
| |(left: 5, right: 5, Similar: True)|578 ns|
| |(left: 5, right: 5, Similar: False)|378 ns|
|Given Enumerable Constant With Different Type Then Are Similar Should Return False| |823 ns|
|Given Two Array Initializations With Same Type And Contents Then Are Similar Should Return True| |817 ns|
|Given List Of Same Type Then Are Similar Should Return True| |722 ns|
|Given Enumerable Of Shorter Length Then Are Similar Should Return True| |717 ns|
|Given Two Array Initializations With Same Type And Different Contents Then Are Similar Should Return False| |714 ns|
|Given Member Expression When Declaring Types Differ Then Are Similar Should Return False| |708 ns|
|Given Method Call Expression With Different Return Type When Are Similar Called Then Should Return False| |704 ns|
|Given Member Expression When Types Differ Then Are Similar Should Return False| |695 ns|
|Given Unary Expression When Node Types Are Different Then Are Similar Should Return False| |685 ns|
|Given Lambda Expression When Name Is Different Then Are Similar Should Return False| |683 ns|
|Given Enumerable Of Longer Length Then Are Similar Should Return True| |672 ns|
|Given Constant With Object Type Then Are Similar Should Return False| |661 ns|
|**Given Unary Expression When Types And Operands Are Same Then Are Similar Should Evaluate Based On Methods**| |**2 ms**|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: True)|652 ns|
| |(source: IsTrue(True), target: IsTrue(True), areSimilar: True)|584 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: False)|300 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: False)|296 ns|
| |(source: IsTrue(True), target: IsTrue("1"), areSimilar: False)|293 ns|
| |(source: IsTrue("1"), target: IsTrue(True), areSimilar: False)|283 ns|
|Given Parameter With Different Type Then Are Similar Should Return False| |591 ns|
|Given Member Expression When Member Names Differ Then Are Similar Should Return False| |567 ns|
|Given Two Inits When Arguments Are Same Then Are Similar Should Return True| |519 ns|
|Given Expression Not Supported Then Are Similar Should Return False| |494 ns|
|Given Enumerable Target With Complex Types Has More Expressions Then Are Similar Should Return True| |490 ns|
|Given Invocation Expression When Parameter Count Differs Then Are Similar Should Return False| |484 ns|
|Given Invocation Expression When Type Is Different Then Are Similar Should Return False| |467 ns|
|Given Constant With Same Reference Then Are Similar Should Return True| |461 ns|
|Given Target Without Query Parts When Is Part Of Called Then Should Return False| |437 ns|
|Given Enumerable With Complex Types In Different Order Then Are Similar Should Return True| |431 ns|
|Given Two Array Initializations With Different Types Then Are Similar Should Return False| |424 ns|
|Given Parameter With Different By Ref Then Are Similar Should Return True| |420 ns|
|Given Parameter With Different Name Then Are Similar Should Return True| |416 ns|
|Given Constants Of Same Type Both Null Then Are Similar Should Return True| |410 ns|
|Given Enumerable Target With Complex Types Has Fewer Expressions Then Are Similar Should Return True| |410 ns|
|Given Two Inits When Types Are Different Then Are Similar Should Return False| |410 ns|
|Given Constants With Different Type Then Are Similar Should Return False| |405 ns|
|Given Constants With Different Values Then Are Similar Should Return False| |387 ns|
|Given Parameter With Same Type And Name Then Are Similar Should Return True| |368 ns|
|Given Constant With Different Reference Then Are Similar Should Return False| |365 ns|
|Given Constants Of Same Type With One Null Then Are Similar Should Return False| |361 ns|
|Given Parameter When Second Parameter Null Then Are Similar Should Return False| |312 ns|
|If Then Else Defaults To True When Condition Not Met| |251 ns|
|Given Target Null When Is Part Of Called Then Should Return False| |103 ns|
|**Given Either Expression Null Then Are Similar Should Return False**| |**62 ns**|
| |(left: null, right: null)|55 ns|
| |(left: 5, right: null)|4 ns|
| |(left: null, right: 5)|2 ns|
## ExpressionSimilarityTestsWithoutRule (93 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Two Queries When Not Similar Then Are Similar Should Return False| |11 ms|
|Given Two Queries When Similar Then Are Similar Should Return True| |7 ms|
|Given Target With Query Parts Not Similiar When Is Part Of Called Then Should Return False| |7 ms|
|Given Enumerable Constant With Different Type Then Are Similar Should Return False| |2 ms|
|**Given Member Inits When Compared Then Are Similar Should Return Result**| |**11 ms**|
| |(source: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, target: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, areSimilar: True)|2 ms|
| |(source: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, target: new SimilarHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(null)}}, areSimilar: False)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = new SimilarClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = new SimilarClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new InheritedHost() {SimClass = new InheritedClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = null}, areSimilar: False)|1 ms|
| |(source: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, target: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, areSimilar: True)|998 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost(new SimilarClass()) {SimClass = new SimilarClass()}, areSimilar: False)|719 ns|
| |(source: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, target: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, areSimilar: False)|707 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new Different() {Name = "Different"}, areSimilar: False)|303 ns|
|Given Lambda Expression When Bodies Are Not Similar Are Similar Then Should Return False| |2 ms|
|Given Invocation Expression When Signatures Match Then Are Similar Should Return True| |1 ms|
|Given Lambda Expression When Similar Then Are Similar Should Return True| |1 ms|
|Given Lambda Expression When Parameters Are Different Types Then Are Similar Should Return False| |1 ms|
|Given Method Call Expression With Different Arguments When Are Similar Called Then Should Return False| |1 ms|
|Given Method Call Expression With Matching Expression And Arguments When Are Similar Called Then Should Return True| |1 ms|
|Given Lambda Expression When Singatures Match Then Are Similar Should Return True| |1 ms|
|Given Invocation Expression When Similar Then Are Similar Should Return True| |1 ms|
|Given Lambda Expression When Parameter Count Differs Then Are Similar Should Return False| |1 ms|
|Given Two Inits When Arguments Are Different Then Are Similar Should Return False| |1 ms|
|Given Lambda Expression When Type Is Different Then Are Similar Should Return False| |1 ms|
|Given Method Call Expression With Static Method When Are Similar Called Then Should Return True| |1 ms|
|Given Lambda Expression When Tail Call Is Different Then Are Similar Should Return True| |1 ms|
|Given Method Call Expression With Different Expression When Are Similar Called Then Should Return False| |1 ms|
|Given Unary Expressions With Same Node Type Method And Operands Then Are Similar Should Return True| |959 ns|
|Given Method Call Expression With Different Return Type When Are Similar Called Then Should Return False| |948 ns|
|Given Target With Similar Query Parts When Is Part Of Called Then Should Return True| |947 ns|
|Given Two Inits When Constructors Are Different Then Are Similar Should Return False| |944 ns|
|**Given Binary Expressions With Same Node Type When Are Similar Called Then Should Evaluate Left And Right On Equivalency**| |**2 ms**|
| |(source: (5 + 6), target: (5 + 5), areSimilar: False)|901 ns|
| |(source: (5 + 6), target: (5 + 6), areSimilar: True)|861 ns|
| |(source: (5 + 6), target: (6 + 6), areSimilar: False)|705 ns|
|Given Member Expression When Expressions Differ Then Are Similar Should Return True| |895 ns|
|Given Method Call Expression With Different Declaring Types When Are Similar Called Then Should Return False| |875 ns|
|Given Method Call Expression With Different Argument Count When Are Similar Called Then Should Return False| |868 ns|
|Given Unary Expression When Operands Are Different Then Are Similar Should Return False| |863 ns|
|Given Binary Expressions When Node Types Are Different Then Are Similar Should Return False| |855 ns|
|**Given Constant With Expression Then Are Similar Should Recursively Compare**| |**2 ms**|
| |(left: 5, right: 5, Similar: True)|842 ns|
| |(left: 5, right: 5, Similar: False)|596 ns|
| |(left: 5, right: 5, Similar: True)|570 ns|
| |(left: 5, right: 5, Similar: False)|319 ns|
|Given Method Call Expression With Different Names When Are Similar Called Then Should Return False| |785 ns|
|Given Parameter With Derived Type Then Are Similar Should Return True| |765 ns|
|Given Member Expression When Type Declaring Type Member Name And Expressions Match Then Are Similar Should Return True| |758 ns|
|Given Constant With Object Type And Other Type Then Are Similar Should Return False| |666 ns|
|Given Enumerable Of Shorter Length Then Are Similar Should Return True| |634 ns|
|Given List Of Different Type Then Are Similar Should Return False| |626 ns|
|Given Invocation Expression When Parameters Are Different Types Then Are Similar Should Return False| |623 ns|
|Given Two Array Initializations With Same Type And Different Contents Then Are Similar Should Return False| |617 ns|
|Given Member Expression When Declaring Types Differ Then Are Similar Should Return False| |607 ns|
|Given Enumerable Of Longer Length Then Are Similar Should Return True| |600 ns|
|Given Unary Expression When Node Types Are Different Then Are Similar Should Return False| |594 ns|
|Given Constant With Object Type Then Are Similar Should Return False| |587 ns|
|Given List Of Same Type Then Are Similar Should Return True| |575 ns|
|Given Enumerable Constant With Same Type Then Are Similar Should Return True| |574 ns|
|Given Two Array Initializations With Same Type And Contents Then Are Similar Should Return True| |525 ns|
|**Given Unary Expression When Types And Operands Are Same Then Are Similar Should Evaluate Based On Methods**| |**2 ms**|
| |(source: IsTrue(True), target: IsTrue(True), areSimilar: True)|519 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: True)|505 ns|
| |(source: IsTrue(True), target: IsTrue("1"), areSimilar: False)|332 ns|
| |(source: IsTrue("1"), target: IsTrue(True), areSimilar: False)|271 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: False)|267 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: False)|258 ns|
|Given Member Expression When Member Names Differ Then Are Similar Should Return False| |472 ns|
|Given Lambda Expression When Name Is Different Then Are Similar Should Return False| |470 ns|
|Given Two Inits When Arguments Are Same Then Are Similar Should Return True| |469 ns|
|Given Enumerable Target With Complex Types Has Fewer Expressions Then Are Similar Should Return True| |467 ns|
|Given Member Expression When Types Differ Then Are Similar Should Return False| |446 ns|
|Given Constants With Different Type Then Are Similar Should Return False| |360 ns|
|Given Invocation Expression When Parameter Count Differs Then Are Similar Should Return False| |350 ns|
|Given Constants Of Same Type Both Null Then Are Similar Should Return True| |337 ns|
|Given Two Inits When Types Are Different Then Are Similar Should Return False| |337 ns|
|Given Constants With Different Values Then Are Similar Should Return False| |336 ns|
|Given Target Without Query Parts When Is Part Of Called Then Should Return False| |321 ns|
|Given Constant With Different Reference Then Are Similar Should Return False| |312 ns|
|Given Expression Not Supported Then Are Similar Should Return False| |306 ns|
|Given Parameter With Same Type And Name Then Are Similar Should Return True| |305 ns|
|Given Enumerable Target With Complex Types Has More Expressions Then Are Similar Should Return True| |304 ns|
|Given Constants Of Same Type With One Null Then Are Similar Should Return False| |301 ns|
|Given Parameter With Different By Ref Then Are Similar Should Return True| |300 ns|
|Given Parameter With Different Name Then Are Similar Should Return True| |299 ns|
|Given Two Array Initializations With Different Types Then Are Similar Should Return False| |279 ns|
|Given Enumerable With Complex Types In Different Order Then Are Similar Should Return True| |276 ns|
|Given Invocation Expression When Type Is Different Then Are Similar Should Return False| |273 ns|
|Given Constant With Same Reference Then Are Similar Should Return True| |264 ns|
|Given Parameter With Different Type Then Are Similar Should Return False| |261 ns|
|Given Parameter When Second Parameter Null Then Are Similar Should Return False| |179 ns|
|Given Target Null When Is Part Of Called Then Should Return False| |22 ns|
|Given Member Binding Lists Of Different Lengths When Member Bindings Are Similar Called Then Should Return False| |8 ns|
|**Given Either Expression Null Then Are Similar Should Return False**| |**9 ns**|
| |(left: null, right: null)|5 ns|
| |(left: 5, right: null)|2 ns|
| |(left: null, right: 5)|1 ns|
## ExpressionExtensionsTest (22 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Similar Queryable When Are Similar Called Then Should Return True| |8 ms|
|Given Expression Not Part Of Target When Is Part Of Called Then Should Return False| |1 ms|
|Given Generic Type With Anonymous Closures When Is Or Contains Anonymous Type Called Then Should Return True| |1 ms|
|Given Expression Part Of Target When Is Part Of Called Then Should Return True| |1 ms|
|**As Invocation Expression With Parameters Should Return Invocation**| |**1 ms**|
| |(expr: i =} (i } 2))|1 ms|
| |(expr: (a, b) =} Convert((a * b), Int64))|224 ns|
|Given Expressions Are Equivalent When Is Equivalent To Called Then Should Return True| |752 ns|
|Given Expressions Are Not Similar When Is Similar To Called Then Should Return False| |728 ns|
|Given Expressions Are Similar When Is Similar To Called Then Should Return True| |679 ns|
|Given Expressions Are Not Equivalent When Is Equivalent To Called Then Should Return False| |662 ns|
|Create Parameter Expression Should Create Parameter With Name| |478 ns|
|As Parameter Expression For Object By Ref Should Return Parameter Expression Of Object Type By Ref| |473 ns|
|As Parameter Expression For Object With Name Should Return Parameter Expression Of Object Type With Name| |413 ns|
|As Parameter Expression For Object Should Return Parameter Expression Of Object Type| |391 ns|
|When Null Then As Enumerable Should Throw Argument Null| |351 ns|
|When Null Then As Parameter Expression For Object Should Throw Null Argument| |349 ns|
|When Null Then As Parameter Expresion For Type Should Throw Argument Null| |342 ns|
|When Null Then As Constant Expression Should Throw Argument Null| |325 ns|
|Create Parameter Expression Should Create Parameter With Parent Type| |312 ns|
|As Invocation Expression With No Parameters Should Return Invocation| |270 ns|
|As Parameter Expression For Type With Name Should Return Parameter Expression For Type With Name| |261 ns|
|As Parameter Expression For Type Should Return Parameter Expression For Type| |251 ns|
|As Parameter Expression For Type By Ref Should Return Parameter Expression For Type By Ref| |247 ns|
|As Constant Expression Should Return Constant Expression With Value| |243 ns|
|As Enumerable Should Return I Expression Enumerator| |235 ns|
|Given Expression When Member Name Extension Called Then Should Return Name| |165 ns|
|Given Generic Type With No Anonymous Closures When Is Or Contains Anonymous Type Called Then Should Return False| |69 ns|
|Given Type Is Anonymous When Is Anonymous Type Called Then Should Return True| |67 ns|
|Given Type Is Not Anonymous When Is Anonymous Type Called Then Should Return False| |53 ns|
## ExpressionEquivalencyTest (92 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Two Queries When Not Equivalent Then Are Equivalent Should Return False| |7 ms|
|Given I Equatable Implemented And False Then Are Equivalent Should Return False| |2 ms|
|When Get Enumerator To String Called Then Should Return Expression Tree| |2 ms|
|Given Enumerable With Same Values In Same Order Then Are Equivalent Should Return True| |2 ms|
|Given Method Call Expression With Matching Expression And Arguments When Are Equivalent Called Then Should Return True| |2 ms|
|Given Enumerable Of Shorter Length Then Are Equivalent Should Return False| |1 ms|
|Given Lambda Expression When Equivalent Then Are Equivalent Should Return True| |1 ms|
|Given Two Invocations When Different Args Then Are Equivalent Should Return False| |1 ms|
|Given Lambda Expression When Parameter Count Differs Then Are Equivalent Should Return False| |1 ms|
|**Given Member Inits When Compared Then Are Equivalent Should Return Result**| |**6 ms**|
| |(source: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}}, areEquivalent: False)|1 ms|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = new TestData()}, areEquivalent: True)|1 ms|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = null}, areEquivalent: False)|909 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, areEquivalent: False)|896 ns|
| |(source: new TestData() {Name = "Hello"}, target: new TestData("Hello") {Name = "GoodBye"}, areEquivalent: False)|765 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new TestData() {Name = "Hello"}, areEquivalent: False)|300 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = new TestData()}, areEquivalent: True)|75 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, target: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, areEquivalent: True)|6 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: null, areEquivalent: False)|5 ns|
| |(source: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, areEquivalent: True)|2 ns|
|Given Two Element Inits That Are Different Values Then Values Are Equivalent Should Return False| |1 ms|
|Given Lambda Expression When Bodies Are Not Equivalent Are Equivalent Then Should Return False| |1 ms|
|Given Method Call Expression With Different Argument Count When Are Equivalent Called Then Should Return False| |1 ms|
|Given Two Element Inits That Are Same Then Values Are Equivalent Should Return True| |1 ms|
|**Given Anonymous Type When Compared To Anonymous Then Values Are Equivalent Should Return Result**| |**2 ms**|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = hello }, areEquivalent: True)|1 ms|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = hello }, areEquivalent: True)|665 ns|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = goodbye }, areEquivalent: False)|16 ns|
|Given Method Call Expression With Different Arguments When Are Equivalent Called Then Should Return False| |1 ms|
|Given Method Call Expression With Different Names When Are Equivalent Called Then Should Return False| |1 ms|
|Given Two Inits When Arguments Are Different Then Are Equivalent Should Return False| |1 ms|
|Given Two Inits When Constructors Are Different Then Are Equivalent Should Return False| |1 ms|
|Given Enumerable Constant With Different Members Then Are Equivalent Should Return False| |1 ms|
|**Given Binary Expressions With Same Node Type When Are Equivalent Called Then Should Evaluate Left And Right On Equivalency**| |**2 ms**|
| |(source: (5 + 6), target: (5 + 5), areEquivalent: False)|1 ms|
| |(source: (5 + 6), target: (5 + 6), areEquivalent: True)|836 ns|
| |(source: (5 + 6), target: (6 + 6), areEquivalent: False)|542 ns|
|Given Method Call Expression With Different Declaring Types When Are Equivalent Called Then Should Return False| |1 ms|
|Given I Comparable Implemented And Zero Then Are Equivalent Should Return True| |1 ms|
|**Given Two I Dictionary When Dictionaries Are Equivalent Called Then Should Return Result**| |**1 ms**|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 2}}, areEqual: True)|995 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 3}}, areEqual: False)|526 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {three, 2}}, areEqual: False)|299 ns|
| |(source: {{one, 1}, {two, 2}}, target: null, areEqual: False)|176 ns|
|Given Binary Expressions When Node Types Are Different Then Are Equivalent Should Return False| |949 ns|
|**Given Member Bindings When Compared Then Member Bindings Are Equivalent Should Return Result**| |**3 ms**|
| |(source: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}, areEquivalent: False)|944 ns|
| |(source: TestProp = new TestData(), target: TestProp = new TestData(), areEquivalent: True)|625 ns|
| |(source: TestProp = new TestData(), target: TestProp = new TestData(), areEquivalent: True)|537 ns|
| |(source: Name = "Hello", target: Name = "GoodBye", areEquivalent: False)|416 ns|
| |(source: TestProp = {Name = "ExpressionEquivalencyTests"}, target: TestProp = {Name = "ExpressionEquivalencyTests"}, areEquivalent: True)|360 ns|
| |(source: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, areEquivalent: True)|290 ns|
| |(source: TestProp = new TestData(), target: null, areEquivalent: False)|164 ns|
| |(source: TestProp = new TestData(), target: Name = "Hello", areEquivalent: False)|144 ns|
| |(source: TestProp = new TestData(), target: TestProp = null, areEquivalent: False)|139 ns|
| |(source: TestProp = {Name = "ExpressionEquivalencyTests"}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, areEquivalent: False)|135 ns|
|Given Member Expression When Member Names Differ Then Are Equivalent Should Return False| |933 ns|
|Given Two Element Inits That Are Different Methods Then Values Are Equivalent Should Return False| |928 ns|
|Given Method Call Expression With Different Expression When Are Equivalent Called Then Should Return False| |922 ns|
|Given Two Array Initializations With Same Type And Contents Then Are Equivalent Should Return True| |909 ns|
|**Given Unary Expression When Types And Operands Are Same Then Are Equivalent Should Evaluate Based On Methods**| |**2 ms**|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: True)|908 ns|
| |(source: IsTrue(True), target: IsTrue(True), areEquivalent: True)|538 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: False)|317 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: False)|305 ns|
| |(source: IsTrue("1"), target: IsTrue(True), areEquivalent: False)|289 ns|
| |(source: IsTrue(True), target: IsTrue("1"), areEquivalent: False)|270 ns|
|Given Enumerable Constant With Source Null Then Are Equivalent Should Return False| |908 ns|
|Given Method Call Expression With Static Method When Are Equivalent Called Then Should Return True| |902 ns|
|Given Member Expression When Expressions Differ Then Are Equivalent Should Return False| |901 ns|
|Given Unary Expression When Operands Are Different Then Are Equivalent Should Return False| |899 ns|
|Given Enumerable Constant With Target Null Then Are Equivalent Should Return False| |861 ns|
|Given Enumerable Of Longer Length Then Are Equivalent Should Return False| |844 ns|
|Given Enumerable Constant With Same Members Then Are Equivalent Should Return True| |843 ns|
|Given Anonymous Parameter With Same Siganture Then Are Equivalent Should Return True| |820 ns|
|Given Two Array Initializations With Same Type And Different Contents Then Are Equivalent Should Return False| |818 ns|
|**Given Constant With Expression Then Are Equivalent Should Recursively Compare**| |**2 ms**|
| |(left: 5, right: 5, equivalent: False)|815 ns|
| |(left: 5, right: 5, equivalent: True)|774 ns|
| |(left: 5, right: 5, equivalent: True)|531 ns|
| |(left: 5, right: 5, equivalent: False)|385 ns|
|Given Lambda Expression When Type Is Different Then Are Equivalent Should Return False| |805 ns|
|Given I Equatable Implemented And True Then Are Equivalent Should Return True| |794 ns|
|Given Anonymous Parameter With Different Signature Then Are Equivalent Should Return False| |793 ns|
|Given Constant With Same Reference Then Are Equivalent Should Return True| |790 ns|
|Given Member Expression When Declaring Types Differ Then Are Equivalent Should Return False| |728 ns|
|Given Lambda Expression When Tail Call Is Different Then Are Equivalent Should Return False| |698 ns|
|Given Method Call Expression With Different Return Type When Are Equivalent Called Then Should Return False| |676 ns|
|Given I Comparable Implemented And Not Zero Then Are Equivalent Should Return False| |664 ns|
|Given Unary Expression When Node Types Are Different Then Are Equivalent Should Return False| |653 ns|
|Given Lambda Expression When Parameters Are Not Equivalent Then Are Equivalent Should Return False| |607 ns|
|Given Member Expression When Type Declaring Type Member Name And Expressions Match Then Are Equivalent Should Return True| |603 ns|
|Given Parameter With Different Name Then Are Equivalent Should Return False| |585 ns|
|Given Member Expression When Types Differ Then Are Equivalent Should Return False| |565 ns|
|Given Enumerable With Different Values Then Are Equivalent Should Return False| |556 ns|
|**Given Two I Dictionary When Values Are Equivalent Called Then Should Return Result**| |**1 ms**|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 2}}, areEqual: True)|545 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 3}}, areEqual: False)|419 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {three, 2}}, areEqual: False)|288 ns|
| |(source: {{one, 1}, {two, 2}}, target: null, areEqual: False)|144 ns|
|Given Two Inits When Arguments Are Same Then Are Equivalent Should Return True| |544 ns|
|Given Enumerable Target Has More Expressions Then Are Equivalent Should Return False| |543 ns|
|Given Enumerable Target Has Fewer Expressions Then Are Equivalent Should Return False| |543 ns|
|Given Enumerable Query When Of Different Type Then Are Equivalent Should Be False| |538 ns|
|Given Enumerable With Items In Different Order Then Are Equivalent Should Return False| |524 ns|
|Given Lambda Expression When Name Is Different Then Are Equivalent Should Return False| |481 ns|
|Given Enumerable Query When Of Same Type Then Are Equivalent Should Be True| |463 ns|
|Given One Element Inits And One Not Element Init Then Values Are Equivalent Should Return False| |424 ns|
|Given Two Array Initializations With Different Types Then Are Equivalent Should Return False| |409 ns|
|Given Constants Of Same Type Both Null Then Are Equivalent Should Return True| |393 ns|
|Given Constant With Different Reference Then Are Equivalent Should Return False| |388 ns|
|Given Constants With Different Type Then Are Equivalent Should Return False| |388 ns|
|Given Parameter With Same Type And Name Then Are Equivalent Should Return True| |376 ns|
|Given Two Invocations When Different Types Then Are Equivalent Should Return False| |370 ns|
|Given Two Inits When Types Are Different Then Are Equivalent Should Return False| |369 ns|
|Given Expression Not Supported Then Are Equivalent Should Return False| |366 ns|
|**Given Two Types When Types Are Equivalent Then Should Return Result**| |**590 ns**|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType4{int, int}), areEquivalent: False)|349 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType3{int}), areEquivalent: True)|139 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType6{int}), areEquivalent: False)|34 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType3{string}), areEquivalent: False)|32 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType5{int}), areEquivalent: False)|28 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof(object), areEquivalent: False)|5 ns|
|Given Constants With Different Values Then Are Equivalent Should Return False| |349 ns|
|Given Enumerable With Target Null Then Are Equivalent Should Return False| |243 ns|
|Are Equivalent Non Generic Enumerable With Null Target Should Return False| |232 ns|
|**Given Two Enumerables When Values Are Equivalent Called Then Should Resolve Without Enumerating String**| |**651 ns**|
| |(source: {'G', 'e', 't', 'E', 'n', ...}, target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: True)|220 ns|
| |(source: {"one", "two"}, target: {"one", "two"}, areEquivalent: True)|176 ns|
| |(source: {"one", "two"}, target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: False)|156 ns|
| |(source: "GetEnumerableValuesMatrix", target: "matrix", areEquivalent: False)|85 ns|
| |(source: "GetEnumerableValuesMatrix", target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: False)|6 ns|
| |(source: "GetEnumerableValuesMatrix", target: "GetEnumerableValuesMatrix", areEquivalent: True)|5 ns|
|Given Two Queries When Equivalent Then Are Equivalent Should Return True| |203 ns|
|Given Parameter With Different Type Then Are Equivalent Should Return False| |146 ns|
|Given Parameter With Different By Ref Then Are Equivalent Should Return False| |129 ns|
|Given Two Invocations When Different Then Are Equivalent Should Return False| |122 ns|
|Given Exception Of Different Type When Values Are Equivalent Called Then Should Return False| |103 ns|
|Given Two Methods That Are Different Then Values Are Equivalent Should Return False| |99 ns|
|Given Exception Of Same Type And Message When Values Are Equivalent Called Then Should Return True| |96 ns|
|**Given Two Invocations When Same Then Are Equivalent Should Return True**| |**98 ns**|
| |(invocation: Invoke(() =} True))|89 ns|
| |(invocation: Invoke(() =} "FuncString"))|6 ns|
| |(invocation: Invoke(i =} (i } 2), i))|2 ns|
|Given Enumerable Query When Target Is Not Enumerable Query Then Values Are Equivalent Should Be False| |85 ns|
|Given Exception Of Same Type And Different Message When Values Are Equivalent Called Then Should Return False| |77 ns|
|Are Equivalent With Null Target Should Return False| |74 ns|
|Given Constants Of Same Type With One Null Then Are Equivalent Should Return False| |66 ns|
|**Given Either Expression Null Then Are Equivalent Should Return False**| |**67 ns**|
| |(left: 5, right: null)|62 ns|
| |(left: null, right: 5)|4 ns|
|Given Same Expression Then Are Equivalent Should Return True| |62 ns|
## ExpressionEquivalencyTestsWithoutRule (67 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Two Queries When Not Equivalent Then Are Equivalent Should Return False| |6 ms|
|Given Enumerable With Same Values In Same Order Then Are Equivalent Should Return True| |2 ms|
|**Given Member Inits When Compared Then Are Equivalent Should Return Result**| |**6 ms**|
| |(source: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}}, areEquivalent: False)|1 ms|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = new TestData()}, areEquivalent: True)|1 ms|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = null}, areEquivalent: False)|969 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, areEquivalent: False)|959 ns|
| |(source: new TestData() {Name = "Hello"}, target: new TestData("Hello") {Name = "GoodBye"}, areEquivalent: False)|744 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new TestData() {Name = "Hello"}, areEquivalent: False)|316 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = new TestData()}, areEquivalent: True)|5 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, target: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, areEquivalent: True)|5 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: null, areEquivalent: False)|3 ns|
| |(source: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, areEquivalent: True)|2 ns|
|Given Lambda Expression When Equivalent Then Are Equivalent Should Return True| |1 ms|
|Given Lambda Expression When Bodies Are Not Equivalent Are Equivalent Then Should Return False| |1 ms|
|Given Method Call Expression With Matching Expression And Arguments When Are Equivalent Called Then Should Return True| |1 ms|
|Given Binary Expressions When Node Types Are Different Then Are Equivalent Should Return False| |1 ms|
|Given Method Call Expression With Different Arguments When Are Equivalent Called Then Should Return False| |1 ms|
|**Given Member Bindings When Compared Then Member Bindings Are Equivalent Should Return Result**| |**3 ms**|
| |(source: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}, areEquivalent: False)|1 ms|
| |(source: TestProp = new TestData(), target: TestProp = new TestData(), areEquivalent: True)|566 ns|
| |(source: Name = "Hello", target: Name = "GoodBye", areEquivalent: False)|449 ns|
| |(source: TestProp = {Name = "ExpressionEquivalencyTests"}, target: TestProp = {Name = "ExpressionEquivalencyTests"}, areEquivalent: True)|293 ns|
| |(source: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, areEquivalent: True)|285 ns|
| |(source: TestProp = {Name = "ExpressionEquivalencyTests"}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, areEquivalent: False)|265 ns|
| |(source: TestProp = new TestData(), target: null, areEquivalent: False)|165 ns|
| |(source: TestProp = new TestData(), target: TestProp = new TestData(), areEquivalent: True)|163 ns|
| |(source: TestProp = new TestData(), target: Name = "Hello", areEquivalent: False)|159 ns|
| |(source: TestProp = new TestData(), target: TestProp = null, areEquivalent: False)|146 ns|
|Given Unary Expression When Operands Are Different Then Are Equivalent Should Return False| |981 ns|
|Given Method Call Expression With Different Argument Count When Are Equivalent Called Then Should Return False| |970 ns|
|Given Two Inits When Arguments Are Different Then Are Equivalent Should Return False| |944 ns|
|Given Unary Expressions With Same Node Type Method And Operands Then Are Equivalent Should Return True| |907 ns|
|Given Method Call Expression With Different Names When Are Equivalent Called Then Should Return False| |901 ns|
|**Given Constant With Expression Then Are Equivalent Should Recursively Compare**| |**2 ms**|
| |(left: 5, right: 5, equivalent: False)|900 ns|
| |(left: 5, right: 5, equivalent: True)|872 ns|
| |(left: 5, right: 5, equivalent: True)|603 ns|
| |(left: 5, right: 5, equivalent: False)|423 ns|
|**Given Binary Expressions With Same Node Type When Are Equivalent Called Then Should Evaluate Left And Right On Equivalency**| |**2 ms**|
| |(source: (5 + 6), target: (5 + 5), areEquivalent: False)|890 ns|
| |(source: (5 + 6), target: (5 + 6), areEquivalent: True)|780 ns|
| |(source: (5 + 6), target: (6 + 6), areEquivalent: False)|533 ns|
|Given Member Expression When Expressions Differ Then Are Equivalent Should Return False| |875 ns|
|Given Method Call Expression With Different Declaring Types When Are Equivalent Called Then Should Return False| |867 ns|
|Given Two Element Inits That Are Same Then Values Are Equivalent Should Return True| |854 ns|
|Given Two Invocations When Different Args Then Are Equivalent Should Return False| |796 ns|
|Given Enumerable Constant With Source Null Then Are Equivalent Should Return False| |767 ns|
|Given Enumerable Constant With Target Null Then Are Equivalent Should Return False| |752 ns|
|Given Enumerable Of Shorter Length Then Are Equivalent Should Return False| |749 ns|
|Given Method Call Expression With Static Method When Are Equivalent Called Then Should Return True| |741 ns|
|Given Enumerable Constant With Different Members Then Are Equivalent Should Return False| |727 ns|
|Given Two Array Initializations With Same Type And Contents Then Are Equivalent Should Return True| |724 ns|
|Given Anonymous Parameter With Different Signature Then Are Equivalent Should Return False| |694 ns|
|Given Enumerable Of Longer Length Then Are Equivalent Should Return False| |682 ns|
|Given Enumerable Constant With Same Members Then Are Equivalent Should Return True| |665 ns|
|Given Method Call Expression With Different Expression When Are Equivalent Called Then Should Return False| |665 ns|
|Given Two Array Initializations With Same Type And Different Contents Then Are Equivalent Should Return False| |658 ns|
|Given Lambda Expression When Type Is Different Then Are Equivalent Should Return False| |651 ns|
|Given Anonymous Parameter With Same Siganture Then Are Equivalent Should Return True| |620 ns|
|Given I Equatable Implemented And False Then Are Equivalent Should Return False| |611 ns|
|Given I Equatable Implemented And True Then Are Equivalent Should Return True| |609 ns|
|Given Method Call Expression With Different Return Type When Are Equivalent Called Then Should Return False| |587 ns|
|Given Two Inits When Constructors Are Different Then Are Equivalent Should Return False| |586 ns|
|Given Member Expression When Declaring Types Differ Then Are Equivalent Should Return False| |582 ns|
|Given I Comparable Implemented And Not Zero Then Are Equivalent Should Return False| |560 ns|
|**Given Unary Expression When Types And Operands Are Same Then Are Equivalent Should Evaluate Based On Methods**| |**2 ms**|
| |(source: IsTrue(True), target: IsTrue(True), areEquivalent: True)|539 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: True)|528 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: False)|281 ns|
| |(source: IsTrue("1"), target: IsTrue(True), areEquivalent: False)|269 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: False)|267 ns|
| |(source: IsTrue(True), target: IsTrue("1"), areEquivalent: False)|263 ns|
|**Given Two I Dictionary When Dictionaries Are Equivalent Called Then Should Return Result**| |**1 ms**|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 2}}, areEqual: True)|532 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 3}}, areEqual: False)|434 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {three, 2}}, areEqual: False)|301 ns|
| |(source: {{one, 1}, {two, 2}}, target: null, areEqual: False)|157 ns|
|Given I Comparable Implemented And Zero Then Are Equivalent Should Return True| |531 ns|
|Given Unary Expression When Node Types Are Different Then Are Equivalent Should Return False| |523 ns|
|Given Two Element Inits That Are Different Values Then Values Are Equivalent Should Return False| |496 ns|
|**Given Two I Dictionary When Values Are Equivalent Called Then Should Return Result**| |**1 ms**|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 2}}, areEqual: True)|485 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 3}}, areEqual: False)|428 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {three, 2}}, areEqual: False)|279 ns|
| |(source: {{one, 1}, {two, 2}}, target: null, areEqual: False)|143 ns|
|Given Enumerable With Items In Different Order Then Are Equivalent Should Return False| |484 ns|
|Given Member Expression When Type Declaring Type Member Name And Expressions Match Then Are Equivalent Should Return True| |471 ns|
|Given Member Expression When Member Names Differ Then Are Equivalent Should Return False| |456 ns|
|Given Enumerable Target Has Fewer Expressions Then Are Equivalent Should Return False| |408 ns|
|Given Member Expression When Types Differ Then Are Equivalent Should Return False| |403 ns|
|Given Enumerable With Different Values Then Are Equivalent Should Return False| |402 ns|
|Given Enumerable Target Has More Expressions Then Are Equivalent Should Return False| |400 ns|
|Given Two Inits When Arguments Are Same Then Are Equivalent Should Return True| |395 ns|
|Given Two Element Inits That Are Different Methods Then Values Are Equivalent Should Return False| |381 ns|
|Given Constants With Different Values Then Are Equivalent Should Return False| |355 ns|
|Given Expression Not Supported Then Are Equivalent Should Return False| |339 ns|
|Given Lambda Expression When Name Is Different Then Are Equivalent Should Return False| |337 ns|
|Given Two Inits When Types Are Different Then Are Equivalent Should Return False| |330 ns|
|Given Constants With Different Type Then Are Equivalent Should Return False| |316 ns|
|Given Parameter With Same Type And Name Then Are Equivalent Should Return True| |313 ns|
|Given Two Array Initializations With Different Types Then Are Equivalent Should Return False| |310 ns|
|Given Constant With Different Reference Then Are Equivalent Should Return False| |307 ns|
|Given Enumerable Query When Of Different Type Then Are Equivalent Should Be False| |307 ns|
|Given Enumerable Query When Of Same Type Then Are Equivalent Should Be True| |299 ns|
|Given Constant With Same Reference Then Are Equivalent Should Return True| |299 ns|
|Given Two Invocations When Different Types Then Are Equivalent Should Return False| |287 ns|
|Given Constants Of Same Type Both Null Then Are Equivalent Should Return True| |279 ns|
|Given Lambda Expression When Tail Call Is Different Then Are Equivalent Should Return False| |278 ns|
|Given Parameter With Different Name Then Are Equivalent Should Return False| |267 ns|
|Are Equivalent Non Generic Enumerable With Null Target Should Return False| |206 ns|
|**Given Two Enumerables When Values Are Equivalent Called Then Should Resolve Without Enumerating String**| |**509 ns**|
| |(source: {'G', 'e', 't', 'E', 'n', ...}, target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: True)|198 ns|
| |(source: {"one", "two"}, target: {"one", "two"}, areEquivalent: True)|145 ns|
| |(source: {"one", "two"}, target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: False)|143 ns|
| |(source: "GetEnumerableValuesMatrix", target: "matrix", areEquivalent: False)|10 ns|
| |(source: "GetEnumerableValuesMatrix", target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: False)|5 ns|
| |(source: "GetEnumerableValuesMatrix", target: "GetEnumerableValuesMatrix", areEquivalent: True)|5 ns|
|Given One Element Inits And One Not Element Init Then Values Are Equivalent Should Return False| |175 ns|
|Given Enumerable With Target Null Then Are Equivalent Should Return False| |162 ns|
|Given Lambda Expression When Parameter Count Differs Then Are Equivalent Should Return False| |69 ns|
|Given Lambda Expression When Parameters Are Not Equivalent Then Are Equivalent Should Return False| |62 ns|
|Given Two Queries When Equivalent Then Are Equivalent Should Return True| |56 ns|
|**Given Two Types When Types Are Equivalent Then Should Return Result**| |**151 ns**|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType3{string}), areEquivalent: False)|52 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType4{int, int}), areEquivalent: False)|29 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType6{int}), areEquivalent: False)|28 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType5{int}), areEquivalent: False)|24 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType3{int}), areEquivalent: True)|11 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof(object), areEquivalent: False)|4 ns|
|**Given Anonymous Type When Compared To Anonymous Then Values Are Equivalent Should Return Result**| |**57 ns**|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = hello }, areEquivalent: True)|40 ns|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = goodbye }, areEquivalent: False)|10 ns|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = hello }, areEquivalent: True)|6 ns|
|Given Two Methods That Are Different Then Values Are Equivalent Should Return False| |32 ns|
|Given Exception Of Different Type When Values Are Equivalent Called Then Should Return False| |14 ns|
|Given Two Invocations When Different Then Are Equivalent Should Return False| |11 ns|
|Given Exception Of Same Type And Message When Values Are Equivalent Called Then Should Return True| |10 ns|
|Given Exception Of Same Type And Different Message When Values Are Equivalent Called Then Should Return False| |9 ns|
|Given Parameter With Different By Ref Then Are Equivalent Should Return False| |9 ns|
|Given Enumerable Query When Target Is Not Enumerable Query Then Values Are Equivalent Should Be False| |7 ns|
|Given Constants Of Same Type With One Null Then Are Equivalent Should Return False| |6 ns|
|Given Same Expression Then Are Equivalent Should Return True| |6 ns|
|Are Equivalent With Null Target Should Return False| |5 ns|
|**Given Two Invocations When Same Then Are Equivalent Should Return True**| |**10 ns**|
| |(invocation: Invoke(() =} True))|5 ns|
| |(invocation: Invoke(() =} "FuncString"))|2 ns|
| |(invocation: Invoke(i =} (i } 2), i))|2 ns|
|**Given Either Expression Null Then Are Equivalent Should Return False**| |**7 ns**|
| |(left: 5, right: null)|5 ns|
| |(left: null, right: 5)|2 ns|
|Given Parameter With Different Type Then Are Equivalent Should Return False| |4 ns|
## ExpressionRulesExtensionsTest (24 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given If Then Result Should Be Based On Evaluation Of If Then Else**| |**5 ms**|
| |(ifCondition: True, thenCondition: True, elseCondition: null, expected: True)|2 ms|
| |(ifCondition: False, thenCondition: True, elseCondition: True, expected: True)|341 ns|
| |(ifCondition: True, thenCondition: False, elseCondition: True, expected: False)|300 ns|
| |(ifCondition: True, thenCondition: True, elseCondition: True, expected: True)|296 ns|
| |(ifCondition: True, thenCondition: True, elseCondition: False, expected: True)|292 ns|
| |(ifCondition: True, thenCondition: False, elseCondition: null, expected: False)|292 ns|
| |(ifCondition: False, thenCondition: False, elseCondition: False, expected: False)|288 ns|
| |(ifCondition: False, thenCondition: True, elseCondition: null, expected: True)|288 ns|
| |(ifCondition: False, thenCondition: False, elseCondition: null, expected: True)|283 ns|
| |(ifCondition: True, thenCondition: False, elseCondition: False, expected: False)|280 ns|
| |(ifCondition: False, thenCondition: False, elseCondition: True, expected: True)|279 ns|
| |(ifCondition: False, thenCondition: True, elseCondition: False, expected: False)|277 ns|
|**Given To Rule Of Type Then Should Create Rule For Converted Types**| |**2 ms**|
| |(sourceVal: 1, targetVal: 2, expected: False)|1 ms|
| |(sourceVal: 2, targetVal: 1, expected: False)|588 ns|
| |(sourceVal: 1, targetVal: 1, expected: True)|583 ns|
|**Given Global Rule Then Should Evaluate Based On Expression Type**| |**1 ms**|
| |(sourceValue: 1, expected: True)|1 ms|
| |(sourceValue: 2, expected: False)|684 ns|
|**Given False Rule Or Expression With Same Node Types Then Or Must Match Should Evaluate Node Types**| |**1 ms**|
| |(nodeTypesShouldMatch: False)|1 ms|
| |(nodeTypesShouldMatch: True)|746 ns|
|Given Expressions With Same Node Types Then Node Types Must Match Should Return True| |837 ns|
|When Null Then Create Parameter Expression Should Throw Argument Null| |827 ns|
|Given Expressions With Different Node Types Then Node Types Must Match Should Return False| |826 ns|
|**Given And Then Result Should Be Logical And Of Expressions**| |**1 ms**|
| |(left: True, right: True)|676 ns|
| |(left: True, right: False)|329 ns|
| |(left: False, right: True)|317 ns|
| |(left: False, right: False)|273 ns|
|Given Same Values Then Members Must Match Should Evaluate To True| |644 ns|
|Given Condition Fails Then Should Call If False| |613 ns|
|**Given Start With And Then Result Is Logical And Of Expressions**| |**1 ms**|
| |(left: True, right: True)|560 ns|
| |(left: False, right: False)|292 ns|
| |(left: True, right: False)|278 ns|
| |(left: False, right: True)|267 ns|
|Given Different Values Then Must Be Same Type Should Evaluate To False| |559 ns|
|**Given Or Then Result Should Be Logical Or Of Expressions**| |**1 ms**|
| |(left: True, right: True)|552 ns|
| |(left: False, right: False)|283 ns|
| |(left: False, right: True)|275 ns|
| |(left: True, right: False)|275 ns|
|**Given Start With Or Then Result Should Be Logical Or Of Expressions**| |**1 ms**|
| |(left: False, right: True)|550 ns|
| |(left: True, right: True)|295 ns|
| |(left: True, right: False)|274 ns|
| |(left: False, right: False)|272 ns|
|**Given Rule That Is True Then And Types Must Be Similar Should Return True**| |**674 ns**|
| |(typesShouldBeSimilar: False)|504 ns|
| |(typesShouldBeSimilar: True)|170 ns|
|Given Expression When Not Applied Then Should Return Logical Not| |480 ns|
|**Given Rule Then Returns Result Of Rule**| |**571 ns**|
| |(result: False)|398 ns|
| |(result: True)|173 ns|
|Given Different Types Then Must Be Same Type Should Evaluate To False| |254 ns|
|Given Expression Non Similar Types Then Types Must Be Similar Should Return False| |236 ns|
|Given Expression With Similar Types Then Types Must Be Similar Should Return True| |235 ns|
|Given Same Types Then Types Must Match Should Evaluate To True| |214 ns|
|Given False Then Should Evaluate To False| |161 ns|
|Given True Then Should Evaluate To True| |159 ns|
## QuerySnapshotHostTest (29 ms)

|Test Name|Duration|
|:--|--:|
|Given Register Snapshot Called When Unregister Called Then Should Stop Calling Back|4 ms|
|Given Register Snapshot Called When Query Executed With Projection Then Should Callback Once|4 ms|
|Given Register Snapshot Called When Query Executed Twice Then Should Callback Twice|4 ms|
|Given Snapshot Host Provider When Query Executed Then Fires Query Executed Event With Expression|2 ms|
|Given Register Snapshot Called When Query Executed Then Should Callback Once|2 ms|
|Given Register Snapshot Called Multiple Times When Query Executed Then Should Call All Callbacks|2 ms|
|Given Snapshot Host Provider When Query Executed Then Fires Query Executed Event|1 ms|
|Given Snapshot Host Provider When I Enumerable Interface Used Then Should Return Enumerator|885 ns|
|Given Snapshot Host Provider When Get Enumerator Called Then Should Return Enumerator|840 ns|
|Given Null When Register Snapshot Called Then Should Throw Argument Null|822 ns|
|Given Registration When Registration Called Again Then Should Throw Invalid Operation|694 ns|
|Snapshot Host Creates Instance Of Snapshot Provider|642 ns|
|Snapshot Host Element Type Returns Type Of Query|592 ns|
|Snapshot Host Captures Expression|554 ns|
|Snapshot Host Captures Query Expression|538 ns|
## QueryInterceptingProviderTest (15 ms)

|Test Name|Duration|
|:--|--:|
|Given Registration When Child Providers Exist Then Registration Should Be Passed To Children|4 ms|
|Given Registration When Child Provider Created Then Registration Should Be Passed To Child|3 ms|
|Given Expression When Create Query Typed Called With Different Type Then Should Return Query With New Provider|1 ms|
|Given Expression When Execute Called Then Should Transform Expression And Call Source Provider|1 ms|
|Given Expression When Create Query Typed Called With Same Type Then Should Return Query With Self As Provider|1 ms|
|Given Expression When Create Query Called Then Should Return New Query Snapshot Host|842 ns|
|Given Expression When Create Query Typed Called Then Should Return New Query Host|798 ns|
|Given Expression When Create Query Called Then Should Return Query With Self As Provider|667 ns|
|Given Null Expression When Create Query Called Then Should Throw Argument Null|518 ns|
|Given Query Host When Get Enumerator Called Then Should Call Execute Enumerable On Provider|469 ns|
|Given Null Expression When Execute Called Then Should Throw Argument Null|442 ns|
|Given No Registration Then The Transformation Should Return Original Expression|439 ns|
|Given Null Expression When Create Query Typed Called Then Should Throw Argument Null|433 ns|
## CustomQueryProviderTest (8 ms)

|Test Name|Duration|
|:--|--:|
|Given Expression When Execute Enumerable Called Then Should Call Source Provider Create Query|4 ms|
|Given Null Expression When Execute Type Called Then Should Throw Argument Null|1 ms|
|Given Expression When Execute Called Then Should Call Source Provider Execute|742 ns|
|Given Expression When Execute Type Called Then Should Call Source Provider Execute|639 ns|
|Given Null Expression When Execute Called Then Should Throw Argument Null|563 ns|
|Given Null Expression When Execute Enumerable Called Then Should Throw Argument Null|539 ns|
## ExpressionEnumeratorTest (12 ms)

|Test Name|Duration|
|:--|--:|
|Given Binary With Conversion When Get Enumerator Called Then Should Include Conversion|3 ms|
|When Get Enumerator Called With New Array Expression Then Should Return Sub Expressions|3 ms|
|When Get Enumerator Called With Query Expression Then Should Return Query Parts|1 ms|
|When Get Enumerator Called With Invocation Expression Then Should Return Sub Expressions|859 ns|
|Given Null Expression When Get Enumerator Called Then Should Return Empty|527 ns|
|Given An Expression With Initialization When Get Enumerator Called Then Should Return Sub Expressions|483 ns|
|When Get Enumerator Called With New Expression Then Should Return Sub Expressions|408 ns|
|When Get Enumerator Called With Nested Constant Expression Then Should Return Enumerator|381 ns|
|Given Lambda When Enumerator Called Then Should Return Expressions|379 ns|
|Given Member Access When Enumerator Called Then Should Return Expressions|313 ns|
|Given Binary When Get Enumerator Called Then Should Return Expressions|274 ns|
|Given Method Call When Enumerator Called Then Should Return Expressions|271 ns|
|When Get Enumerator Called With Constant Expression Then Should Return Enumerator|171 ns|
|White Space Not Allowed Returns Properly Populated Argument Exception|153 ns|
|Given Unary When Enumerator Called Then Should Return Expressions|149 ns|
|Given Default When Enumerator Called Then Should Return Expressions|147 ns|
## ExceptionHelperTest (3 ms)

|Test Name|Duration|
|:--|--:|
|Null Reference Returns Properly Populated Null Reference Exception|2 ms|
|Given Null Reference Thrown Then Should Have Target Name|501 ns|
|Invalid Operation Extension With Parameters Returns Invalid Operation With Message|364 ns|
|Invalid Operation Extension Returns Invalid Operation With Message|159 ns|
|Method Call On Type Required Exception Returns Properly Populated Argument Exception|151 ns|
## QuerySnapshotProviderTest (10 ms)

|Test Name|Duration|
|:--|--:|
|Execute Enumerable Raises Query Executed|1 ms|
|Create Query For Type Registers To Propagate Events|1 ms|
|Create Query Typed Provides Same Query As Underlying Provider|1 ms|
|Create Query Provides Same Query As Underlying Provider|1 ms|
|Create Query For Type Creates New Provider For Type|876 ns|
|Create Query For Type With Same Type Uses Same Provider|837 ns|
|Create Query Creates A Query Snapshot Host With Same Provider|712 ns|
|Given Null Expression When Execute Enumerable Called Then Should Throw Argument Null|575 ns|
|Snapshot Host Provider Is The Snapshot Provider Instance|530 ns|
|Given Null Expression When Create Query Called Then Should Throw Argument Null|466 ns|
|Given Null Expression When Create Query Typed Called Then Should Throw Argument Null|463 ns|
## IExpressionEnumeratorExtensionsTest (13 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Methods With Name For Type Non Generic Should Return Method Call Expressions| |1 ms|
|Methods From Template Should Return Matching Method Call Expressions| |1 ms|
|Constants Of Type Should Return Constants Of Given Type| |1 ms|
|**Give Method Name With Null Or Whitespace When Methods With Name Called Then Should Throw Argument**| |**1 ms**|
| |(methodName: "    ")|1 ms|
| |(methodName: null)|490 ns|
|Given Unary Expressions With Same Node Type Method And Operands Then Are Similar Should Return True| |863 ns|
|**When Name Is Null Or White Space Then Methods With Name For Type Should Throw Argument**| |**1 ms**|
| |(methodName: " ")|797 ns|
| |(methodName: null)|490 ns|
|Given Non Member Expression When Methods From Template Called Then Should Throw Argument| |715 ns|
|Methods With Name For Type Should Return Method Call Expressions| |691 ns|
|When Null Constants Of Type Should Throw Argument Null| |641 ns|
|**Given Expression Type When Of Expression Type Called Then Should Return Expression With Matching Type**| |**1 ms**|
| |(type: Parameter)|637 ns|
| |(type: Lambda)|360 ns|
| |(type: Constant)|348 ns|
| |(type: Call)|331 ns|
|Given Method Name When Methods With Name Called Then Should Return Matching Method Call Expressions| |624 ns|
|Given Different Declaring Type When Methods From Template Called Then Should Throw Argument| |606 ns|
|Given Null When Methods From Template Called Then Should Throw Argument Null| |503 ns|
|When Null Methods With Name For Type Should Throw Argument Null| |363 ns|
|When Null Methods With Name Should Throw Argument Null| |306 ns|

[Go Back](./index.md)

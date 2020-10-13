# Summary of Test Runs for ExpressionPowerTools.Core

Jump to group:

- [CustomQueryProviderTest](#customqueryprovidertest-9-ms)
- [DefaultComparisonRulesTest](#defaultcomparisonrulestest-356-ms)
- [DefaultHighPerformanceRulesTest](#defaulthighperformancerulestest-350-ms)
- [EnsureTest](#ensuretest-35-ms)
- [ExceptionHelperTest](#exceptionhelpertest-1-ms)
- [ExpressionEnumeratorTest](#expressionenumeratortest-12-ms)
- [ExpressionEquivalencyTest](#expressionequivalencytest-89-ms)
- [ExpressionEquivalencyTestsWithoutRule](#expressionequivalencytestswithoutrule-64-ms)
- [ExpressionEvaluatorTest](#expressionevaluatortest-60-ms)
- [ExpressionExtensionsTest](#expressionextensionstest-18-ms)
- [ExpressionRulesExtensionsTest](#expressionrulesextensionstest-24-ms)
- [ExpressionSimilarityTest](#expressionsimilaritytest-96-ms)
- [ExpressionSimilarityTestsWithoutRule](#expressionsimilaritytestswithoutrule-92-ms)
- [IExpressionEnumeratorExtensionsTest](#iexpressionenumeratorextensionstest-20-ms)
- [IQueryableExtensionsTest](#iqueryableextensionstest-157-ms)
- [MemberAdapterTest](#memberadaptertest-521-ms)
- [QueryHostTest](#queryhosttest-15-ms)
- [QueryInterceptingProviderTest](#queryinterceptingprovidertest-16-ms)
- [QuerySnapshotHostTest](#querysnapshothosttest-30-ms)
- [QuerySnapshotProviderTest](#querysnapshotprovidertest-10-ms)
- [ServiceHostTest](#servicehosttest-268-ms)
- [ServicesTest](#servicestest-23-ms)

The slowest test was 'Given Rules For Type Exist When Get Rule For Equivalency Called Then Should Return Ruleset' at 37 ms.

## MemberAdapterTest (521 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Key When Get Member For Key Called Then Should Return Key**| |**276 ms**|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: Int32 Result{MemberAdapterTests,Int32}(ExpressionPowerTools.Core.Tests.MemberAdapterTests, System.String))|26 ms|
| |(key: "M:System.Linq.Queryable.SelectMany^^3(System.Linq."..., expected: System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.MemberAdapterTests+RelatedThing} SelectMany{{}f__AnonymousType8^3,SimpleThing,RelatedThing}(System.Linq.IQueryable^1{{}f__AnonymousType8^3{System.String,System.String,System.String}}, System.Linq.Expressions.Expression^1{System.Func^2{{}f__AnonymousType8^3{System.String,System.String,System.String},System.Collections.Generic.IEnumerable^1{ExpressionPowerTools.Core.Tests.MemberAdapterTests+SimpleThing}}}, System.Linq.Expressions.Expression^1{System.Func^3{{}f__AnonymousType8^3{System.String,System.String,System.String},ExpressionPowerTools.Core.Tests.MemberAdapterTests+SimpleThing,ExpressionPowerTools.Core.Tests.MemberAdapterTests+RelatedThing}}))|23 ms|
| |(key: "M:ExpressionPowerTools.Core.Extensions.ExpressionE"..., expected: System.Linq.Expressions.ParameterExpression CreateParameterExpression{T,TValue}(System.Linq.Expressions.Expression^1{System.Func^2{T,TValue}}))|15 ms|
| |(key: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: Boolean CheckEquivalency(System.Linq.Expressions.Expression, System.Linq.Expressions.Expression))|15 ms|
| |(key: "M:ExpressionPowerTools.Core.Hosts.QueryHost^2.#cto"..., expected: Void .ctor(System.Linq.Expressions.Expression, TProvider))|15 ms|
| |(key: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{,,}))|14 ms|
| |(key: "T:{}f__AnonymousType9{Id=System.Int32,SubAnon={}f_"..., expected: typeof({}f__AnonymousType9{int, {}f__AnonymousType10{int, string}}))|13 ms|
| |(key: "M:ExpressionPowerTools.Core.Members.MemberAdapter."..., expected: Boolean TryGetMemberInfo(System.String, System.Reflection.MemberInfo ByRef))|13 ms|
| |(key: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: Boolean CheckEquivalency{T}(T, System.Linq.Expressions.Expression))|13 ms|
| |(key: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: Boolean CheckEquivalency{ConstantExpression}(System.Linq.Expressions.ConstantExpression, System.Linq.Expressions.Expression))|12 ms|
| |(key: "M:System.Linq.Queryable.Select^^2(System.Linq.IQue"..., expected: System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.IdType} Select{IdType,IdType}(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.IdType}, System.Linq.Expressions.Expression^1{System.Func^2{ExpressionPowerTools.Core.Tests.TestHelpers.IdType,ExpressionPowerTools.Core.Tests.TestHelpers.IdType}}))|9 ms|
| |(key: "T:System.Linq.IQueryable^1", expected: typeof(System.Linq.IQueryable{}))|8 ms|
| |(key: "T:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: typeof(ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules))|7 ms|
| |(key: "P:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: Int32 Item {System.String})|6 ms|
| |(key: "M:System.Collections.Generic.List{ExpressionPowerT"..., expected: Void Add(ExpressionPowerTools.Core.Tests.MemberAdapterTests))|6 ms|
| |(key: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation))|6 ms|
| |(key: "T:System.Int32{}", expected: typeof(int{}))|5 ms|
| |(key: "M:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., expected: T GetService{T}(System.Object{}))|5 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: TResult Result{T,TResult}(T, System.String))|5 ms|
| |(key: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation, System.IComparable{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation}, char}))|5 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: TProperty Property{TProperty}(System.Object, System.String))|4 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: System.String Property{String}(System.Object, System.String))|4 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: Int32 Compare{Z}(T, Z))|4 ms|
| |(key: "M:ExpressionPowerTools.Core.Extensions.ExpressionE"..., expected: System.Linq.Expressions.ParameterExpression CreateParameterExpression{Object,String}(System.Linq.Expressions.Expression^1{System.Func^2{System.Object,System.String}}))|3 ms|
| |(key: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: Void .ctor())|3 ms|
| |(key: "E:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: System.EventHandler eventRaised)|3 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: Int32 Compare{Z}(ThingImplementation, Z))|3 ms|
| |(key: "P:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: U Value)|3 ms|
| |(key: "T:System.String", expected: typeof(string))|2 ms|
| |(key: "P:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: System.Linq.Expressions.Expression^1{System.Func^3{System.Linq.Expressions.ConstantExpression,System.Linq.Expressions.ConstantExpression,System.Boolean}} DefaultConstantRules)|2 ms|
| |(key: "F:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: System.Collections.Generic.IDictionary^2{System.Type,ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules+ExpressionComparer} cache)|2 ms|
| |(key: "T:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., expected: typeof(ExpressionPowerTools.Core.Dependencies.ServiceHost))|2 ms|
| |(key: "M:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., expected: Void .cctor())|1 ms|
|Given Bad Key When Get Member Not Found Then Should Throw Argument Exception| |12 ms|
|**Given Null Or Empty String When Called Then Should Throw Argument Exception**| |**13 ms**|
| |(key: "\t\t\n")|7 ms|
| |(key: null)|3 ms|
| |(key: "")|2 ms|
|**Given Member When Get Key For Member Called Then Should Return Key**| |**82 ms**|
| |(expected: "F:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: System.Collections.Generic.IDictionary^2{System.Type,ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules+ExpressionComparer} cache)|7 ms|
| |(expected: "T:{}f__AnonymousType9{Id=System.Int32,SubAnon={}f_"..., member: typeof({}f__AnonymousType9{int, {}f__AnonymousType10{int, string}}))|6 ms|
| |(expected: "M:ExpressionPowerTools.Core.Hosts.QueryHost^2.#cto"..., member: Void .ctor(System.Linq.Expressions.Expression, TProvider))|5 ms|
| |(expected: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: Void .ctor())|3 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: Int32 Result{MemberAdapterTests,Int32}(ExpressionPowerTools.Core.Tests.MemberAdapterTests, System.String))|2 ms|
| |(expected: "M:System.Linq.Queryable.SelectMany^^3(System.Linq."..., member: System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.MemberAdapterTests+RelatedThing} SelectMany{{}f__AnonymousType8^3,SimpleThing,RelatedThing}(System.Linq.IQueryable^1{{}f__AnonymousType8^3{System.String,System.String,System.String}}, System.Linq.Expressions.Expression^1{System.Func^2{{}f__AnonymousType8^3{System.String,System.String,System.String},System.Collections.Generic.IEnumerable^1{ExpressionPowerTools.Core.Tests.MemberAdapterTests+SimpleThing}}}, System.Linq.Expressions.Expression^1{System.Func^3{{}f__AnonymousType8^3{System.String,System.String,System.String},ExpressionPowerTools.Core.Tests.MemberAdapterTests+SimpleThing,ExpressionPowerTools.Core.Tests.MemberAdapterTests+RelatedThing}}))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: TResult Result{T,TResult}(T, System.String))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: Boolean CheckEquivalency{ConstantExpression}(System.Linq.Expressions.ConstantExpression, System.Linq.Expressions.Expression))|2 ms|
| |(expected: "M:System.Linq.Queryable.Select^^2(System.Linq.IQue"..., member: System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.IdType} Select{IdType,IdType}(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.IdType}, System.Linq.Expressions.Expression^1{System.Func^2{ExpressionPowerTools.Core.Tests.TestHelpers.IdType,ExpressionPowerTools.Core.Tests.TestHelpers.IdType}}))|2 ms|
| |(expected: "P:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: System.Linq.Expressions.Expression^1{System.Func^3{System.Linq.Expressions.ConstantExpression,System.Linq.Expressions.ConstantExpression,System.Boolean}} DefaultConstantRules)|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: Boolean CheckEquivalency(System.Linq.Expressions.Expression, System.Linq.Expressions.Expression))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: Boolean CheckEquivalency{T}(T, System.Linq.Expressions.Expression))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Extensions.ExpressionE"..., member: System.Linq.Expressions.ParameterExpression CreateParameterExpression{T,TValue}(System.Linq.Expressions.Expression^1{System.Func^2{T,TValue}}))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: Int32 Compare{Z}(T, Z))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., member: Void .cctor())|2 ms|
| |(expected: "E:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: System.EventHandler eventRaised)|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: Int32 Compare{Z}(ThingImplementation, Z))|2 ms|
| |(expected: "M:System.Collections.Generic.List{ExpressionPowerT"..., member: Void Add(ExpressionPowerTools.Core.Tests.MemberAdapterTests))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., member: T GetService{T}(System.Object{}))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Members.MemberAdapter."..., member: Boolean TryGetMemberInfo(System.String, System.Reflection.MemberInfo ByRef))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: System.String Property{String}(System.Object, System.String))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Extensions.ExpressionE"..., member: System.Linq.Expressions.ParameterExpression CreateParameterExpression{Object,String}(System.Linq.Expressions.Expression^1{System.Func^2{System.Object,System.String}}))|2 ms|
| |(expected: "T:System.Int32{}", member: typeof(int{}))|2 ms|
| |(expected: "P:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: U Value)|2 ms|
| |(expected: "P:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: Int32 Item {System.String})|1 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: TProperty Property{TProperty}(System.Object, System.String))|1 ms|
| |(expected: "T:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., member: typeof(ExpressionPowerTools.Core.Dependencies.ServiceHost))|1 ms|
| |(expected: "T:System.Linq.IQueryable^1", member: typeof(System.Linq.IQueryable{}))|1 ms|
| |(expected: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{,,}))|1 ms|
| |(expected: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation, System.IComparable{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation}, char}))|1 ms|
| |(expected: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation))|1 ms|
| |(expected: "T:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: typeof(ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules))|1 ms|
| |(expected: "T:System.String", member: typeof(string))|1 ms|
|Get Member For Key Typed Returns Correct Result| |6 ms|
|Given Null Properties When Make Anonymous Type Called Then Should Through Argument Null| |6 ms|
|Given Invalid String When Called Then Should Throw Exception With String| |6 ms|
|Given Bad Key Type When Get Member For Key Called Then Should Throw Argument| |5 ms|
|**Can Recreate All Members**| |**99 ms**|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IMemberAdapter), key: "T:ExpressionPowerTools.Core.Signatures.IMemberAdap"...)|5 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Extensions.IQueryableExtensions), key: "T:ExpressionPowerTools.Core.Extensions.IQueryableE"...)|4 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions), key: "T:ExpressionPowerTools.Core.Extensions.IExpression"...)|4 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQueryHost{,}), key: "T:ExpressionPowerTools.Core.Signatures.IQueryHost^"...)|3 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Members.MemberAdapter), key: "T:ExpressionPowerTools.Core.Members.MemberAdapter")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Dependencies.ServiceHost), key: "T:ExpressionPowerTools.Core.Dependencies.ServiceHo"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Dependencies.Services), key: "T:ExpressionPowerTools.Core.Dependencies.Services")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Contract.Ensure), key: "T:ExpressionPowerTools.Core.Contract.Ensure")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Providers.QuerySnapshotProvider{}), key: "T:ExpressionPowerTools.Core.Providers.QuerySnapsho"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Serialization.Signatures.ITypesCompressor), key: "T:ExpressionPowerTools.Serialization.Signatures.IT"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Hosts.QuerySnapshotHost{}), key: "T:ExpressionPowerTools.Core.Hosts.QuerySnapshotHos"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules), key: "T:ExpressionPowerTools.Core.Comparisons.DefaultCom"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules), key: "T:ExpressionPowerTools.Core.Comparisons.DefaultHig"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Extensions.ExpressionExtensions), key: "T:ExpressionPowerTools.Core.Extensions.ExpressionE"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.ExpressionEnumerator), key: "T:ExpressionPowerTools.Core.ExpressionEnumerator")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator), key: "T:ExpressionPowerTools.Core.Comparisons.Expression"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQuerySnapshot), key: "T:ExpressionPowerTools.Core.Signatures.IQuerySnaps"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity), key: "T:ExpressionPowerTools.Core.Comparisons.Expression"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQueryInterceptor), key: "T:ExpressionPowerTools.Core.Signatures.IQueryInter"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions), key: "T:ExpressionPowerTools.Core.Extensions.ExpressionR"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency), key: "T:ExpressionPowerTools.Core.Comparisons.Expression"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Providers.QueryInterceptingProvider{}), key: "T:ExpressionPowerTools.Core.Providers.QueryInterce"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQueryInterceptingProvider{}), key: "T:ExpressionPowerTools.Core.Signatures.IQueryInter"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator), key: "T:ExpressionPowerTools.Core.Signatures.IExpression"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IExpressionEvaluator), key: "T:ExpressionPowerTools.Core.Signatures.IExpression"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs), key: "T:ExpressionPowerTools.Core.Providers.QuerySnapsho"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.ExpressionTransformer), key: "T:ExpressionPowerTools.Core.ExpressionTransformer")|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost{}), key: "T:ExpressionPowerTools.Core.Signatures.IQuerySnaps"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider{}), key: "T:ExpressionPowerTools.Core.Signatures.IQuerySnaps"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.ICustomQueryProvider{}), key: "T:ExpressionPowerTools.Core.Signatures.ICustomQuer"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider), key: "T:ExpressionPowerTools.Core.Signatures.IExpression"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IServiceRegistration), key: "T:ExpressionPowerTools.Core.Signatures.IServiceReg"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IDependentServiceRegistration), key: "T:ExpressionPowerTools.Core.Signatures.IDependentS"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Resources.ExceptionHelper), key: "T:ExpressionPowerTools.Core.Resources.ExceptionHel"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IServices), key: "T:ExpressionPowerTools.Core.Signatures.IServices")|1 ms|
| |(expected: System.Delegate{} GetInvocationList(), key: "M:System.MulticastDelegate.GetInvocationList")|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Providers.CustomQueryProvider{}), key: "T:ExpressionPowerTools.Core.Providers.CustomQueryP"...)|1 ms|
| |(expected: Int32 GetHashCode(), key: "M:System.Object.GetHashCode")|1 ms|
| |(expected: System.Type GetType(), key: "M:System.Object.GetType")|1 ms|
| |(expected: Boolean Equals(System.Object), key: "M:System.Object.Equals(System.Object)")|1 ms|
| |(expected: System.Object Target, key: "P:System.Delegate.Target")|1 ms|
| |(expected: Void GetObjectData(System.Runtime.Serialization.SerializationInfo, System.Runtime.Serialization.StreamingContext), key: "M:System.MulticastDelegate.GetObjectData(System.Ru"...)|1 ms|
| |(expected: System.Reflection.MethodInfo Method, key: "P:System.Delegate.Method")|1 ms|
| |(expected: System.Object Clone(), key: "M:System.Delegate.Clone")|1 ms|
| |(expected: System.Object DynamicInvoke(System.Object{}), key: "M:System.Delegate.DynamicInvoke(System.Object{})")|1 ms|
|Given Anonymous Type Signature When Make Anonymous Type Called Then Should Return Anonymous Type| |4 ms|
|Given Bad Properties When Make Anonymous Type Called Then Should Return Null| |3 ms|
|Given Null Member When Get Key For Member Called Then Should Throw Argument Null Exception| |2 ms|
|Given Empty Properties When Make Anonymous Type Called Then Should Throw Argument| |2 ms|
|When Null Then As Enumerable Expression Should Throw Argument Null| |363 ns|
## IQueryableExtensionsTest (157 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Fragment Is Not In Query When Has Fragment Called Then Should Return False**| |**66 ms**|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_0(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|21 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_1(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|21 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_4(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|10 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_2(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|7 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_3(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|7 ms|
|Given Not Similar Typed Queries Is Similar To Should Return False| |14 ms|
|Given Not Similar Queries Is Similar To Should Return False| |13 ms|
|**Given Fragment Is In Query When Has Fragment Called Then Should Return True**| |**14 ms**|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_1(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|6 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_0(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|4 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_4(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|1 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_2(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|1 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_3(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|1 ms|
|Given Queryable When Create Intercepted Query Called Then Should Apply Transformation| |5 ms|
|Given Queryable When Create Snapshot Host Called Then Should Return Snapshot Registered For Callback| |5 ms|
|Given Equivalent Queries Is Equivalent To Should Return True| |5 ms|
|Given Similar Typed Queries Is Similar To Should Return True| |5 ms|
|Given Equivalent Typed Queries Is Equivalent To Should Return True| |5 ms|
|Given Not Equivalent Typed Queries Is Equivalent To Should Return False| |4 ms|
|Given Similar Queries Is Similar To Should Return True| |4 ms|
|Given Not Equivalent Queries Is Equivalent To Should Return False| |4 ms|
|Given Queryable When Create Snapshot Host Called Then Should Return Snapshot Host| |1 ms|
|Given Queryable When Create Intercepted Query Called Then Should Register Transformation| |1 ms|
|Given Queryable When Create Intercepted Query Called Then Should Return Query Host| |1 ms|
|As Enumerable Should Return I Expression Enumerator For Query Expression| |928 ns|
|Create Query Template Uses Empty List| |812 ns|
|When Null Of Expression Type Should Throw Argument Null| |804 ns|
|Create Query Template From Query Uses Empty List| |348 ns|
|Given Null Is Equivalent To Should Return False| |235 ns|
|Given Null Is Similar To Should Return False| |226 ns|
## DefaultComparisonRulesTest (356 ms)

|Test Name|Duration|
|:--|--:|
|Given Rules For Type Exist When Get Rule For Equivalency Called Then Should Return Ruleset|37 ms|
|Given Non Supported Expression Then Typed Similarity Should Return False|36 ms|
|Given No Rule Then Check Similarity Should Return False|36 ms|
|Given Similar Expressions Then Non Generic Check Similarity Should Compare|34 ms|
|Given Equivalent Expressions Then Non Generic Check Equivalency Should Compare|33 ms|
|Given Rules For Type Do Not Exist When Get Rule For Similarity Called Then Should Return Null|31 ms|
|Given Rules For Type Do Not Exist When Get Rule For Equivalency Called Then Should Return Null|30 ms|
|Given Non Supported Expression Then Typed Equivalency Should Return False|30 ms|
|Given No Rule Then Check Equivalency Should Return False|28 ms|
|Given Rules For Type Exist When Get Rule For Similarity Called Then Should Return Ruleset|27 ms|
|Given Supported Expression Then Typed Equivalency Should Return True|27 ms|
|Given Null Queryable When Custom Query Provider Created Then Should Throw Argument Null|441 ns|
## DefaultHighPerformanceRulesTest (350 ms)

|Test Name|Duration|
|:--|--:|
|Given Rules For Type Do Not Exist When Get Rule For Equivalency Called Then Should Return Null|34 ms|
|Given Rules For Type Exist When Get Rule For Similarity Called Then Should Return Ruleset|32 ms|
|Given Rules For Type Exist When Get Rule For Equivalency Called Then Should Return Ruleset|30 ms|
|Given Equivalent Expressions Then Non Generic Check Equivalency Should Compare|29 ms|
|Given Similar Expressions Then Non Generic Check Similarity Should Compare|28 ms|
|Given No Rule Then Check Equivalency Should Return False|28 ms|
|Given Supported Expression Then Typed Equivalency Should Return True|28 ms|
|Given Non Supported Expression Then Typed Equivalency Should Return False|28 ms|
|Given Non Supported Expression Then Typed Similarity Should Return False|27 ms|
|Given No Rule Then Check Similarity Should Return False|27 ms|
|Given Rules For Type Do Not Exist When Get Rule For Similarity Called Then Should Return Null|27 ms|
|Given Supported Expression Then Typed Similarity Should Return True|27 ms|
## ServiceHostTest (268 ms)

|Test Name|Duration|
|:--|--:|
|Additional Initialization After Reset Is Fine|33 ms|
|Reset Sets To Default|29 ms|
|Default Query Snapshot Host Is Query Snapshot Host|23 ms|
|Default Query Intercepting Provider Is Query Intercepting Provider|22 ms|
|Initialize Includes Default Services|22 ms|
|Default Query Host Is Query Host|18 ms|
|Default Expression Enumerator Is Expression Enumerator|18 ms|
|Creates A Default Instance Of Services|13 ms|
|Default Rules Provider Is Singleton Of Default Comparison Rules|12 ms|
|Given Registered Satellite Service When Initialize Called Then Will Override|11 ms|
|Given Satellite Implementation Of I Dependent Service Registration When Reset Called Then Should Register Service|11 ms|
|Given Registered Satellite Service When Initialize Called Then After Registered Called|11 ms|
|Default Query Snapshot Provider Is Query Snapshot Provider|11 ms|
|Default Evaluator Is Singleton Of Expression Evaluator|11 ms|
|Get Lazy Defers Resolution Until Value Acccessed|11 ms|
|Query With Projection Triggers Snapshot|3 ms|
## EnsureTest (35 ms)

|Test Name|Duration|
|:--|--:|
|Given Supported Expression Then Typed Similarity Should Return True|28 ms|
|Given Expression That Resolves To Null When Not Null Or Whitespace Called Then Should Throw Argument|2 ms|
|Given Argument Null Thrown Then Should Have Target Name|1 ms|
|Given Expression That Resolves To Whitespace When Not Null Or Whitespace Called Then Should Throw Argument|652 ns|
|Given Expression That Resolves To Null When Variable Not Null Called Then Should Throw Null Reference|565 ns|
|Given Expression That Resolves To Null When Not Null Called Then Should Throw Argument Null|401 ns|
|Given Expression That Does Not Resolve To Null When Variable Not Null Called Then Should Return|383 ns|
|Given Expression That Resolves To Value When Not Null Or Whitespace Called Then Should Return|312 ns|
|Given Expression That Does Not Resolve To Null When Not Null Called Then Should Return|310 ns|
|Given Expression Is Not Null When Variable Not Null Called Then Should Do Nothing|290 ns|
## ServicesTest (23 ms)

|Test Name|Duration|
|:--|--:|
|Second Call To Initialize Should Throw Invalid Operation|17 ms|
|Given Generic Registration When Get Service Called Then Should Implement Type|900 ns|
|Given Registered Generic Type When Same Generic Type Registered With Then Should Replace Implementation|860 ns|
|Given Registered Singleton When Same Type Registered With Singleton Then Should Replace Instance|531 ns|
|Given Registered Singleton When Get Service Called Then Should Return Singleton|454 ns|
|Given Configured When Get Service Called With Non Registered Service Then Should Throw Invalid Operation|384 ns|
|Given Registered Type When Singleton Registered Then Should Replace Type|366 ns|
|Given Null Instance When Register Singleton Called Then Should Throw Argument Null|359 ns|
|Given Registered Singleton When Type Registered Then Should Replace Singleton|356 ns|
|Given Configured When Get Service Called With Non Argument With Resolve Set Then Should Return With Argument|284 ns|
|Given Configured When Register Service Called Then Should Throw Invalid Operation|252 ns|
|Given Generic Registration When Signature Is Not Assignable From Implementation Then Should Throw Invalid Operation|208 ns|
|Given Not Configured When Get Service Called Then Should Throw Invalid Operation|208 ns|
|Given Registered Type When Same Type Registered Then Should Replace Type|199 ns|
|Given Not Configured When Get Service Called For Generic Type Then Should Throw Invalid Operation|187 ns|
|Given Configured When Get Service Called With Registered Service Then Should Return Instance|157 ns|
|Given Generic Registration When Signature Is Assignable From Implementation Then Should Not Throw Invalid Operation|83 ns|
|Given Generic Registration When Signature Base Class Of Implementation Then Should Not Throw Invalid Operation|77 ns|
## QueryHostTest (15 ms)

|Test Name|Duration|
|:--|--:|
|Keys Are Unique|12 ms|
|Given Null Provider Then Throws Argument Null|751 ns|
|Given Query Host Of Type Then Element Type Should Return Type|502 ns|
|Given Query Host Created With Expression Then Returns Same Expression|495 ns|
|Given Query Host Provider And Custom Provider Should Be Same|377 ns|
|Given Query Host Created With Provider Then Returns Same Provider|371 ns|
|Given Null Expression Then Throws Argument Null|320 ns|
## ExpressionSimilarityTestsWithoutRule (92 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Two Queries When Not Similar Then Are Similar Should Return False| |12 ms|
|Given Two Queries When Similar Then Are Similar Should Return True| |7 ms|
|Given Target With Query Parts Not Similiar When Is Part Of Called Then Should Return False| |7 ms|
|Given Target With Similar Query Parts When Is Part Of Called Then Should Return True| |3 ms|
|Given Method Call Expression With Different Arguments When Are Similar Called Then Should Return False| |1 ms|
|Given Invocation Expression When Signatures Match Then Are Similar Should Return True| |1 ms|
|Given Lambda Expression When Parameters Are Different Types Then Are Similar Should Return False| |1 ms|
|Given Lambda Expression When Bodies Are Not Similar Are Similar Then Should Return False| |1 ms|
|Given Lambda Expression When Similar Then Are Similar Should Return True| |1 ms|
|Given Lambda Expression When Parameter Count Differs Then Are Similar Should Return False| |1 ms|
|Given Lambda Expression When Singatures Match Then Are Similar Should Return True| |1 ms|
|Given Invocation Expression When Similar Then Are Similar Should Return True| |1 ms|
|Given Method Call Expression With Matching Expression And Arguments When Are Similar Called Then Should Return True| |1 ms|
|**Given Member Inits When Compared Then Are Similar Should Return Result**| |**8 ms**|
| |(source: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, target: new SimilarHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(null)}}, areSimilar: False)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = new SimilarClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = new SimilarClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new InheritedHost() {SimClass = new InheritedClass()}, areSimilar: True)|975 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = null}, areSimilar: False)|859 ns|
| |(source: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, target: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, areSimilar: True)|852 ns|
| |(source: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, target: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, areSimilar: True)|804 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost(new SimilarClass()) {SimClass = new SimilarClass()}, areSimilar: False)|628 ns|
| |(source: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, target: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, areSimilar: False)|610 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new Different() {Name = "Different"}, areSimilar: False)|253 ns|
|Given Two Inits When Arguments Are Different Then Are Similar Should Return False| |1 ms|
|Given Lambda Expression When Tail Call Is Different Then Are Similar Should Return True| |1 ms|
|**Given Binary Expressions With Same Node Type When Are Similar Called Then Should Evaluate Left And Right On Equivalency**| |**3 ms**|
| |(source: (5 + 6), target: (5 + 5), areSimilar: False)|1 ms|
| |(source: (5 + 6), target: (5 + 6), areSimilar: True)|958 ns|
| |(source: (5 + 6), target: (6 + 6), areSimilar: False)|856 ns|
|Given Method Call Expression With Static Method When Are Similar Called Then Should Return True| |1 ms|
|Given Lambda Expression When Type Is Different Then Are Similar Should Return False| |1 ms|
|Given Method Call Expression With Different Expression When Are Similar Called Then Should Return False| |1 ms|
|Given Unary Expressions With Same Node Type Method And Operands Then Are Similar Should Return True| |972 ns|
|**Given Constant With Expression Then Are Similar Should Recursively Compare**| |**3 ms**|
| |(left: 5, right: 5, Similar: False)|911 ns|
| |(left: 5, right: 5, Similar: True)|888 ns|
| |(left: 5, right: 5, Similar: True)|849 ns|
| |(left: 5, right: 5, Similar: False)|479 ns|
|Given Two Inits When Constructors Are Different Then Are Similar Should Return False| |902 ns|
|Given Method Call Expression With Different Names When Are Similar Called Then Should Return False| |879 ns|
|Given Binary Expressions When Node Types Are Different Then Are Similar Should Return False| |863 ns|
|Given Parameter With Derived Type Then Are Similar Should Return True| |826 ns|
|Given Method Call Expression With Different Argument Count When Are Similar Called Then Should Return False| |823 ns|
|Given Unary Expression When Operands Are Different Then Are Similar Should Return False| |757 ns|
|Given Member Expression When Expressions Differ Then Are Similar Should Return True| |749 ns|
|Given Method Call Expression With Different Declaring Types When Are Similar Called Then Should Return False| |742 ns|
|Given Member Expression When Type Declaring Type Member Name And Expressions Match Then Are Similar Should Return True| |726 ns|
|Given Member Expression When Declaring Types Differ Then Are Similar Should Return False| |715 ns|
|Given Enumerable Of Shorter Length Then Are Similar Should Return True| |684 ns|
|Given Two Array Initializations With Same Type And Different Contents Then Are Similar Should Return False| |671 ns|
|Given Method Call Expression With Different Return Type When Are Similar Called Then Should Return False| |591 ns|
|Given Invocation Expression When Parameters Are Different Types Then Are Similar Should Return False| |585 ns|
|Given List Of Different Type Then Are Similar Should Return False| |585 ns|
|Given List Of Same Type Then Are Similar Should Return True| |583 ns|
|Given Two Array Initializations With Same Type And Contents Then Are Similar Should Return True| |580 ns|
|Given Unary Expression When Node Types Are Different Then Are Similar Should Return False| |579 ns|
|Given Constant With Object Type And Other Type Then Are Similar Should Return False| |560 ns|
|**Given Unary Expression When Types And Operands Are Same Then Are Similar Should Evaluate Based On Methods**| |**2 ms**|
| |(source: IsTrue(True), target: IsTrue(True), areSimilar: True)|541 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: True)|512 ns|
| |(source: IsTrue(True), target: IsTrue("1"), areSimilar: False)|321 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: False)|265 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: False)|257 ns|
| |(source: IsTrue("1"), target: IsTrue(True), areSimilar: False)|252 ns|
|Given Constant With Object Type Then Are Similar Should Return False| |504 ns|
|Given Enumerable Of Longer Length Then Are Similar Should Return True| |503 ns|
|Given Enumerable Constant With Same Type Then Are Similar Should Return True| |498 ns|
|Given Enumerable Constant With Different Type Then Are Similar Should Return False| |497 ns|
|Given Two Inits When Arguments Are Same Then Are Similar Should Return True| |440 ns|
|Given Member Expression When Types Differ Then Are Similar Should Return False| |421 ns|
|Given Invocation Expression When Type Is Different Then Are Similar Should Return False| |404 ns|
|Given Member Expression When Member Names Differ Then Are Similar Should Return False| |399 ns|
|Given Expression Not Supported Then Are Similar Should Return False| |377 ns|
|Given Target Without Query Parts When Is Part Of Called Then Should Return False| |368 ns|
|Given Lambda Expression When Name Is Different Then Are Similar Should Return False| |315 ns|
|Given Parameter With Same Type And Name Then Are Similar Should Return True| |314 ns|
|Given Enumerable With Complex Types In Different Order Then Are Similar Should Return True| |306 ns|
|Given Two Array Initializations With Different Types Then Are Similar Should Return False| |300 ns|
|Given Parameter With Different Name Then Are Similar Should Return True| |297 ns|
|Given Constants Of Same Type Both Null Then Are Similar Should Return True| |294 ns|
|Given Constant With Same Reference Then Are Similar Should Return True| |294 ns|
|Given Constants Of Same Type With One Null Then Are Similar Should Return False| |290 ns|
|Given Constants With Different Values Then Are Similar Should Return False| |279 ns|
|Given Parameter With Different By Ref Then Are Similar Should Return True| |275 ns|
|Given Invocation Expression When Parameter Count Differs Then Are Similar Should Return False| |274 ns|
|Given Parameter With Different Type Then Are Similar Should Return False| |269 ns|
|Given Enumerable Target With Complex Types Has More Expressions Then Are Similar Should Return True| |266 ns|
|Given Enumerable Target With Complex Types Has Fewer Expressions Then Are Similar Should Return True| |265 ns|
|Given Two Inits When Types Are Different Then Are Similar Should Return False| |265 ns|
|Given Constant With Different Reference Then Are Similar Should Return False| |256 ns|
|Given Constants With Different Type Then Are Similar Should Return False| |252 ns|
|Given Parameter When Second Parameter Null Then Are Similar Should Return False| |145 ns|
|Given Target Null When Is Part Of Called Then Should Return False| |25 ns|
|Given Member Binding Lists Of Different Lengths When Member Bindings Are Similar Called Then Should Return False| |8 ns|
|**Given Either Expression Null Then Are Similar Should Return False**| |**10 ns**|
| |(left: null, right: null)|5 ns|
| |(left: 5, right: null)|2 ns|
| |(left: null, right: 5)|2 ns|
## ExpressionEvaluatorTest (60 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Non Similar Queryable When Are Similar Called Then Should Return False| |11 ms|
|Given Query That Is Not Part Of Other Query When Is Part Of Called Then Should Return False| |8 ms|
|Given Equivalent Queryable When Are Equivalent Called Then Should Return True| |7 ms|
|Given Similar Queryable When Are Similar Called Then Should Return True| |6 ms|
|Given Non Equivalent Queryable When Are Equivalent Called Then Should Return False| |6 ms|
|Given Similar Enumerable When Are Similar Called Then Should Return True| |2 ms|
|Given Equivalent Enumerable When Are Equivalent Called Then Should Return True| |2 ms|
|Given Non Similar Expressions When Are Similar Called Then Should Return False| |1 ms|
|Given Similar Expressions When Are Similar Called Then Should Return True| |1 ms|
|Given Non Equivalent Enumerable When Are Equivalent Called Then Should Return False| |1 ms|
|Given Non Similar Enumerable When Are Similar Called Then Should Return False| |1 ms|
|Given Equivalent Expressions When Are Equivalent Called Then Should Return True| |1 ms|
|Given Expression That Is Not Part Of Other Expression When Is Part Of Called Then Should Return False| |1 ms|
|Given Non Equivalent Expressions When Are Equivalent Called Then Should Return False| |1 ms|
|Given Expression That Is Part Of Other Expression When Is Part Of Called Then Should Return True| |1 ms|
|Given Query That Is Part Of Other Query When Is Part Of Called Then Should Return True| |973 ns|
|Handles Dictionaries Are Equivalent| |943 ns|
|Given Unary Expressions With Same Node Type Method And Operands Then Are Equivalent Should Return True| |741 ns|
|Handles Member Bindings Are Equivalent| |660 ns|
|Handle Null And Type Check| |567 ns|
|Handles Anonymous Values Are Equivalent| |248 ns|
|**Given Null And Not Null Query When Is Part Of Called Then Should Return False**| |**104 ns**|
| |(source: null, target: {})|100 ns|
| |(source: {}, target: null)|4 ns|
|**Given Null And Not Null Query When Are Similar Called Then Should Return False**| |**83 ns**|
| |(source: null, target: {})|77 ns|
| |(source: {}, target: null)|5 ns|
|**Given Null And Not Null Query When Are Equivalent Called Then Should Return False**| |**82 ns**|
| |(source: null, target: {})|76 ns|
| |(source: {}, target: null)|5 ns|
## ExpressionSimilarityTest (96 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Two Queries When Not Similar Then Are Similar Should Return False| |10 ms|
|Given Target With Query Parts Not Similiar When Is Part Of Called Then Should Return False| |7 ms|
|Given Two Queries When Similar Then Are Similar Should Return True| |7 ms|
|Given Invocation Expression When Parameters Are Different Types Then Are Similar Should Return False| |2 ms|
|Given Lambda Expression When Bodies Are Not Similar Are Similar Then Should Return False| |2 ms|
|Given Two Inits When Constructors Are Different Then Are Similar Should Return False| |2 ms|
|Given Lambda Expression When Similar Then Are Similar Should Return True| |1 ms|
|Given Invocation Expression When Signatures Match Then Are Similar Should Return True| |1 ms|
|Given Invocation Expression When Similar Then Are Similar Should Return True| |1 ms|
|Given Member Binding Lists Of Different Lengths When Member Bindings Are Similar Called Then Should Return False| |1 ms|
|Given Lambda Expression When Parameters Are Different Types Then Are Similar Should Return False| |1 ms|
|Given Lambda Expression When Parameter Count Differs Then Are Similar Should Return False| |1 ms|
|Given Lambda Expression When Singatures Match Then Are Similar Should Return True| |1 ms|
|**Given Member Inits When Compared Then Are Similar Should Return Result**| |**8 ms**|
| |(source: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, target: new SimilarHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(null)}}, areSimilar: False)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = new SimilarClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = new SimilarClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new InheritedHost() {SimClass = new InheritedClass()}, areSimilar: True)|995 ns|
| |(source: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, target: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, areSimilar: True)|946 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = null}, areSimilar: False)|856 ns|
| |(source: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, target: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, areSimilar: True)|742 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost(new SimilarClass()) {SimClass = new SimilarClass()}, areSimilar: False)|631 ns|
| |(source: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, target: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, areSimilar: False)|609 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new Different() {Name = "Different"}, areSimilar: False)|252 ns|
|Given Method Call Expression With Different Arguments When Are Similar Called Then Should Return False| |1 ms|
|Given Method Call Expression With Matching Expression And Arguments When Are Similar Called Then Should Return True| |1 ms|
|Given Method Call Expression With Static Method When Are Similar Called Then Should Return True| |1 ms|
|Given Two Inits When Arguments Are Different Then Are Similar Should Return False| |1 ms|
|Given Enumerable Constant With Same Type Then Are Similar Should Return True| |1 ms|
|Given Lambda Expression When Type Is Different Then Are Similar Should Return False| |1 ms|
|Given Lambda Expression When Tail Call Is Different Then Are Similar Should Return True| |1 ms|
|Given Target With Similar Query Parts When Is Part Of Called Then Should Return True| |1 ms|
|Given Method Call Expression With Different Expression When Are Similar Called Then Should Return False| |1 ms|
|**Given Binary Expressions With Same Node Type When Are Similar Called Then Should Evaluate Left And Right On Equivalency**| |**2 ms**|
| |(source: (5 + 6), target: (5 + 5), areSimilar: False)|1 ms|
| |(source: (5 + 6), target: (5 + 6), areSimilar: True)|844 ns|
| |(source: (5 + 6), target: (6 + 6), areSimilar: False)|577 ns|
|Given Method Call Expression With Different Argument Count When Are Similar Called Then Should Return False| |1 ms|
|Given Method Call Expression With Different Names When Are Similar Called Then Should Return False| |906 ns|
|Given Method Call Expression With Different Declaring Types When Are Similar Called Then Should Return False| |895 ns|
|Given Unary Expression When Operands Are Different Then Are Similar Should Return False| |884 ns|
|Given List Of Different Type Then Are Similar Should Return False| |873 ns|
|Given Binary Expressions When Node Types Are Different Then Are Similar Should Return False| |873 ns|
|Given Member Expression When Expressions Differ Then Are Similar Should Return True| |870 ns|
|Given Parameter With Derived Type Then Are Similar Should Return True| |868 ns|
|**Given Constant With Expression Then Are Similar Should Recursively Compare**| |**2 ms**|
| |(left: 5, right: 5, Similar: True)|840 ns|
| |(left: 5, right: 5, Similar: False)|643 ns|
| |(left: 5, right: 5, Similar: True)|596 ns|
| |(left: 5, right: 5, Similar: False)|453 ns|
|Given Member Expression When Type Declaring Type Member Name And Expressions Match Then Are Similar Should Return True| |745 ns|
|Given Two Array Initializations With Same Type And Contents Then Are Similar Should Return True| |696 ns|
|Given Two Array Initializations With Same Type And Different Contents Then Are Similar Should Return False| |695 ns|
|Given Constant With Object Type Then Are Similar Should Return False| |673 ns|
|Given Enumerable Constant With Different Type Then Are Similar Should Return False| |652 ns|
|Given Enumerable Of Shorter Length Then Are Similar Should Return True| |640 ns|
|Given Member Expression When Declaring Types Differ Then Are Similar Should Return False| |640 ns|
|Given Method Call Expression With Different Return Type When Are Similar Called Then Should Return False| |639 ns|
|Given List Of Same Type Then Are Similar Should Return True| |618 ns|
|Given Unary Expression When Node Types Are Different Then Are Similar Should Return False| |615 ns|
|Given Enumerable Of Longer Length Then Are Similar Should Return True| |603 ns|
|**Given Unary Expression When Types And Operands Are Same Then Are Similar Should Evaluate Based On Methods**| |**2 ms**|
| |(source: IsTrue(True), target: IsTrue(True), areSimilar: True)|594 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: True)|575 ns|
| |(source: IsTrue("1"), target: IsTrue(True), areSimilar: False)|362 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: False)|263 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: False)|261 ns|
| |(source: IsTrue(True), target: IsTrue("1"), areSimilar: False)|250 ns|
|Given Constant With Object Type And Other Type Then Are Similar Should Return False| |587 ns|
|Given Member Expression When Member Names Differ Then Are Similar Should Return False| |572 ns|
|Given Parameter With Different Type Then Are Similar Should Return False| |558 ns|
|Given Member Expression When Types Differ Then Are Similar Should Return False| |500 ns|
|Given Invocation Expression When Type Is Different Then Are Similar Should Return False| |495 ns|
|Given Invocation Expression When Parameter Count Differs Then Are Similar Should Return False| |479 ns|
|Given Two Inits When Arguments Are Same Then Are Similar Should Return True| |476 ns|
|Given Enumerable Target With Complex Types Has More Expressions Then Are Similar Should Return True| |474 ns|
|Given Lambda Expression When Name Is Different Then Are Similar Should Return False| |453 ns|
|Given Target Without Query Parts When Is Part Of Called Then Should Return False| |441 ns|
|Given Constants Of Same Type Both Null Then Are Similar Should Return True| |410 ns|
|Given Constants With Different Type Then Are Similar Should Return False| |395 ns|
|Given Two Array Initializations With Different Types Then Are Similar Should Return False| |385 ns|
|Given Parameter With Different Name Then Are Similar Should Return True| |374 ns|
|Given Parameter With Different By Ref Then Are Similar Should Return True| |372 ns|
|Given Constants With Different Values Then Are Similar Should Return False| |367 ns|
|Given Enumerable Target With Complex Types Has Fewer Expressions Then Are Similar Should Return True| |363 ns|
|Given Expression Not Supported Then Are Similar Should Return False| |363 ns|
|Given Enumerable With Complex Types In Different Order Then Are Similar Should Return True| |361 ns|
|Given Constant With Same Reference Then Are Similar Should Return True| |361 ns|
|Given Parameter With Same Type And Name Then Are Similar Should Return True| |355 ns|
|Given Two Inits When Types Are Different Then Are Similar Should Return False| |350 ns|
|Given Constant With Different Reference Then Are Similar Should Return False| |328 ns|
|Given Constants Of Same Type With One Null Then Are Similar Should Return False| |318 ns|
|Given Parameter When Second Parameter Null Then Are Similar Should Return False| |257 ns|
|If Then Else Defaults To True When Condition Not Met| |234 ns|
|Given Target Null When Is Part Of Called Then Should Return False| |111 ns|
|**Given Either Expression Null Then Are Similar Should Return False**| |**61 ns**|
| |(left: null, right: null)|55 ns|
| |(left: 5, right: null)|4 ns|
| |(left: null, right: 5)|2 ns|
## ExpressionEquivalencyTest (89 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Two Queries When Not Equivalent Then Are Equivalent Should Return False| |7 ms|
|**Given Member Inits When Compared Then Are Equivalent Should Return Result**| |**7 ms**|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = null}, areEquivalent: False)|2 ms|
| |(source: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}}, areEquivalent: False)|1 ms|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = new TestData()}, areEquivalent: True)|1 ms|
| |(source: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, areEquivalent: False)|923 ns|
| |(source: new TestData() {Name = "Hello"}, target: new TestData("Hello") {Name = "GoodBye"}, areEquivalent: False)|723 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new TestData() {Name = "Hello"}, areEquivalent: False)|291 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = new TestData()}, areEquivalent: True)|69 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: null, areEquivalent: False)|6 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, target: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, areEquivalent: True)|6 ns|
| |(source: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, areEquivalent: True)|2 ns|
|When Get Enumerator To String Called Then Should Return Expression Tree| |2 ms|
|Given Enumerable With Same Values In Same Order Then Are Equivalent Should Return True| |2 ms|
|Given Method Call Expression With Matching Expression And Arguments When Are Equivalent Called Then Should Return True| |1 ms|
|Given Enumerable Of Shorter Length Then Are Equivalent Should Return False| |1 ms|
|Given Two Invocations When Different Args Then Are Equivalent Should Return False| |1 ms|
|Given Lambda Expression When Equivalent Then Are Equivalent Should Return True| |1 ms|
|Given Enumerable With Items In Different Order Then Are Equivalent Should Return False| |1 ms|
|Given Two Element Inits That Are Different Values Then Values Are Equivalent Should Return False| |1 ms|
|Given Method Call Expression With Different Arguments When Are Equivalent Called Then Should Return False| |1 ms|
|Given Two Inits When Arguments Are Different Then Are Equivalent Should Return False| |1 ms|
|Given Lambda Expression When Bodies Are Not Equivalent Are Equivalent Then Should Return False| |1 ms|
|**Given Anonymous Type When Compared To Anonymous Then Values Are Equivalent Should Return Result**| |**2 ms**|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = hello }, areEquivalent: True)|1 ms|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = hello }, areEquivalent: True)|670 ns|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = goodbye }, areEquivalent: False)|16 ns|
|Given Two Element Inits That Are Same Then Values Are Equivalent Should Return True| |1 ms|
|Given Method Call Expression With Different Names When Are Equivalent Called Then Should Return False| |1 ms|
|Given Two Inits When Constructors Are Different Then Are Equivalent Should Return False| |1 ms|
|**Given Binary Expressions With Same Node Type When Are Equivalent Called Then Should Evaluate Left And Right On Equivalency**| |**2 ms**|
| |(source: (5 + 6), target: (5 + 5), areEquivalent: False)|981 ns|
| |(source: (5 + 6), target: (5 + 6), areEquivalent: True)|771 ns|
| |(source: (5 + 6), target: (6 + 6), areEquivalent: False)|513 ns|
|Given Method Call Expression With Different Argument Count When Are Equivalent Called Then Should Return False| |975 ns|
|Given Binary Expressions When Node Types Are Different Then Are Equivalent Should Return False| |970 ns|
|Given Two Array Initializations With Same Type And Contents Then Are Equivalent Should Return True| |957 ns|
|Given Method Call Expression With Different Declaring Types When Are Equivalent Called Then Should Return False| |955 ns|
|Given I Comparable Implemented And Zero Then Are Equivalent Should Return True| |949 ns|
|Given Enumerable Of Longer Length Then Are Equivalent Should Return False| |930 ns|
|Given Member Expression When Member Names Differ Then Are Equivalent Should Return False| |925 ns|
|Given Method Call Expression With Static Method When Are Equivalent Called Then Should Return True| |917 ns|
|**Given Unary Expression When Types And Operands Are Same Then Are Equivalent Should Evaluate Based On Methods**| |**2 ms**|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: True)|915 ns|
| |(source: IsTrue(True), target: IsTrue(True), areEquivalent: True)|631 ns|
| |(source: IsTrue(True), target: IsTrue("1"), areEquivalent: False)|318 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: False)|309 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: False)|297 ns|
| |(source: IsTrue("1"), target: IsTrue(True), areEquivalent: False)|286 ns|
|**Given Two I Dictionary When Dictionaries Are Equivalent Called Then Should Return Result**| |**1 ms**|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 2}}, areEqual: True)|897 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 3}}, areEqual: False)|405 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {three, 2}}, areEqual: False)|296 ns|
| |(source: {{one, 1}, {two, 2}}, target: null, areEqual: False)|166 ns|
|Given Two Element Inits That Are Different Methods Then Values Are Equivalent Should Return False| |879 ns|
|**Given Member Bindings When Compared Then Member Bindings Are Equivalent Should Return Result**| |**3 ms**|
| |(source: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}, areEquivalent: False)|871 ns|
| |(source: TestProp = new TestData(), target: TestProp = new TestData(), areEquivalent: True)|585 ns|
| |(source: TestProp = new TestData(), target: TestProp = new TestData(), areEquivalent: True)|510 ns|
| |(source: Name = "Hello", target: Name = "GoodBye", areEquivalent: False)|432 ns|
| |(source: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, areEquivalent: True)|275 ns|
| |(source: TestProp = {Name = "ExpressionEquivalencyTests"}, target: TestProp = {Name = "ExpressionEquivalencyTests"}, areEquivalent: True)|262 ns|
| |(source: TestProp = new TestData(), target: null, areEquivalent: False)|149 ns|
| |(source: TestProp = new TestData(), target: Name = "Hello", areEquivalent: False)|146 ns|
| |(source: TestProp = new TestData(), target: TestProp = null, areEquivalent: False)|135 ns|
| |(source: TestProp = {Name = "ExpressionEquivalencyTests"}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, areEquivalent: False)|130 ns|
|Given Unary Expression When Operands Are Different Then Are Equivalent Should Return False| |866 ns|
|Given Member Expression When Expressions Differ Then Are Equivalent Should Return False| |863 ns|
|Given Enumerable Constant With Different Members Then Are Equivalent Should Return False| |850 ns|
|Given I Equatable Implemented And True Then Are Equivalent Should Return True| |840 ns|
|Given Member Expression When Declaring Types Differ Then Are Equivalent Should Return False| |839 ns|
|Given Enumerable Constant With Same Members Then Are Equivalent Should Return True| |835 ns|
|Given Enumerable With Different Values Then Are Equivalent Should Return False| |835 ns|
|Given Anonymous Parameter With Different Signature Then Are Equivalent Should Return False| |821 ns|
|Given Method Call Expression With Different Expression When Are Equivalent Called Then Should Return False| |820 ns|
|Given Enumerable Constant With Target Null Then Are Equivalent Should Return False| |819 ns|
|Given Enumerable Constant With Source Null Then Are Equivalent Should Return False| |810 ns|
|Given Anonymous Parameter With Same Siganture Then Are Equivalent Should Return True| |802 ns|
|Given I Equatable Implemented And False Then Are Equivalent Should Return False| |801 ns|
|Given Two Array Initializations With Same Type And Different Contents Then Are Equivalent Should Return False| |786 ns|
|**Given Constant With Expression Then Are Equivalent Should Recursively Compare**| |**2 ms**|
| |(left: 5, right: 5, equivalent: False)|771 ns|
| |(left: 5, right: 5, equivalent: True)|736 ns|
| |(left: 5, right: 5, equivalent: True)|520 ns|
| |(left: 5, right: 5, equivalent: False)|340 ns|
|Given Lambda Expression When Type Is Different Then Are Equivalent Should Return False| |769 ns|
|Given Constant With Same Reference Then Are Equivalent Should Return True| |732 ns|
|Given Method Call Expression With Different Return Type When Are Equivalent Called Then Should Return False| |658 ns|
|Given I Comparable Implemented And Not Zero Then Are Equivalent Should Return False| |633 ns|
|Given Lambda Expression When Tail Call Is Different Then Are Equivalent Should Return False| |616 ns|
|Given Unary Expression When Node Types Are Different Then Are Equivalent Should Return False| |610 ns|
|Given Lambda Expression When Parameters Are Not Equivalent Then Are Equivalent Should Return False| |608 ns|
|Given Two Inits When Arguments Are Same Then Are Equivalent Should Return True| |605 ns|
|Given Member Expression When Types Differ Then Are Equivalent Should Return False| |556 ns|
|Given Member Expression When Type Declaring Type Member Name And Expressions Match Then Are Equivalent Should Return True| |539 ns|
|Given Enumerable Target Has More Expressions Then Are Equivalent Should Return False| |536 ns|
|Given Enumerable Query When Of Different Type Then Are Equivalent Should Be False| |515 ns|
|Given Enumerable Target Has Fewer Expressions Then Are Equivalent Should Return False| |495 ns|
|**Given Two I Dictionary When Values Are Equivalent Called Then Should Return Result**| |**1 ms**|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 2}}, areEqual: True)|494 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 3}}, areEqual: False)|416 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {three, 2}}, areEqual: False)|312 ns|
| |(source: {{one, 1}, {two, 2}}, target: null, areEqual: False)|143 ns|
|Given Enumerable Query When Of Same Type Then Are Equivalent Should Be True| |459 ns|
|Given Lambda Expression When Name Is Different Then Are Equivalent Should Return False| |452 ns|
|Given Parameter With Same Type And Name Then Are Equivalent Should Return True| |423 ns|
|Given Parameter With Different Name Then Are Equivalent Should Return False| |405 ns|
|Given One Element Inits And One Not Element Init Then Values Are Equivalent Should Return False| |403 ns|
|Given Two Array Initializations With Different Types Then Are Equivalent Should Return False| |387 ns|
|Given Two Inits When Types Are Different Then Are Equivalent Should Return False| |379 ns|
|Given Constants Of Same Type Both Null Then Are Equivalent Should Return True| |376 ns|
|Given Two Invocations When Different Types Then Are Equivalent Should Return False| |361 ns|
|Given Constants With Different Type Then Are Equivalent Should Return False| |360 ns|
|Given Constant With Different Reference Then Are Equivalent Should Return False| |358 ns|
|Given Expression Not Supported Then Are Equivalent Should Return False| |346 ns|
|Given Constants With Different Values Then Are Equivalent Should Return False| |344 ns|
|**Given Two Types When Types Are Equivalent Then Should Return Result**| |**563 ns**|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType4{int, int}), areEquivalent: False)|337 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType3{int}), areEquivalent: True)|135 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType6{int}), areEquivalent: False)|31 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType3{string}), areEquivalent: False)|29 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType5{int}), areEquivalent: False)|25 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof(object), areEquivalent: False)|5 ns|
|Given Lambda Expression When Parameter Count Differs Then Are Equivalent Should Return False| |276 ns|
|**Given Two Enumerables When Values Are Equivalent Called Then Should Resolve Without Enumerating String**| |**688 ns**|
| |(source: {'G', 'e', 't', 'E', 'n', ...}, target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: True)|273 ns|
| |(source: {"one", "two"}, target: {"one", "two"}, areEquivalent: True)|171 ns|
| |(source: {"one", "two"}, target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: False)|153 ns|
| |(source: "GetEnumerableValuesMatrix", target: "matrix", areEquivalent: False)|77 ns|
| |(source: "GetEnumerableValuesMatrix", target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: False)|6 ns|
| |(source: "GetEnumerableValuesMatrix", target: "GetEnumerableValuesMatrix", areEquivalent: True)|5 ns|
|Given Two Queries When Equivalent Then Are Equivalent Should Return True| |271 ns|
|Given Enumerable With Target Null Then Are Equivalent Should Return False| |226 ns|
|Are Equivalent Non Generic Enumerable With Null Target Should Return False| |216 ns|
|Given Parameter With Different Type Then Are Equivalent Should Return False| |135 ns|
|Given Parameter With Different By Ref Then Are Equivalent Should Return False| |123 ns|
|Given Exception Of Different Type When Values Are Equivalent Called Then Should Return False| |101 ns|
|Given Two Invocations When Different Then Are Equivalent Should Return False| |100 ns|
|Given Two Methods That Are Different Then Values Are Equivalent Should Return False| |94 ns|
|Given Enumerable Query When Target Is Not Enumerable Query Then Values Are Equivalent Should Be False| |91 ns|
|Given Exception Of Same Type And Message When Values Are Equivalent Called Then Should Return True| |87 ns|
|**Given Two Invocations When Same Then Are Equivalent Should Return True**| |**94 ns**|
| |(invocation: Invoke(() =} True))|85 ns|
| |(invocation: Invoke(() =} "FuncString"))|6 ns|
| |(invocation: Invoke(i =} (i } 2), i))|3 ns|
|Are Equivalent With Null Target Should Return False| |75 ns|
|Given Exception Of Same Type And Different Message When Values Are Equivalent Called Then Should Return False| |66 ns|
|Given Constants Of Same Type With One Null Then Are Equivalent Should Return False| |59 ns|
|Given Same Expression Then Are Equivalent Should Return True| |58 ns|
|**Given Either Expression Null Then Are Equivalent Should Return False**| |**61 ns**|
| |(left: 5, right: null)|56 ns|
| |(left: null, right: 5)|4 ns|
## ExpressionEquivalencyTestsWithoutRule (64 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Two Queries When Not Equivalent Then Are Equivalent Should Return False| |6 ms|
|Given Lambda Expression When Equivalent Then Are Equivalent Should Return True| |3 ms|
|Given Enumerable With Same Values In Same Order Then Are Equivalent Should Return True| |1 ms|
|**Given Member Inits When Compared Then Are Equivalent Should Return Result**| |**5 ms**|
| |(source: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}}, areEquivalent: False)|1 ms|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = new TestData()}, areEquivalent: True)|1 ms|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = null}, areEquivalent: False)|884 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, areEquivalent: False)|852 ns|
| |(source: new TestData() {Name = "Hello"}, target: new TestData("Hello") {Name = "GoodBye"}, areEquivalent: False)|655 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new TestData() {Name = "Hello"}, areEquivalent: False)|283 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, target: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, areEquivalent: True)|5 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = new TestData()}, areEquivalent: True)|5 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: null, areEquivalent: False)|3 ns|
| |(source: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, areEquivalent: True)|2 ns|
|Given Lambda Expression When Bodies Are Not Equivalent Are Equivalent Then Should Return False| |1 ms|
|Given Method Call Expression With Matching Expression And Arguments When Are Equivalent Called Then Should Return True| |1 ms|
|Given Method Call Expression With Different Arguments When Are Equivalent Called Then Should Return False| |1 ms|
|Given Unary Expression When Operands Are Different Then Are Equivalent Should Return False| |998 ns|
|Given Enumerable Constant With Target Null Then Are Equivalent Should Return False| |912 ns|
|Given Two Inits When Arguments Are Different Then Are Equivalent Should Return False| |899 ns|
|**Given Member Bindings When Compared Then Member Bindings Are Equivalent Should Return Result**| |**2 ms**|
| |(source: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}, areEquivalent: False)|863 ns|
| |(source: TestProp = new TestData(), target: TestProp = new TestData(), areEquivalent: True)|501 ns|
| |(source: Name = "Hello", target: Name = "GoodBye", areEquivalent: False)|395 ns|
| |(source: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, areEquivalent: True)|258 ns|
| |(source: TestProp = {Name = "ExpressionEquivalencyTests"}, target: TestProp = {Name = "ExpressionEquivalencyTests"}, areEquivalent: True)|256 ns|
| |(source: TestProp = new TestData(), target: TestProp = new TestData(), areEquivalent: True)|146 ns|
| |(source: TestProp = new TestData(), target: null, areEquivalent: False)|141 ns|
| |(source: TestProp = new TestData(), target: Name = "Hello", areEquivalent: False)|138 ns|
| |(source: TestProp = new TestData(), target: TestProp = null, areEquivalent: False)|135 ns|
| |(source: TestProp = {Name = "ExpressionEquivalencyTests"}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, areEquivalent: False)|129 ns|
|Given Binary Expressions When Node Types Are Different Then Are Equivalent Should Return False| |860 ns|
|Given Method Call Expression With Different Argument Count When Are Equivalent Called Then Should Return False| |858 ns|
|Given Unary Expressions With Same Node Type Method And Operands Then Are Equivalent Should Return True| |845 ns|
|Given Two Element Inits That Are Same Then Values Are Equivalent Should Return True| |792 ns|
|Given I Comparable Implemented And Not Zero Then Are Equivalent Should Return False| |791 ns|
|Given Two Invocations When Different Args Then Are Equivalent Should Return False| |789 ns|
|**Given Binary Expressions With Same Node Type When Are Equivalent Called Then Should Evaluate Left And Right On Equivalency**| |**2 ms**|
| |(source: (5 + 6), target: (5 + 5), areEquivalent: False)|782 ns|
| |(source: (5 + 6), target: (5 + 6), areEquivalent: True)|753 ns|
| |(source: (5 + 6), target: (6 + 6), areEquivalent: False)|500 ns|
|Given Method Call Expression With Different Names When Are Equivalent Called Then Should Return False| |759 ns|
|Given Method Call Expression With Different Declaring Types When Are Equivalent Called Then Should Return False| |755 ns|
|**Given Constant With Expression Then Are Equivalent Should Recursively Compare**| |**2 ms**|
| |(left: 5, right: 5, equivalent: False)|747 ns|
| |(left: 5, right: 5, equivalent: True)|726 ns|
| |(left: 5, right: 5, equivalent: True)|495 ns|
| |(left: 5, right: 5, equivalent: False)|281 ns|
|Given Member Expression When Expressions Differ Then Are Equivalent Should Return False| |735 ns|
|**Given Unary Expression When Types And Operands Are Same Then Are Equivalent Should Evaluate Based On Methods**| |**2 ms**|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: True)|691 ns|
| |(source: IsTrue(True), target: IsTrue(True), areEquivalent: True)|508 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: False)|274 ns|
| |(source: IsTrue("1"), target: IsTrue(True), areEquivalent: False)|268 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: False)|263 ns|
| |(source: IsTrue(True), target: IsTrue("1"), areEquivalent: False)|256 ns|
|Given Enumerable Constant With Source Null Then Are Equivalent Should Return False| |689 ns|
|Given Enumerable Of Shorter Length Then Are Equivalent Should Return False| |689 ns|
|Given Two Array Initializations With Same Type And Different Contents Then Are Equivalent Should Return False| |689 ns|
|Given Two Inits When Constructors Are Different Then Are Equivalent Should Return False| |681 ns|
|Given Method Call Expression With Static Method When Are Equivalent Called Then Should Return True| |652 ns|
|Given Two Array Initializations With Same Type And Contents Then Are Equivalent Should Return True| |652 ns|
|Given Enumerable Constant With Different Members Then Are Equivalent Should Return False| |643 ns|
|Given I Equatable Implemented And True Then Are Equivalent Should Return True| |639 ns|
|Given Enumerable Of Longer Length Then Are Equivalent Should Return False| |637 ns|
|Given Method Call Expression With Different Expression When Are Equivalent Called Then Should Return False| |633 ns|
|Given Enumerable Constant With Same Members Then Are Equivalent Should Return True| |632 ns|
|Given I Comparable Implemented And Zero Then Are Equivalent Should Return True| |601 ns|
|Given Anonymous Parameter With Same Siganture Then Are Equivalent Should Return True| |548 ns|
|Given Lambda Expression When Type Is Different Then Are Equivalent Should Return False| |541 ns|
|Given I Equatable Implemented And False Then Are Equivalent Should Return False| |541 ns|
|Given Anonymous Parameter With Different Signature Then Are Equivalent Should Return False| |533 ns|
|Given Method Call Expression With Different Return Type When Are Equivalent Called Then Should Return False| |518 ns|
|Given Member Expression When Declaring Types Differ Then Are Equivalent Should Return False| |505 ns|
|Given Unary Expression When Node Types Are Different Then Are Equivalent Should Return False| |503 ns|
|**Given Two I Dictionary When Values Are Equivalent Called Then Should Return Result**| |**1 ms**|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 2}}, areEqual: True)|466 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 3}}, areEqual: False)|402 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {three, 2}}, areEqual: False)|277 ns|
| |(source: {{one, 1}, {two, 2}}, target: null, areEqual: False)|139 ns|
|Given Two Element Inits That Are Different Values Then Values Are Equivalent Should Return False| |432 ns|
|Given Member Expression When Type Declaring Type Member Name And Expressions Match Then Are Equivalent Should Return True| |422 ns|
|Given Enumerable Target Has Fewer Expressions Then Are Equivalent Should Return False| |416 ns|
|**Given Two I Dictionary When Dictionaries Are Equivalent Called Then Should Return Result**| |**1 ms**|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 2}}, areEqual: True)|401 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 3}}, areEqual: False)|385 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {three, 2}}, areEqual: False)|261 ns|
| |(source: {{one, 1}, {two, 2}}, target: null, areEqual: False)|136 ns|
|Given Two Inits When Arguments Are Same Then Are Equivalent Should Return True| |400 ns|
|Given Enumerable Target Has More Expressions Then Are Equivalent Should Return False| |393 ns|
|Given Member Expression When Types Differ Then Are Equivalent Should Return False| |388 ns|
|Given Enumerable With Different Values Then Are Equivalent Should Return False| |387 ns|
|Given Enumerable With Items In Different Order Then Are Equivalent Should Return False| |387 ns|
|Given Member Expression When Member Names Differ Then Are Equivalent Should Return False| |385 ns|
|Given Constants With Different Type Then Are Equivalent Should Return False| |363 ns|
|Given Two Element Inits That Are Different Methods Then Values Are Equivalent Should Return False| |326 ns|
|Given Parameter With Same Type And Name Then Are Equivalent Should Return True| |303 ns|
|Given Constant With Different Reference Then Are Equivalent Should Return False| |302 ns|
|Given Two Inits When Types Are Different Then Are Equivalent Should Return False| |292 ns|
|Given Two Array Initializations With Different Types Then Are Equivalent Should Return False| |285 ns|
|Given Enumerable Query When Of Different Type Then Are Equivalent Should Be False| |282 ns|
|Given Constants Of Same Type Both Null Then Are Equivalent Should Return True| |274 ns|
|Given Lambda Expression When Tail Call Is Different Then Are Equivalent Should Return False| |272 ns|
|Given Lambda Expression When Name Is Different Then Are Equivalent Should Return False| |271 ns|
|Given Constant With Same Reference Then Are Equivalent Should Return True| |268 ns|
|Given Constants With Different Values Then Are Equivalent Should Return False| |266 ns|
|Given Two Invocations When Different Types Then Are Equivalent Should Return False| |266 ns|
|Given Enumerable Query When Of Same Type Then Are Equivalent Should Be True| |264 ns|
|Given Parameter With Different Name Then Are Equivalent Should Return False| |258 ns|
|Given Expression Not Supported Then Are Equivalent Should Return False| |254 ns|
|**Given Two Enumerables When Values Are Equivalent Called Then Should Resolve Without Enumerating String**| |**487 ns**|
| |(source: {'G', 'e', 't', 'E', 'n', ...}, target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: True)|185 ns|
| |(source: {"one", "two"}, target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: False)|139 ns|
| |(source: {"one", "two"}, target: {"one", "two"}, areEquivalent: True)|139 ns|
| |(source: "GetEnumerableValuesMatrix", target: "matrix", areEquivalent: False)|10 ns|
| |(source: "GetEnumerableValuesMatrix", target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: False)|6 ns|
| |(source: "GetEnumerableValuesMatrix", target: "GetEnumerableValuesMatrix", areEquivalent: True)|5 ns|
|Given Two Queries When Equivalent Then Are Equivalent Should Return True| |160 ns|
|Given One Element Inits And One Not Element Init Then Values Are Equivalent Should Return False| |155 ns|
|Given Enumerable With Target Null Then Are Equivalent Should Return False| |144 ns|
|Are Equivalent Non Generic Enumerable With Null Target Should Return False| |139 ns|
|Given Lambda Expression When Parameters Are Not Equivalent Then Are Equivalent Should Return False| |113 ns|
|Given Exception Of Different Type When Values Are Equivalent Called Then Should Return False| |50 ns|
|**Given Two Types When Types Are Equivalent Then Should Return Result**| |**146 ns**|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType3{string}), areEquivalent: False)|48 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType4{int, int}), areEquivalent: False)|29 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType6{int}), areEquivalent: False)|28 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType5{int}), areEquivalent: False)|24 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType3{int}), areEquivalent: True)|11 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof(object), areEquivalent: False)|4 ns|
|**Given Anonymous Type When Compared To Anonymous Then Values Are Equivalent Should Return Result**| |**61 ns**|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = hello }, areEquivalent: True)|39 ns|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = goodbye }, areEquivalent: False)|15 ns|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = hello }, areEquivalent: True)|6 ns|
|Given Two Methods That Are Different Then Values Are Equivalent Should Return False| |31 ns|
|Given Lambda Expression When Parameter Count Differs Then Are Equivalent Should Return False| |19 ns|
|Given Two Invocations When Different Then Are Equivalent Should Return False| |11 ns|
|Given Exception Of Same Type And Different Message When Values Are Equivalent Called Then Should Return False| |11 ns|
|Given Same Expression Then Are Equivalent Should Return True| |9 ns|
|Given Parameter With Different By Ref Then Are Equivalent Should Return False| |9 ns|
|Given Exception Of Same Type And Message When Values Are Equivalent Called Then Should Return True| |8 ns|
|Given Enumerable Query When Target Is Not Enumerable Query Then Values Are Equivalent Should Be False| |7 ns|
|Given Constants Of Same Type With One Null Then Are Equivalent Should Return False| |7 ns|
|**Given Two Invocations When Same Then Are Equivalent Should Return True**| |**10 ns**|
| |(invocation: Invoke(() =} True))|5 ns|
| |(invocation: Invoke(() =} "FuncString"))|2 ns|
| |(invocation: Invoke(i =} (i } 2), i))|2 ns|
|Are Equivalent With Null Target Should Return False| |5 ns|
|**Given Either Expression Null Then Are Equivalent Should Return False**| |**7 ns**|
| |(left: 5, right: null)|4 ns|
| |(left: null, right: 5)|2 ns|
|Given Parameter With Different Type Then Are Equivalent Should Return False| |4 ns|
## CustomQueryProviderTest (9 ms)

|Test Name|Duration|
|:--|--:|
|Given Expression When Execute Enumerable Called Then Should Call Source Provider Create Query|5 ms|
|Given Null Expression When Execute Type Called Then Should Throw Argument Null|1 ms|
|Given Expression When Execute Called Then Should Call Source Provider Execute|813 ns|
|Given Expression When Execute Type Called Then Should Call Source Provider Execute|761 ns|
|Given Null Expression When Execute Called Then Should Throw Argument Null|749 ns|
|Given Null Expression When Execute Enumerable Called Then Should Throw Argument Null|570 ns|
## QuerySnapshotHostTest (30 ms)

|Test Name|Duration|
|:--|--:|
|Given Register Snapshot Called When Query Executed With Projection Then Should Callback Once|4 ms|
|Given Register Snapshot Called When Unregister Called Then Should Stop Calling Back|4 ms|
|Given Register Snapshot Called When Query Executed Twice Then Should Callback Twice|3 ms|
|Given Register Snapshot Called When Query Executed Then Should Callback Once|2 ms|
|Given Snapshot Host Provider When Query Executed Then Fires Query Executed Event With Expression|2 ms|
|Given Register Snapshot Called Multiple Times When Query Executed Then Should Call All Callbacks|2 ms|
|Given Null When Register Snapshot Called Then Should Throw Argument Null|2 ms|
|Given Snapshot Host Provider When Query Executed Then Fires Query Executed Event|1 ms|
|Given Snapshot Host Provider When I Enumerable Interface Used Then Should Return Enumerator|867 ns|
|Given Snapshot Host Provider When Get Enumerator Called Then Should Return Enumerator|842 ns|
|Given Registration When Registration Called Again Then Should Throw Invalid Operation|744 ns|
|Snapshot Host Captures Expression|569 ns|
|Snapshot Host Element Type Returns Type Of Query|565 ns|
|Snapshot Host Captures Query Expression|538 ns|
|Snapshot Host Creates Instance Of Snapshot Provider|526 ns|
## ExpressionExtensionsTest (18 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Expression Part Of Target When Is Part Of Called Then Should Return True| |4 ms|
|Given Generic Type With Anonymous Closures When Is Or Contains Anonymous Type Called Then Should Return True| |1 ms|
|**As Invocation Expression With Parameters Should Return Invocation**| |**1 ms**|
| |(expr: i =} (i } 2))|1 ms|
| |(expr: (a, b) =} Convert((a * b), Int64))|348 ns|
|Given Expression Not Part Of Target When Is Part Of Called Then Should Return False| |1 ms|
|Given Expressions Are Equivalent When Is Equivalent To Called Then Should Return True| |795 ns|
|Given Expressions Are Not Equivalent When Is Equivalent To Called Then Should Return False| |781 ns|
|Given Expressions Are Not Similar When Is Similar To Called Then Should Return False| |737 ns|
|Given Expressions Are Similar When Is Similar To Called Then Should Return True| |690 ns|
|As Parameter Expression For Object Should Return Parameter Expression Of Object Type| |627 ns|
|As Parameter Expression For Object With Name Should Return Parameter Expression Of Object Type With Name| |569 ns|
|Create Parameter Expression Should Create Parameter With Name| |491 ns|
|When Null Then As Enumerable Should Throw Argument Null| |456 ns|
|As Parameter Expression For Object By Ref Should Return Parameter Expression Of Object Type By Ref| |392 ns|
|When Null Then As Parameter Expresion For Type Should Throw Argument Null| |382 ns|
|When Null Then As Parameter Expression For Object Should Throw Null Argument| |354 ns|
|When Null Then As Constant Expression Should Throw Argument Null| |337 ns|
|As Invocation Expression With No Parameters Should Return Invocation| |331 ns|
|Create Parameter Expression Should Create Parameter With Parent Type| |321 ns|
|As Parameter Expression For Type With Name Should Return Parameter Expression For Type With Name| |318 ns|
|Handles Non Generic Enumerables Are Equivalent| |292 ns|
|As Constant Expression Should Return Constant Expression With Value| |252 ns|
|As Parameter Expression For Type By Ref Should Return Parameter Expression For Type By Ref| |247 ns|
|As Parameter Expression For Type Should Return Parameter Expression For Type| |246 ns|
|As Enumerable Should Return I Expression Enumerator| |237 ns|
|Given Expression When Member Name Extension Called Then Should Return Name| |183 ns|
|Given Generic Type With No Anonymous Closures When Is Or Contains Anonymous Type Called Then Should Return False| |70 ns|
|Given Type Is Anonymous When Is Anonymous Type Called Then Should Return True| |68 ns|
|Given Type Is Not Anonymous When Is Anonymous Type Called Then Should Return False| |53 ns|
## QueryInterceptingProviderTest (16 ms)

|Test Name|Duration|
|:--|--:|
|Given Registration When Child Providers Exist Then Registration Should Be Passed To Children|4 ms|
|Given Registration When Child Provider Created Then Registration Should Be Passed To Child|3 ms|
|Given Expression When Create Query Typed Called With Different Type Then Should Return Query With New Provider|1 ms|
|Given Expression When Execute Called Then Should Transform Expression And Call Source Provider|1 ms|
|Given Expression When Create Query Typed Called With Same Type Then Should Return Query With Self As Provider|1 ms|
|Given Expression When Create Query Typed Called Then Should Return New Query Host|845 ns|
|Given Expression When Create Query Called Then Should Return New Query Snapshot Host|843 ns|
|Given Expression When Create Query Called Then Should Return Query With Self As Provider|718 ns|
|Given Null Expression When Create Query Called Then Should Throw Argument Null|479 ns|
|Given Null Expression When Create Query Typed Called Then Should Throw Argument Null|458 ns|
|Given Null Expression When Execute Called Then Should Throw Argument Null|451 ns|
|Given Query Host When Get Enumerator Called Then Should Call Execute Enumerable On Provider|448 ns|
|Given No Registration Then The Transformation Should Return Original Expression|430 ns|
## ExpressionRulesExtensionsTest (24 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Or Then Result Should Be Logical Or Of Expressions**| |**2 ms**|
| |(left: True, right: True)|1 ms|
| |(left: True, right: False)|274 ns|
| |(left: False, right: False)|273 ns|
| |(left: False, right: True)|265 ns|
|**Given To Rule Of Type Then Should Create Rule For Converted Types**| |**2 ms**|
| |(sourceVal: 1, targetVal: 2, expected: False)|1 ms|
| |(sourceVal: 1, targetVal: 1, expected: True)|619 ns|
| |(sourceVal: 2, targetVal: 1, expected: False)|594 ns|
|**Given Global Rule Then Should Evaluate Based On Expression Type**| |**1 ms**|
| |(sourceValue: 1, expected: True)|1 ms|
| |(sourceValue: 2, expected: False)|733 ns|
|**Given False Rule Or Expression With Same Node Types Then Or Must Match Should Evaluate Node Types**| |**1 ms**|
| |(nodeTypesShouldMatch: False)|1 ms|
| |(nodeTypesShouldMatch: True)|744 ns|
|Given Expressions With Same Node Types Then Node Types Must Match Should Return True| |831 ns|
|When Null Then Create Parameter Expression Should Throw Argument Null| |822 ns|
|Given Expressions With Different Node Types Then Node Types Must Match Should Return False| |819 ns|
|**Given And Then Result Should Be Logical And Of Expressions**| |**1 ms**|
| |(left: True, right: True)|677 ns|
| |(left: False, right: True)|276 ns|
| |(left: False, right: False)|272 ns|
| |(left: True, right: False)|267 ns|
|**Given If Then Result Should Be Based On Evaluation Of If Then Else**| |**3 ms**|
| |(ifCondition: True, thenCondition: True, elseCondition: null, expected: True)|665 ns|
| |(ifCondition: False, thenCondition: False, elseCondition: True, expected: True)|343 ns|
| |(ifCondition: False, thenCondition: True, elseCondition: True, expected: True)|336 ns|
| |(ifCondition: False, thenCondition: False, elseCondition: null, expected: True)|289 ns|
| |(ifCondition: False, thenCondition: True, elseCondition: False, expected: False)|289 ns|
| |(ifCondition: False, thenCondition: True, elseCondition: null, expected: True)|283 ns|
| |(ifCondition: True, thenCondition: True, elseCondition: False, expected: True)|282 ns|
| |(ifCondition: True, thenCondition: False, elseCondition: False, expected: False)|282 ns|
| |(ifCondition: False, thenCondition: False, elseCondition: False, expected: False)|281 ns|
| |(ifCondition: True, thenCondition: False, elseCondition: True, expected: False)|280 ns|
| |(ifCondition: True, thenCondition: False, elseCondition: null, expected: False)|277 ns|
| |(ifCondition: True, thenCondition: True, elseCondition: True, expected: True)|276 ns|
|Given Same Values Then Members Must Match Should Evaluate To True| |558 ns|
|**Given Start With Or Then Result Should Be Logical Or Of Expressions**| |**1 ms**|
| |(left: False, right: True)|555 ns|
| |(left: True, right: False)|274 ns|
| |(left: False, right: False)|274 ns|
| |(left: True, right: True)|271 ns|
|Given Different Values Then Must Be Same Type Should Evaluate To False| |546 ns|
|Given Condition Fails Then Should Call If False| |541 ns|
|**Given Start With And Then Result Is Logical And Of Expressions**| |**1 ms**|
| |(left: True, right: True)|540 ns|
| |(left: True, right: False)|365 ns|
| |(left: False, right: True)|275 ns|
| |(left: False, right: False)|271 ns|
|Given Expression When Not Applied Then Should Return Logical Not| |461 ns|
|**Given Rule That Is True Then And Types Must Be Similar Should Return True**| |**632 ns**|
| |(typesShouldBeSimilar: False)|434 ns|
| |(typesShouldBeSimilar: True)|197 ns|
|**Given Rule Then Returns Result Of Rule**| |**599 ns**|
| |(result: False)|381 ns|
| |(result: True)|217 ns|
|Given Different Types Then Must Be Same Type Should Evaluate To False| |258 ns|
|Given Expression With Similar Types Then Types Must Be Similar Should Return True| |243 ns|
|Given Expression Non Similar Types Then Types Must Be Similar Should Return False| |231 ns|
|Given Same Types Then Types Must Match Should Evaluate To True| |216 ns|
|Given False Then Should Evaluate To False| |161 ns|
|Given True Then Should Evaluate To True| |157 ns|
## ExpressionEnumeratorTest (12 ms)

|Test Name|Duration|
|:--|--:|
|Given Binary With Conversion When Get Enumerator Called Then Should Include Conversion|3 ms|
|When Get Enumerator Called With New Array Expression Then Should Return Sub Expressions|3 ms|
|When Get Enumerator Called With Query Expression Then Should Return Query Parts|1 ms|
|When Get Enumerator Called With Invocation Expression Then Should Return Sub Expressions|782 ns|
|Given Null Expression When Get Enumerator Called Then Should Return Empty|530 ns|
|Given An Expression With Initialization When Get Enumerator Called Then Should Return Sub Expressions|456 ns|
|Given Lambda When Enumerator Called Then Should Return Expressions|415 ns|
|When Get Enumerator Called With New Expression Then Should Return Sub Expressions|333 ns|
|Given Member Access When Enumerator Called Then Should Return Expressions|306 ns|
|When Get Enumerator Called With Nested Constant Expression Then Should Return Enumerator|291 ns|
|Given Method Call When Enumerator Called Then Should Return Expressions|280 ns|
|Given Binary When Get Enumerator Called Then Should Return Expressions|269 ns|
|When Get Enumerator Called With Constant Expression Then Should Return Enumerator|174 ns|
|Given Unary When Enumerator Called Then Should Return Expressions|155 ns|
|Given Default When Enumerator Called Then Should Return Expressions|145 ns|
|White Space Not Allowed Returns Properly Populated Argument Exception|100 ns|
## IExpressionEnumeratorExtensionsTest (20 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Methods From Template Should Return Matching Method Call Expressions| |2 ms|
|When Null Constants Of Type Should Throw Argument Null| |1 ms|
|When Member Passed For Type Then Should Return Member Expressions For That Member| |1 ms|
|Methods With Name For Type Non Generic Should Return Method Call Expressions| |1 ms|
|Constants Of Type Should Return Constants Of Given Type| |1 ms|
|Given Method Name When Methods With Name Called Then Should Return Matching Method Call Expressions| |978 ns|
|**Give Method Name With Null Or Whitespace When Methods With Name Called Then Should Throw Argument**| |**1 ms**|
| |(methodName: "    ")|920 ns|
| |(methodName: null)|531 ns|
|Given Null When Methods From Template Called Then Should Throw Argument Null| |841 ns|
|Given Unary Expressions With Same Node Type Method And Operands Then Are Similar Should Return True| |841 ns|
|**When Name Is Null Or White Space Then Methods With Name For Type Should Throw Argument**| |**1 ms**|
| |(methodName: " ")|795 ns|
| |(methodName: null)|536 ns|
|**Given Null Or Empty Name When Members With Name On Type Called Then Should Throw Argument**| |**1 ms**|
| |(name: null)|745 ns|
| |(name: " ")|514 ns|
| |(name: "")|496 ns|
|Methods With Name For Type Should Return Method Call Expressions| |729 ns|
|When Member Passed For Wrong Type Then Should Return Nothing| |673 ns|
|Given Different Declaring Type When Methods From Template Called Then Should Throw Argument| |665 ns|
|**Given Expression Type When Of Expression Type Called Then Should Return Expression With Matching Type**| |**1 ms**|
| |(type: Parameter)|664 ns|
| |(type: Constant)|381 ns|
| |(type: Call)|375 ns|
| |(type: Lambda)|368 ns|
|Given Non Member Expression When Methods From Template Called Then Should Throw Argument| |657 ns|
|Given Null Expression Enumerator When Members With Name On Type Called Then Should Throw Null| |476 ns|
|When Null Methods With Name Should Throw Argument Null| |419 ns|
|When Null Methods With Name For Type Should Throw Argument Null| |345 ns|
## QuerySnapshotProviderTest (10 ms)

|Test Name|Duration|
|:--|--:|
|Execute Enumerable Raises Query Executed|1 ms|
|Create Query For Type Registers To Propagate Events|1 ms|
|Create Query Typed Provides Same Query As Underlying Provider|1 ms|
|Create Query Provides Same Query As Underlying Provider|1 ms|
|Create Query For Type Creates New Provider For Type|870 ns|
|Create Query For Type With Same Type Uses Same Provider|829 ns|
|Create Query Creates A Query Snapshot Host With Same Provider|713 ns|
|Snapshot Host Provider Is The Snapshot Provider Instance|523 ns|
|Given Null Expression When Execute Enumerable Called Then Should Throw Argument Null|466 ns|
|Given Null Expression When Create Query Typed Called Then Should Throw Argument Null|456 ns|
|Given Null Expression When Create Query Called Then Should Throw Argument Null|453 ns|
## ExceptionHelperTest (1 ms)

|Test Name|Duration|
|:--|--:|
|Given Null Reference Thrown Then Should Have Target Name|751 ns|
|Invalid Operation Extension With Parameters Returns Invalid Operation With Message|366 ns|
|Method Call On Type Required Exception Returns Properly Populated Argument Exception|133 ns|
|Invalid Operation Extension Returns Invalid Operation With Message|103 ns|
|Null Reference Returns Properly Populated Null Reference Exception|80 ns|

[Go Back](./index.md)

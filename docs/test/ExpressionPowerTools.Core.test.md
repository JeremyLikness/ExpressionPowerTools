# Summary of Test Runs for ExpressionPowerTools.Core

Jump to group:

- [CustomQueryProviderTest](#customqueryprovidertest-12-ms)
- [DefaultComparisonRulesTest](#defaultcomparisonrulestest-330-ms)
- [DefaultHighPerformanceRulesTest](#defaulthighperformancerulestest-326-ms)
- [EnsureTest](#ensuretest-34-ms)
- [ExceptionHelperTest](#exceptionhelpertest-1-ms)
- [ExpressionEnumeratorTest](#expressionenumeratortest-18-ms)
- [ExpressionEquivalencyTest](#expressionequivalencytest-91-ms)
- [ExpressionEquivalencyTestsWithoutRule](#expressionequivalencytestswithoutrule-74-ms)
- [ExpressionEvaluatorTest](#expressionevaluatortest-55-ms)
- [ExpressionExtensionsTest](#expressionextensionstest-20-ms)
- [ExpressionRulesExtensionsTest](#expressionrulesextensionstest-22-ms)
- [ExpressionSimilarityTest](#expressionsimilaritytest-101-ms)
- [ExpressionSimilarityTestsWithoutRule](#expressionsimilaritytestswithoutrule-91-ms)
- [IExpressionEnumeratorExtensionsTest](#iexpressionenumeratorextensionstest-15-ms)
- [IQueryableExtensionsTest](#iqueryableextensionstest-165-ms)
- [MemberAdapterTest](#memberadaptertest-371-ms)
- [QueryHostTest](#queryhosttest-14-ms)
- [QueryInterceptingProviderTest](#queryinterceptingprovidertest-16-ms)
- [QuerySnapshotHostTest](#querysnapshothosttest-29-ms)
- [QuerySnapshotProviderTest](#querysnapshotprovidertest-9-ms)
- [ServiceHostTest](#servicehosttest-200-ms)
- [ServicesTest](#servicestest-26-ms)

The slowest test was 'Given Rules For Type Exist When Get Rule For Equivalency Called Then Should Return Ruleset' at 33 ms.

## MemberAdapterTest (371 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Key When Get Member For Key Called Then Should Return Key**| |**171 ms**|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: Int32 Result{MemberAdapterTests,Int32}(ExpressionPowerTools.Core.Tests.MemberAdapterTests, System.String))|24 ms|
| |(key: "M:System.Linq.Queryable.SelectMany^^3(System.Linq."..., expected: System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.MemberAdapterTests+RelatedThing} SelectMany{{}f__AnonymousType7^3,SimpleThing,RelatedThing}(System.Linq.IQueryable^1{{}f__AnonymousType7^3{System.String,System.String,System.String}}, System.Linq.Expressions.Expression^1{System.Func^2{{}f__AnonymousType7^3{System.String,System.String,System.String},System.Collections.Generic.IEnumerable^1{ExpressionPowerTools.Core.Tests.MemberAdapterTests+SimpleThing}}}, System.Linq.Expressions.Expression^1{System.Func^3{{}f__AnonymousType7^3{System.String,System.String,System.String},ExpressionPowerTools.Core.Tests.MemberAdapterTests+SimpleThing,ExpressionPowerTools.Core.Tests.MemberAdapterTests+RelatedThing}}))|21 ms|
| |(key: "M:System.Linq.Queryable.Select^^2(System.Linq.IQue"..., expected: System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.IdType} Select{IdType,IdType}(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.IdType}, System.Linq.Expressions.Expression^1{System.Func^2{ExpressionPowerTools.Core.Tests.TestHelpers.IdType,ExpressionPowerTools.Core.Tests.TestHelpers.IdType}}))|15 ms|
| |(key: "M:ExpressionPowerTools.Core.Members.MemberAdapter."..., expected: Boolean TryGetMemberInfo(System.String, System.Reflection.MemberInfo ByRef))|11 ms|
| |(key: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation, System.IComparable{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation}, char}))|10 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: Int32 Compare{Z}(T, Z))|10 ms|
| |(key: "F:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: System.Collections.Generic.IDictionary^2{System.Type,ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules+ExpressionComparer} cache)|6 ms|
| |(key: "P:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: U Value)|5 ms|
| |(key: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: Boolean CheckEquivalency{T}(T, System.Linq.Expressions.Expression))|4 ms|
| |(key: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: Void .ctor())|4 ms|
| |(key: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: Boolean CheckEquivalency{ConstantExpression}(System.Linq.Expressions.ConstantExpression, System.Linq.Expressions.Expression))|3 ms|
| |(key: "P:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: Int32 Item {System.String})|3 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: Int32 Compare{Z}(ThingImplementation, Z))|3 ms|
| |(key: "M:System.Collections.Generic.List{ExpressionPowerT"..., expected: Void Add(ExpressionPowerTools.Core.Tests.MemberAdapterTests))|3 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: TResult Result{T,TResult}(T, System.String))|3 ms|
| |(key: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{,,}))|3 ms|
| |(key: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation))|3 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: TProperty Property{TProperty}(System.Object, System.String))|3 ms|
| |(key: "E:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: System.EventHandler eventRaised)|2 ms|
| |(key: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., expected: System.String Property{String}(System.Object, System.String))|2 ms|
| |(key: "M:ExpressionPowerTools.Core.Extensions.ExpressionE"..., expected: System.Linq.Expressions.ParameterExpression CreateParameterExpression{T,TValue}(System.Linq.Expressions.Expression^1{System.Func^2{T,TValue}}))|2 ms|
| |(key: "M:ExpressionPowerTools.Core.Hosts.QueryHost^2.#cto"..., expected: Void .ctor(System.Linq.Expressions.Expression, TProvider))|2 ms|
| |(key: "M:ExpressionPowerTools.Core.Extensions.ExpressionE"..., expected: System.Linq.Expressions.ParameterExpression CreateParameterExpression{Object,String}(System.Linq.Expressions.Expression^1{System.Func^2{System.Object,System.String}}))|2 ms|
| |(key: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: Boolean CheckEquivalency(System.Linq.Expressions.Expression, System.Linq.Expressions.Expression))|2 ms|
| |(key: "T:System.Linq.IQueryable^1", expected: typeof(System.Linq.IQueryable{}))|2 ms|
| |(key: "T:System.Int32{}", expected: typeof(int{}))|2 ms|
| |(key: "P:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: System.Linq.Expressions.Expression^1{System.Func^3{System.Linq.Expressions.ConstantExpression,System.Linq.Expressions.ConstantExpression,System.Boolean}} DefaultConstantRules)|2 ms|
| |(key: "T:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., expected: typeof(ExpressionPowerTools.Core.Dependencies.ServiceHost))|1 ms|
| |(key: "M:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., expected: Void .cctor())|1 ms|
| |(key: "T:System.String", expected: typeof(string))|1 ms|
| |(key: "M:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., expected: T GetService{T}(System.Object{}))|1 ms|
| |(key: "T:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., expected: typeof(ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules))|1 ms|
|**Can Recreate All Members**| |**97 ms**|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQueryInterceptingProvider{}), key: "T:ExpressionPowerTools.Core.Signatures.IQueryInter"...)|6 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Dependencies.ServiceHost), key: "T:ExpressionPowerTools.Core.Dependencies.ServiceHo"...)|4 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Dependencies.Services), key: "T:ExpressionPowerTools.Core.Dependencies.Services")|3 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQueryHost{,}), key: "T:ExpressionPowerTools.Core.Signatures.IQueryHost^"...)|3 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQueryInterceptor), key: "T:ExpressionPowerTools.Core.Signatures.IQueryInter"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider{}), key: "T:ExpressionPowerTools.Core.Signatures.IQuerySnaps"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IMemberAdapter), key: "T:ExpressionPowerTools.Core.Signatures.IMemberAdap"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.ExpressionEnumerator), key: "T:ExpressionPowerTools.Core.ExpressionEnumerator")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IServiceRegistration), key: "T:ExpressionPowerTools.Core.Signatures.IServiceReg"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQuerySnapshot), key: "T:ExpressionPowerTools.Core.Signatures.IQuerySnaps"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost{}), key: "T:ExpressionPowerTools.Core.Signatures.IQuerySnaps"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs), key: "T:ExpressionPowerTools.Core.Providers.QuerySnapsho"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IServices), key: "T:ExpressionPowerTools.Core.Signatures.IServices")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.ExpressionTransformer), key: "T:ExpressionPowerTools.Core.ExpressionTransformer")|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Providers.QuerySnapshotProvider{}), key: "T:ExpressionPowerTools.Core.Providers.QuerySnapsho"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Resources.ExceptionHelper), key: "T:ExpressionPowerTools.Core.Resources.ExceptionHel"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator), key: "T:ExpressionPowerTools.Core.Comparisons.Expression"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IDependentServiceRegistration), key: "T:ExpressionPowerTools.Core.Signatures.IDependentS"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IExpressionEvaluator), key: "T:ExpressionPowerTools.Core.Signatures.IExpression"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity), key: "T:ExpressionPowerTools.Core.Comparisons.Expression"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.ICustomQueryProvider{}), key: "T:ExpressionPowerTools.Core.Signatures.ICustomQuer"...)|2 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Members.MemberAdapter), key: "T:ExpressionPowerTools.Core.Members.MemberAdapter")|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Extensions.ExpressionExtensions), key: "T:ExpressionPowerTools.Core.Extensions.ExpressionE"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator), key: "T:ExpressionPowerTools.Core.Signatures.IExpression"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions), key: "T:ExpressionPowerTools.Core.Extensions.IExpression"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Extensions.ExpressionRulesExtensions), key: "T:ExpressionPowerTools.Core.Extensions.ExpressionR"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Hosts.QuerySnapshotHost{}), key: "T:ExpressionPowerTools.Core.Hosts.QuerySnapshotHos"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Providers.QueryInterceptingProvider{}), key: "T:ExpressionPowerTools.Core.Providers.QueryInterce"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Signatures.IExpressionComparisonRuleProvider), key: "T:ExpressionPowerTools.Core.Signatures.IExpression"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Providers.CustomQueryProvider{}), key: "T:ExpressionPowerTools.Core.Providers.CustomQueryP"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Extensions.IQueryableExtensions), key: "T:ExpressionPowerTools.Core.Extensions.IQueryableE"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Contract.Ensure), key: "T:ExpressionPowerTools.Core.Contract.Ensure")|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules), key: "T:ExpressionPowerTools.Core.Comparisons.DefaultCom"...)|1 ms|
| |(expected: System.Object DynamicInvoke(System.Object{}), key: "M:System.Delegate.DynamicInvoke(System.Object{})")|1 ms|
| |(expected: System.Object Target, key: "P:System.Delegate.Target")|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency), key: "T:ExpressionPowerTools.Core.Comparisons.Expression"...)|1 ms|
| |(expected: typeof(ExpressionPowerTools.Core.Comparisons.DefaultHighPerformanceRules), key: "T:ExpressionPowerTools.Core.Comparisons.DefaultHig"...)|1 ms|
| |(expected: System.Reflection.MethodInfo Method, key: "P:System.Delegate.Method")|1 ms|
| |(expected: System.Type GetType(), key: "M:System.Object.GetType")|1 ms|
| |(expected: System.Delegate{} GetInvocationList(), key: "M:System.MulticastDelegate.GetInvocationList")|1 ms|
| |(expected: Void GetObjectData(System.Runtime.Serialization.SerializationInfo, System.Runtime.Serialization.StreamingContext), key: "M:System.MulticastDelegate.GetObjectData(System.Ru"...)|1 ms|
| |(expected: Boolean Equals(System.Object), key: "M:System.Object.Equals(System.Object)")|1 ms|
| |(expected: System.Object Clone(), key: "M:System.Delegate.Clone")|1 ms|
| |(expected: Int32 GetHashCode(), key: "M:System.Object.GetHashCode")|1 ms|
|**Given Member When Get Key For Member Called Then Should Return Key**| |**76 ms**|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: Int32 Result{MemberAdapterTests,Int32}(ExpressionPowerTools.Core.Tests.MemberAdapterTests, System.String))|6 ms|
| |(expected: "T:System.Linq.IQueryable^1", member: typeof(System.Linq.IQueryable{}))|6 ms|
| |(expected: "M:System.Linq.Queryable.SelectMany^^3(System.Linq."..., member: System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.MemberAdapterTests+RelatedThing} SelectMany{{}f__AnonymousType7^3,SimpleThing,RelatedThing}(System.Linq.IQueryable^1{{}f__AnonymousType7^3{System.String,System.String,System.String}}, System.Linq.Expressions.Expression^1{System.Func^2{{}f__AnonymousType7^3{System.String,System.String,System.String},System.Collections.Generic.IEnumerable^1{ExpressionPowerTools.Core.Tests.MemberAdapterTests+SimpleThing}}}, System.Linq.Expressions.Expression^1{System.Func^3{{}f__AnonymousType7^3{System.String,System.String,System.String},ExpressionPowerTools.Core.Tests.MemberAdapterTests+SimpleThing,ExpressionPowerTools.Core.Tests.MemberAdapterTests+RelatedThing}}))|3 ms|
| |(expected: "T:System.Int32{}", member: typeof(int{}))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: Boolean CheckEquivalency(System.Linq.Expressions.Expression, System.Linq.Expressions.Expression))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: TResult Result{T,TResult}(T, System.String))|2 ms|
| |(expected: "M:System.Linq.Queryable.Select^^2(System.Linq.IQue"..., member: System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.IdType} Select{IdType,IdType}(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.IdType}, System.Linq.Expressions.Expression^1{System.Func^2{ExpressionPowerTools.Core.Tests.TestHelpers.IdType,ExpressionPowerTools.Core.Tests.TestHelpers.IdType}}))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: Boolean CheckEquivalency{ConstantExpression}(System.Linq.Expressions.ConstantExpression, System.Linq.Expressions.Expression))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: Int32 Compare{Z}(T, Z))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: Boolean CheckEquivalency{T}(T, System.Linq.Expressions.Expression))|2 ms|
| |(expected: "M:System.Collections.Generic.List{ExpressionPowerT"..., member: Void Add(ExpressionPowerTools.Core.Tests.MemberAdapterTests))|2 ms|
| |(expected: "P:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: System.Linq.Expressions.Expression^1{System.Func^3{System.Linq.Expressions.ConstantExpression,System.Linq.Expressions.ConstantExpression,System.Boolean}} DefaultConstantRules)|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Extensions.ExpressionE"..., member: System.Linq.Expressions.ParameterExpression CreateParameterExpression{T,TValue}(System.Linq.Expressions.Expression^1{System.Func^2{T,TValue}}))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: Int32 Compare{Z}(ThingImplementation, Z))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: System.String Property{String}(System.Object, System.String))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Members.MemberAdapter."..., member: Boolean TryGetMemberInfo(System.String, System.Reflection.MemberInfo ByRef))|2 ms|
| |(expected: "E:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: System.EventHandler eventRaised)|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: Void .ctor())|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Extensions.ExpressionE"..., member: System.Linq.Expressions.ParameterExpression CreateParameterExpression{Object,String}(System.Linq.Expressions.Expression^1{System.Func^2{System.Object,System.String}}))|2 ms|
| |(expected: "M:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: TProperty Property{TProperty}(System.Object, System.String))|1 ms|
| |(expected: "P:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: Int32 Item {System.String})|1 ms|
| |(expected: "M:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., member: T GetService{T}(System.Object{}))|1 ms|
| |(expected: "M:ExpressionPowerTools.Core.Hosts.QueryHost^2.#cto"..., member: Void .ctor(System.Linq.Expressions.Expression, TProvider))|1 ms|
| |(expected: "M:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., member: Void .cctor())|1 ms|
| |(expected: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{,,}))|1 ms|
| |(expected: "F:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: System.Collections.Generic.IDictionary^2{System.Type,ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules+ExpressionComparer} cache)|1 ms|
| |(expected: "P:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: U Value)|1 ms|
| |(expected: "T:ExpressionPowerTools.Core.Dependencies.ServiceHo"..., member: typeof(ExpressionPowerTools.Core.Dependencies.ServiceHost))|1 ms|
| |(expected: "T:System.String", member: typeof(string))|1 ms|
| |(expected: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation))|1 ms|
| |(expected: "T:ExpressionPowerTools.Core.Tests.MemberAdapterTes"..., member: typeof(ExpressionPowerTools.Core.Tests.MemberAdapterTests+IThing{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation, System.IComparable{ExpressionPowerTools.Core.Tests.MemberAdapterTests+ThingImplementation}, char}))|1 ms|
| |(expected: "T:ExpressionPowerTools.Core.Comparisons.DefaultCom"..., member: typeof(ExpressionPowerTools.Core.Comparisons.DefaultComparisonRules))|1 ms|
|Get Member For Key Typed Returns Correct Result| |6 ms|
|**Given Null Or Empty String When Called Then Should Throw Argument Exception**| |**14 ms**|
| |(key: "")|6 ms|
| |(key: null)|5 ms|
| |(key: "\t\t\n")|2 ms|
|Given Null Member When Get Key For Member Called Then Should Throw Argument Null Exception| |2 ms|
|Given Invalid String When Called Then Should Throw Exception With String| |2 ms|
|When Null Then As Enumerable Expression Should Throw Argument Null| |373 ns|
## IQueryableExtensionsTest (165 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Fragment Is Not In Query When Has Fragment Called Then Should Return False**| |**72 ms**|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_0(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|22 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_1(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|22 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_4(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|11 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_3(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|7 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentNotInQueryMatrix}b__15_2(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|7 ms|
|Given Not Similar Typed Queries Is Similar To Should Return False| |14 ms|
|Given Not Similar Queries Is Similar To Should Return False| |12 ms|
|Given Queryable When Create Intercepted Query Called Then Should Apply Transformation| |8 ms|
|**Given Fragment Is In Query When Has Fragment Called Then Should Return True**| |**14 ms**|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_1(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|5 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_0(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|4 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_4(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|1 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_2(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|1 ms|
| |(query: Func^2 { Method = System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper} {FragmentInQueryMatrix}b__17_3(System.Linq.IQueryable^1{ExpressionPowerTools.Core.Tests.TestHelpers.QueryHelper}), Target = {}c { } })|1 ms|
|Given Equivalent Queries Is Equivalent To Should Return True| |5 ms|
|Given Queryable When Create Snapshot Host Called Then Should Return Snapshot Registered For Callback| |5 ms|
|Given Similar Typed Queries Is Similar To Should Return True| |5 ms|
|Given Equivalent Typed Queries Is Equivalent To Should Return True| |4 ms|
|Given Not Equivalent Queries Is Equivalent To Should Return False| |4 ms|
|Given Similar Queries Is Similar To Should Return True| |4 ms|
|Given Not Equivalent Typed Queries Is Equivalent To Should Return False| |4 ms|
|Given Queryable When Create Snapshot Host Called Then Should Return Snapshot Host| |1 ms|
|Given Queryable When Create Intercepted Query Called Then Should Register Transformation| |1 ms|
|Given Queryable When Create Intercepted Query Called Then Should Return Query Host| |1 ms|
|As Enumerable Should Return I Expression Enumerator For Query Expression| |892 ns|
|When Null Of Expression Type Should Throw Argument Null| |772 ns|
|Create Query Template Uses Empty List| |741 ns|
|Create Query Template From Query Uses Empty List| |376 ns|
|Given Null Is Equivalent To Should Return False| |237 ns|
|Given Null Is Similar To Should Return False| |219 ns|
## DefaultComparisonRulesTest (330 ms)

|Test Name|Duration|
|:--|--:|
|Given Rules For Type Exist When Get Rule For Equivalency Called Then Should Return Ruleset|33 ms|
|Given Equivalent Expressions Then Non Generic Check Equivalency Should Compare|33 ms|
|Given Similar Expressions Then Non Generic Check Similarity Should Compare|33 ms|
|Given Rules For Type Do Not Exist When Get Rule For Similarity Called Then Should Return Null|31 ms|
|Given Non Supported Expression Then Typed Similarity Should Return False|31 ms|
|Given Rules For Type Do Not Exist When Get Rule For Equivalency Called Then Should Return Null|30 ms|
|Given No Rule Then Check Equivalency Should Return False|28 ms|
|Given Non Supported Expression Then Typed Equivalency Should Return False|27 ms|
|Given Rules For Type Exist When Get Rule For Similarity Called Then Should Return Ruleset|26 ms|
|Given No Rule Then Check Similarity Should Return False|26 ms|
|Given Supported Expression Then Typed Equivalency Should Return True|26 ms|
|Given Null Queryable When Custom Query Provider Created Then Should Throw Argument Null|422 ns|
## ServiceHostTest (200 ms)

|Test Name|Duration|
|:--|--:|
|Additional Initialization After Reset Is Fine|31 ms|
|Reset Sets To Default|21 ms|
|Default Query Intercepting Provider Is Query Intercepting Provider|20 ms|
|Initialize Includes Default Services|19 ms|
|Default Expression Enumerator Is Expression Enumerator|14 ms|
|Default Query Snapshot Provider Is Query Snapshot Provider|12 ms|
|Given Registered Satellite Service When Initialize Called Then After Registered Called|12 ms|
|Default Evaluator Is Singleton Of Expression Evaluator|10 ms|
|Default Query Snapshot Host Is Query Snapshot Host|10 ms|
|Default Rules Provider Is Singleton Of Default Comparison Rules|9 ms|
|Default Query Host Is Query Host|9 ms|
|Get Lazy Defers Resolution Until Value Acccessed|8 ms|
|Given Registered Satellite Service When Initialize Called Then Will Override|8 ms|
|Given Satellite Implementation Of I Dependent Service Registration When Reset Called Then Should Register Service|4 ms|
|Creates A Default Instance Of Services|4 ms|
|Query With Projection Triggers Snapshot|3 ms|
## DefaultHighPerformanceRulesTest (326 ms)

|Test Name|Duration|
|:--|--:|
|Given Equivalent Expressions Then Non Generic Check Equivalency Should Compare|31 ms|
|Given No Rule Then Check Equivalency Should Return False|28 ms|
|Given Supported Expression Then Typed Equivalency Should Return True|27 ms|
|Given Similar Expressions Then Non Generic Check Similarity Should Compare|27 ms|
|Given Rules For Type Do Not Exist When Get Rule For Similarity Called Then Should Return Null|26 ms|
|Given Rules For Type Exist When Get Rule For Equivalency Called Then Should Return Ruleset|26 ms|
|Given Supported Expression Then Typed Similarity Should Return True|26 ms|
|Given Non Supported Expression Then Typed Equivalency Should Return False|26 ms|
|Given Non Supported Expression Then Typed Similarity Should Return False|26 ms|
|Given Rules For Type Exist When Get Rule For Similarity Called Then Should Return Ruleset|26 ms|
|Given No Rule Then Check Similarity Should Return False|26 ms|
|Given Rules For Type Do Not Exist When Get Rule For Equivalency Called Then Should Return Null|26 ms|
## EnsureTest (34 ms)

|Test Name|Duration|
|:--|--:|
|Given Supported Expression Then Typed Similarity Should Return True|29 ms|
|Given Argument Null Thrown Then Should Have Target Name|1 ms|
|Given Expression That Resolves To Null When Variable Not Null Called Then Should Throw Null Reference|826 ns|
|Given Expression That Resolves To Whitespace When Not Null Or Whitespace Called Then Should Throw Argument|759 ns|
|Given Expression That Does Not Resolve To Null When Not Null Called Then Should Return|574 ns|
|Given Expression That Does Not Resolve To Null When Variable Not Null Called Then Should Return|465 ns|
|Given Expression That Resolves To Null When Not Null Called Then Should Throw Argument Null|388 ns|
|Given Expression That Resolves To Null When Not Null Or Whitespace Called Then Should Throw Argument|387 ns|
|Given Expression Is Not Null When Variable Not Null Called Then Should Do Nothing|332 ns|
|Given Expression That Resolves To Value When Not Null Or Whitespace Called Then Should Return|298 ns|
## ServicesTest (26 ms)

|Test Name|Duration|
|:--|--:|
|Second Call To Initialize Should Throw Invalid Operation|20 ms|
|Given Generic Registration When Get Service Called Then Should Implement Type|954 ns|
|Given Registered Generic Type When Same Generic Type Registered With Then Should Replace Implementation|876 ns|
|Given Registered Singleton When Same Type Registered With Singleton Then Should Replace Instance|595 ns|
|Given Registered Singleton When Get Service Called Then Should Return Singleton|463 ns|
|Given Configured When Get Service Called With Non Registered Service Then Should Throw Invalid Operation|407 ns|
|Given Registered Type When Singleton Registered Then Should Replace Type|394 ns|
|Given Registered Singleton When Type Registered Then Should Replace Singleton|367 ns|
|Given Null Instance When Register Singleton Called Then Should Throw Argument Null|362 ns|
|Given Configured When Get Service Called With Non Argument With Resolve Set Then Should Return With Argument|289 ns|
|Given Configured When Register Service Called Then Should Throw Invalid Operation|249 ns|
|Given Not Configured When Get Service Called Then Should Throw Invalid Operation|219 ns|
|Given Generic Registration When Signature Is Not Assignable From Implementation Then Should Throw Invalid Operation|218 ns|
|Given Registered Type When Same Type Registered Then Should Replace Type|212 ns|
|Given Not Configured When Get Service Called For Generic Type Then Should Throw Invalid Operation|196 ns|
|Given Configured When Get Service Called With Registered Service Then Should Return Instance|164 ns|
|Given Generic Registration When Signature Base Class Of Implementation Then Should Not Throw Invalid Operation|85 ns|
|Given Generic Registration When Signature Is Assignable From Implementation Then Should Not Throw Invalid Operation|85 ns|
## ExpressionEvaluatorTest (55 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Non Similar Queryable When Are Similar Called Then Should Return False| |12 ms|
|Given Query That Is Not Part Of Other Query When Is Part Of Called Then Should Return False| |8 ms|
|Given Equivalent Queryable When Are Equivalent Called Then Should Return True| |7 ms|
|Given Non Equivalent Queryable When Are Equivalent Called Then Should Return False| |6 ms|
|Given Expression That Is Part Of Other Expression When Is Part Of Called Then Should Return True| |3 ms|
|Given Similar Enumerable When Are Similar Called Then Should Return True| |2 ms|
|Given Equivalent Enumerable When Are Equivalent Called Then Should Return True| |2 ms|
|Given Non Similar Expressions When Are Similar Called Then Should Return False| |1 ms|
|Given Non Equivalent Enumerable When Are Equivalent Called Then Should Return False| |1 ms|
|Given Similar Expressions When Are Similar Called Then Should Return True| |1 ms|
|Given Equivalent Expressions When Are Equivalent Called Then Should Return True| |1 ms|
|Given Non Similar Enumerable When Are Similar Called Then Should Return False| |1 ms|
|Given Non Equivalent Expressions When Are Equivalent Called Then Should Return False| |1 ms|
|Given Expression That Is Not Part Of Other Expression When Is Part Of Called Then Should Return False| |1 ms|
|Given Query That Is Part Of Other Query When Is Part Of Called Then Should Return True| |1 ms|
|Given Unary Expressions With Same Node Type Method And Operands Then Are Equivalent Should Return True| |894 ns|
|**Given Null And Not Null Query When Is Part Of Called Then Should Return False**| |**109 ns**|
| |(source: null, target: {})|104 ns|
| |(source: {}, target: null)|4 ns|
|**Given Null And Not Null Query When Are Similar Called Then Should Return False**| |**99 ns**|
| |(source: null, target: {})|92 ns|
| |(source: {}, target: null)|6 ns|
|**Given Null And Not Null Query When Are Equivalent Called Then Should Return False**| |**82 ns**|
| |(source: null, target: {})|76 ns|
| |(source: {}, target: null)|5 ns|
## ExpressionSimilarityTestsWithoutRule (91 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Two Queries When Not Similar Then Are Similar Should Return False| |11 ms|
|Given Target With Query Parts Not Similiar When Is Part Of Called Then Should Return False| |7 ms|
|Given Two Queries When Similar Then Are Similar Should Return True| |6 ms|
|**Given Binary Expressions With Same Node Type When Are Similar Called Then Should Evaluate Left And Right On Equivalency**| |**3 ms**|
| |(source: (5 + 6), target: (5 + 6), areSimilar: True)|2 ms|
| |(source: (5 + 6), target: (5 + 5), areSimilar: False)|925 ns|
| |(source: (5 + 6), target: (6 + 6), areSimilar: False)|607 ns|
|Given Lambda Expression When Bodies Are Not Similar Are Similar Then Should Return False| |1 ms|
|Given Constant With Different Reference Then Are Similar Should Return False| |1 ms|
|Given Invocation Expression When Signatures Match Then Are Similar Should Return True| |1 ms|
|Given Lambda Expression When Parameters Are Different Types Then Are Similar Should Return False| |1 ms|
|**Given Member Inits When Compared Then Are Similar Should Return Result**| |**9 ms**|
| |(source: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, target: new SimilarHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(null)}}, areSimilar: False)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = new SimilarClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = new SimilarClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new InheritedHost() {SimClass = new InheritedClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = null}, areSimilar: False)|1 ms|
| |(source: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, target: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, areSimilar: True)|1 ms|
| |(source: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, target: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, areSimilar: True)|854 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost(new SimilarClass()) {SimClass = new SimilarClass()}, areSimilar: False)|720 ns|
| |(source: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, target: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, areSimilar: False)|716 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new Different() {Name = "Different"}, areSimilar: False)|314 ns|
|Given Method Call Expression With Different Arguments When Are Similar Called Then Should Return False| |1 ms|
|Given Lambda Expression When Similar Then Are Similar Should Return True| |1 ms|
|Given Lambda Expression When Parameter Count Differs Then Are Similar Should Return False| |1 ms|
|Given Lambda Expression When Singatures Match Then Are Similar Should Return True| |1 ms|
|Given Invocation Expression When Similar Then Are Similar Should Return True| |1 ms|
|Given Two Inits When Arguments Are Different Then Are Similar Should Return False| |1 ms|
|Given Method Call Expression With Matching Expression And Arguments When Are Similar Called Then Should Return True| |1 ms|
|Given Lambda Expression When Tail Call Is Different Then Are Similar Should Return True| |1 ms|
|Given Method Call Expression With Static Method When Are Similar Called Then Should Return True| |1 ms|
|Given Lambda Expression When Type Is Different Then Are Similar Should Return False| |1 ms|
|Given Method Call Expression With Different Expression When Are Similar Called Then Should Return False| |1 ms|
|Given Two Inits When Constructors Are Different Then Are Similar Should Return False| |1 ms|
|Given Unary Expressions With Same Node Type Method And Operands Then Are Similar Should Return True| |904 ns|
|Given Target With Similar Query Parts When Is Part Of Called Then Should Return True| |866 ns|
|Given Member Expression When Expressions Differ Then Are Similar Should Return True| |860 ns|
|Given Unary Expression When Operands Are Different Then Are Similar Should Return False| |857 ns|
|Given Method Call Expression With Different Declaring Types When Are Similar Called Then Should Return False| |855 ns|
|Given Parameter With Derived Type Then Are Similar Should Return True| |846 ns|
|Given Binary Expressions When Node Types Are Different Then Are Similar Should Return False| |837 ns|
|Given Member Expression When Type Declaring Type Member Name And Expressions Match Then Are Similar Should Return True| |831 ns|
|Given Method Call Expression With Different Argument Count When Are Similar Called Then Should Return False| |802 ns|
|Given Method Call Expression With Different Names When Are Similar Called Then Should Return False| |798 ns|
|**Given Constant With Expression Then Are Similar Should Recursively Compare**| |**2 ms**|
| |(left: 5, right: 5, Similar: True)|766 ns|
| |(left: 5, right: 5, Similar: False)|593 ns|
| |(left: 5, right: 5, Similar: True)|585 ns|
| |(left: 5, right: 5, Similar: False)|336 ns|
|Given Method Call Expression With Different Return Type When Are Similar Called Then Should Return False| |725 ns|
|Given Constant With Object Type And Other Type Then Are Similar Should Return False| |680 ns|
|Given Unary Expression When Node Types Are Different Then Are Similar Should Return False| |644 ns|
|Given List Of Different Type Then Are Similar Should Return False| |619 ns|
|Given Enumerable Of Shorter Length Then Are Similar Should Return True| |613 ns|
|Given Constant With Object Type Then Are Similar Should Return False| |603 ns|
|Given Member Expression When Declaring Types Differ Then Are Similar Should Return False| |599 ns|
|Given Two Array Initializations With Same Type And Different Contents Then Are Similar Should Return False| |592 ns|
|Given Two Array Initializations With Same Type And Contents Then Are Similar Should Return True| |589 ns|
|Given Enumerable Constant With Same Type Then Are Similar Should Return True| |586 ns|
|Given Enumerable Constant With Different Type Then Are Similar Should Return False| |586 ns|
|Given List Of Same Type Then Are Similar Should Return True| |567 ns|
|**Given Unary Expression When Types And Operands Are Same Then Are Similar Should Evaluate Based On Methods**| |**2 ms**|
| |(source: IsTrue(True), target: IsTrue(True), areSimilar: True)|533 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: True)|506 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: False)|324 ns|
| |(source: IsTrue(True), target: IsTrue("1"), areSimilar: False)|322 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: False)|260 ns|
| |(source: IsTrue("1"), target: IsTrue(True), areSimilar: False)|258 ns|
|Given Invocation Expression When Parameters Are Different Types Then Are Similar Should Return False| |530 ns|
|Given Enumerable Of Longer Length Then Are Similar Should Return True| |521 ns|
|Given Member Expression When Member Names Differ Then Are Similar Should Return False| |457 ns|
|Given Two Inits When Arguments Are Same Then Are Similar Should Return True| |422 ns|
|Given Two Inits When Types Are Different Then Are Similar Should Return False| |410 ns|
|Given Member Expression When Types Differ Then Are Similar Should Return False| |399 ns|
|Given Enumerable Target With Complex Types Has Fewer Expressions Then Are Similar Should Return True| |339 ns|
|Given Constants With Different Type Then Are Similar Should Return False| |332 ns|
|Given Constants With Different Values Then Are Similar Should Return False| |330 ns|
|Given Target Without Query Parts When Is Part Of Called Then Should Return False| |326 ns|
|Given Invocation Expression When Parameter Count Differs Then Are Similar Should Return False| |317 ns|
|Given Enumerable With Complex Types In Different Order Then Are Similar Should Return True| |312 ns|
|Given Lambda Expression When Name Is Different Then Are Similar Should Return False| |312 ns|
|Given Invocation Expression When Type Is Different Then Are Similar Should Return False| |310 ns|
|Given Parameter With Same Type And Name Then Are Similar Should Return True| |308 ns|
|Given Constant With Same Reference Then Are Similar Should Return True| |305 ns|
|Given Two Array Initializations With Different Types Then Are Similar Should Return False| |305 ns|
|Given Parameter With Different By Ref Then Are Similar Should Return True| |299 ns|
|Given Parameter With Different Type Then Are Similar Should Return False| |298 ns|
|Given Constants Of Same Type Both Null Then Are Similar Should Return True| |283 ns|
|Given Enumerable Target With Complex Types Has More Expressions Then Are Similar Should Return True| |271 ns|
|Given Constants Of Same Type With One Null Then Are Similar Should Return False| |271 ns|
|Given Parameter With Different Name Then Are Similar Should Return True| |265 ns|
|Given Expression Not Supported Then Are Similar Should Return False| |255 ns|
|Given Parameter When Second Parameter Null Then Are Similar Should Return False| |169 ns|
|Given Target Null When Is Part Of Called Then Should Return False| |23 ns|
|Given Member Binding Lists Of Different Lengths When Member Bindings Are Similar Called Then Should Return False| |9 ns|
|**Given Either Expression Null Then Are Similar Should Return False**| |**10 ns**|
| |(left: null, right: null)|5 ns|
| |(left: 5, right: null)|3 ns|
| |(left: null, right: 5)|2 ns|
## ExpressionSimilarityTest (101 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Two Queries When Not Similar Then Are Similar Should Return False| |10 ms|
|Given Two Queries When Similar Then Are Similar Should Return True| |9 ms|
|Given Target With Query Parts Not Similiar When Is Part Of Called Then Should Return False| |7 ms|
|Given Member Binding Lists Of Different Lengths When Member Bindings Are Similar Called Then Should Return False| |2 ms|
|Given Lambda Expression When Bodies Are Not Similar Are Similar Then Should Return False| |2 ms|
|Given Two Inits When Constructors Are Different Then Are Similar Should Return False| |2 ms|
|Given Invocation Expression When Signatures Match Then Are Similar Should Return True| |2 ms|
|Given Lambda Expression When Similar Then Are Similar Should Return True| |1 ms|
|Given Lambda Expression When Parameters Are Different Types Then Are Similar Should Return False| |1 ms|
|Given Lambda Expression When Parameter Count Differs Then Are Similar Should Return False| |1 ms|
|Given Method Call Expression With Matching Expression And Arguments When Are Similar Called Then Should Return True| |1 ms|
|Given Invocation Expression When Similar Then Are Similar Should Return True| |1 ms|
|**Given Member Inits When Compared Then Are Similar Should Return Result**| |**10 ms**|
| |(source: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, target: new SimilarHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(null)}}, areSimilar: False)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = new SimilarClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = new SimilarClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new InheritedHost() {SimClass = new InheritedClass()}, areSimilar: True)|1 ms|
| |(source: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, target: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, areSimilar: False)|1 ms|
| |(source: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, target: new SimilarHost() {SimClass = {Name = "ExpressionSimilarityTests"}}, areSimilar: True)|999 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost() {SimClass = null}, areSimilar: False)|997 ns|
| |(source: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, target: new InheritedHost() {Classes = {Void Add(SimilarClass)(new SimilarClass()), Void Add(SimilarClass)(new InheritedClass())}}, areSimilar: True)|854 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new SimilarHost(new SimilarClass()) {SimClass = new SimilarClass()}, areSimilar: False)|709 ns|
| |(source: new SimilarHost() {SimClass = new SimilarClass()}, target: new Different() {Name = "Different"}, areSimilar: False)|290 ns|
|Given Lambda Expression When Singatures Match Then Are Similar Should Return True| |1 ms|
|Given Method Call Expression With Different Arguments When Are Similar Called Then Should Return False| |1 ms|
|Given Lambda Expression When Type Is Different Then Are Similar Should Return False| |1 ms|
|Given Target With Similar Query Parts When Is Part Of Called Then Should Return True| |1 ms|
|Given Two Inits When Arguments Are Different Then Are Similar Should Return False| |1 ms|
|Given Lambda Expression When Tail Call Is Different Then Are Similar Should Return True| |1 ms|
|Given Enumerable Constant With Same Type Then Are Similar Should Return True| |1 ms|
|Given Method Call Expression With Static Method When Are Similar Called Then Should Return True| |1 ms|
|Given Method Call Expression With Different Argument Count When Are Similar Called Then Should Return False| |1 ms|
|Given Method Call Expression With Different Expression When Are Similar Called Then Should Return False| |1 ms|
|Given Invocation Expression When Parameters Are Different Types Then Are Similar Should Return False| |984 ns|
|Given Method Call Expression With Different Names When Are Similar Called Then Should Return False| |921 ns|
|Given Member Expression When Expressions Differ Then Are Similar Should Return True| |909 ns|
|Given Method Call Expression With Different Declaring Types When Are Similar Called Then Should Return False| |905 ns|
|**Given Binary Expressions With Same Node Type When Are Similar Called Then Should Evaluate Left And Right On Equivalency**| |**2 ms**|
| |(source: (5 + 6), target: (5 + 5), areSimilar: False)|898 ns|
| |(source: (5 + 6), target: (5 + 6), areSimilar: True)|761 ns|
| |(source: (5 + 6), target: (6 + 6), areSimilar: False)|524 ns|
|Given Parameter With Derived Type Then Are Similar Should Return True| |879 ns|
|Given Binary Expressions When Node Types Are Different Then Are Similar Should Return False| |873 ns|
|Given List Of Different Type Then Are Similar Should Return False| |872 ns|
|Given Unary Expression When Operands Are Different Then Are Similar Should Return False| |861 ns|
|**Given Constant With Expression Then Are Similar Should Recursively Compare**| |**2 ms**|
| |(left: 5, right: 5, Similar: True)|856 ns|
| |(left: 5, right: 5, Similar: False)|654 ns|
| |(left: 5, right: 5, Similar: True)|586 ns|
| |(left: 5, right: 5, Similar: False)|373 ns|
|Given Enumerable Of Longer Length Then Are Similar Should Return True| |818 ns|
|Given Member Expression When Type Declaring Type Member Name And Expressions Match Then Are Similar Should Return True| |757 ns|
|Given Member Expression When Declaring Types Differ Then Are Similar Should Return False| |748 ns|
|Given Enumerable Constant With Different Type Then Are Similar Should Return False| |742 ns|
|Given Two Array Initializations With Same Type And Different Contents Then Are Similar Should Return False| |730 ns|
|Given Two Array Initializations With Same Type And Contents Then Are Similar Should Return True| |710 ns|
|Given Enumerable Of Shorter Length Then Are Similar Should Return True| |668 ns|
|Given List Of Same Type Then Are Similar Should Return True| |656 ns|
|Given Method Call Expression With Different Return Type When Are Similar Called Then Should Return False| |636 ns|
|Given Unary Expression When Node Types Are Different Then Are Similar Should Return False| |615 ns|
|Given Constant With Object Type Then Are Similar Should Return False| |607 ns|
|Given Constant With Object Type And Other Type Then Are Similar Should Return False| |600 ns|
|**Given Unary Expression When Types And Operands Are Same Then Are Similar Should Evaluate Based On Methods**| |**2 ms**|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: True)|587 ns|
| |(source: IsTrue(True), target: IsTrue(True), areSimilar: True)|529 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: False)|270 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areSimilar: False)|267 ns|
| |(source: IsTrue(True), target: IsTrue("1"), areSimilar: False)|254 ns|
| |(source: IsTrue("1"), target: IsTrue(True), areSimilar: False)|254 ns|
|Given Two Inits When Arguments Are Same Then Are Similar Should Return True| |539 ns|
|Given Member Expression When Member Names Differ Then Are Similar Should Return False| |525 ns|
|Given Member Expression When Types Differ Then Are Similar Should Return False| |516 ns|
|Given Invocation Expression When Type Is Different Then Are Similar Should Return False| |500 ns|
|Given Invocation Expression When Parameter Count Differs Then Are Similar Should Return False| |468 ns|
|Given Parameter With Same Type And Name Then Are Similar Should Return True| |467 ns|
|Given Lambda Expression When Name Is Different Then Are Similar Should Return False| |450 ns|
|Given Parameter With Different Type Then Are Similar Should Return False| |431 ns|
|Given Enumerable Target With Complex Types Has More Expressions Then Are Similar Should Return True| |429 ns|
|Given Parameter With Different By Ref Then Are Similar Should Return True| |421 ns|
|Given Constants Of Same Type Both Null Then Are Similar Should Return True| |419 ns|
|Given Constants With Different Type Then Are Similar Should Return False| |415 ns|
|Given Target Without Query Parts When Is Part Of Called Then Should Return False| |413 ns|
|Given Two Array Initializations With Different Types Then Are Similar Should Return False| |405 ns|
|Given Constants Of Same Type With One Null Then Are Similar Should Return False| |382 ns|
|Given Parameter With Different Name Then Are Similar Should Return True| |379 ns|
|Given Enumerable With Complex Types In Different Order Then Are Similar Should Return True| |376 ns|
|Given Enumerable Target With Complex Types Has Fewer Expressions Then Are Similar Should Return True| |372 ns|
|Given Two Inits When Types Are Different Then Are Similar Should Return False| |357 ns|
|Given Constant With Same Reference Then Are Similar Should Return True| |345 ns|
|Given Constant With Different Reference Then Are Similar Should Return False| |343 ns|
|Given Constants With Different Values Then Are Similar Should Return False| |340 ns|
|Given Expression Not Supported Then Are Similar Should Return False| |335 ns|
|Given Parameter When Second Parameter Null Then Are Similar Should Return False| |257 ns|
|If Then Else Defaults To True When Condition Not Met| |220 ns|
|Given Target Null When Is Part Of Called Then Should Return False| |102 ns|
|**Given Either Expression Null Then Are Similar Should Return False**| |**63 ns**|
| |(left: null, right: null)|56 ns|
| |(left: 5, right: null)|4 ns|
| |(left: null, right: 5)|2 ns|
## QueryHostTest (14 ms)

|Test Name|Duration|
|:--|--:|
|Keys Are Unique|10 ms|
|Given Query Host Provider And Custom Provider Should Be Same|1 ms|
|Given Null Provider Then Throws Argument Null|752 ns|
|Given Query Host Created With Expression Then Returns Same Expression|508 ns|
|Given Query Host Of Type Then Element Type Should Return Type|480 ns|
|Given Query Host Created With Provider Then Returns Same Provider|386 ns|
|Given Null Expression Then Throws Argument Null|314 ns|
## CustomQueryProviderTest (12 ms)

|Test Name|Duration|
|:--|--:|
|Given Expression When Execute Enumerable Called Then Should Call Source Provider Create Query|8 ms|
|Given Null Expression When Execute Type Called Then Should Throw Argument Null|1 ms|
|Given Expression When Execute Type Called Then Should Call Source Provider Execute|1 ms|
|Given Expression When Execute Called Then Should Call Source Provider Execute|737 ns|
|Given Null Expression When Execute Enumerable Called Then Should Throw Argument Null|586 ns|
|Given Null Expression When Execute Called Then Should Throw Argument Null|579 ns|
## ExpressionEquivalencyTestsWithoutRule (74 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Method Call Expression With Different Names When Are Equivalent Called Then Should Return False| |8 ms|
|Given Two Queries When Not Equivalent Then Are Equivalent Should Return False| |6 ms|
|Given Enumerable With Same Values In Same Order Then Are Equivalent Should Return True| |2 ms|
|**Given Member Inits When Compared Then Are Equivalent Should Return Result**| |**6 ms**|
| |(source: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}}, areEquivalent: False)|1 ms|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = new TestData()}, areEquivalent: True)|1 ms|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = null}, areEquivalent: False)|993 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, areEquivalent: False)|979 ns|
| |(source: new TestData() {Name = "Hello"}, target: new TestData("Hello") {Name = "GoodBye"}, areEquivalent: False)|763 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new TestData() {Name = "Hello"}, areEquivalent: False)|327 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = new TestData()}, areEquivalent: True)|6 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, target: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, areEquivalent: True)|6 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: null, areEquivalent: False)|3 ns|
| |(source: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, areEquivalent: True)|3 ns|
|Given Lambda Expression When Equivalent Then Are Equivalent Should Return True| |1 ms|
|Given Lambda Expression When Bodies Are Not Equivalent Are Equivalent Then Should Return False| |1 ms|
|Given Method Call Expression With Matching Expression And Arguments When Are Equivalent Called Then Should Return True| |1 ms|
|Given Method Call Expression With Different Arguments When Are Equivalent Called Then Should Return False| |1 ms|
|**Given Member Bindings When Compared Then Member Bindings Are Equivalent Should Return Result**| |**3 ms**|
| |(source: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}, areEquivalent: False)|977 ns|
| |(source: TestProp = new TestData(), target: TestProp = new TestData(), areEquivalent: True)|567 ns|
| |(source: Name = "Hello", target: Name = "GoodBye", areEquivalent: False)|453 ns|
| |(source: TestProp = {Name = "ExpressionEquivalencyTests"}, target: TestProp = {Name = "ExpressionEquivalencyTests"}, areEquivalent: True)|295 ns|
| |(source: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, areEquivalent: True)|284 ns|
| |(source: TestProp = new TestData(), target: TestProp = new TestData(), areEquivalent: True)|163 ns|
| |(source: TestProp = new TestData(), target: null, areEquivalent: False)|162 ns|
| |(source: TestProp = new TestData(), target: Name = "Hello", areEquivalent: False)|160 ns|
| |(source: TestProp = new TestData(), target: TestProp = null, areEquivalent: False)|148 ns|
| |(source: TestProp = {Name = "ExpressionEquivalencyTests"}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, areEquivalent: False)|146 ns|
|Given Unary Expression When Operands Are Different Then Are Equivalent Should Return False| |934 ns|
|Given Two Inits When Arguments Are Different Then Are Equivalent Should Return False| |922 ns|
|Given Method Call Expression With Different Declaring Types When Are Equivalent Called Then Should Return False| |897 ns|
|Given Member Expression When Expressions Differ Then Are Equivalent Should Return False| |884 ns|
|Given Method Call Expression With Different Argument Count When Are Equivalent Called Then Should Return False| |883 ns|
|Given Unary Expressions With Same Node Type Method And Operands Then Are Equivalent Should Return True| |879 ns|
|Given Two Element Inits That Are Same Then Values Are Equivalent Should Return True| |842 ns|
|**Given Constant With Expression Then Are Equivalent Should Recursively Compare**| |**2 ms**|
| |(left: 5, right: 5, equivalent: False)|822 ns|
| |(left: 5, right: 5, equivalent: True)|760 ns|
| |(left: 5, right: 5, equivalent: True)|517 ns|
| |(left: 5, right: 5, equivalent: False)|283 ns|
|**Given Binary Expressions With Same Node Type When Are Equivalent Called Then Should Evaluate Left And Right On Equivalency**| |**2 ms**|
| |(source: (5 + 6), target: (5 + 5), areEquivalent: False)|817 ns|
| |(source: (5 + 6), target: (5 + 6), areEquivalent: True)|772 ns|
| |(source: (5 + 6), target: (6 + 6), areEquivalent: False)|519 ns|
|Given Enumerable Constant With Source Null Then Are Equivalent Should Return False| |798 ns|
|Given Binary Expressions When Node Types Are Different Then Are Equivalent Should Return False| |778 ns|
|Given Enumerable Constant With Different Members Then Are Equivalent Should Return False| |772 ns|
|Given Method Call Expression With Static Method When Are Equivalent Called Then Should Return True| |752 ns|
|Given Two Array Initializations With Same Type And Contents Then Are Equivalent Should Return True| |746 ns|
|Given Enumerable Constant With Target Null Then Are Equivalent Should Return False| |725 ns|
|Given Enumerable Of Shorter Length Then Are Equivalent Should Return False| |697 ns|
|Given Two Invocations When Different Args Then Are Equivalent Should Return False| |695 ns|
|Given Enumerable Of Longer Length Then Are Equivalent Should Return False| |684 ns|
|Given Lambda Expression When Type Is Different Then Are Equivalent Should Return False| |673 ns|
|Given Anonymous Parameter With Same Siganture Then Are Equivalent Should Return True| |671 ns|
|Given Two Array Initializations With Same Type And Different Contents Then Are Equivalent Should Return False| |670 ns|
|Given Enumerable Constant With Same Members Then Are Equivalent Should Return True| |667 ns|
|Given Method Call Expression With Different Expression When Are Equivalent Called Then Should Return False| |658 ns|
|Given I Equatable Implemented And True Then Are Equivalent Should Return True| |649 ns|
|Given Anonymous Parameter With Different Signature Then Are Equivalent Should Return False| |638 ns|
|Given I Equatable Implemented And False Then Are Equivalent Should Return False| |624 ns|
|Given Two Inits When Constructors Are Different Then Are Equivalent Should Return False| |599 ns|
|Given Method Call Expression With Different Return Type When Are Equivalent Called Then Should Return False| |594 ns|
|Given Member Expression When Declaring Types Differ Then Are Equivalent Should Return False| |589 ns|
|Given I Comparable Implemented And Not Zero Then Are Equivalent Should Return False| |556 ns|
|**Given Two I Dictionary When Dictionaries Are Equivalent Called Then Should Return Result**| |**1 ms**|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 2}}, areEqual: True)|555 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 3}}, areEqual: False)|472 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {three, 2}}, areEqual: False)|322 ns|
| |(source: {{one, 1}, {two, 2}}, target: null, areEqual: False)|171 ns|
|**Given Unary Expression When Types And Operands Are Same Then Are Equivalent Should Evaluate Based On Methods**| |**2 ms**|
| |(source: IsTrue(True), target: IsTrue(True), areEquivalent: True)|535 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: True)|529 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: False)|282 ns|
| |(source: IsTrue(True), target: IsTrue("1"), areEquivalent: False)|280 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: False)|277 ns|
| |(source: IsTrue("1"), target: IsTrue(True), areEquivalent: False)|267 ns|
|Given I Comparable Implemented And Zero Then Are Equivalent Should Return True| |531 ns|
|Given Unary Expression When Node Types Are Different Then Are Equivalent Should Return False| |528 ns|
|**Given Two I Dictionary When Values Are Equivalent Called Then Should Return Result**| |**1 ms**|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 2}}, areEqual: True)|497 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 3}}, areEqual: False)|419 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {three, 2}}, areEqual: False)|289 ns|
| |(source: {{one, 1}, {two, 2}}, target: null, areEqual: False)|148 ns|
|Given Two Element Inits That Are Different Values Then Values Are Equivalent Should Return False| |497 ns|
|Given Member Expression When Type Declaring Type Member Name And Expressions Match Then Are Equivalent Should Return True| |494 ns|
|Given Member Expression When Member Names Differ Then Are Equivalent Should Return False| |467 ns|
|Given Enumerable With Items In Different Order Then Are Equivalent Should Return False| |430 ns|
|Given Enumerable Target Has Fewer Expressions Then Are Equivalent Should Return False| |425 ns|
|Given Enumerable Target Has More Expressions Then Are Equivalent Should Return False| |417 ns|
|Given Member Expression When Types Differ Then Are Equivalent Should Return False| |409 ns|
|Given Enumerable With Different Values Then Are Equivalent Should Return False| |405 ns|
|Given Two Inits When Arguments Are Same Then Are Equivalent Should Return True| |404 ns|
|Given Constant With Same Reference Then Are Equivalent Should Return True| |390 ns|
|Given Two Element Inits That Are Different Methods Then Values Are Equivalent Should Return False| |385 ns|
|Given Two Inits When Types Are Different Then Are Equivalent Should Return False| |339 ns|
|Given Two Array Initializations With Different Types Then Are Equivalent Should Return False| |326 ns|
|Given Constants With Different Values Then Are Equivalent Should Return False| |320 ns|
|Given Enumerable Query When Of Different Type Then Are Equivalent Should Be False| |316 ns|
|Given Constant With Different Reference Then Are Equivalent Should Return False| |314 ns|
|Given Enumerable Query When Of Same Type Then Are Equivalent Should Be True| |306 ns|
|Given Parameter With Same Type And Name Then Are Equivalent Should Return True| |284 ns|
|Given Lambda Expression When Name Is Different Then Are Equivalent Should Return False| |282 ns|
|Given Lambda Expression When Tail Call Is Different Then Are Equivalent Should Return False| |282 ns|
|Given Parameter With Different Name Then Are Equivalent Should Return False| |279 ns|
|Given Constants Of Same Type Both Null Then Are Equivalent Should Return True| |274 ns|
|Given Two Invocations When Different Types Then Are Equivalent Should Return False| |270 ns|
|Given Expression Not Supported Then Are Equivalent Should Return False| |269 ns|
|Given Constants With Different Type Then Are Equivalent Should Return False| |268 ns|
|**Given Two Enumerables When Values Are Equivalent Called Then Should Resolve Without Enumerating String**| |**551 ns**|
| |(source: {'G', 'e', 't', 'E', 'n', ...}, target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: True)|192 ns|
| |(source: {"one", "two"}, target: {"one", "two"}, areEquivalent: True)|178 ns|
| |(source: {"one", "two"}, target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: False)|153 ns|
| |(source: "GetEnumerableValuesMatrix", target: "matrix", areEquivalent: False)|11 ns|
| |(source: "GetEnumerableValuesMatrix", target: "GetEnumerableValuesMatrix", areEquivalent: True)|8 ns|
| |(source: "GetEnumerableValuesMatrix", target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: False)|6 ns|
|Given One Element Inits And One Not Element Init Then Values Are Equivalent Should Return False| |171 ns|
|Given Enumerable With Target Null Then Are Equivalent Should Return False| |165 ns|
|Are Equivalent Non Generic Enumerable With Null Target Should Return False| |140 ns|
|Given Lambda Expression When Parameter Count Differs Then Are Equivalent Should Return False| |70 ns|
|Given Lambda Expression When Parameters Are Not Equivalent Then Are Equivalent Should Return False| |60 ns|
|Given Two Queries When Equivalent Then Are Equivalent Should Return True| |54 ns|
|**Given Two Types When Types Are Equivalent Then Should Return Result**| |**88 ns**|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType3{string}), areEquivalent: False)|50 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType4{int}), areEquivalent: True)|24 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType3{int}), areEquivalent: True)|7 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof(object), areEquivalent: False)|5 ns|
|**Given Anonymous Type When Compared To Anonymous Then Values Are Equivalent Should Return Result**| |**69 ns**|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = hello }, areEquivalent: True)|49 ns|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = goodbye }, areEquivalent: False)|13 ns|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = hello }, areEquivalent: True)|6 ns|
|Given Two Methods That Are Different Then Values Are Equivalent Should Return False| |31 ns|
|Given Exception Of Different Type When Values Are Equivalent Called Then Should Return False| |14 ns|
|Given Two Invocations When Different Then Are Equivalent Should Return False| |11 ns|
|Given Parameter With Different By Ref Then Are Equivalent Should Return False| |10 ns|
|Given Exception Of Same Type And Message When Values Are Equivalent Called Then Should Return True| |10 ns|
|Given Exception Of Same Type And Different Message When Values Are Equivalent Called Then Should Return False| |9 ns|
|Given Enumerable Query When Target Is Not Enumerable Query Then Values Are Equivalent Should Be False| |7 ns|
|Given Constants Of Same Type With One Null Then Are Equivalent Should Return False| |6 ns|
|Are Equivalent With Null Target Should Return False| |6 ns|
|Given Same Expression Then Are Equivalent Should Return True| |6 ns|
|**Given Two Invocations When Same Then Are Equivalent Should Return True**| |**10 ns**|
| |(invocation: Invoke(() =} True))|5 ns|
| |(invocation: Invoke(() =} "FuncString"))|2 ns|
| |(invocation: Invoke(i =} (i } 2), i))|2 ns|
|**Given Either Expression Null Then Are Equivalent Should Return False**| |**9 ns**|
| |(left: 5, right: null)|5 ns|
| |(left: null, right: 5)|3 ns|
|Given Parameter With Different Type Then Are Equivalent Should Return False| |5 ns|
## ExpressionExtensionsTest (20 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Similar Queryable When Are Similar Called Then Should Return True| |7 ms|
|Given Generic Type With Anonymous Closures When Is Or Contains Anonymous Type Called Then Should Return True| |1 ms|
|Given Expression Part Of Target When Is Part Of Called Then Should Return True| |1 ms|
|Given Expression Not Part Of Target When Is Part Of Called Then Should Return False| |1 ms|
|**As Invocation Expression With Parameters Should Return Invocation**| |**1 ms**|
| |(expr: i =} (i } 2))|1 ms|
| |(expr: (a, b) =} Convert((a * b), Int64))|196 ns|
|Given Expressions Are Equivalent When Is Equivalent To Called Then Should Return True| |708 ns|
|Given Expressions Are Not Similar When Is Similar To Called Then Should Return False| |690 ns|
|Given Expressions Are Not Equivalent When Is Equivalent To Called Then Should Return False| |681 ns|
|Given Expressions Are Similar When Is Similar To Called Then Should Return True| |616 ns|
|Create Parameter Expression Should Create Parameter With Name| |482 ns|
|As Parameter Expression For Object By Ref Should Return Parameter Expression Of Object Type By Ref| |445 ns|
|As Parameter Expression For Object With Name Should Return Parameter Expression Of Object Type With Name| |395 ns|
|As Parameter Expression For Object Should Return Parameter Expression Of Object Type| |375 ns|
|When Null Then As Enumerable Should Throw Argument Null| |357 ns|
|When Null Then As Parameter Expresion For Type Should Throw Argument Null| |337 ns|
|When Null Then As Parameter Expression For Object Should Throw Null Argument| |334 ns|
|When Null Then As Constant Expression Should Throw Argument Null| |323 ns|
|Create Parameter Expression Should Create Parameter With Parent Type| |294 ns|
|As Invocation Expression With No Parameters Should Return Invocation| |266 ns|
|As Parameter Expression For Type With Name Should Return Parameter Expression For Type With Name| |243 ns|
|As Parameter Expression For Type By Ref Should Return Parameter Expression For Type By Ref| |238 ns|
|As Constant Expression Should Return Constant Expression With Value| |233 ns|
|As Parameter Expression For Type Should Return Parameter Expression For Type| |231 ns|
|As Enumerable Should Return I Expression Enumerator| |224 ns|
|Given Expression When Member Name Extension Called Then Should Return Name| |166 ns|
|Given Generic Type With No Anonymous Closures When Is Or Contains Anonymous Type Called Then Should Return False| |71 ns|
|Given Type Is Anonymous When Is Anonymous Type Called Then Should Return True| |68 ns|
|Given Type Is Not Anonymous When Is Anonymous Type Called Then Should Return False| |53 ns|
## ExpressionEquivalencyTest (91 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Two Queries When Not Equivalent Then Are Equivalent Should Return False| |6 ms|
|Given Enumerable With Same Values In Same Order Then Are Equivalent Should Return True| |3 ms|
|Given Method Call Expression With Matching Expression And Arguments When Are Equivalent Called Then Should Return True| |2 ms|
|When Get Enumerator To String Called Then Should Return Expression Tree| |2 ms|
|Given Enumerable Of Shorter Length Then Are Equivalent Should Return False| |2 ms|
|Given Two Invocations When Different Args Then Are Equivalent Should Return False| |1 ms|
|Given Lambda Expression When Equivalent Then Are Equivalent Should Return True| |1 ms|
|**Given Member Inits When Compared Then Are Equivalent Should Return Result**| |**5 ms**|
| |(source: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}}, areEquivalent: False)|1 ms|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = new TestData()}, areEquivalent: True)|1 ms|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = null}, areEquivalent: False)|886 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, areEquivalent: False)|874 ns|
| |(source: new TestData() {Name = "Hello"}, target: new TestData("Hello") {Name = "GoodBye"}, areEquivalent: False)|727 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new TestData() {Name = "Hello"}, areEquivalent: False)|298 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: new ExpressionEquivalencyTests() {TestProp = new TestData()}, areEquivalent: True)|71 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = new TestData()}, target: null, areEquivalent: False)|6 ns|
| |(source: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, target: new ExpressionEquivalencyTests() {TestProp = {Name = "ExpressionEquivalencyTests"}}, areEquivalent: True)|6 ns|
| |(source: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, target: new ExpressionEquivalencyTests() {TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}}, areEquivalent: True)|3 ns|
|Given Two Element Inits That Are Different Values Then Values Are Equivalent Should Return False| |1 ms|
|**Given Anonymous Type When Compared To Anonymous Then Values Are Equivalent Should Return Result**| |**3 ms**|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = hello }, areEquivalent: True)|1 ms|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = hello }, areEquivalent: True)|1 ms|
| |(source: { Foo = 1, Bar = hello }, target: { Foo = 1, Bar = goodbye }, areEquivalent: False)|60 ns|
|Given Two Inits When Constructors Are Different Then Are Equivalent Should Return False| |1 ms|
|Given Lambda Expression When Bodies Are Not Equivalent Are Equivalent Then Should Return False| |1 ms|
|Given Two Element Inits That Are Same Then Values Are Equivalent Should Return True| |1 ms|
|Given Method Call Expression With Different Arguments When Are Equivalent Called Then Should Return False| |1 ms|
|Given Method Call Expression With Different Names When Are Equivalent Called Then Should Return False| |1 ms|
|**Given Binary Expressions With Same Node Type When Are Equivalent Called Then Should Evaluate Left And Right On Equivalency**| |**2 ms**|
| |(source: (5 + 6), target: (5 + 5), areEquivalent: False)|1 ms|
| |(source: (5 + 6), target: (5 + 6), areEquivalent: True)|918 ns|
| |(source: (5 + 6), target: (6 + 6), areEquivalent: False)|681 ns|
|Given Two Inits When Arguments Are Different Then Are Equivalent Should Return False| |1 ms|
|**Given Two I Dictionary When Dictionaries Are Equivalent Called Then Should Return Result**| |**1 ms**|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 2}}, areEqual: True)|1 ms|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 3}}, areEqual: False)|462 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {three, 2}}, areEqual: False)|321 ns|
| |(source: {{one, 1}, {two, 2}}, target: null, areEqual: False)|174 ns|
|Given Method Call Expression With Different Argument Count When Are Equivalent Called Then Should Return False| |1 ms|
|Given Method Call Expression With Different Declaring Types When Are Equivalent Called Then Should Return False| |1 ms|
|Given Member Expression When Member Names Differ Then Are Equivalent Should Return False| |998 ns|
|Given I Comparable Implemented And Zero Then Are Equivalent Should Return True| |984 ns|
|**Given Unary Expression When Types And Operands Are Same Then Are Equivalent Should Evaluate Based On Methods**| |**2 ms**|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: True)|984 ns|
| |(source: IsTrue(True), target: IsTrue(True), areEquivalent: True)|580 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: False)|323 ns|
| |(source: IsTrue("1"), target: IsTrue("1"), areEquivalent: False)|304 ns|
| |(source: IsTrue("1"), target: IsTrue(True), areEquivalent: False)|298 ns|
| |(source: IsTrue(True), target: IsTrue("1"), areEquivalent: False)|298 ns|
|Given Enumerable Constant With Same Members Then Are Equivalent Should Return True| |950 ns|
|Given Unary Expression When Operands Are Different Then Are Equivalent Should Return False| |940 ns|
|Given Two Element Inits That Are Different Methods Then Values Are Equivalent Should Return False| |915 ns|
|Given Binary Expressions When Node Types Are Different Then Are Equivalent Should Return False| |914 ns|
|**Given Member Bindings When Compared Then Member Bindings Are Equivalent Should Return Result**| |**3 ms**|
| |(source: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(null)}, areEquivalent: False)|905 ns|
| |(source: TestProp = new TestData(), target: TestProp = new TestData(), areEquivalent: True)|623 ns|
| |(source: TestProp = new TestData(), target: TestProp = new TestData(), areEquivalent: True)|530 ns|
| |(source: Name = "Hello", target: Name = "GoodBye", areEquivalent: False)|417 ns|
| |(source: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, areEquivalent: True)|278 ns|
| |(source: TestProp = {Name = "ExpressionEquivalencyTests"}, target: TestProp = {Name = "ExpressionEquivalencyTests"}, areEquivalent: True)|267 ns|
| |(source: TestProp = new TestData(), target: null, areEquivalent: False)|155 ns|
| |(source: TestProp = new TestData(), target: Name = "Hello", areEquivalent: False)|145 ns|
| |(source: TestProp = {Name = "ExpressionEquivalencyTests"}, target: TestProps = {Void Add(TestData)(new TestData()), Void Add(TestData)(new TestData())}, areEquivalent: False)|138 ns|
| |(source: TestProp = new TestData(), target: TestProp = null, areEquivalent: False)|137 ns|
|Given Method Call Expression With Different Expression When Are Equivalent Called Then Should Return False| |898 ns|
|Given Member Expression When Expressions Differ Then Are Equivalent Should Return False| |898 ns|
|Given Two Array Initializations With Same Type And Contents Then Are Equivalent Should Return True| |890 ns|
|Given Method Call Expression With Static Method When Are Equivalent Called Then Should Return True| |886 ns|
|Given Constant With Same Reference Then Are Equivalent Should Return True| |876 ns|
|Given Enumerable Of Longer Length Then Are Equivalent Should Return False| |849 ns|
|Given Enumerable Constant With Target Null Then Are Equivalent Should Return False| |849 ns|
|Given Anonymous Parameter With Same Siganture Then Are Equivalent Should Return True| |833 ns|
|Given Two Array Initializations With Same Type And Different Contents Then Are Equivalent Should Return False| |831 ns|
|Given Enumerable Constant With Source Null Then Are Equivalent Should Return False| |829 ns|
|Given Enumerable Constant With Different Members Then Are Equivalent Should Return False| |813 ns|
|Given Lambda Expression When Type Is Different Then Are Equivalent Should Return False| |806 ns|
|**Given Constant With Expression Then Are Equivalent Should Recursively Compare**| |**2 ms**|
| |(left: 5, right: 5, equivalent: False)|800 ns|
| |(left: 5, right: 5, equivalent: True)|777 ns|
| |(left: 5, right: 5, equivalent: True)|518 ns|
| |(left: 5, right: 5, equivalent: False)|347 ns|
|Given I Equatable Implemented And False Then Are Equivalent Should Return False| |777 ns|
|Given Anonymous Parameter With Different Signature Then Are Equivalent Should Return False| |777 ns|
|Given Method Call Expression With Different Return Type When Are Equivalent Called Then Should Return False| |763 ns|
|Given I Equatable Implemented And True Then Are Equivalent Should Return True| |754 ns|
|Given Member Expression When Declaring Types Differ Then Are Equivalent Should Return False| |744 ns|
|Given Lambda Expression When Tail Call Is Different Then Are Equivalent Should Return False| |690 ns|
|Given Unary Expression When Node Types Are Different Then Are Equivalent Should Return False| |645 ns|
|Given I Comparable Implemented And Not Zero Then Are Equivalent Should Return False| |644 ns|
|Given Lambda Expression When Parameters Are Not Equivalent Then Are Equivalent Should Return False| |622 ns|
|Given Enumerable Target Has More Expressions Then Are Equivalent Should Return False| |600 ns|
|Given Member Expression When Type Declaring Type Member Name And Expressions Match Then Are Equivalent Should Return True| |557 ns|
|Given Enumerable With Different Values Then Are Equivalent Should Return False| |556 ns|
|Given Two Inits When Arguments Are Same Then Are Equivalent Should Return True| |556 ns|
|**Given Two I Dictionary When Values Are Equivalent Called Then Should Return Result**| |**1 ms**|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 2}}, areEqual: True)|545 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {two, 3}}, areEqual: False)|414 ns|
| |(source: {{one, 1}, {two, 2}}, target: {{one, 1}, {three, 2}}, areEqual: False)|283 ns|
| |(source: {{one, 1}, {two, 2}}, target: null, areEqual: False)|149 ns|
|Given Enumerable Query When Of Different Type Then Are Equivalent Should Be False| |540 ns|
|Given Enumerable Target Has Fewer Expressions Then Are Equivalent Should Return False| |538 ns|
|Given Member Expression When Types Differ Then Are Equivalent Should Return False| |534 ns|
|Given Enumerable With Items In Different Order Then Are Equivalent Should Return False| |516 ns|
|Given Enumerable Query When Of Same Type Then Are Equivalent Should Be True| |476 ns|
|Given Lambda Expression When Name Is Different Then Are Equivalent Should Return False| |458 ns|
|Given One Element Inits And One Not Element Init Then Values Are Equivalent Should Return False| |418 ns|
|Given Two Invocations When Different Types Then Are Equivalent Should Return False| |411 ns|
|Given Two Array Initializations With Different Types Then Are Equivalent Should Return False| |410 ns|
|Given Parameter With Different Name Then Are Equivalent Should Return False| |399 ns|
|Given Parameter With Same Type And Name Then Are Equivalent Should Return True| |395 ns|
|Given Constants Of Same Type Both Null Then Are Equivalent Should Return True| |383 ns|
|Given Constants With Different Type Then Are Equivalent Should Return False| |373 ns|
|Given Expression Not Supported Then Are Equivalent Should Return False| |371 ns|
|Given Constant With Different Reference Then Are Equivalent Should Return False| |369 ns|
|Given Two Inits When Types Are Different Then Are Equivalent Should Return False| |359 ns|
|Given Constants With Different Values Then Are Equivalent Should Return False| |353 ns|
|Are Equivalent Non Generic Enumerable With Null Target Should Return False| |304 ns|
|Given Enumerable With Target Null Then Are Equivalent Should Return False| |293 ns|
|Given Lambda Expression When Parameter Count Differs Then Are Equivalent Should Return False| |285 ns|
|**Given Two Enumerables When Values Are Equivalent Called Then Should Resolve Without Enumerating String**| |**650 ns**|
| |(source: {'G', 'e', 't', 'E', 'n', ...}, target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: True)|226 ns|
| |(source: {"one", "two"}, target: {"one", "two"}, areEquivalent: True)|177 ns|
| |(source: {"one", "two"}, target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: False)|156 ns|
| |(source: "GetEnumerableValuesMatrix", target: "matrix", areEquivalent: False)|77 ns|
| |(source: "GetEnumerableValuesMatrix", target: {'G', 'e', 't', 'E', 'n', ...}, areEquivalent: False)|7 ns|
| |(source: "GetEnumerableValuesMatrix", target: "GetEnumerableValuesMatrix", areEquivalent: True)|6 ns|
|**Given Two Types When Types Are Equivalent Then Should Return Result**| |**263 ns**|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType4{int}), areEquivalent: True)|222 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType3{string}), areEquivalent: False)|29 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof({}f__AnonymousType3{int}), areEquivalent: True)|6 ns|
| |(source: typeof({}f__AnonymousType3{int}), target: typeof(object), areEquivalent: False)|4 ns|
|Given Two Queries When Equivalent Then Are Equivalent Should Return True| |205 ns|
|Given Parameter With Different Type Then Are Equivalent Should Return False| |140 ns|
|Given Parameter With Different By Ref Then Are Equivalent Should Return False| |127 ns|
|Given Two Methods That Are Different Then Values Are Equivalent Should Return False| |100 ns|
|Given Two Invocations When Different Then Are Equivalent Should Return False| |98 ns|
|Given Exception Of Different Type When Values Are Equivalent Called Then Should Return False| |97 ns|
|Given Exception Of Same Type And Message When Values Are Equivalent Called Then Should Return True| |91 ns|
|**Given Two Invocations When Same Then Are Equivalent Should Return True**| |**98 ns**|
| |(invocation: Invoke(() =} True))|88 ns|
| |(invocation: Invoke(() =} "FuncString"))|6 ns|
| |(invocation: Invoke(i =} (i } 2), i))|3 ns|
|Given Enumerable Query When Target Is Not Enumerable Query Then Values Are Equivalent Should Be False| |85 ns|
|Given Exception Of Same Type And Different Message When Values Are Equivalent Called Then Should Return False| |73 ns|
|Are Equivalent With Null Target Should Return False| |70 ns|
|Given Constants Of Same Type With One Null Then Are Equivalent Should Return False| |68 ns|
|Given Same Expression Then Are Equivalent Should Return True| |63 ns|
|**Given Either Expression Null Then Are Equivalent Should Return False**| |**65 ns**|
| |(left: 5, right: null)|60 ns|
| |(left: null, right: 5)|5 ns|
## QuerySnapshotHostTest (29 ms)

|Test Name|Duration|
|:--|--:|
|Given Register Snapshot Called When Query Executed With Projection Then Should Callback Once|4 ms|
|Given Register Snapshot Called When Unregister Called Then Should Stop Calling Back|4 ms|
|Given Register Snapshot Called When Query Executed Twice Then Should Callback Twice|4 ms|
|Given Register Snapshot Called When Query Executed Then Should Callback Once|2 ms|
|Given Snapshot Host Provider When Query Executed Then Fires Query Executed Event With Expression|2 ms|
|Given Register Snapshot Called Multiple Times When Query Executed Then Should Call All Callbacks|2 ms|
|Given Snapshot Host Provider When Query Executed Then Fires Query Executed Event|1 ms|
|Given Null When Register Snapshot Called Then Should Throw Argument Null|906 ns|
|Given Snapshot Host Provider When I Enumerable Interface Used Then Should Return Enumerator|894 ns|
|Given Snapshot Host Provider When Get Enumerator Called Then Should Return Enumerator|847 ns|
|Given Registration When Registration Called Again Then Should Throw Invalid Operation|755 ns|
|Snapshot Host Element Type Returns Type Of Query|630 ns|
|Snapshot Host Creates Instance Of Snapshot Provider|557 ns|
|Snapshot Host Captures Expression|550 ns|
|Snapshot Host Captures Query Expression|544 ns|
## QueryInterceptingProviderTest (16 ms)

|Test Name|Duration|
|:--|--:|
|Given Registration When Child Providers Exist Then Registration Should Be Passed To Children|4 ms|
|Given Registration When Child Provider Created Then Registration Should Be Passed To Child|3 ms|
|Given Expression When Create Query Typed Called With Different Type Then Should Return Query With New Provider|1 ms|
|Given Expression When Execute Called Then Should Transform Expression And Call Source Provider|1 ms|
|Given Expression When Create Query Typed Called With Same Type Then Should Return Query With Self As Provider|1 ms|
|Given Expression When Create Query Typed Called Then Should Return New Query Host|1 ms|
|Given Expression When Create Query Called Then Should Return New Query Snapshot Host|850 ns|
|Given Expression When Create Query Called Then Should Return Query With Self As Provider|800 ns|
|Given Null Expression When Execute Called Then Should Throw Argument Null|622 ns|
|Given Query Host When Get Enumerator Called Then Should Call Execute Enumerable On Provider|521 ns|
|Given Null Expression When Create Query Called Then Should Throw Argument Null|485 ns|
|Given Null Expression When Create Query Typed Called Then Should Throw Argument Null|478 ns|
|Given No Registration Then The Transformation Should Return Original Expression|439 ns|
## ExpressionEnumeratorTest (18 ms)

|Test Name|Duration|
|:--|--:|
|Given Binary With Conversion When Get Enumerator Called Then Should Include Conversion|4 ms|
|Given Member Access When Enumerator Called Then Should Return Expressions|3 ms|
|When Get Enumerator Called With New Array Expression Then Should Return Sub Expressions|3 ms|
|When Get Enumerator Called With Query Expression Then Should Return Query Parts|1 ms|
|When Get Enumerator Called With Invocation Expression Then Should Return Sub Expressions|895 ns|
|Given Null Expression When Get Enumerator Called Then Should Return Empty|802 ns|
|Given Lambda When Enumerator Called Then Should Return Expressions|658 ns|
|Given An Expression With Initialization When Get Enumerator Called Then Should Return Sub Expressions|551 ns|
|Given Method Call When Enumerator Called Then Should Return Expressions|459 ns|
|When Get Enumerator Called With New Expression Then Should Return Sub Expressions|417 ns|
|When Get Enumerator Called With Nested Constant Expression Then Should Return Enumerator|339 ns|
|Given Binary When Get Enumerator Called Then Should Return Expressions|331 ns|
|Given Unary When Enumerator Called Then Should Return Expressions|329 ns|
|When Get Enumerator Called With Constant Expression Then Should Return Enumerator|217 ns|
|Given Default When Enumerator Called Then Should Return Expressions|184 ns|
|White Space Not Allowed Returns Properly Populated Argument Exception|151 ns|
## ExpressionRulesExtensionsTest (22 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given To Rule Of Type Then Should Create Rule For Converted Types**| |**2 ms**|
| |(sourceVal: 1, targetVal: 2, expected: False)|1 ms|
| |(sourceVal: 1, targetVal: 1, expected: True)|552 ns|
| |(sourceVal: 2, targetVal: 1, expected: False)|538 ns|
|**Given Global Rule Then Should Evaluate Based On Expression Type**| |**1 ms**|
| |(sourceValue: 1, expected: True)|1 ms|
| |(sourceValue: 2, expected: False)|642 ns|
|**Given False Rule Or Expression With Same Node Types Then Or Must Match Should Evaluate Node Types**| |**1 ms**|
| |(nodeTypesShouldMatch: False)|1 ms|
| |(nodeTypesShouldMatch: True)|681 ns|
|When Null Then Create Parameter Expression Should Throw Argument Null| |831 ns|
|**Given And Then Result Should Be Logical And Of Expressions**| |**1 ms**|
| |(left: True, right: True)|825 ns|
| |(left: False, right: True)|265 ns|
| |(left: False, right: False)|258 ns|
| |(left: True, right: False)|253 ns|
|Given Expressions With Different Node Types Then Node Types Must Match Should Return False| |766 ns|
|Given Expressions With Same Node Types Then Node Types Must Match Should Return True| |760 ns|
|**Given If Then Result Should Be Based On Evaluation Of If Then Else**| |**3 ms**|
| |(ifCondition: True, thenCondition: True, elseCondition: null, expected: True)|641 ns|
| |(ifCondition: False, thenCondition: True, elseCondition: True, expected: True)|333 ns|
| |(ifCondition: False, thenCondition: True, elseCondition: False, expected: False)|286 ns|
| |(ifCondition: True, thenCondition: True, elseCondition: True, expected: True)|286 ns|
| |(ifCondition: True, thenCondition: False, elseCondition: null, expected: False)|282 ns|
| |(ifCondition: True, thenCondition: False, elseCondition: True, expected: False)|282 ns|
| |(ifCondition: False, thenCondition: False, elseCondition: False, expected: False)|279 ns|
| |(ifCondition: False, thenCondition: True, elseCondition: null, expected: True)|279 ns|
| |(ifCondition: False, thenCondition: False, elseCondition: True, expected: True)|276 ns|
| |(ifCondition: False, thenCondition: False, elseCondition: null, expected: True)|273 ns|
| |(ifCondition: True, thenCondition: True, elseCondition: False, expected: True)|271 ns|
| |(ifCondition: True, thenCondition: False, elseCondition: False, expected: False)|266 ns|
|Given Same Values Then Members Must Match Should Evaluate To True| |549 ns|
|**Given Start With Or Then Result Should Be Logical Or Of Expressions**| |**1 ms**|
| |(left: False, right: True)|542 ns|
| |(left: True, right: True)|273 ns|
| |(left: True, right: False)|257 ns|
| |(left: False, right: False)|250 ns|
|Given Condition Fails Then Should Call If False| |538 ns|
|**Given Or Then Result Should Be Logical Or Of Expressions**| |**1 ms**|
| |(left: True, right: True)|538 ns|
| |(left: False, right: True)|261 ns|
| |(left: False, right: False)|257 ns|
| |(left: True, right: False)|254 ns|
|**Given Start With And Then Result Is Logical And Of Expressions**| |**1 ms**|
| |(left: True, right: True)|536 ns|
| |(left: True, right: False)|256 ns|
| |(left: False, right: False)|256 ns|
| |(left: False, right: True)|252 ns|
|**Given Rule That Is True Then And Types Must Be Similar Should Return True**| |**646 ns**|
| |(typesShouldBeSimilar: False)|503 ns|
| |(typesShouldBeSimilar: True)|143 ns|
|Given Expression When Not Applied Then Should Return Logical Not| |466 ns|
|Given Different Values Then Must Be Same Type Should Evaluate To False| |421 ns|
|**Given Rule Then Returns Result Of Rule**| |**535 ns**|
| |(result: False)|380 ns|
| |(result: True)|155 ns|
|Given Expression With Similar Types Then Types Must Be Similar Should Return True| |250 ns|
|Given Different Types Then Must Be Same Type Should Evaluate To False| |243 ns|
|Given Expression Non Similar Types Then Types Must Be Similar Should Return False| |215 ns|
|Given Same Types Then Types Must Match Should Evaluate To True| |201 ns|
|Given False Then Should Evaluate To False| |175 ns|
|Given True Then Should Evaluate To True| |163 ns|
## IExpressionEnumeratorExtensionsTest (15 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**When Name Is Null Or White Space Then Methods With Name For Type Should Throw Argument**| |**2 ms**|
| |(methodName: null)|2 ms|
| |(methodName: " ")|796 ns|
|Methods From Template Should Return Matching Method Call Expressions| |1 ms|
|Methods With Name For Type Non Generic Should Return Method Call Expressions| |1 ms|
|Constants Of Type Should Return Constants Of Given Type| |1 ms|
|**Give Method Name With Null Or Whitespace When Methods With Name Called Then Should Throw Argument**| |**1 ms**|
| |(methodName: "    ")|921 ns|
| |(methodName: null)|549 ns|
|Given Unary Expressions With Same Node Type Method And Operands Then Are Similar Should Return True| |866 ns|
|Given Method Name When Methods With Name Called Then Should Return Matching Method Call Expressions| |770 ns|
|Methods With Name For Type Should Return Method Call Expressions| |725 ns|
|When Null Constants Of Type Should Throw Argument Null| |721 ns|
|**Given Expression Type When Of Expression Type Called Then Should Return Expression With Matching Type**| |**1 ms**|
| |(type: Parameter)|679 ns|
| |(type: Constant)|378 ns|
| |(type: Lambda)|365 ns|
| |(type: Call)|358 ns|
|Given Non Member Expression When Methods From Template Called Then Should Throw Argument| |659 ns|
|Given Different Declaring Type When Methods From Template Called Then Should Throw Argument| |642 ns|
|Given Null When Methods From Template Called Then Should Throw Argument Null| |532 ns|
|When Null Methods With Name For Type Should Throw Argument Null| |407 ns|
|When Null Methods With Name Should Throw Argument Null| |330 ns|
## QuerySnapshotProviderTest (9 ms)

|Test Name|Duration|
|:--|--:|
|Execute Enumerable Raises Query Executed|1 ms|
|Create Query For Type Registers To Propagate Events|1 ms|
|Create Query Typed Provides Same Query As Underlying Provider|1 ms|
|Create Query Provides Same Query As Underlying Provider|1 ms|
|Create Query For Type Creates New Provider For Type|875 ns|
|Create Query For Type With Same Type Uses Same Provider|866 ns|
|Create Query Creates A Query Snapshot Host With Same Provider|712 ns|
|Snapshot Host Provider Is The Snapshot Provider Instance|540 ns|
|Given Null Expression When Execute Enumerable Called Then Should Throw Argument Null|478 ns|
|Given Null Expression When Create Query Called Then Should Throw Argument Null|464 ns|
|Given Null Expression When Create Query Typed Called Then Should Throw Argument Null|462 ns|
## ExceptionHelperTest (1 ms)

|Test Name|Duration|
|:--|--:|
|Given Null Reference Thrown Then Should Have Target Name|559 ns|
|Invalid Operation Extension With Parameters Returns Invalid Operation With Message|469 ns|
|Method Call On Type Required Exception Returns Properly Populated Argument Exception|220 ns|
|Invalid Operation Extension Returns Invalid Operation With Message|179 ns|
|Null Reference Returns Properly Populated Null Reference Exception|123 ns|

[Go Back](./index.md)

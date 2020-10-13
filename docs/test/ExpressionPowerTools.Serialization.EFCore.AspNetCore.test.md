# Summary of Test Runs for ExpressionPowerTools.Serialization.EFCore.AspNetCore

Jump to group:

- [CollectionHandleTest](#collectionhandletest-11-ms)
- [DbContextAdapterTest](#dbcontextadaptertest-295-ms)
- [EndToEndTest](#endtoendtest-926-ms)
- [ExpressionPowerToolsEFCoreMiddlewareTest](#expressionpowertoolsefcoremiddlewaretest-572-ms)
- [MiddlewareExtensionsTest](#middlewareextensionstest-86-ms)
- [QueryDeserializerTest](#querydeserializertest-559-ms)
- [QueryResultSerializerTest](#queryresultserializertest-138-ms)
- [RouteProcessorTest](#routeprocessortest-7-ms)

The slowest test was 'Single Db Context Works' at 543 ms.

## EndToEndTest (926 ms)

|Test Name|Duration|
|:--|--:|
|Single Db Context Works|543 ms|
|Multiple Db Contexts Work|154 ms|
|Default Ctor Restriction Honored|40 ms|
|Single Request Works|38 ms|
|Count Request Works|38 ms|
|No Default Rules Honored|31 ms|
|Alternate Path Works|28 ms|
|Complex Alternate Path Works|26 ms|
|Not In Path Ignored|23 ms|
|Given Valid Parameters When Try Get Db Set Called Then Should Return Property Info And True|288 ns|
## QueryDeserializerTest (559 ms)

|Test Name|Duration|
|:--|--:|
|Given Null Query When Deserialize Async Called Then Should Throw Argument Null|315 ms|
|Given Rules Passed When Map Power Tools E F Core Base Called Then Should Configure Rules|150 ms|
|Given Is Count True In Payload When Deserialize Async Called Then Should Return Is Count True|51 ms|
|Given Json Not Serialization Payload When Deserialize Async Called Then Should Throw Null Reference|38 ms|
|Given No Json Payload When Deserialize Async Called Then Should Throw Argument|1 ms|
|Given Null Stream When Deserialize Async Called Then Should Throw Argument Null|1 ms|
## ExpressionPowerToolsEFCoreMiddlewareTest (572 ms)

|Test Name|Duration|
|:--|--:|
|Given Context Types Not Derived From Db Context When Middleware Instantiated Then Should Throw Argument|210 ms|
|Given Valid Body Invoke Called Then Should Return Result|156 ms|
|Given Invalid Body Invoke Called Then Should Set Internal Server Error Status Code|119 ms|
|Specific Rules Applied|47 ms|
|Given Path With Invalid Collection When Invoke Called Then Should Invoke Next Delegate|13 ms|
|Given Db Context Not Registered With Service Provider When Invoke Called Then Should Set Bad Request Status Code|6 ms|
|Given Path With Invalid Context When Invoke Called Then Should Invoke Next Delegate|3 ms|
|Given Path Not Of Root When Invoke Called Then Should Invoke Next Delegate|3 ms|
|Given Path Not With Collection When Invoke Called Then Should Invoke Next Delegate|3 ms|
|Given Path Not With Context When Invoke Called Then Should Invoke Next Delegate|3 ms|
|Given Method Not Post When Invoke Called Then Should Invoke Next Delegate|2 ms|
|Given Null Context Types When Middleware Instantiated Then Should Throw Argument Null|946 ns|
|Given Null Path When Middleware Instantiated Then Should Throw Argument|840 ns|
|Given Null Next Delegate When Middleware Instantiated Then Should Throw Argument Null|558 ns|
## DbContextAdapterTest (295 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Parameters Are Valid When Create Query Called Then Should Return Query| |207 ms|
|Given Null Db Context When Create Query Called Then Should Throw Argument Null| |81 ms|
|Given Type Not Derived From Db Context When Collection Handle Instantiated Then Should Throw Argument| |1 ms|
|Given Collection Does Not Reference Db Set When Create Query Called Then Should Throw Argument Null| |1 ms|
|Given Collection Not On Db Context When Create Query Called Then Should Throw Target| |1 ms|
|Given Null Collection When Create Query Called Then Should Throw Argument Null| |829 ns|
|**Given No Match Between Context And Types When Try Get Context Called Then Should Return False**| |**871 ns**|
| |(typeList: {}, context: "TestWidgetsContext")|599 ns|
| |(typeList: {typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext)}, context: "TestProductsContext")|128 ns|
| |(typeList: {}, context: null)|65 ns|
| |(typeList: null, context: "TestWidgetsContext")|28 ns|
| |(typeList: null, context: null)|24 ns|
| |(typeList: {typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.DbContextAdapterTests)}, context: "DbContextAdapterTests")|24 ns|
|Given Match Between Context And Types When Try Get Context Called Then Should Return Context Type And True| |259 ns|
|**Given No Match Between Collection And Db Set When Try Get Db Set Called Then Should Return False**| |**365 ns**|
| |(dbContextType: typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext), collection: "Decoy")|201 ns|
| |(dbContextType: typeof(string), collection: "Length")|50 ns|
| |(dbContextType: typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext), collection: "")|42 ns|
| |(dbContextType: null, collection: null)|37 ns|
| |(dbContextType: null, collection: "Widgets")|34 ns|
## QueryResultSerializerTest (138 ms)

|Test Name|Duration|
|:--|--:|
|Given Valid Inputs When Deserialize Async Called Then Should Deserialize Queryable|92 ms|
|Given Valid Parameters When Serialize Async Called Then Should Serialize To Stream|27 ms|
|Given Null Query When Serialize Async Called Then Should Throw Argument Exception|10 ms|
|Given Valid Parameters With Is Count True When Serialize Async Called Then Should Serialize To Stream|6 ms|
|Given Null Stream When Serialize Async Called Then Should Throw Argument Null|1 ms|
## MiddlewareExtensionsTest (86 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Bad Pattern When Map Power Tools E F Core Based Called Then Should Throw Argument**| |**55 ms**|
| |(pattern: "/efcore/{decoy}/{otherdecoy}")|48 ms|
| |(pattern: "/efcore/{context}/{decoy}")|1 ms|
| |(pattern: "/efcore/{context}")|1 ms|
| |(pattern: "/efcore/{collection}/{decoy}")|1 ms|
| |(pattern: "/efcore")|1 ms|
| |(pattern: "/efcore/{collection}")|1 ms|
|Given Config Passed When Map Power Tools E F Core Base Called Then Should Configure Defaults| |23 ms|
|**Given Bad Db Context Types When Map Power Tools E F Core Base Called Then Should Throw Argument**| |**3 ms**|
| |(dbContextTypes: {typeof(string)})|1 ms|
| |(dbContextTypes: {})|1 ms|
|**Given Null Inputs When Map Power Tools E F Core Base Called Then Should Throw Argument Null**| |**3 ms**|
| |(useEndPointRouteBuilder: True, pattern: null, contextTypes: {typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext)})|1 ms|
| |(useEndPointRouteBuilder: True, pattern: RoutePattern { Defaults = {}, InboundPrecedence = 1.33, OutboundPrecedence = 5.33, ParameterPolicies = {}, Parameters = {RoutePatternParameterPart { ... }, RoutePatternParameterPart { ... }}, ... }, contextTypes: null)|1 ms|
| |(useEndPointRouteBuilder: False, pattern: RoutePattern { Defaults = {}, InboundPrecedence = 1.33, OutboundPrecedence = 5.33, ParameterPolicies = {}, Parameters = {RoutePatternParameterPart { ... }, RoutePatternParameterPart { ... }}, ... }, contextTypes: {typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext)})|635 ns|
|Given Zero Length Context Types When Middleware Instantiated Then Should Throw Argument| |998 ns|
## CollectionHandleTest (11 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Proper Type And Collection When Collection Handle Instantiated Then Should Set Properties| |8 ms|
|**Given Null Type Or Null Collection When Collection Handle Instantiated Then Should Throw Argument Null**| |**1 ms**|
| |(dbContext: typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestProductsContext), collection: null)|1 ms|
| |(dbContext: null, collection: null)|397 ns|
| |(dbContext: null, collection: Microsoft.EntityFrameworkCore.DbSet^1{ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestProduct} Products)|282 ns|
|Given Collection Not A Property On Db Context Type When Collection Handle Instantiated Then Should Throw Argument| |895 ns|
|Given Collection Not A Db Set When Collection Handle Instantiated Then Should Throw Argument| |757 ns|
## RouteProcessorTest (7 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Path When Parse Path Called Then Should Return Parts**| |**5 ms**|
| |(path: null, expected: (, ))|4 ms|
| |(path: "efcore", expected: (, ))|232 ns|
| |(path: "", expected: (, ))|111 ns|
| |(path: "/efcore/context/collection", expected: (context, collection))|95 ns|
| |(path: "/efcore", expected: (, ))|63 ns|
| |(path: "efcore/context", expected: (, ))|57 ns|
| |(path: "efcore/context/collection", expected: (, ))|49 ns|
| |(path: "efcore/context/collection/", expected: (, ))|42 ns|
| |(path: "/efcore/context/collection/", expected: (context, collection))|31 ns|
| |(path: "/efcore/context", expected: (, ))|28 ns|
| |(path: "/efcore/context/", expected: (, ))|26 ns|
|Given Valid Parameters With Payload Single When Serialize Async Called Then Should Serialize To Stream| |1 ms|

[Go Back](./index.md)

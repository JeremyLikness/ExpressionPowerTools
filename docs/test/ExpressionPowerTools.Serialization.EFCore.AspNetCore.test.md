# Summary of Test Runs for ExpressionPowerTools.Serialization.EFCore.AspNetCore

Jump to group:

- [CollectionHandleTest](#collectionhandletest-11-ms)
- [DbContextAdapterTest](#dbcontextadaptertest-287-ms)
- [EndToEndTest](#endtoendtest-784-ms)
- [ExpressionPowerToolsEFCoreMiddlewareTest](#expressionpowertoolsefcoremiddlewaretest-515-ms)
- [MiddlewareExtensionsTest](#middlewareextensionstest-54-ms)
- [QueryDeserializerTest](#querydeserializertest-432-ms)
- [QueryResultSerializerTest](#queryresultserializertest-79-ms)
- [RouteProcessorTest](#routeprocessortest-7-ms)

The slowest test was 'Single Db Context Works' at 507 ms.

## EndToEndTest (784 ms)

|Test Name|Duration|
|:--|--:|
|Single Db Context Works|507 ms|
|Multiple Db Contexts Work|144 ms|
|Single Request Works|22 ms|
|Default Ctor Restriction Honored|20 ms|
|Count Request Works|19 ms|
|Json Options Are Applied|16 ms|
|Complex Alternate Path Works|15 ms|
|Not In Path Ignored|14 ms|
|Alternate Path Works|11 ms|
|No Default Rules Honored|11 ms|
|Given Valid Parameters When Try Get Db Set Called Then Should Return Property Info And True|209 ns|
## QueryDeserializerTest (432 ms)

|Test Name|Duration|
|:--|--:|
|Given Null Query When Deserialize Async Called Then Should Throw Argument Null|231 ms|
|Given Rules Passed When Map Power Tools E F Core Base Called Then Should Configure Rules|137 ms|
|Given Json Not Serialization Payload When Deserialize Async Called Then Should Throw Null Reference|36 ms|
|Given Is Count True In Payload When Deserialize Async Called Then Should Return Is Count True|22 ms|
|Given No Json Payload When Deserialize Async Called Then Should Throw Argument|1 ms|
|Given Null Stream When Deserialize Async Called Then Should Throw Argument Null|1 ms|
## DbContextAdapterTest (287 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Parameters Are Valid When Create Query Called Then Should Return Query| |194 ms|
|Given Null Db Context When Create Query Called Then Should Throw Argument Null| |87 ms|
|Given Type Not Derived From Db Context When Collection Handle Instantiated Then Should Throw Argument| |1 ms|
|Given Collection Does Not Reference Db Set When Create Query Called Then Should Throw Argument Null| |899 ns|
|Given Collection Not On Db Context When Create Query Called Then Should Throw Target| |757 ns|
|**Given No Match Between Context And Types When Try Get Context Called Then Should Return False**| |**852 ns**|
| |(typeList: {}, context: "TestWidgetsContext")|586 ns|
| |(typeList: {typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext)}, context: "TestProductsContext")|130 ns|
| |(typeList: {}, context: null)|57 ns|
| |(typeList: null, context: "TestWidgetsContext")|28 ns|
| |(typeList: null, context: null)|25 ns|
| |(typeList: {typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.DbContextAdapterTests)}, context: "DbContextAdapterTests")|24 ns|
|Given Null Collection When Create Query Called Then Should Throw Argument Null| |546 ns|
|Given Match Between Context And Types When Try Get Context Called Then Should Return Context Type And True| |206 ns|
|**Given No Match Between Collection And Db Set When Try Get Db Set Called Then Should Return False**| |**312 ns**|
| |(dbContextType: typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext), collection: "Decoy")|178 ns|
| |(dbContextType: typeof(string), collection: "Length")|44 ns|
| |(dbContextType: null, collection: null)|37 ns|
| |(dbContextType: typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext), collection: "")|26 ns|
| |(dbContextType: null, collection: "Widgets")|25 ns|
## ExpressionPowerToolsEFCoreMiddlewareTest (515 ms)

|Test Name|Duration|
|:--|--:|
|Given Context Types Not Derived From Db Context When Middleware Instantiated Then Should Throw Argument|188 ms|
|Given Valid Body Invoke Called Then Should Return Result|142 ms|
|Given Invalid Body Invoke Called Then Should Set Internal Server Error Status Code|129 ms|
|Specific Rules Applied|21 ms|
|Given Path With Invalid Collection When Invoke Called Then Should Invoke Next Delegate|12 ms|
|Given Db Context Not Registered With Service Provider When Invoke Called Then Should Set Bad Request Status Code|5 ms|
|Given Path Not Of Root When Invoke Called Then Should Invoke Next Delegate|3 ms|
|Given Path With Invalid Context When Invoke Called Then Should Invoke Next Delegate|2 ms|
|Given Path Not With Collection When Invoke Called Then Should Invoke Next Delegate|2 ms|
|Given Path Not With Context When Invoke Called Then Should Invoke Next Delegate|2 ms|
|Given Method Not Post When Invoke Called Then Should Invoke Next Delegate|2 ms|
|Given Null Context Types When Middleware Instantiated Then Should Throw Argument Null|744 ns|
|Given Null Path When Middleware Instantiated Then Should Throw Argument|583 ns|
|Given Null Next Delegate When Middleware Instantiated Then Should Throw Argument Null|455 ns|
## MiddlewareExtensionsTest (54 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Bad Pattern When Map Power Tools E F Core Based Called Then Should Throw Argument**| |**48 ms**|
| |(pattern: "/efcore/{decoy}/{otherdecoy}")|42 ms|
| |(pattern: "/efcore/{context}/{decoy}")|1 ms|
| |(pattern: "/efcore/{collection}")|1 ms|
| |(pattern: "/efcore")|1 ms|
| |(pattern: "/efcore/{context}")|1 ms|
| |(pattern: "/efcore/{collection}/{decoy}")|1 ms|
|**Given Bad Db Context Types When Map Power Tools E F Core Base Called Then Should Throw Argument**| |**2 ms**|
| |(dbContextTypes: {typeof(string)})|1 ms|
| |(dbContextTypes: {})|1 ms|
|**Given Null Inputs When Map Power Tools E F Core Base Called Then Should Throw Argument Null**| |**2 ms**|
| |(useEndPointRouteBuilder: True, pattern: RoutePattern { Defaults = {}, InboundPrecedence = 1.33, OutboundPrecedence = 5.33, ParameterPolicies = {}, Parameters = {RoutePatternParameterPart { ... }, RoutePatternParameterPart { ... }}, ... }, contextTypes: null)|1 ms|
| |(useEndPointRouteBuilder: True, pattern: null, contextTypes: {typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext)})|1 ms|
| |(useEndPointRouteBuilder: False, pattern: RoutePattern { Defaults = {}, InboundPrecedence = 1.33, OutboundPrecedence = 5.33, ParameterPolicies = {}, Parameters = {RoutePatternParameterPart { ... }, RoutePatternParameterPart { ... }}, ... }, contextTypes: {typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext)})|454 ns|
|Given Zero Length Context Types When Middleware Instantiated Then Should Throw Argument| |705 ns|
## QueryResultSerializerTest (79 ms)

|Test Name|Duration|
|:--|--:|
|Given Valid Inputs When Deserialize Async Called Then Should Deserialize Queryable|43 ms|
|Given Valid Parameters When Serialize Async Called Then Should Serialize To Stream|18 ms|
|Given Null Query When Serialize Async Called Then Should Throw Argument Exception|10 ms|
|Given Valid Parameters With Is Count True When Serialize Async Called Then Should Serialize To Stream|5 ms|
|Given Null Stream When Serialize Async Called Then Should Throw Argument Null|1 ms|
## CollectionHandleTest (11 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Proper Type And Collection When Collection Handle Instantiated Then Should Set Properties| |8 ms|
|Given Collection Not A Property On Db Context Type When Collection Handle Instantiated Then Should Throw Argument| |806 ns|
|Given Collection Not A Db Set When Collection Handle Instantiated Then Should Throw Argument| |742 ns|
|**Given Null Type Or Null Collection When Collection Handle Instantiated Then Should Throw Argument Null**| |**1 ms**|
| |(dbContext: typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestProductsContext), collection: null)|711 ns|
| |(dbContext: null, collection: Microsoft.EntityFrameworkCore.DbSet^1{ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestProduct} Products)|233 ns|
| |(dbContext: null, collection: null)|227 ns|
## RouteProcessorTest (7 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Path When Parse Path Called Then Should Return Parts**| |**5 ms**|
| |(path: null, expected: (, ))|4 ms|
| |(path: "efcore", expected: (, ))|269 ns|
| |(path: "", expected: (, ))|145 ns|
| |(path: "/efcore/context/collection", expected: (context, collection))|119 ns|
| |(path: "efcore/context", expected: (, ))|69 ns|
| |(path: "/efcore", expected: (, ))|61 ns|
| |(path: "efcore/context/collection/", expected: (, ))|49 ns|
| |(path: "efcore/context/collection", expected: (, ))|45 ns|
| |(path: "/efcore/context/", expected: (, ))|39 ns|
| |(path: "/efcore/context", expected: (, ))|29 ns|
| |(path: "/efcore/context/collection/", expected: (context, collection))|26 ns|
|Given Valid Parameters With Payload Single When Serialize Async Called Then Should Serialize To Stream| |2 ms|

[Go Back](./index.md)

# Summary of Test Runs for ExpressionPowerTools.Serialization.EFCore.AspNetCore

Jump to group:

- [CollectionHandleTest](#collectionhandletest-13-ms)
- [DbContextAdapterTest](#dbcontextadaptertest-270-ms)
- [EndToEndTest](#endtoendtest-755-ms)
- [ExpressionPowerToolsEFCoreMiddlewareTest](#expressionpowertoolsefcoremiddlewaretest-490-ms)
- [MiddlewareExtensionsTest](#middlewareextensionstest-54-ms)
- [QueryDeserializerTest](#querydeserializertest-433-ms)
- [QueryResultSerializerTest](#queryresultserializertest-84-ms)
- [RouteProcessorTest](#routeprocessortest-8-ms)

The slowest test was 'Single Db Context Works' at 481 ms.

## EndToEndTest (755 ms)

|Test Name|Duration|
|:--|--:|
|Single Db Context Works|481 ms|
|Multiple Db Contexts Work|149 ms|
|Single Request Works|22 ms|
|Default Ctor Restriction Honored|20 ms|
|Count Request Works|19 ms|
|Json Options Are Applied|17 ms|
|Complex Alternate Path Works|12 ms|
|No Default Rules Honored|12 ms|
|Alternate Path Works|12 ms|
|Not In Path Ignored|7 ms|
|Given Valid Parameters When Try Get Db Set Called Then Should Return Property Info And True|129 ns|
## QueryDeserializerTest (433 ms)

|Test Name|Duration|
|:--|--:|
|Given Null Query When Deserialize Async Called Then Should Throw Argument Null|233 ms|
|Given Rules Passed When Map Power Tools E F Core Base Called Then Should Configure Rules|144 ms|
|Given Json Not Serialization Payload When Deserialize Async Called Then Should Throw Null Reference|31 ms|
|Given Is Count True In Payload When Deserialize Async Called Then Should Return Is Count True|20 ms|
|Given No Json Payload When Deserialize Async Called Then Should Throw Argument|1 ms|
|Given Null Stream When Deserialize Async Called Then Should Throw Argument Null|1 ms|
## DbContextAdapterTest (270 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Parameters Are Valid When Create Query Called Then Should Return Query| |196 ms|
|Given Null Db Context When Create Query Called Then Should Throw Argument Null| |68 ms|
|Given Type Not Derived From Db Context When Collection Handle Instantiated Then Should Throw Argument| |1 ms|
|Given Collection Does Not Reference Db Set When Create Query Called Then Should Throw Argument Null| |714 ns|
|Given Collection Not On Db Context When Create Query Called Then Should Throw Target| |636 ns|
|**Given No Match Between Context And Types When Try Get Context Called Then Should Return False**| |**745 ns**|
| |(typeList: {}, context: "TestWidgetsContext")|507 ns|
| |(typeList: {typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext)}, context: "TestProductsContext")|112 ns|
| |(typeList: {}, context: null)|50 ns|
| |(typeList: null, context: "TestWidgetsContext")|27 ns|
| |(typeList: null, context: null)|24 ns|
| |(typeList: {typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.DbContextAdapterTests)}, context: "DbContextAdapterTests")|22 ns|
|Given Null Collection When Create Query Called Then Should Throw Argument Null| |502 ns|
|Given Match Between Context And Types When Try Get Context Called Then Should Return Context Type And True| |165 ns|
|**Given No Match Between Collection And Db Set When Try Get Db Set Called Then Should Return False**| |**219 ns**|
| |(dbContextType: typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext), collection: "Decoy")|120 ns|
| |(dbContextType: typeof(string), collection: "Length")|31 ns|
| |(dbContextType: null, collection: null)|23 ns|
| |(dbContextType: typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext), collection: "")|23 ns|
| |(dbContextType: null, collection: "Widgets")|20 ns|
## ExpressionPowerToolsEFCoreMiddlewareTest (490 ms)

|Test Name|Duration|
|:--|--:|
|Given Context Types Not Derived From Db Context When Middleware Instantiated Then Should Throw Argument|195 ms|
|Given Valid Body Invoke Called Then Should Return Result|138 ms|
|Given Invalid Body Invoke Called Then Should Set Internal Server Error Status Code|99 ms|
|Specific Rules Applied|21 ms|
|Given Path With Invalid Collection When Invoke Called Then Should Invoke Next Delegate|12 ms|
|Given Db Context Not Registered With Service Provider When Invoke Called Then Should Set Bad Request Status Code|6 ms|
|Given Path Not Of Root When Invoke Called Then Should Invoke Next Delegate|3 ms|
|Given Path With Invalid Context When Invoke Called Then Should Invoke Next Delegate|3 ms|
|Given Path Not With Collection When Invoke Called Then Should Invoke Next Delegate|2 ms|
|Given Path Not With Context When Invoke Called Then Should Invoke Next Delegate|2 ms|
|Given Method Not Post When Invoke Called Then Should Invoke Next Delegate|2 ms|
|Given Null Context Types When Middleware Instantiated Then Should Throw Argument Null|737 ns|
|Given Null Path When Middleware Instantiated Then Should Throw Argument|638 ns|
|Given Null Next Delegate When Middleware Instantiated Then Should Throw Argument Null|440 ns|
## QueryResultSerializerTest (84 ms)

|Test Name|Duration|
|:--|--:|
|Given Valid Inputs When Deserialize Async Called Then Should Deserialize Queryable|49 ms|
|Given Valid Parameters When Serialize Async Called Then Should Serialize To Stream|16 ms|
|Given Null Query When Serialize Async Called Then Should Throw Argument Exception|11 ms|
|Given Valid Parameters With Is Count True When Serialize Async Called Then Should Serialize To Stream|4 ms|
|Given Null Stream When Serialize Async Called Then Should Throw Argument Null|1 ms|
## MiddlewareExtensionsTest (54 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Bad Pattern When Map Power Tools E F Core Based Called Then Should Throw Argument**| |**48 ms**|
| |(pattern: "/efcore/{decoy}/{otherdecoy}")|42 ms|
| |(pattern: "/efcore/{context}/{decoy}")|1 ms|
| |(pattern: "/efcore/{collection}/{decoy}")|1 ms|
| |(pattern: "/efcore")|1 ms|
| |(pattern: "/efcore/{context}")|1 ms|
| |(pattern: "/efcore/{collection}")|1 ms|
|**Given Bad Db Context Types When Map Power Tools E F Core Base Called Then Should Throw Argument**| |**2 ms**|
| |(dbContextTypes: {typeof(string)})|1 ms|
| |(dbContextTypes: {})|1 ms|
|**Given Null Inputs When Map Power Tools E F Core Base Called Then Should Throw Argument Null**| |**2 ms**|
| |(useEndPointRouteBuilder: True, pattern: RoutePattern { Defaults = {}, InboundPrecedence = 1.33, OutboundPrecedence = 5.33, ParameterPolicies = {}, Parameters = {RoutePatternParameterPart { ... }, RoutePatternParameterPart { ... }}, ... }, contextTypes: null)|1 ms|
| |(useEndPointRouteBuilder: True, pattern: null, contextTypes: {typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext)})|1 ms|
| |(useEndPointRouteBuilder: False, pattern: RoutePattern { Defaults = {}, InboundPrecedence = 1.33, OutboundPrecedence = 5.33, ParameterPolicies = {}, Parameters = {RoutePatternParameterPart { ... }, RoutePatternParameterPart { ... }}, ... }, contextTypes: {typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestWidgetsContext)})|569 ns|
|Given Zero Length Context Types When Middleware Instantiated Then Should Throw Argument| |751 ns|
## CollectionHandleTest (13 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Proper Type And Collection When Collection Handle Instantiated Then Should Set Properties| |10 ms|
|**Given Null Type Or Null Collection When Collection Handle Instantiated Then Should Throw Argument Null**| |**1 ms**|
| |(dbContext: typeof(ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestProductsContext), collection: null)|1 ms|
| |(dbContext: null, collection: Microsoft.EntityFrameworkCore.DbSet^1{ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers.TestProduct} Products)|324 ns|
| |(dbContext: null, collection: null)|273 ns|
|Given Collection Not A Property On Db Context Type When Collection Handle Instantiated Then Should Throw Argument| |815 ns|
|Given Collection Not A Db Set When Collection Handle Instantiated Then Should Throw Argument| |765 ns|
## RouteProcessorTest (8 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Path When Parse Path Called Then Should Return Parts**| |**6 ms**|
| |(path: null, expected: (, ))|5 ms|
| |(path: "efcore", expected: (, ))|288 ns|
| |(path: "/efcore", expected: (, ))|162 ns|
| |(path: "/efcore/context/collection", expected: (context, collection))|143 ns|
| |(path: "", expected: (, ))|129 ns|
| |(path: "efcore/context", expected: (, ))|84 ns|
| |(path: "/efcore/context", expected: (, ))|79 ns|
| |(path: "efcore/context/collection/", expected: (, ))|62 ns|
| |(path: "efcore/context/collection", expected: (, ))|47 ns|
| |(path: "/efcore/context/collection/", expected: (context, collection))|29 ns|
| |(path: "/efcore/context/", expected: (, ))|23 ns|
|Given Valid Parameters With Payload Single When Serialize Async Called Then Should Serialize To Stream| |1 ms|

[Go Back](./index.md)

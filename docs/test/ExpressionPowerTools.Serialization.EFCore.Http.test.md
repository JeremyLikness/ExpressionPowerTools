# Summary of Test Runs for ExpressionPowerTools.Serialization.EFCore.Http

Jump to group:

- [ClientExtensionsTest](#clientextensionstest-498-ms)
- [ClientHttpConfigurationTest](#clienthttpconfigurationtest-161-ms)
- [DbClientContextTest](#dbclientcontexttest-3-ms)
- [HttpRemoteQueryResolverTest](#httpremotequeryresolvertest-112-ms)
- [RemoteClientTest](#remoteclienttest-154-ms)
- [RemoteQueryTest](#remotequerytest-16-ms)

The slowest test was 'Given Remote Query When Execute Remote Async Then Should Return I Remote Queryable' at 155 ms.

## ClientHttpConfigurationTest (161 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Remote Query When Execute Remote Async Then Should Return I Remote Queryable| |155 ms|
|Given Null Factory When Set Client Factory Called Then Should Throw Argument Null| |437 ns|
|**Given Invalid Path Template When Set Path Template Called Then Should Throw Argument**| |**2 ms**|
| |(path: "efcore/{context}/{decoy}")|429 ns|
| |(path: null)|277 ns|
| |(path: "efcore/{context}")|197 ns|
| |(path: "efcore/{context}/{collection}/{collection}")|188 ns|
| |(path: "{collection}")|188 ns|
| |(path: "/{context}{collection}")|187 ns|
| |(path: "/{context}")|184 ns|
| |(path: "/efcore/{context}{collection}")|182 ns|
| |(path: "{context}/{decoy}")|182 ns|
| |(path: "/efcore/{context}/{context}")|181 ns|
| |(path: "/{context}/{context}")|178 ns|
| |(path: "")|172 ns|
| |(path: "efcore/{collection}")|171 ns|
| |(path: "{context}/{collection}/{collection}")|170 ns|
|Given Factory When Set Client Factory Called Then Should Set Factory| |358 ns|
|**Given Valid Path Template When Set Path Template Called Then Should Set Path Template**| |**2 ms**|
| |(path: "efcore/{context}/{collection}/")|239 ns|
| |(path: "/{collection}/{context}")|160 ns|
| |(path: "efcore/{collection}/{context}")|154 ns|
| |(path: "{collection}/{context}/")|152 ns|
| |(path: "efcore/{collection}/{context}/")|151 ns|
| |(path: "{context}/{collection}/")|148 ns|
| |(path: "efcore/{context}/{collection}")|148 ns|
| |(path: "{context}/{collection}")|147 ns|
| |(path: "a/b/{context}/c/d/{collection}")|146 ns|
| |(path: "/{collection}/{context}/")|146 ns|
| |(path: "/{context}/{collection}/")|146 ns|
| |(path: "/{context}/{collection}")|144 ns|
| |(path: "{collection}/{context}")|144 ns|
|Is Registered| |90 ns|
## ClientExtensionsTest (498 ms)

|Test Name|Duration|
|:--|--:|
|Given Query Then As Enumerable Async Returns Enumerable|116 ms|
|Defaults To Use Service Provider|63 ms|
|Given Query Then To Array Async Returns Array|51 ms|
|Given Query Then Single Async Returns Single|48 ms|
|Given Query Then Count Async Returns Count|44 ms|
|Given Query Then To List Async Returns List|43 ms|
|Given Query Then To Hash Set Async Returns Hash Set|41 ms|
|Chaining Works|33 ms|
|Configure Path Sets Path|20 ms|
|Configure Client Captures Client|16 ms|
|Give Null Query Then To Array Async Throws Argument Null|7 ms|
|Given Non Remote Query When Execute Remote Async Then Should Throw Null Reference|3 ms|
|Give Null Query Then To Hash Set Async Throws Argument Null|3 ms|
|Given Null Query Then Count Async Throws Argument Null|1 ms|
|Given Null Query Then Single Async Throws Argument Null|1 ms|
|Give Null Query Then To List Async Throws Argument Null|804 ns|
|Give Null Query Then As Enumerable Async Throws Argument Null|779 ns|
|Given Null Query When Execute Remote Async Then Should Throw Argument Null|575 ns|
## RemoteClientTest (154 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Query When Fetch Remote Query Async Called Then Should Check For Success Code**| |**33 ms**|
| |(code: BadRequest)|33 ms|
| |(code: OK)|652 ns|
|**Query Yields Results**| |**116 ms**|
| |(queryCase: Single)|24 ms|
| |(queryCase: HashSet)|20 ms|
| |(queryCase: Array)|18 ms|
| |(queryCase: List)|18 ms|
| |(queryCase: Enumerable)|18 ms|
| |(queryCase: Count)|16 ms|
|Given Query When Fetch Remote Query Async Called Then Should Call Post Async| |1 ms|
|**Given Null Or Empty Path When Fetch Remote Query Async Called Then Should Throw Argument**| |**1 ms**|
| |(path: "")|1 ms|
| |(path: null)|267 ns|
| |(path: "  ")|257 ns|
|Given Null Query Content When Fetch Remote Query Async Called Then Should Throw Argument Null| |1 ms|
## HttpRemoteQueryResolverTest (112 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Empty Result Returns Default Or Negative**| |**102 ms**|
| |(queryCase: Array)|19 ms|
| |(queryCase: Count)|17 ms|
| |(queryCase: List)|17 ms|
| |(queryCase: Enumerable)|16 ms|
| |(queryCase: HashSet)|15 ms|
| |(queryCase: Single)|15 ms|
|**Given Query Not I Remote Query When Method Called Then Should Throw Argument Exception**| |**5 ms**|
| |(queryCase: List)|3 ms|
| |(queryCase: Count)|531 ns|
| |(queryCase: Enumerable)|494 ns|
| |(queryCase: HashSet)|492 ns|
| |(queryCase: Array)|489 ns|
| |(queryCase: Single)|479 ns|
|**Given Null Query When Method Called Then Should Throw Argument Null**| |**3 ms**|
| |(queryCase: Count)|1 ms|
| |(queryCase: Enumerable)|470 ns|
| |(queryCase: List)|468 ns|
| |(queryCase: HashSet)|458 ns|
| |(queryCase: Array)|454 ns|
| |(queryCase: Single)|444 ns|
|Given Expression References Non Db Set Wen Query Called Then Should Throw Argument| |903 ns|
## RemoteQueryTest (16 ms)

|Test Name|Duration|
|:--|--:|
|Given Remote Query With Projection When Filters Applied Then Should Retain Result Context|5 ms|
|Given Query When Fetch Remote Query Async Called Then Should Return Result|4 ms|
|Given Remote Query When Filters Applied Then Should Retain Result Context|3 ms|
|Given Remote Query Execution Should Intercept To Empty|2 ms|
|Given Null Remote Context When Remote Query Provider Instantiated Then Should Throw Argument Null|697 ns|
## DbClientContextTest (3 ms)

|Test Name|Duration|
|:--|--:|
|Given Expression On Different Context When Query Called Then Should Throw Argument|1 ms|
|Given Expression Of Correct Type Then Should Build Query With Context|1 ms|
|Given Empty Expression When Query Called Then Should Throw Argument Null|560 ns|
|Sets Appropriate Defaults|292 ns|

[Go Back](./index.md)

# Summary of Test Runs for ExpressionPowerTools.Serialization.EFCore.Http

Jump to group:

- [ClientExtensionsTest](#clientextensionstest-428-ms)
- [ClientHttpConfigurationTest](#clienthttpconfigurationtest-163-ms)
- [DbClientContextTest](#dbclientcontexttest-1-ms)
- [HttpRemoteQueryResolverTest](#httpremotequeryresolvertest-44-ms)
- [RemoteClientTest](#remoteclienttest-73-ms)
- [RemoteQueryTest](#remotequerytest-15-ms)

The slowest test was 'Given Remote Query When Execute Remote Async Then Should Return I Remote Queryable' at 156 ms.

## ClientHttpConfigurationTest (163 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Remote Query When Execute Remote Async Then Should Return I Remote Queryable| |156 ms|
|**Given Invalid Path Template When Set Path Template Called Then Should Throw Argument**| |**4 ms**|
| |(path: "efcore/{collection}")|1 ms|
| |(path: "efcore/{context}/{decoy}")|398 ns|
| |(path: null)|250 ns|
| |(path: "efcore/{context}/{collection}/{collection}")|221 ns|
| |(path: "")|203 ns|
| |(path: "{context}/{decoy}")|195 ns|
| |(path: "efcore/{context}")|182 ns|
| |(path: "/{context}/{context}")|182 ns|
| |(path: "/efcore/{context}/{context}")|180 ns|
| |(path: "{collection}")|174 ns|
| |(path: "/{context}")|172 ns|
| |(path: "/{context}{collection}")|171 ns|
| |(path: "/efcore/{context}{collection}")|170 ns|
| |(path: "{context}/{collection}/{collection}")|168 ns|
|Given Null Factory When Set Client Factory Called Then Should Throw Argument Null| |384 ns|
|Given Factory When Set Client Factory Called Then Should Set Factory| |361 ns|
|**Given Valid Path Template When Set Path Template Called Then Should Set Path Template**| |**2 ms**|
| |(path: "efcore/{context}/{collection}/")|282 ns|
| |(path: "efcore/{collection}/{context}/")|171 ns|
| |(path: "a/b/{context}/c/d/{collection}")|169 ns|
| |(path: "efcore/{collection}/{context}")|169 ns|
| |(path: "/{collection}/{context}")|164 ns|
| |(path: "/{context}/{collection}")|163 ns|
| |(path: "{context}/{collection}/")|162 ns|
| |(path: "{collection}/{context}/")|159 ns|
| |(path: "/{collection}/{context}/")|159 ns|
| |(path: "efcore/{context}/{collection}")|158 ns|
| |(path: "{context}/{collection}")|156 ns|
| |(path: "{collection}/{context}")|155 ns|
| |(path: "/{context}/{collection}/")|155 ns|
|Is Registered| |107 ns|
## ClientExtensionsTest (428 ms)

|Test Name|Duration|
|:--|--:|
|Given Query Then As Enumerable Async Returns Enumerable|88 ms|
|Defaults To Use Service Provider|59 ms|
|Given Query Then Single Async Returns Single|49 ms|
|Given Query Then To List Async Returns List|39 ms|
|Given Query Then To Array Async Returns Array|38 ms|
|Given Query Then Count Async Returns Count|38 ms|
|Given Query Then To Hash Set Async Returns Hash Set|37 ms|
|Chaining Works|33 ms|
|Configure Client Captures Client|17 ms|
|Configure Path Sets Path|15 ms|
|Give Null Query Then To Hash Set Async Throws Argument Null|4 ms|
|Give Null Query Then To Array Async Throws Argument Null|1 ms|
|Given Null Query Then Count Async Throws Argument Null|1 ms|
|Given Non Remote Query When Execute Remote Async Then Should Throw Null Reference|1 ms|
|Given Null Query Then Single Async Throws Argument Null|1 ms|
|Give Null Query Then As Enumerable Async Throws Argument Null|799 ns|
|Give Null Query Then To List Async Throws Argument Null|763 ns|
|Given Null Query When Execute Remote Async Then Should Throw Argument Null|545 ns|
## RemoteClientTest (73 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Query When Fetch Remote Query Async Called Then Should Check For Success Code**| |**28 ms**|
| |(code: BadRequest)|27 ms|
| |(code: OK)|595 ns|
|**Query Yields Results**| |**41 ms**|
| |(queryCase: Single)|14 ms|
| |(queryCase: List)|5 ms|
| |(queryCase: Array)|5 ms|
| |(queryCase: Count)|5 ms|
| |(queryCase: Enumerable)|5 ms|
| |(queryCase: HashSet)|5 ms|
|Given Query When Fetch Remote Query Async Called Then Should Call Post Async| |1 ms|
|**Given Null Or Empty Path When Fetch Remote Query Async Called Then Should Throw Argument**| |**1 ms**|
| |(path: "")|949 ns|
| |(path: null)|249 ns|
| |(path: "  ")|232 ns|
|Given Null Query Content When Fetch Remote Query Async Called Then Should Throw Argument Null| |931 ns|
## HttpRemoteQueryResolverTest (44 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Empty Result Returns Default Or Negative**| |**34 ms**|
| |(queryCase: HashSet)|7 ms|
| |(queryCase: Count)|5 ms|
| |(queryCase: List)|5 ms|
| |(queryCase: Single)|5 ms|
| |(queryCase: Array)|5 ms|
| |(queryCase: Enumerable)|5 ms|
|**Given Query Not I Remote Query When Method Called Then Should Throw Argument Exception**| |**5 ms**|
| |(queryCase: List)|3 ms|
| |(queryCase: Count)|523 ns|
| |(queryCase: HashSet)|477 ns|
| |(queryCase: Enumerable)|471 ns|
| |(queryCase: Single)|463 ns|
| |(queryCase: Array)|454 ns|
|Given Expression On Different Context When Query Called Then Should Throw Argument| |1 ms|
|**Given Null Query When Method Called Then Should Throw Argument Null**| |**3 ms**|
| |(queryCase: Count)|1 ms|
| |(queryCase: List)|424 ns|
| |(queryCase: HashSet)|423 ns|
| |(queryCase: Enumerable)|417 ns|
| |(queryCase: Single)|408 ns|
| |(queryCase: Array)|407 ns|
## RemoteQueryTest (15 ms)

|Test Name|Duration|
|:--|--:|
|Given Remote Query With Projection When Filters Applied Then Should Retain Result Context|5 ms|
|Given Query When Fetch Remote Query Async Called Then Should Return Result|3 ms|
|Given Remote Query When Filters Applied Then Should Retain Result Context|3 ms|
|Given Remote Query Execution Should Intercept To Empty|2 ms|
|Given Null Remote Context When Remote Query Provider Instantiated Then Should Throw Argument Null|832 ns|
## DbClientContextTest (1 ms)

|Test Name|Duration|
|:--|--:|
|Given Expression Of Correct Type Then Should Build Query With Context|1 ms|
|Given Empty Expression When Query Called Then Should Throw Argument Null|506 ns|
|Sets Appropriate Defaults|288 ns|

[Go Back](./index.md)

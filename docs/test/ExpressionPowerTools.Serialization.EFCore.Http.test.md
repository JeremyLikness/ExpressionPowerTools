# Summary of Test Runs for ExpressionPowerTools.Serialization.EFCore.Http

Jump to group:

- [ClientExtensionsTest](#clientextensionstest-402-ms)
- [ClientHttpConfigurationTest](#clienthttpconfigurationtest-158-ms)
- [DbClientContextTest](#dbclientcontexttest-2-ms)
- [HttpRemoteQueryResolverTest](#httpremotequeryresolvertest-44-ms)
- [RemoteClientTest](#remoteclienttest-65-ms)
- [RemoteQueryTest](#remotequerytest-14-ms)

The slowest test was 'Given Remote Query When Execute Remote Async Then Should Return I Remote Queryable' at 150 ms.

## ClientHttpConfigurationTest (158 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|Given Remote Query When Execute Remote Async Then Should Return I Remote Queryable| |150 ms|
|**Given Valid Path Template When Set Path Template Called Then Should Set Path Template**| |**4 ms**|
| |(path: "efcore/{context}/{collection}/")|1 ms|
| |(path: "/{context}/{collection}/")|307 ns|
| |(path: "/{context}/{collection}")|242 ns|
| |(path: "{context}/{collection}")|239 ns|
| |(path: "{collection}/{context}/")|233 ns|
| |(path: "{collection}/{context}")|222 ns|
| |(path: "efcore/{context}/{collection}")|214 ns|
| |(path: "/{collection}/{context}/")|195 ns|
| |(path: "efcore/{collection}/{context}/")|168 ns|
| |(path: "efcore/{collection}/{context}")|162 ns|
| |(path: "/{collection}/{context}")|161 ns|
| |(path: "{context}/{collection}/")|159 ns|
| |(path: "a/b/{context}/c/d/{collection}")|159 ns|
|Given Null Factory When Set Client Factory Called Then Should Throw Argument Null| |517 ns|
|Given Factory When Set Client Factory Called Then Should Set Factory| |494 ns|
|**Given Invalid Path Template When Set Path Template Called Then Should Throw Argument**| |**2 ms**|
| |(path: "efcore/{context}/{decoy}")|399 ns|
| |(path: null)|243 ns|
| |(path: "efcore/{context}")|180 ns|
| |(path: "/efcore/{context}/{context}")|176 ns|
| |(path: "{collection}")|173 ns|
| |(path: "/{context}")|173 ns|
| |(path: "efcore/{collection}")|171 ns|
| |(path: "/{context}{collection}")|169 ns|
| |(path: "")|168 ns|
| |(path: "efcore/{context}/{collection}/{collection}")|168 ns|
| |(path: "/efcore/{context}{collection}")|168 ns|
| |(path: "{context}/{decoy}")|167 ns|
| |(path: "{context}/{collection}/{collection}")|166 ns|
| |(path: "/{context}/{context}")|165 ns|
|Is Registered| |124 ns|
## ClientExtensionsTest (402 ms)

|Test Name|Duration|
|:--|--:|
|Given Query Then As Enumerable Async Returns Enumerable|77 ms|
|Defaults To Use Service Provider|55 ms|
|Given Query Then Single Async Returns Single|44 ms|
|Given Query Then To List Async Returns List|40 ms|
|Given Query Then To Hash Set Async Returns Hash Set|38 ms|
|Given Query Then Count Async Returns Count|37 ms|
|Given Query Then To Array Async Returns Array|35 ms|
|Chaining Works|31 ms|
|Configure Client Captures Client|16 ms|
|Configure Path Sets Path|13 ms|
|Give Null Query Then To Hash Set Async Throws Argument Null|2 ms|
|Given Non Remote Query When Execute Remote Async Then Should Throw Null Reference|1 ms|
|Given Null Query Then Count Async Throws Argument Null|1 ms|
|Given Null Query Then Single Async Throws Argument Null|1 ms|
|Give Null Query Then To Array Async Throws Argument Null|1 ms|
|Give Null Query Then As Enumerable Async Throws Argument Null|957 ns|
|Give Null Query Then To List Async Throws Argument Null|747 ns|
|Given Null Query When Execute Remote Async Then Should Throw Argument Null|514 ns|
## RemoteClientTest (65 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Given Query When Fetch Remote Query Async Called Then Should Check For Success Code**| |**21 ms**|
| |(code: BadRequest)|21 ms|
| |(code: OK)|583 ns|
|**Query Yields Results**| |**40 ms**|
| |(queryCase: Single)|14 ms|
| |(queryCase: Count)|5 ms|
| |(queryCase: List)|5 ms|
| |(queryCase: HashSet)|5 ms|
| |(queryCase: Enumerable)|5 ms|
| |(queryCase: Array)|5 ms|
|Given Query When Fetch Remote Query Async Called Then Should Call Post Async| |1 ms|
|Given Null Query Content When Fetch Remote Query Async Called Then Should Throw Argument Null| |1 ms|
|**Given Null Or Empty Path When Fetch Remote Query Async Called Then Should Throw Argument**| |**1 ms**|
| |(path: "")|885 ns|
| |(path: null)|231 ns|
| |(path: "  ")|222 ns|
## HttpRemoteQueryResolverTest (44 ms)

|Test Name|Test Iteration|Duration|
|:--|:--|--:|
|**Empty Result Returns Default Or Negative**| |**34 ms**|
| |(queryCase: HashSet)|7 ms|
| |(queryCase: List)|5 ms|
| |(queryCase: Count)|5 ms|
| |(queryCase: Single)|5 ms|
| |(queryCase: Array)|5 ms|
| |(queryCase: Enumerable)|5 ms|
|**Given Query Not I Remote Query When Method Called Then Should Throw Argument Exception**| |**5 ms**|
| |(queryCase: List)|2 ms|
| |(queryCase: Count)|500 ns|
| |(queryCase: Enumerable)|471 ns|
| |(queryCase: HashSet)|463 ns|
| |(queryCase: Single)|461 ns|
| |(queryCase: Array)|447 ns|
|Given Expression On Different Context When Query Called Then Should Throw Argument| |1 ms|
|**Given Null Query When Method Called Then Should Throw Argument Null**| |**2 ms**|
| |(queryCase: Count)|989 ns|
| |(queryCase: List)|407 ns|
| |(queryCase: Enumerable)|401 ns|
| |(queryCase: HashSet)|399 ns|
| |(queryCase: Single)|388 ns|
| |(queryCase: Array)|385 ns|
## RemoteQueryTest (14 ms)

|Test Name|Duration|
|:--|--:|
|Given Remote Query With Projection When Filters Applied Then Should Retain Result Context|4 ms|
|Given Query When Fetch Remote Query Async Called Then Should Return Result|3 ms|
|Given Remote Query When Filters Applied Then Should Retain Result Context|2 ms|
|Given Remote Query Execution Should Intercept To Empty|2 ms|
|Given Null Remote Context When Remote Query Provider Instantiated Then Should Throw Argument Null|577 ns|
## DbClientContextTest (2 ms)

|Test Name|Duration|
|:--|--:|
|Given Expression Of Correct Type Then Should Build Query With Context|1 ms|
|Given Empty Expression When Query Called Then Should Throw Argument Null|685 ns|
|Sets Appropriate Defaults|386 ns|

[Go Back](./index.md)

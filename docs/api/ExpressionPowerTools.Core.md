<a name='assembly'></a>
# ExpressionPowerTools.Core

## Contents

- [Ensure](#T-ExpressionPowerTools-Core-Contract-Ensure 'ExpressionPowerTools.Core.Contract.Ensure')
  - [NotNullOrWhitespace(value)](#M-ExpressionPowerTools-Core-Contract-Ensure-NotNullOrWhitespace-System-Linq-Expressions-Expression{System-Func{System-String}}- 'ExpressionPowerTools.Core.Contract.Ensure.NotNullOrWhitespace(System.Linq.Expressions.Expression{System.Func{System.String}})')
  - [NotNull\`\`1(value)](#M-ExpressionPowerTools-Core-Contract-Ensure-NotNull``1-System-Linq-Expressions-Expression{System-Func{``0}}- 'ExpressionPowerTools.Core.Contract.Ensure.NotNull``1(System.Linq.Expressions.Expression{System.Func{``0}})')
  - [PropertyNotNull\`\`1(value)](#M-ExpressionPowerTools-Core-Contract-Ensure-PropertyNotNull``1-System-Linq-Expressions-Expression{System-Func{``0}}- 'ExpressionPowerTools.Core.Contract.Ensure.PropertyNotNull``1(System.Linq.Expressions.Expression{System.Func{``0}})')
- [ExceptionHelper](#T-ExpressionPowerTools-Core-Resources-ExceptionHelper 'ExpressionPowerTools.Core.Resources.ExceptionHelper')
  - [ExceptionResources](#F-ExpressionPowerTools-Core-Resources-ExceptionHelper-ExceptionResources 'ExpressionPowerTools.Core.Resources.ExceptionHelper.ExceptionResources')
  - [MethodAccessRequired](#F-ExpressionPowerTools-Core-Resources-ExceptionHelper-MethodAccessRequired 'ExpressionPowerTools.Core.Resources.ExceptionHelper.MethodAccessRequired')
  - [NullReference](#F-ExpressionPowerTools-Core-Resources-ExceptionHelper-NullReference 'ExpressionPowerTools.Core.Resources.ExceptionHelper.NullReference')
  - [ResourceFile](#F-ExpressionPowerTools-Core-Resources-ExceptionHelper-ResourceFile 'ExpressionPowerTools.Core.Resources.ExceptionHelper.ResourceFile')
  - [ResourceManager](#F-ExpressionPowerTools-Core-Resources-ExceptionHelper-ResourceManager 'ExpressionPowerTools.Core.Resources.ExceptionHelper.ResourceManager')
  - [WhitespaceNotAllowed](#F-ExpressionPowerTools-Core-Resources-ExceptionHelper-WhitespaceNotAllowed 'ExpressionPowerTools.Core.Resources.ExceptionHelper.WhitespaceNotAllowed')
  - [MethodCallOnTypeRequiredException(parameterName)](#M-ExpressionPowerTools-Core-Resources-ExceptionHelper-MethodCallOnTypeRequiredException-System-String- 'ExpressionPowerTools.Core.Resources.ExceptionHelper.MethodCallOnTypeRequiredException(System.String)')
  - [NullReferenceNotAllowedException(memberName)](#M-ExpressionPowerTools-Core-Resources-ExceptionHelper-NullReferenceNotAllowedException-System-String- 'ExpressionPowerTools.Core.Resources.ExceptionHelper.NullReferenceNotAllowedException(System.String)')
  - [WhitespaceNotAllowedException(parameterName)](#M-ExpressionPowerTools-Core-Resources-ExceptionHelper-WhitespaceNotAllowedException-System-String- 'ExpressionPowerTools.Core.Resources.ExceptionHelper.WhitespaceNotAllowedException(System.String)')
- [ExceptionResources](#T-ExpressionPowerTools-Core-Resources-ExceptionResources 'ExpressionPowerTools.Core.Resources.ExceptionResources')
  - [Culture](#P-ExpressionPowerTools-Core-Resources-ExceptionResources-Culture 'ExpressionPowerTools.Core.Resources.ExceptionResources.Culture')
  - [MethodAccessRequired](#P-ExpressionPowerTools-Core-Resources-ExceptionResources-MethodAccessRequired 'ExpressionPowerTools.Core.Resources.ExceptionResources.MethodAccessRequired')
  - [NullReference](#P-ExpressionPowerTools-Core-Resources-ExceptionResources-NullReference 'ExpressionPowerTools.Core.Resources.ExceptionResources.NullReference')
  - [ResourceManager](#P-ExpressionPowerTools-Core-Resources-ExceptionResources-ResourceManager 'ExpressionPowerTools.Core.Resources.ExceptionResources.ResourceManager')
  - [WhitespaceNotAllowed](#P-ExpressionPowerTools-Core-Resources-ExceptionResources-WhitespaceNotAllowed 'ExpressionPowerTools.Core.Resources.ExceptionResources.WhitespaceNotAllowed')
- [ExpressionEnumerator](#T-ExpressionPowerTools-Core-ExpressionEnumerator 'ExpressionPowerTools.Core.ExpressionEnumerator')
  - [#ctor(expr)](#M-ExpressionPowerTools-Core-ExpressionEnumerator-#ctor-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.ExpressionEnumerator.#ctor(System.Linq.Expressions.Expression)')
  - [expression](#F-ExpressionPowerTools-Core-ExpressionEnumerator-expression 'ExpressionPowerTools.Core.ExpressionEnumerator.expression')
  - [queue](#F-ExpressionPowerTools-Core-ExpressionEnumerator-queue 'ExpressionPowerTools.Core.ExpressionEnumerator.queue')
  - [GetEnumerator()](#M-ExpressionPowerTools-Core-ExpressionEnumerator-GetEnumerator 'ExpressionPowerTools.Core.ExpressionEnumerator.GetEnumerator')
  - [RecurseBinaryExpression(binary)](#M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseBinaryExpression-System-Linq-Expressions-BinaryExpression- 'ExpressionPowerTools.Core.ExpressionEnumerator.RecurseBinaryExpression(System.Linq.Expressions.BinaryExpression)')
  - [RecurseConstantExpression(constant)](#M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseConstantExpression-System-Linq-Expressions-ConstantExpression- 'ExpressionPowerTools.Core.ExpressionEnumerator.RecurseConstantExpression(System.Linq.Expressions.ConstantExpression)')
  - [RecurseExpression(expression)](#M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseExpression-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.ExpressionEnumerator.RecurseExpression(System.Linq.Expressions.Expression)')
  - [RecurseLambdaExpression(lambda)](#M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseLambdaExpression-System-Linq-Expressions-LambdaExpression- 'ExpressionPowerTools.Core.ExpressionEnumerator.RecurseLambdaExpression(System.Linq.Expressions.LambdaExpression)')
  - [RecurseMemberExpression(member)](#M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseMemberExpression-System-Linq-Expressions-MemberExpression- 'ExpressionPowerTools.Core.ExpressionEnumerator.RecurseMemberExpression(System.Linq.Expressions.MemberExpression)')
  - [RecurseMethodCallExpression(method)](#M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseMethodCallExpression-System-Linq-Expressions-MethodCallExpression- 'ExpressionPowerTools.Core.ExpressionEnumerator.RecurseMethodCallExpression(System.Linq.Expressions.MethodCallExpression)')
  - [RecurseUnaryExpression(unary)](#M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseUnaryExpression-System-Linq-Expressions-UnaryExpression- 'ExpressionPowerTools.Core.ExpressionEnumerator.RecurseUnaryExpression(System.Linq.Expressions.UnaryExpression)')
  - [System#Collections#IEnumerable#GetEnumerator()](#M-ExpressionPowerTools-Core-ExpressionEnumerator-System#Collections#IEnumerable#GetEnumerator 'ExpressionPowerTools.Core.ExpressionEnumerator.System#Collections#IEnumerable#GetEnumerator')
- [ExpressionEquivalency](#T-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency')
  - [AreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-AreEquivalent-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.AreEquivalent(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [AreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-AreEquivalent-System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression},System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.AreEquivalent(System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression},System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression})')
  - [ConstantsAreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-ConstantsAreEquivalent-System-Linq-Expressions-ConstantExpression,System-Linq-Expressions-ConstantExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.ConstantsAreEquivalent(System.Linq.Expressions.ConstantExpression,System.Linq.Expressions.ConstantExpression)')
  - [NullAndTypeCheck(source,other)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-NullAndTypeCheck-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.NullAndTypeCheck(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
- [ExpressionExtensions](#T-ExpressionPowerTools-Core-Extensions-ExpressionExtensions 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions')
  - [AsConstantExpression(obj)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsConstantExpression-System-Object- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.AsConstantExpression(System.Object)')
  - [AsEnumerable(expression)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsEnumerable-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.AsEnumerable(System.Linq.Expressions.Expression)')
  - [AsParameterExpression(obj)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsParameterExpression-System-Object- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.AsParameterExpression(System.Object)')
  - [AsParameterExpression(type)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsParameterExpression-System-Type- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.AsParameterExpression(System.Type)')
  - [CreateParameterExpression\`\`2(value)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-CreateParameterExpression``2-System-Linq-Expressions-Expression{System-Func{``0,``1}}- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.CreateParameterExpression``2(System.Linq.Expressions.Expression{System.Func{``0,``1}})')
  - [MemberName\`\`1(expr)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-MemberName``1-System-Linq-Expressions-Expression{System-Func{``0}}- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.MemberName``1(System.Linq.Expressions.Expression{System.Func{``0}})')
- [IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator')
- [IExpressionEnumeratorExtensions](#T-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions')
  - [ConstantsOfType\`\`1(expressionEnumerator)](#M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-ConstantsOfType``1-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator- 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.ConstantsOfType``1(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator)')
  - [MethodsFromTemplate\`\`1(expressionEnumerator,method)](#M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-MethodsFromTemplate``1-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-Linq-Expressions-Expression{System-Action{``0}}- 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.MethodsFromTemplate``1(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator,System.Linq.Expressions.Expression{System.Action{``0}})')
  - [MethodsWithName(expressionEnumerator,name)](#M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-MethodsWithName-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-String- 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.MethodsWithName(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator,System.String)')
  - [MethodsWithNameForType(expressionEnumerator,type,name)](#M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-MethodsWithNameForType-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-Type,System-String- 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.MethodsWithNameForType(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator,System.Type,System.String)')
  - [MethodsWithNameForType\`\`1(expressionEnumerator,name)](#M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-MethodsWithNameForType``1-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-String- 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.MethodsWithNameForType``1(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator,System.String)')
  - [OfExpressionType(expressionEnumerator,type)](#M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-OfExpressionType-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-Linq-Expressions-ExpressionType- 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.OfExpressionType(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator,System.Linq.Expressions.ExpressionType)')
- [IQueryableExtensions](#T-ExpressionPowerTools-Core-Extensions-IQueryableExtensions 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions')
  - [AsEnumerableExpression(query)](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-AsEnumerableExpression-System-Linq-IQueryable- 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.AsEnumerableExpression(System.Linq.IQueryable)')
  - [AsEnumerableExpression\`\`1(query)](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-AsEnumerableExpression``1-System-Linq-IQueryable{``0}- 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.AsEnumerableExpression``1(System.Linq.IQueryable{``0})')

<a name='T-ExpressionPowerTools-Core-Contract-Ensure'></a>
## Ensure `type`

##### Namespace

ExpressionPowerTools.Core.Contract

##### Summary

Helper methods for validation.

<a name='M-ExpressionPowerTools-Core-Contract-Ensure-NotNullOrWhitespace-System-Linq-Expressions-Expression{System-Func{System-String}}-'></a>
### NotNullOrWhitespace(value) `method`

##### Summary

Ensure the property is not null or whitespace.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Linq.Expressions.Expression{System.Func{System.String}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{System.String}}') | An expression that resolves to the value. |

<a name='M-ExpressionPowerTools-Core-Contract-Ensure-NotNull``1-System-Linq-Expressions-Expression{System-Func{``0}}-'></a>
### NotNull\`\`1(value) `method`

##### Summary

Ensures that the result of an argument expression is
not null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Linq.Expressions.Expression{System.Func{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0}}') | An expression that resolves to the value. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the value to test. |

<a name='M-ExpressionPowerTools-Core-Contract-Ensure-PropertyNotNull``1-System-Linq-Expressions-Expression{System-Func{``0}}-'></a>
### PropertyNotNull\`\`1(value) `method`

##### Summary

Ensures that the result of an expression is not null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Linq.Expressions.Expression{System.Func{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0}}') | An expression that resolves to the value. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the value to test. |

<a name='T-ExpressionPowerTools-Core-Resources-ExceptionHelper'></a>
## ExceptionHelper `type`

##### Namespace

ExpressionPowerTools.Core.Resources

##### Summary

Helper for localized exceptions.

<a name='F-ExpressionPowerTools-Core-Resources-ExceptionHelper-ExceptionResources'></a>
### ExceptionResources `constants`

##### Summary

Name of resource file.

<a name='F-ExpressionPowerTools-Core-Resources-ExceptionHelper-MethodAccessRequired'></a>
### MethodAccessRequired `constants`

##### Summary

Method access message.

<a name='F-ExpressionPowerTools-Core-Resources-ExceptionHelper-NullReference'></a>
### NullReference `constants`

##### Summary

Null reference message.

<a name='F-ExpressionPowerTools-Core-Resources-ExceptionHelper-ResourceFile'></a>
### ResourceFile `constants`

##### Summary

Path to the resource file.

<a name='F-ExpressionPowerTools-Core-Resources-ExceptionHelper-ResourceManager'></a>
### ResourceManager `constants`

##### Summary

Resource manager to use.

<a name='F-ExpressionPowerTools-Core-Resources-ExceptionHelper-WhitespaceNotAllowed'></a>
### WhitespaceNotAllowed `constants`

##### Summary

Whitespace message.

<a name='M-ExpressionPowerTools-Core-Resources-ExceptionHelper-MethodCallOnTypeRequiredException-System-String-'></a>
### MethodCallOnTypeRequiredException(parameterName) `method`

##### Summary

Generates a [ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') for invalid expression.

##### Returns

The [ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parameterName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the parameter. |

<a name='M-ExpressionPowerTools-Core-Resources-ExceptionHelper-NullReferenceNotAllowedException-System-String-'></a>
### NullReferenceNotAllowedException(memberName) `method`

##### Summary

Null reference exception.

##### Returns

A [NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The member that is null. |

<a name='M-ExpressionPowerTools-Core-Resources-ExceptionHelper-WhitespaceNotAllowedException-System-String-'></a>
### WhitespaceNotAllowedException(parameterName) `method`

##### Summary

Generates a [ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') for empty string.

##### Returns

The [ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parameterName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the parameter. |

<a name='T-ExpressionPowerTools-Core-Resources-ExceptionResources'></a>
## ExceptionResources `type`

##### Namespace

ExpressionPowerTools.Core.Resources

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-ExpressionPowerTools-Core-Resources-ExceptionResources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all
  resource lookups using this strongly typed resource class.

<a name='P-ExpressionPowerTools-Core-Resources-ExceptionResources-MethodAccessRequired'></a>
### MethodAccessRequired `property`

##### Summary

Looks up a localized string similar to The parameter must be an expression that resolves to a method on the declared type..

<a name='P-ExpressionPowerTools-Core-Resources-ExceptionResources-NullReference'></a>
### NullReference `property`

##### Summary

Looks up a localized string similar to The value of {0} cannot be null..

<a name='P-ExpressionPowerTools-Core-Resources-ExceptionResources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='P-ExpressionPowerTools-Core-Resources-ExceptionResources-WhitespaceNotAllowed'></a>
### WhitespaceNotAllowed `property`

##### Summary

Looks up a localized string similar to The parameter requires a value. Null and whitespace not allowed..

<a name='T-ExpressionPowerTools-Core-ExpressionEnumerator'></a>
## ExpressionEnumerator `type`

##### Namespace

ExpressionPowerTools.Core

##### Summary

Recurse an [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') tree.

<a name='M-ExpressionPowerTools-Core-ExpressionEnumerator-#ctor-System-Linq-Expressions-Expression-'></a>
### #ctor(expr) `constructor`

##### Summary

Initializes a new instance of the [ExpressionEnumerator](#T-ExpressionPowerTools-Core-ExpressionEnumerator 'ExpressionPowerTools.Core.ExpressionEnumerator') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expr | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to enumerate. |

<a name='F-ExpressionPowerTools-Core-ExpressionEnumerator-expression'></a>
### expression `constants`

##### Summary

The root [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression').

<a name='F-ExpressionPowerTools-Core-ExpressionEnumerator-queue'></a>
### queue `constants`

##### Summary

A queue to track visited expressions.

<a name='M-ExpressionPowerTools-Core-ExpressionEnumerator-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Implements [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1').

##### Returns

The [IEnumerator\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerator`1 'System.Collections.Generic.IEnumerator`1').

##### Parameters

This method has no parameters.

<a name='M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseBinaryExpression-System-Linq-Expressions-BinaryExpression-'></a>
### RecurseBinaryExpression(binary) `method`

##### Summary

Recurse a binary expression.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| binary | [System.Linq.Expressions.BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression') | The [BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression') to parse. |

<a name='M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseConstantExpression-System-Linq-Expressions-ConstantExpression-'></a>
### RecurseConstantExpression(constant) `method`

##### Summary

Recurse any expression in the constant.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| constant | [System.Linq.Expressions.ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression') | The [ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression'). |

<a name='M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseExpression-System-Linq-Expressions-Expression-'></a>
### RecurseExpression(expression) `method`

##### Summary

Main entry, similar to "Visit" on [ExpressionVisitor](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ExpressionVisitor 'System.Linq.Expressions.ExpressionVisitor').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') under consideration. |

<a name='M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseLambdaExpression-System-Linq-Expressions-LambdaExpression-'></a>
### RecurseLambdaExpression(lambda) `method`

##### Summary

Recurse a lambda expression.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lambda | [System.Linq.Expressions.LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression') | The [LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression') to parse. |

<a name='M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseMemberExpression-System-Linq-Expressions-MemberExpression-'></a>
### RecurseMemberExpression(member) `method`

##### Summary

Recurse a member expression.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| member | [System.Linq.Expressions.MemberExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberExpression 'System.Linq.Expressions.MemberExpression') | The [MemberExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberExpression 'System.Linq.Expressions.MemberExpression') to parse. |

<a name='M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseMethodCallExpression-System-Linq-Expressions-MethodCallExpression-'></a>
### RecurseMethodCallExpression(method) `method`

##### Summary

Recurse a method call expression.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| method | [System.Linq.Expressions.MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression') | The [MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression') to recurse. |

<a name='M-ExpressionPowerTools-Core-ExpressionEnumerator-RecurseUnaryExpression-System-Linq-Expressions-UnaryExpression-'></a>
### RecurseUnaryExpression(unary) `method`

##### Summary

Recurse a unary expression.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| unary | [System.Linq.Expressions.UnaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.UnaryExpression 'System.Linq.Expressions.UnaryExpression') | The [UnaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.UnaryExpression 'System.Linq.Expressions.UnaryExpression') to parse. |

<a name='M-ExpressionPowerTools-Core-ExpressionEnumerator-System#Collections#IEnumerable#GetEnumerator'></a>
### System#Collections#IEnumerable#GetEnumerator() `method`

##### Summary

Non-generic version.

##### Returns

The generic version as a non-generic inteface.

##### Parameters

This method has no parameters.

<a name='T-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency'></a>
## ExpressionEquivalency `type`

##### Namespace

ExpressionPowerTools.Core.Comparisons

##### Summary

Host for comparisons.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-AreEquivalent-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### AreEquivalent(source,target) `method`

##### Summary

Entry for equivalency comparisons. Will cast to
known types and compare.

##### Returns

A flag indicating whether the source and target are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |
| target | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The target [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to compare to. |

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-AreEquivalent-System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression},System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}-'></a>
### AreEquivalent(source,target) `method`

##### Summary

Comparison of multiple expressions. Equivalent
only when all elements match, in order, and
pass the equivalent test.

##### Returns

A flag indicating whether the two sets of
expressions are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}') | The source expressions. |
| target | [System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}') | The target expressions. |

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-ConstantsAreEquivalent-System-Linq-Expressions-ConstantExpression,System-Linq-Expressions-ConstantExpression-'></a>
### ConstantsAreEquivalent(source,target) `method`

##### Summary

Method to compare two 
instances.

##### Returns

A flag indicating whether the two are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression') | The source constant. |
| target | [System.Linq.Expressions.ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression') | The target constant. |

##### Remarks

To be true, both must have the same type and value. If the
value is an expression tree, it is recursed.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-NullAndTypeCheck-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### NullAndTypeCheck(source,other) `method`

##### Summary

Comparison matrix for types and nulls.

##### Returns

A flag indicating whether the types are
equal and the values are both not null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source to compare. |
| other | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The target to compare to. |

<a name='T-ExpressionPowerTools-Core-Extensions-ExpressionExtensions'></a>
## ExpressionExtensions `type`

##### Namespace

ExpressionPowerTools.Core.Extensions

##### Summary

Extension methods for fluent API over expressions.

<a name='M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsConstantExpression-System-Object-'></a>
### AsConstantExpression(obj) `method`

##### Summary

Wraps an item as a [ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression').

##### Returns

The [ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The object to wrap. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when object is null. |

##### Example

For example:

```csharp
var target = this.AsConstantExpression();
```

<a name='M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsEnumerable-System-Linq-Expressions-Expression-'></a>
### AsEnumerable(expression) `method`

##### Summary

Provides a way to enumerate an expression tree.

##### Returns

The [IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to recurse. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when expression is null. |

##### Example

For example:

```csharp
var expr = Expression.Constant(this);
var target = expr.AsEnumerable();
```

<a name='M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsParameterExpression-System-Object-'></a>
### AsParameterExpression(obj) `method`

##### Summary

Creates a [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression') based on the
type of the object.

##### Returns

The [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The object to inspect. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when object is null. |

##### Example

For example:

```csharp
var target = this.AsParameterExpression();
// target.Type == this.GetType()
```

<a name='M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsParameterExpression-System-Type-'></a>
### AsParameterExpression(type) `method`

##### Summary

Creates a [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression') based on the
[Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type').

##### Returns

The [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') to use. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when type is null. |

##### Example

For example:

```csharp
var target = GetType().AsParameterExpression();
// target.Type == GetType()
```

<a name='M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-CreateParameterExpression``2-System-Linq-Expressions-Expression{System-Func{``0,``1}}-'></a>
### CreateParameterExpression\`\`2(value) `method`

##### Summary

Extracts the parameter from a member expression.

##### Returns

The [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Linq.Expressions.Expression{System.Func{\`\`0,\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0,``1}}') | An expression that evaluates to the member. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The parent type. |
| TValue | The member type. |

##### Example

For example:

```csharp
var result = ExpressionExtensions
    .CreateParameterExpression{Foo, string}(
       foo =&gt; foo.Bar);
// result.Type == typeof(string)
// result.Name == "Bar";
```

<a name='M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-MemberName``1-System-Linq-Expressions-Expression{System-Func{``0}}-'></a>
### MemberName\`\`1(expr) `method`

##### Summary

Extracts the name of the target of an expression.

##### Returns

The name of the target.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expr | [System.Linq.Expressions.Expression{System.Func{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{``0}}') | An expression that results in a parameter. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the target. |

##### Example

For example:

```csharp
Expression{Func{string}} expr = () =&gt; foo;
expr.MemberName(); // "foo"
```

<a name='T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator'></a>
## IExpressionEnumerator `type`

##### Namespace

ExpressionPowerTools.Core.Signatures

##### Summary

Enables recursing over an expression tree.

<a name='T-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions'></a>
## IExpressionEnumeratorExtensions `type`

##### Namespace

ExpressionPowerTools.Core.Extensions

##### Summary

Extensions for filtering [IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator').

<a name='M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-ConstantsOfType``1-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator-'></a>
### ConstantsOfType\`\`1(expressionEnumerator) `method`

##### Summary

Helper extension to extract constants from an expression tree.

##### Returns

The [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1') with
matching types.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expressionEnumerator | [ExpressionPowerTools.Core.Signatures.IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') | The [IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') to parse. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of constant to extract. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when enumerator is null. |

<a name='M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-MethodsFromTemplate``1-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-Linq-Expressions-Expression{System-Action{``0}}-'></a>
### MethodsFromTemplate\`\`1(expressionEnumerator,method) `method`

##### Summary

Use a template to specify the method to search for.

##### Returns

The list of matching [MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression') instances.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expressionEnumerator | [ExpressionPowerTools.Core.Signatures.IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') | The [IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') to query. |
| method | [System.Linq.Expressions.Expression{System.Action{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Action{``0}}') | An expression that accesses the method. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') the method is on. |

##### Remarks

Only matches method name and declaring type. Arguments are ignored.

<a name='M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-MethodsWithName-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-String-'></a>
### MethodsWithName(expressionEnumerator,name) `method`

##### Summary

Helper extension to extract methods with a particular name.

##### Returns

The [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1') result.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expressionEnumerator | [ExpressionPowerTools.Core.Signatures.IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') | The [IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') to query. |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The method name to extract. |

<a name='M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-MethodsWithNameForType-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-Type,System-String-'></a>
### MethodsWithNameForType(expressionEnumerator,type,name) `method`

##### Summary

Extracts instances of expressions that represent a method
on a type.

##### Returns

The filtered [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1') result.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expressionEnumerator | [ExpressionPowerTools.Core.Signatures.IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') | The [IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') to query. |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') to check for. |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the method. |

<a name='M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-MethodsWithNameForType``1-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-String-'></a>
### MethodsWithNameForType\`\`1(expressionEnumerator,name) `method`

##### Summary

Extracts instances of expressions that represent a method
on a type.

##### Returns

The [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1') filtered results.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expressionEnumerator | [ExpressionPowerTools.Core.Signatures.IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') | The [IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') to query. |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the method to query for. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type hosting the method. |

<a name='M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-OfExpressionType-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-Linq-Expressions-ExpressionType-'></a>
### OfExpressionType(expressionEnumerator,type) `method`

##### Summary

Helper extension to extract nodes with a specific
[ExpressionType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ExpressionType 'System.Linq.Expressions.ExpressionType') value.

##### Returns

The filtered result of [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expressionEnumerator | [ExpressionPowerTools.Core.Signatures.IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') | The [IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') to query. |
| type | [System.Linq.Expressions.ExpressionType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ExpressionType 'System.Linq.Expressions.ExpressionType') | The [ExpressionType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ExpressionType 'System.Linq.Expressions.ExpressionType') to extract. |

<a name='T-ExpressionPowerTools-Core-Extensions-IQueryableExtensions'></a>
## IQueryableExtensions `type`

##### Namespace

ExpressionPowerTools.Core.Extensions

##### Summary

Extensions over the [IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable') interface.

<a name='M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-AsEnumerableExpression-System-Linq-IQueryable-'></a>
### AsEnumerableExpression(query) `method`

##### Summary

Providers a way to enumerate the expression behind a query.

##### Returns

The [IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator') instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Linq.IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable') | The query to enumerate. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when query is null. |

##### Example

For example:

```csharp
var query = new List{IQueryableExtensionsTests}()
       .AsQueryable()
       .Where(t =&gt; t.GetHashCode() == int.MaxValue);
var target = query.AsEnumerableExpression();
```

<a name='M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-AsEnumerableExpression``1-System-Linq-IQueryable{``0}-'></a>
### AsEnumerableExpression\`\`1(query) `method`

##### Summary

Generic extension.

##### Returns

The [IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1'). |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The query type. |

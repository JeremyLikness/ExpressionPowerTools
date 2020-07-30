<a name='assembly'></a>
# ExpressionPowerTools.Core

## Contents

- [CustomQueryProvider\`1](#T-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1 'ExpressionPowerTools.Core.Providers.CustomQueryProvider`1')
  - [#ctor(sourceQuery)](#M-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-#ctor-System-Linq-IQueryable- 'ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.#ctor(System.Linq.IQueryable)')
  - [Source](#P-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-Source 'ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.Source')
  - [CreateQuery(expression)](#M-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-CreateQuery-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.CreateQuery(System.Linq.Expressions.Expression)')
  - [CreateQuery\`\`1(expression)](#M-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-CreateQuery``1-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.CreateQuery``1(System.Linq.Expressions.Expression)')
  - [Execute(expression)](#M-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-Execute-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.Execute(System.Linq.Expressions.Expression)')
  - [ExecuteEnumerable(expression)](#M-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-ExecuteEnumerable-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.ExecuteEnumerable(System.Linq.Expressions.Expression)')
  - [Execute\`\`1(expression)](#M-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-Execute``1-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.CustomQueryProvider`1.Execute``1(System.Linq.Expressions.Expression)')
- [Ensure](#T-ExpressionPowerTools-Core-Contract-Ensure 'ExpressionPowerTools.Core.Contract.Ensure')
  - [NotNullOrWhitespace(value)](#M-ExpressionPowerTools-Core-Contract-Ensure-NotNullOrWhitespace-System-Linq-Expressions-Expression{System-Func{System-String}}- 'ExpressionPowerTools.Core.Contract.Ensure.NotNullOrWhitespace(System.Linq.Expressions.Expression{System.Func{System.String}})')
  - [NotNull\`\`1(value)](#M-ExpressionPowerTools-Core-Contract-Ensure-NotNull``1-System-Linq-Expressions-Expression{System-Func{``0}}- 'ExpressionPowerTools.Core.Contract.Ensure.NotNull``1(System.Linq.Expressions.Expression{System.Func{``0}})')
  - [VariableNotNull\`\`1(value)](#M-ExpressionPowerTools-Core-Contract-Ensure-VariableNotNull``1-System-Linq-Expressions-Expression{System-Func{``0}}- 'ExpressionPowerTools.Core.Contract.Ensure.VariableNotNull``1(System.Linq.Expressions.Expression{System.Func{``0}})')
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
  - [BinariesAreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-BinariesAreEquivalent-System-Linq-Expressions-BinaryExpression,System-Linq-Expressions-BinaryExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.BinariesAreEquivalent(System.Linq.Expressions.BinaryExpression,System.Linq.Expressions.BinaryExpression)')
  - [ConstantsAreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-ConstantsAreEquivalent-System-Linq-Expressions-ConstantExpression,System-Linq-Expressions-ConstantExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.ConstantsAreEquivalent(System.Linq.Expressions.ConstantExpression,System.Linq.Expressions.ConstantExpression)')
  - [LambdasAreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-LambdasAreEquivalent-System-Linq-Expressions-LambdaExpression,System-Linq-Expressions-LambdaExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.LambdasAreEquivalent(System.Linq.Expressions.LambdaExpression,System.Linq.Expressions.LambdaExpression)')
  - [MembersAreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-MembersAreEquivalent-System-Linq-Expressions-MemberExpression,System-Linq-Expressions-MemberExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.MembersAreEquivalent(System.Linq.Expressions.MemberExpression,System.Linq.Expressions.MemberExpression)')
  - [MethodsAreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-MethodsAreEquivalent-System-Linq-Expressions-MethodCallExpression,System-Linq-Expressions-MethodCallExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.MethodsAreEquivalent(System.Linq.Expressions.MethodCallExpression,System.Linq.Expressions.MethodCallExpression)')
  - [NullAndTypeCheck(source,other)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-NullAndTypeCheck-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.NullAndTypeCheck(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [ParametersAreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-ParametersAreEquivalent-System-Linq-Expressions-ParameterExpression,System-Linq-Expressions-ParameterExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.ParametersAreEquivalent(System.Linq.Expressions.ParameterExpression,System.Linq.Expressions.ParameterExpression)')
  - [UnariesAreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-UnariesAreEquivalent-System-Linq-Expressions-UnaryExpression,System-Linq-Expressions-UnaryExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.UnariesAreEquivalent(System.Linq.Expressions.UnaryExpression,System.Linq.Expressions.UnaryExpression)')
  - [ValuesAreEquivalent(type,source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-ValuesAreEquivalent-System-Type,System-Object,System-Object- 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency.ValuesAreEquivalent(System.Type,System.Object,System.Object)')
- [ExpressionEvaluator](#T-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator 'ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator')
  - [AreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-AreEquivalent-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.AreEquivalent(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [AreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-AreEquivalent-System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression},System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}- 'ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.AreEquivalent(System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression},System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression})')
  - [AreEquivalent\`\`1(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-AreEquivalent``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}- 'ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.AreEquivalent``1(System.Linq.IQueryable{``0},System.Linq.IQueryable{``0})')
  - [AreSimilar(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-AreSimilar-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.AreSimilar(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [AreSimilar(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-AreSimilar-System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression},System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}- 'ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.AreSimilar(System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression},System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression})')
  - [AreSimilar\`\`1(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-AreSimilar``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}- 'ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.AreSimilar``1(System.Linq.IQueryable{``0},System.Linq.IQueryable{``0})')
  - [IsPartOf(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-IsPartOf-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.IsPartOf(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [IsPartOf\`\`1(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-IsPartOf``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}- 'ExpressionPowerTools.Core.Comparisons.ExpressionEvaluator.IsPartOf``1(System.Linq.IQueryable{``0},System.Linq.IQueryable{``0})')
- [ExpressionExtensions](#T-ExpressionPowerTools-Core-Extensions-ExpressionExtensions 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions')
  - [AsConstantExpression(obj)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsConstantExpression-System-Object- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.AsConstantExpression(System.Object)')
  - [AsEnumerable(expression)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsEnumerable-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.AsEnumerable(System.Linq.Expressions.Expression)')
  - [AsParameterExpression(obj,name,byRef)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsParameterExpression-System-Object,System-String,System-Boolean- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.AsParameterExpression(System.Object,System.String,System.Boolean)')
  - [AsParameterExpression(type,name,byRef)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsParameterExpression-System-Type,System-String,System-Boolean- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.AsParameterExpression(System.Type,System.String,System.Boolean)')
  - [CreateParameterExpression\`\`2(value)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-CreateParameterExpression``2-System-Linq-Expressions-Expression{System-Func{``0,``1}}- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.CreateParameterExpression``2(System.Linq.Expressions.Expression{System.Func{``0,``1}})')
  - [IsEquivalentTo(source,target)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-IsEquivalentTo-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.IsEquivalentTo(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [IsPartOf(source,target)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-IsPartOf-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.IsPartOf(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [IsSimilarTo(source,target)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-IsSimilarTo-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.IsSimilarTo(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [MemberName\`\`1(expr)](#M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-MemberName``1-System-Linq-Expressions-Expression{System-Func{``0}}- 'ExpressionPowerTools.Core.Extensions.ExpressionExtensions.MemberName``1(System.Linq.Expressions.Expression{System.Func{``0}})')
- [ExpressionSimilarity](#T-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity')
  - [AreSimilar(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-AreSimilar-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.AreSimilar(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [AreSimilar(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-AreSimilar-System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression},System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}- 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.AreSimilar(System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression},System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression})')
  - [BinariesAreSimilar(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-BinariesAreSimilar-System-Linq-Expressions-BinaryExpression,System-Linq-Expressions-BinaryExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.BinariesAreSimilar(System.Linq.Expressions.BinaryExpression,System.Linq.Expressions.BinaryExpression)')
  - [ConstantsAreSimilar(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-ConstantsAreSimilar-System-Linq-Expressions-ConstantExpression,System-Linq-Expressions-ConstantExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.ConstantsAreSimilar(System.Linq.Expressions.ConstantExpression,System.Linq.Expressions.ConstantExpression)')
  - [IsPartOf(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-IsPartOf-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.IsPartOf(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [LambdasAreSimilar(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-LambdasAreSimilar-System-Linq-Expressions-LambdaExpression,System-Linq-Expressions-LambdaExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.LambdasAreSimilar(System.Linq.Expressions.LambdaExpression,System.Linq.Expressions.LambdaExpression)')
  - [MembersAreSimilar(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-MembersAreSimilar-System-Linq-Expressions-MemberExpression,System-Linq-Expressions-MemberExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.MembersAreSimilar(System.Linq.Expressions.MemberExpression,System.Linq.Expressions.MemberExpression)')
  - [MethodsAreSimilar(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-MethodsAreSimilar-System-Linq-Expressions-MethodCallExpression,System-Linq-Expressions-MethodCallExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.MethodsAreSimilar(System.Linq.Expressions.MethodCallExpression,System.Linq.Expressions.MethodCallExpression)')
  - [TypeCheckAndCompare\`\`1(source,target,compare)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-TypeCheckAndCompare``1-``0,System-Linq-Expressions-Expression,System-Func{``0,``0,System-Boolean}- 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.TypeCheckAndCompare``1(``0,System.Linq.Expressions.Expression,System.Func{``0,``0,System.Boolean})')
  - [TypesAreSimilar(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-TypesAreSimilar-System-Type,System-Type- 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.TypesAreSimilar(System.Type,System.Type)')
  - [UnariesAreSimilar(source,target)](#M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-UnariesAreSimilar-System-Linq-Expressions-UnaryExpression,System-Linq-Expressions-UnaryExpression- 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity.UnariesAreSimilar(System.Linq.Expressions.UnaryExpression,System.Linq.Expressions.UnaryExpression)')
- [ExpressionTransformer](#T-ExpressionPowerTools-Core-ExpressionTransformer 'ExpressionPowerTools.Core.ExpressionTransformer')
- [ICustomQueryProvider\`1](#T-ExpressionPowerTools-Core-Signatures-ICustomQueryProvider`1 'ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1')
  - [ExecuteEnumerable(expression)](#M-ExpressionPowerTools-Core-Signatures-ICustomQueryProvider`1-ExecuteEnumerable-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1.ExecuteEnumerable(System.Linq.Expressions.Expression)')
- [IExpressionEnumerator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator 'ExpressionPowerTools.Core.Signatures.IExpressionEnumerator')
- [IExpressionEnumeratorExtensions](#T-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions')
  - [ConstantsOfType\`\`1(expressionEnumerator)](#M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-ConstantsOfType``1-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator- 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.ConstantsOfType``1(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator)')
  - [MethodsFromTemplate\`\`1(expressionEnumerator,method)](#M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-MethodsFromTemplate``1-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-Linq-Expressions-Expression{System-Action{``0}}- 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.MethodsFromTemplate``1(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator,System.Linq.Expressions.Expression{System.Action{``0}})')
  - [MethodsWithName(expressionEnumerator,name)](#M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-MethodsWithName-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-String- 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.MethodsWithName(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator,System.String)')
  - [MethodsWithNameForType(expressionEnumerator,type,name)](#M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-MethodsWithNameForType-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-Type,System-String- 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.MethodsWithNameForType(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator,System.Type,System.String)')
  - [MethodsWithNameForType\`\`1(expressionEnumerator,name)](#M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-MethodsWithNameForType``1-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-String- 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.MethodsWithNameForType``1(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator,System.String)')
  - [OfExpressionType(expressionEnumerator,type)](#M-ExpressionPowerTools-Core-Extensions-IExpressionEnumeratorExtensions-OfExpressionType-ExpressionPowerTools-Core-Signatures-IExpressionEnumerator,System-Linq-Expressions-ExpressionType- 'ExpressionPowerTools.Core.Extensions.IExpressionEnumeratorExtensions.OfExpressionType(ExpressionPowerTools.Core.Signatures.IExpressionEnumerator,System.Linq.Expressions.ExpressionType)')
- [IExpressionEvaluator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator 'ExpressionPowerTools.Core.Signatures.IExpressionEvaluator')
  - [AreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-AreEquivalent-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.AreEquivalent(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [AreEquivalent(source,target)](#M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-AreEquivalent-System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression},System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}- 'ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.AreEquivalent(System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression},System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression})')
  - [AreEquivalent\`\`1(source,target)](#M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-AreEquivalent``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}- 'ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.AreEquivalent``1(System.Linq.IQueryable{``0},System.Linq.IQueryable{``0})')
  - [AreSimilar(source,target)](#M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-AreSimilar-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.AreSimilar(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [AreSimilar(source,target)](#M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-AreSimilar-System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression},System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}- 'ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.AreSimilar(System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression},System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression})')
  - [AreSimilar\`\`1(source,target)](#M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-AreSimilar``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}- 'ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.AreSimilar``1(System.Linq.IQueryable{``0},System.Linq.IQueryable{``0})')
  - [IsPartOf(source,target)](#M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-IsPartOf-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.IsPartOf(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)')
  - [IsPartOf\`\`1(source,target)](#M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-IsPartOf``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}- 'ExpressionPowerTools.Core.Signatures.IExpressionEvaluator.IsPartOf``1(System.Linq.IQueryable{``0},System.Linq.IQueryable{``0})')
- [IQueryHost\`2](#T-ExpressionPowerTools-Core-Signatures-IQueryHost`2 'ExpressionPowerTools.Core.Signatures.IQueryHost`2')
  - [CustomProvider](#P-ExpressionPowerTools-Core-Signatures-IQueryHost`2-CustomProvider 'ExpressionPowerTools.Core.Signatures.IQueryHost`2.CustomProvider')
- [IQueryInterceptingProvider\`1](#T-ExpressionPowerTools-Core-Signatures-IQueryInterceptingProvider`1 'ExpressionPowerTools.Core.Signatures.IQueryInterceptingProvider`1')
- [IQueryInterceptor](#T-ExpressionPowerTools-Core-Signatures-IQueryInterceptor 'ExpressionPowerTools.Core.Signatures.IQueryInterceptor')
  - [RegisterInterceptor(transformation)](#M-ExpressionPowerTools-Core-Signatures-IQueryInterceptor-RegisterInterceptor-ExpressionPowerTools-Core-ExpressionTransformer- 'ExpressionPowerTools.Core.Signatures.IQueryInterceptor.RegisterInterceptor(ExpressionPowerTools.Core.ExpressionTransformer)')
- [IQuerySnapshot](#T-ExpressionPowerTools-Core-Signatures-IQuerySnapshot 'ExpressionPowerTools.Core.Signatures.IQuerySnapshot')
  - [Parent](#P-ExpressionPowerTools-Core-Signatures-IQuerySnapshot-Parent 'ExpressionPowerTools.Core.Signatures.IQuerySnapshot.Parent')
  - [OnExecuteEnumerableCalled(expression)](#M-ExpressionPowerTools-Core-Signatures-IQuerySnapshot-OnExecuteEnumerableCalled-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Signatures.IQuerySnapshot.OnExecuteEnumerableCalled(System.Linq.Expressions.Expression)')
- [IQuerySnapshotHost\`1](#T-ExpressionPowerTools-Core-Signatures-IQuerySnapshotHost`1 'ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1')
  - [RegisterSnap(callback)](#M-ExpressionPowerTools-Core-Signatures-IQuerySnapshotHost`1-RegisterSnap-System-Action{System-Linq-Expressions-Expression}- 'ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.RegisterSnap(System.Action{System.Linq.Expressions.Expression})')
  - [UnregisterSnap(id)](#M-ExpressionPowerTools-Core-Signatures-IQuerySnapshotHost`1-UnregisterSnap-System-String- 'ExpressionPowerTools.Core.Signatures.IQuerySnapshotHost`1.UnregisterSnap(System.String)')
- [IQuerySnapshotProvider\`1](#T-ExpressionPowerTools-Core-Signatures-IQuerySnapshotProvider`1 'ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1')
- [IQueryableExtensions](#T-ExpressionPowerTools-Core-Extensions-IQueryableExtensions 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions')
  - [AsEnumerableExpression(query)](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-AsEnumerableExpression-System-Linq-IQueryable- 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.AsEnumerableExpression(System.Linq.IQueryable)')
  - [AsEnumerableExpression\`\`1(query)](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-AsEnumerableExpression``1-System-Linq-IQueryable{``0}- 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.AsEnumerableExpression``1(System.Linq.IQueryable{``0})')
  - [CreateInterceptedQueryable\`\`1(source,transformation)](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-CreateInterceptedQueryable``1-System-Linq-IQueryable{``0},ExpressionPowerTools-Core-ExpressionTransformer- 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.CreateInterceptedQueryable``1(System.Linq.IQueryable{``0},ExpressionPowerTools.Core.ExpressionTransformer)')
  - [CreateQueryTemplate\`\`1()](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-CreateQueryTemplate``1 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.CreateQueryTemplate``1')
  - [CreateQueryTemplate\`\`1(noop)](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-CreateQueryTemplate``1-System-Linq-IQueryable{``0}- 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.CreateQueryTemplate``1(System.Linq.IQueryable{``0})')
  - [CreateSnapshotQueryable\`\`1(source,callback)](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-CreateSnapshotQueryable``1-System-Linq-IQueryable{``0},System-Action{System-Linq-Expressions-Expression}- 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.CreateSnapshotQueryable``1(System.Linq.IQueryable{``0},System.Action{System.Linq.Expressions.Expression})')
  - [HasFragment\`\`1(source,fragment)](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-HasFragment``1-System-Linq-IQueryable{``0},System-Func{System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}}- 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.HasFragment``1(System.Linq.IQueryable{``0},System.Func{System.Linq.IQueryable{``0},System.Linq.IQueryable{``0}})')
  - [IsEquivalentTo(source,target)](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-IsEquivalentTo-System-Linq-IQueryable,System-Linq-IQueryable- 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.IsEquivalentTo(System.Linq.IQueryable,System.Linq.IQueryable)')
  - [IsEquivalentTo\`\`1(source,target)](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-IsEquivalentTo``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}- 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.IsEquivalentTo``1(System.Linq.IQueryable{``0},System.Linq.IQueryable{``0})')
  - [IsSimilarTo(source,target)](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-IsSimilarTo-System-Linq-IQueryable,System-Linq-IQueryable- 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.IsSimilarTo(System.Linq.IQueryable,System.Linq.IQueryable)')
  - [IsSimilarTo\`\`1(source,target)](#M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-IsSimilarTo``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}- 'ExpressionPowerTools.Core.Extensions.IQueryableExtensions.IsSimilarTo``1(System.Linq.IQueryable{``0},System.Linq.IQueryable{``0})')
- [QueryHost\`2](#T-ExpressionPowerTools-Core-Hosts-QueryHost`2 'ExpressionPowerTools.Core.Hosts.QueryHost`2')
  - [#ctor(expression,provider)](#M-ExpressionPowerTools-Core-Hosts-QueryHost`2-#ctor-System-Linq-Expressions-Expression,`1- 'ExpressionPowerTools.Core.Hosts.QueryHost`2.#ctor(System.Linq.Expressions.Expression,`1)')
  - [CustomProvider](#P-ExpressionPowerTools-Core-Hosts-QueryHost`2-CustomProvider 'ExpressionPowerTools.Core.Hosts.QueryHost`2.CustomProvider')
  - [ElementType](#P-ExpressionPowerTools-Core-Hosts-QueryHost`2-ElementType 'ExpressionPowerTools.Core.Hosts.QueryHost`2.ElementType')
  - [Expression](#P-ExpressionPowerTools-Core-Hosts-QueryHost`2-Expression 'ExpressionPowerTools.Core.Hosts.QueryHost`2.Expression')
  - [Provider](#P-ExpressionPowerTools-Core-Hosts-QueryHost`2-Provider 'ExpressionPowerTools.Core.Hosts.QueryHost`2.Provider')
  - [GetEnumerator()](#M-ExpressionPowerTools-Core-Hosts-QueryHost`2-GetEnumerator 'ExpressionPowerTools.Core.Hosts.QueryHost`2.GetEnumerator')
  - [System#Collections#IEnumerable#GetEnumerator()](#M-ExpressionPowerTools-Core-Hosts-QueryHost`2-System#Collections#IEnumerable#GetEnumerator 'ExpressionPowerTools.Core.Hosts.QueryHost`2.System#Collections#IEnumerable#GetEnumerator')
- [QueryInterceptingProvider\`1](#T-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1 'ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1')
  - [#ctor(sourceQuery)](#M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-#ctor-System-Linq-IQueryable- 'ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.#ctor(System.Linq.IQueryable)')
  - [transformation](#F-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-transformation 'ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.transformation')
  - [CreateQuery(expression)](#M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-CreateQuery-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.CreateQuery(System.Linq.Expressions.Expression)')
  - [CreateQuery\`\`1(expression)](#M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-CreateQuery``1-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.CreateQuery``1(System.Linq.Expressions.Expression)')
  - [Execute(expression)](#M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-Execute-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.Execute(System.Linq.Expressions.Expression)')
  - [ExecuteEnumerable(expression)](#M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-ExecuteEnumerable-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.ExecuteEnumerable(System.Linq.Expressions.Expression)')
  - [RegisterInterceptor(transformation)](#M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-RegisterInterceptor-ExpressionPowerTools-Core-ExpressionTransformer- 'ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.RegisterInterceptor(ExpressionPowerTools.Core.ExpressionTransformer)')
  - [TransformExpression(source)](#M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-TransformExpression-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1.TransformExpression(System.Linq.Expressions.Expression)')
- [QuerySnapshotEventArgs](#T-ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs 'ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs')
  - [#ctor(expression)](#M-ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs-#ctor-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs.#ctor(System.Linq.Expressions.Expression)')
  - [Expression](#P-ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs-Expression 'ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs.Expression')
- [QuerySnapshotHost\`1](#T-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1 'ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1')
  - [#ctor(source)](#M-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1-#ctor-System-Linq-IQueryable{`0}- 'ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.#ctor(System.Linq.IQueryable{`0})')
  - [#ctor(source,expression)](#M-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1-#ctor-System-Linq-IQueryable,System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.#ctor(System.Linq.IQueryable,System.Linq.Expressions.Expression)')
  - [#ctor(expression,provider)](#M-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1-#ctor-System-Linq-Expressions-Expression,ExpressionPowerTools-Core-Signatures-IQuerySnapshotProvider{`0}- 'ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.#ctor(System.Linq.Expressions.Expression,ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider{`0})')
  - [RegisterSnap(callback)](#M-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1-RegisterSnap-System-Action{System-Linq-Expressions-Expression}- 'ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.RegisterSnap(System.Action{System.Linq.Expressions.Expression})')
  - [SnapshotProvider_QueryExecuted(sender,e)](#M-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1-SnapshotProvider_QueryExecuted-System-Object,ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs- 'ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.SnapshotProvider_QueryExecuted(System.Object,ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs)')
  - [UnregisterSnap(id)](#M-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1-UnregisterSnap-System-String- 'ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1.UnregisterSnap(System.String)')
- [QuerySnapshotProvider\`1](#T-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1 'ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1')
  - [#ctor(sourceQuery)](#M-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1-#ctor-System-Linq-IQueryable- 'ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.#ctor(System.Linq.IQueryable)')
  - [Parent](#P-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1-Parent 'ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.Parent')
  - [CreateQuery(expression)](#M-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1-CreateQuery-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.CreateQuery(System.Linq.Expressions.Expression)')
  - [CreateQuery\`\`1(expression)](#M-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1-CreateQuery``1-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.CreateQuery``1(System.Linq.Expressions.Expression)')
  - [ExecuteEnumerable(expression)](#M-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1-ExecuteEnumerable-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.ExecuteEnumerable(System.Linq.Expressions.Expression)')
  - [OnExecuteEnumerableCalled(expression)](#M-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1-OnExecuteEnumerableCalled-System-Linq-Expressions-Expression- 'ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1.OnExecuteEnumerableCalled(System.Linq.Expressions.Expression)')

<a name='T-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1'></a>
## CustomQueryProvider\`1 `type`

##### Namespace

ExpressionPowerTools.Core.Providers

##### Summary

Base query provider class.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The entity type. |

<a name='M-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-#ctor-System-Linq-IQueryable-'></a>
### #ctor(sourceQuery) `constructor`

##### Summary

Initializes a new instance of the [CustomQueryProvider\`1](#T-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1 'ExpressionPowerTools.Core.Providers.CustomQueryProvider`1') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceQuery | [System.Linq.IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable') | The query to snapshot. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Throw when query is null. |

<a name='P-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-Source'></a>
### Source `property`

##### Summary

Gets the source [IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable').

<a name='M-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-CreateQuery-System-Linq-Expressions-Expression-'></a>
### CreateQuery(expression) `method`

##### Summary

Creates the query.

##### Returns

The query.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The query [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |

<a name='M-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-CreateQuery``1-System-Linq-Expressions-Expression-'></a>
### CreateQuery\`\`1(expression) `method`

##### Summary

Creates the query.

##### Returns

The query.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The query [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TElement | The entity type. |

<a name='M-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-Execute-System-Linq-Expressions-Expression-'></a>
### Execute(expression) `method`

##### Summary

Runs the query and returns the result.

##### Returns

The query result.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to use. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Throw when expression is null. |

<a name='M-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-ExecuteEnumerable-System-Linq-Expressions-Expression-'></a>
### ExecuteEnumerable(expression) `method`

##### Summary

Return the enumerable result.

##### Returns

The [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to parse. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Throw when expression is null. |

<a name='M-ExpressionPowerTools-Core-Providers-CustomQueryProvider`1-Execute``1-System-Linq-Expressions-Expression-'></a>
### Execute\`\`1(expression) `method`

##### Summary

Runs the query and returns the typed result.

##### Returns

The query result.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The query [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TResult | The type of the result. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Throw when expression is null. |

<a name='T-ExpressionPowerTools-Core-Contract-Ensure'></a>
## Ensure `type`

##### Namespace

ExpressionPowerTools.Core.Contract

##### Summary

Helper methods for validation.

<a name='M-ExpressionPowerTools-Core-Contract-Ensure-NotNullOrWhitespace-System-Linq-Expressions-Expression{System-Func{System-String}}-'></a>
### NotNullOrWhitespace(value) `method`

##### Summary

Ensure the value is not null or whitespace.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Linq.Expressions.Expression{System.Func{System.String}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{System.String}}') | An expression that resolves to the value. |

##### Example

For example:

```csharp
Ensure.NotNullOrWhiteSpace(() =&gt; value);
```

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

##### Example

```csharp
Ensure.NotNull(() =&gt; parameter);
```

<a name='M-ExpressionPowerTools-Core-Contract-Ensure-VariableNotNull``1-System-Linq-Expressions-Expression{System-Func{``0}}-'></a>
### VariableNotNull\`\`1(value) `method`

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

##### Example

For example:

```csharp
Ensure.VariableNotNull(() =&gt; localVariable);
```

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

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-BinariesAreEquivalent-System-Linq-Expressions-BinaryExpression,System-Linq-Expressions-BinaryExpression-'></a>
### BinariesAreEquivalent(source,target) `method`

##### Summary

Determines whether two binaries are equivalent.

##### Returns

A flag that indicates whether the two expressions are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression') | The source [BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression'). |
| target | [System.Linq.Expressions.BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression') | The target [BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression'). |

##### Remarks

Two instances of [BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression') are equivalent when they share the same
[ExpressionType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ExpressionType 'System.Linq.Expressions.ExpressionType') and the recursive determination of the left expressoin and
the right expressions is equivalent.

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
| source | [System.Linq.Expressions.ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression') | The source [ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression'). |
| target | [System.Linq.Expressions.ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression') | The target [ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression'). |

##### Remarks

To be true, both must have the same type and value. If the
value is an expression tree, it is recursed.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-LambdasAreEquivalent-System-Linq-Expressions-LambdaExpression,System-Linq-Expressions-LambdaExpression-'></a>
### LambdasAreEquivalent(source,target) `method`

##### Summary

Determine whether two lambdas are equivalent.

##### Returns

A flag indicating whether the two expressions are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression') | The source [LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression'). |
| target | [System.Linq.Expressions.LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression') | The target [LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression'). |

##### Remarks

Two lambda expressions are equivalent when they share the same type,
name, tail call optimization, parameter count, and when both body
and parameters are equivalent.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-MembersAreEquivalent-System-Linq-Expressions-MemberExpression,System-Linq-Expressions-MemberExpression-'></a>
### MembersAreEquivalent(source,target) `method`

##### Summary

Determine whether two members are equivalent.

##### Returns

A flag indicating whether the two expressions are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.MemberExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberExpression 'System.Linq.Expressions.MemberExpression') | The source [MemberExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberExpression 'System.Linq.Expressions.MemberExpression'). |
| target | [System.Linq.Expressions.MemberExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberExpression 'System.Linq.Expressions.MemberExpression') | The target [MemberExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberExpression 'System.Linq.Expressions.MemberExpression'). |

##### Remarks

Two instances of [MemberExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberExpression 'System.Linq.Expressions.MemberExpression') are equivalent
when they share the same type (this will match the member type), the same
declaring type, the same name, and if there is an expression, the
expressions are equivalent.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-MethodsAreEquivalent-System-Linq-Expressions-MethodCallExpression,System-Linq-Expressions-MethodCallExpression-'></a>
### MethodsAreEquivalent(source,target) `method`

##### Summary

Determine whether two methods are equivalent.

##### Returns

A flag indicating whether the two expressions are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression') | The source [MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression'). |
| target | [System.Linq.Expressions.MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression') | The target [MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression'). |

##### Remarks

Two metods are equivalent when they share the same return type,
the same declaring type, the same name, are either both instance
or static fields, and all arguments pass equivalency.

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

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-ParametersAreEquivalent-System-Linq-Expressions-ParameterExpression,System-Linq-Expressions-ParameterExpression-'></a>
### ParametersAreEquivalent(source,target) `method`

##### Summary

Check for equivalent parameters.

##### Returns

A flag indicating whether the two are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression') | The source [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression'). |
| target | [System.Linq.Expressions.ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression') | The target [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression'). |

##### Remarks

To be true, type, value, and reference must be the same.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-UnariesAreEquivalent-System-Linq-Expressions-UnaryExpression,System-Linq-Expressions-UnaryExpression-'></a>
### UnariesAreEquivalent(source,target) `method`

##### Summary

Determines whether two unaries are equivalent.

##### Returns

A flag that indicates whether the two expressions are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.UnaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.UnaryExpression 'System.Linq.Expressions.UnaryExpression') | The source [UnaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.UnaryExpression 'System.Linq.Expressions.UnaryExpression'). |
| target | [System.Linq.Expressions.UnaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.UnaryExpression 'System.Linq.Expressions.UnaryExpression') | The target [UnaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.UnaryExpression 'System.Linq.Expressions.UnaryExpression'). |

##### Remarks

Two instances of [UnaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.UnaryExpression 'System.Linq.Expressions.UnaryExpression') are equivalent when they share the same
[ExpressionType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ExpressionType 'System.Linq.Expressions.ExpressionType'), method information, and when their operands pass
equivalency.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency-ValuesAreEquivalent-System-Type,System-Object,System-Object-'></a>
### ValuesAreEquivalent(type,source,target) `method`

##### Summary

Attempts to compare values in various ways.

##### Returns

A flag indicating equivalency.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') of the values. |
| source | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The source value. |
| target | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The target value. |

<a name='T-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator'></a>
## ExpressionEvaluator `type`

##### Namespace

ExpressionPowerTools.Core.Comparisons

##### Summary

Implementation of [IExpressionEvaluator](#T-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator 'ExpressionPowerTools.Core.Signatures.IExpressionEvaluator') for advanced
expression comparisons.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-AreEquivalent-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
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

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-AreEquivalent-System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression},System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}-'></a>
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

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-AreEquivalent``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}-'></a>
### AreEquivalent\`\`1(source,target) `method`

##### Summary

Entry for equivalency comparisons. Will cast to
known types and compare.

##### Returns

A flag indicating whether the source and target are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The source [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1'). |
| target | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The target [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1') to compare to. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') of the entity. |

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-AreSimilar-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### AreSimilar(source,target) `method`

##### Summary

Entry for similarity comparisons. Will cast to
known types and compare.

##### Returns

A flag indicating whether the source and target are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |
| target | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The target [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to compare to. |

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-AreSimilar-System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression},System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}-'></a>
### AreSimilar(source,target) `method`

##### Summary

Comparison of multiple expressions. Similar
only when all elements match, in order, and
pass the similarity test. It's fine if the
source does not have the same number of entities
as the target.

##### Returns

A flag indicating whether the two sets of
expressions are Similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}') | The source expressions. |
| target | [System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}') | The target expressions. |

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-AreSimilar``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}-'></a>
### AreSimilar\`\`1(source,target) `method`

##### Summary

Entry for similarity comparisons. Will cast to
known types and compare.

##### Returns

A flag indicating whether the source and target are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The source [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1'). |
| target | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The target [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1') to compare to. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') of entity. |

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-IsPartOf-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### IsPartOf(source,target) `method`

##### Summary

Determines whether an [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') is part of another expression.

##### Returns

A flag indicating whether the source is part of the target.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |
| target | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The target [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to parse. |

##### Remarks

A source is part of a target if an [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') exists in the
target's tree that is similar to the source.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionEvaluator-IsPartOf``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}-'></a>
### IsPartOf\`\`1(source,target) `method`

##### Summary

Determines whether an [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1') is part of another query.

##### Returns

A flag indicating whether the source is part of the target.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The source [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1'). |
| target | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The target [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1') to parse. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') of the entity. |

##### Remarks

A source is part of a target if an [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') exists in the
target's tree that is similar to the source.

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

<a name='M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsParameterExpression-System-Object,System-String,System-Boolean-'></a>
### AsParameterExpression(obj,name,byRef) `method`

##### Summary

Creates a [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression') based on the
type of the object.

##### Returns

The [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The object to inspect. |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Optional name for the parameter. |
| byRef | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` when parameter is by reference. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when object is null. |

##### Example

For example:

```csharp
var target = this.AsParameterExpression(nameof(parameter));
// target.Type == this.GetType(), target.Name == "parameter"
```

<a name='M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-AsParameterExpression-System-Type,System-String,System-Boolean-'></a>
### AsParameterExpression(type,name,byRef) `method`

##### Summary

Creates a [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression') based on the
[Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type').

##### Returns

The [ParameterExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ParameterExpression 'System.Linq.Expressions.ParameterExpression').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') to use. |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Optional name for the parameter. |
| byRef | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to `true` when parameter is by reference. |

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

<a name='M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-IsEquivalentTo-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### IsEquivalentTo(source,target) `method`

##### Summary

Uses [ExpressionEquivalency](#T-ExpressionPowerTools-Core-Comparisons-ExpressionEquivalency 'ExpressionPowerTools.Core.Comparisons.ExpressionEquivalency') to determine equivalency.

##### Returns

A flag indicating whether the expressions are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |
| target | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The target [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |

<a name='M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-IsPartOf-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### IsPartOf(source,target) `method`

##### Summary

Uses [ExpressionSimilarity](#T-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity') to determine if an [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression')
is part of another.

##### Returns

A flag indicating whether the source is part of the target.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |
| target | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The target [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to parse. |

<a name='M-ExpressionPowerTools-Core-Extensions-ExpressionExtensions-IsSimilarTo-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### IsSimilarTo(source,target) `method`

##### Summary

Uses [ExpressionSimilarity](#T-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity 'ExpressionPowerTools.Core.Comparisons.ExpressionSimilarity') to determine similarity.

##### Returns

A flag indicating whether the expressions are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |
| target | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The target [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |

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
Expression&lt;Func&lt;string&gt;&gt; expr = () =&gt; foo;
expr.MemberName(); // "foo"
```

<a name='T-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity'></a>
## ExpressionSimilarity `type`

##### Namespace

ExpressionPowerTools.Core.Comparisons

##### Summary

Expression similarity methods.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-AreSimilar-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### AreSimilar(source,target) `method`

##### Summary

Entry for similarity comparisons. Will cast to
known types and compare.

##### Returns

A flag indicating whether the source and target are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |
| target | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The target [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to compare to. |

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-AreSimilar-System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression},System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}-'></a>
### AreSimilar(source,target) `method`

##### Summary

Comparison of multiple expressions. Similar
only when all elements match, in order, and
pass the similarity test. It's fine if the
source does not have the same number of entities
as the target.

##### Returns

A flag indicating whether the two sets of
expressions are Similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}') | The source expressions. |
| target | [System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}') | The target expressions. |

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-BinariesAreSimilar-System-Linq-Expressions-BinaryExpression,System-Linq-Expressions-BinaryExpression-'></a>
### BinariesAreSimilar(source,target) `method`

##### Summary

Determines whether two binaries are similar.

##### Returns

A flag that indicates whether the two expressions are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression') | The source [BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression'). |
| target | [System.Linq.Expressions.BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression') | The target [BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression'). |

##### Remarks

Two instances of [BinaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.BinaryExpression 'System.Linq.Expressions.BinaryExpression') are similar when they share the same
[ExpressionType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ExpressionType 'System.Linq.Expressions.ExpressionType') and the recursive determination of the left expressoin and
the right expressions is similar.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-ConstantsAreSimilar-System-Linq-Expressions-ConstantExpression,System-Linq-Expressions-ConstantExpression-'></a>
### ConstantsAreSimilar(source,target) `method`

##### Summary

Method to compare two 
instances.

##### Returns

A flag indicating whether the two are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression') | The source [ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression'). |
| target | [System.Linq.Expressions.ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression') | The target [ConstantExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ConstantExpression 'System.Linq.Expressions.ConstantExpression'). |

##### Remarks

If the constant is an expression, similarity is recursed. If it is a value type,
the source and target must be equal. Otherwise, similar is based on types.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-IsPartOf-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### IsPartOf(source,target) `method`

##### Summary

Determines whether an [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') is part of another expression.

##### Returns

A flag indicating whether the source is part of the target.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |
| target | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The target [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to parse. |

##### Remarks

A source is part of a target if an [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') exists in the
target's tree that is similar to the source.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-LambdasAreSimilar-System-Linq-Expressions-LambdaExpression,System-Linq-Expressions-LambdaExpression-'></a>
### LambdasAreSimilar(source,target) `method`

##### Summary

Determine whether two lambdas are similar.

##### Returns

A flag indicating whether the two expressions are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression') | The source [LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression'). |
| target | [System.Linq.Expressions.LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression') | The target [LambdaExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.LambdaExpression 'System.Linq.Expressions.LambdaExpression'). |

##### Remarks

Two lambda expressions are similar when they share the same name,
similar parameters, and when both body and parameters are similar.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-MembersAreSimilar-System-Linq-Expressions-MemberExpression,System-Linq-Expressions-MemberExpression-'></a>
### MembersAreSimilar(source,target) `method`

##### Summary

Determine whether two members are similar.

##### Returns

A flag indicating whether the two expressions are Similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.MemberExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberExpression 'System.Linq.Expressions.MemberExpression') | The source [MemberExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberExpression 'System.Linq.Expressions.MemberExpression'). |
| target | [System.Linq.Expressions.MemberExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberExpression 'System.Linq.Expressions.MemberExpression') | The target [MemberExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberExpression 'System.Linq.Expressions.MemberExpression'). |

##### Remarks

Two instances of [MemberExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberExpression 'System.Linq.Expressions.MemberExpression') are similar
when they share the same type (this will match the member type), the same
declaring type, the same name, and if there is an expression, the
expressions are similar.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-MethodsAreSimilar-System-Linq-Expressions-MethodCallExpression,System-Linq-Expressions-MethodCallExpression-'></a>
### MethodsAreSimilar(source,target) `method`

##### Summary

Determine whether two methods are similar.

##### Returns

A flag indicating whether the two expressions are Similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression') | The source [MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression'). |
| target | [System.Linq.Expressions.MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression') | The target [MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression'). |

##### Remarks

Two metods are similar when they share the same return type, declaring type,
the same name, are either both instance or static fields, and all
arguments pass similarity. Arguments of same expression type are tested
for similarity. Arguments of different expression types are tested for the
same return type.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-TypeCheckAndCompare``1-``0,System-Linq-Expressions-Expression,System-Func{``0,``0,System-Boolean}-'></a>
### TypeCheckAndCompare\`\`1(source,target,compare) `method`

##### Summary

Checks for a match of the target type and calls the comparison
if there is a match.

##### Returns

A flag indicating whether the expressions are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [\`\`0](#T-``0 '``0') | The source [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |
| target | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The target [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |
| compare | [System.Func{\`\`0,\`\`0,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``0,System.Boolean}') | The method to compare. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') type to evaluate. |

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-TypesAreSimilar-System-Type,System-Type-'></a>
### TypesAreSimilar(source,target) `method`

##### Summary

Determines whether types are similar.

##### Returns

A flag indicating whether the types are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The source [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') to check. |
| target | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The target [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') to check. |

##### Remarks

Object must match object. Value types must match exactly.
Other types can be derived from each other.

<a name='M-ExpressionPowerTools-Core-Comparisons-ExpressionSimilarity-UnariesAreSimilar-System-Linq-Expressions-UnaryExpression,System-Linq-Expressions-UnaryExpression-'></a>
### UnariesAreSimilar(source,target) `method`

##### Summary

Determines whether two unaries are similar.

##### Returns

A flag that indicates whether the two expressions are Similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.UnaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.UnaryExpression 'System.Linq.Expressions.UnaryExpression') | The source [UnaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.UnaryExpression 'System.Linq.Expressions.UnaryExpression'). |
| target | [System.Linq.Expressions.UnaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.UnaryExpression 'System.Linq.Expressions.UnaryExpression') | The target [UnaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.UnaryExpression 'System.Linq.Expressions.UnaryExpression'). |

##### Remarks

Two instances of [UnaryExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.UnaryExpression 'System.Linq.Expressions.UnaryExpression') are similar when they share the same
[ExpressionType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.ExpressionType 'System.Linq.Expressions.ExpressionType'), method information, and when their operands pass
equivalency.

<a name='T-ExpressionPowerTools-Core-ExpressionTransformer'></a>
## ExpressionTransformer `type`

##### Namespace

ExpressionPowerTools.Core

##### Summary

Transform one expression to another.

##### Returns

The transformed expression.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [T:ExpressionPowerTools.Core.ExpressionTransformer](#T-T-ExpressionPowerTools-Core-ExpressionTransformer 'T:ExpressionPowerTools.Core.ExpressionTransformer') | The source [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |

<a name='T-ExpressionPowerTools-Core-Signatures-ICustomQueryProvider`1'></a>
## ICustomQueryProvider\`1 `type`

##### Namespace

ExpressionPowerTools.Core.Signatures

##### Summary

Interface for a custom implementation of [IQueryProvider](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryProvider 'System.Linq.IQueryProvider').

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The entity type. |

<a name='M-ExpressionPowerTools-Core-Signatures-ICustomQueryProvider`1-ExecuteEnumerable-System-Linq-Expressions-Expression-'></a>
### ExecuteEnumerable(expression) `method`

##### Summary

Execute enumeration from the [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression').

##### Returns

An instance of [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to enumerate. |

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

<a name='T-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator'></a>
## IExpressionEvaluator `type`

##### Namespace

ExpressionPowerTools.Core.Signatures

##### Summary

Evaluator as facade to equivalency and similarity.

<a name='M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-AreEquivalent-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
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

<a name='M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-AreEquivalent-System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression},System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}-'></a>
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

<a name='M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-AreEquivalent``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}-'></a>
### AreEquivalent\`\`1(source,target) `method`

##### Summary

Entry for equivalency comparisons. Will cast to
known types and compare.

##### Returns

A flag indicating whether the source and target are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The source [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1'). |
| target | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The target [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1') to compare to. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of entity. |

<a name='M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-AreSimilar-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### AreSimilar(source,target) `method`

##### Summary

Entry for similarity comparisons. Will cast to
known types and compare.

##### Returns

A flag indicating whether the source and target are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |
| target | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The target [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to compare to. |

<a name='M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-AreSimilar-System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression},System-Collections-Generic-IEnumerable{System-Linq-Expressions-Expression}-'></a>
### AreSimilar(source,target) `method`

##### Summary

Comparison of multiple expressions. Similar
only when all elements match, in order, and
pass the similarity test. It's fine if the
source does not have the same number of entities
as the target.

##### Returns

A flag indicating whether the two sets of
expressions are Similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}') | The source expressions. |
| target | [System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.Linq.Expressions.Expression}') | The target expressions. |

<a name='M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-AreSimilar``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}-'></a>
### AreSimilar\`\`1(source,target) `method`

##### Summary

Entry for similarity comparisons. Will cast to
known types and compare.

##### Returns

A flag indicating whether the source and target are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The source [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1'). |
| target | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The target [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1') to compare to. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of entity. |

<a name='M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-IsPartOf-System-Linq-Expressions-Expression,System-Linq-Expressions-Expression-'></a>
### IsPartOf(source,target) `method`

##### Summary

Determines whether an [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') is part of another expression.

##### Returns

A flag indicating whether the source is part of the target.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |
| target | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The target [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to parse. |

##### Remarks

A source is part of a target if an [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') exists in the
target's tree that is similar to the source.

<a name='M-ExpressionPowerTools-Core-Signatures-IExpressionEvaluator-IsPartOf``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}-'></a>
### IsPartOf\`\`1(source,target) `method`

##### Summary

Determines whether an [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1') is part of another query.

##### Returns

A flag indicating whether the source is part of the target.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The source [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1'). |
| target | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The target [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1') to parse. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of entity. |

##### Remarks

A source is part of a target if an [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') exists in the
target's tree that is similar to the source.

<a name='T-ExpressionPowerTools-Core-Signatures-IQueryHost`2'></a>
## IQueryHost\`2 `type`

##### Namespace

ExpressionPowerTools.Core.Signatures

##### Summary

Interface for custom query host.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of entity. |
| TProvider | The [ICustomQueryProvider\`1](#T-ExpressionPowerTools-Core-Signatures-ICustomQueryProvider`1 'ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1') to handle logic. |

<a name='P-ExpressionPowerTools-Core-Signatures-IQueryHost`2-CustomProvider'></a>
### CustomProvider `property`

##### Summary

Gets the [ICustomQueryProvider\`1](#T-ExpressionPowerTools-Core-Signatures-ICustomQueryProvider`1 'ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1') that handles the custom logic.

<a name='T-ExpressionPowerTools-Core-Signatures-IQueryInterceptingProvider`1'></a>
## IQueryInterceptingProvider\`1 `type`

##### Namespace

ExpressionPowerTools.Core.Signatures

##### Summary

Interface for provider that intercepts the [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') when run.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type. |

<a name='T-ExpressionPowerTools-Core-Signatures-IQueryInterceptor'></a>
## IQueryInterceptor `type`

##### Namespace

ExpressionPowerTools.Core.Signatures

##### Summary

Exposes a method to register a transformation.

<a name='M-ExpressionPowerTools-Core-Signatures-IQueryInterceptor-RegisterInterceptor-ExpressionPowerTools-Core-ExpressionTransformer-'></a>
### RegisterInterceptor(transformation) `method`

##### Summary

Register the transformation to intercept.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| transformation | [ExpressionPowerTools.Core.ExpressionTransformer](#T-ExpressionPowerTools-Core-ExpressionTransformer 'ExpressionPowerTools.Core.ExpressionTransformer') | The method to inspect and/or transform. |

<a name='T-ExpressionPowerTools-Core-Signatures-IQuerySnapshot'></a>
## IQuerySnapshot `type`

##### Namespace

ExpressionPowerTools.Core.Signatures

##### Summary

Non-generic interface for snapshot host.

<a name='P-ExpressionPowerTools-Core-Signatures-IQuerySnapshot-Parent'></a>
### Parent `property`

##### Summary

Gets the parent provider for bubbling events.

<a name='M-ExpressionPowerTools-Core-Signatures-IQuerySnapshot-OnExecuteEnumerableCalled-System-Linq-Expressions-Expression-'></a>
### OnExecuteEnumerableCalled(expression) `method`

##### Summary

Method to raise call.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to snapshot. |

<a name='T-ExpressionPowerTools-Core-Signatures-IQuerySnapshotHost`1'></a>
## IQuerySnapshotHost\`1 `type`

##### Namespace

ExpressionPowerTools.Core.Signatures

##### Summary

Host to snapshot a query. Will raise an event when it is executed
to allow inspecting the expression.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of entity. |

<a name='M-ExpressionPowerTools-Core-Signatures-IQuerySnapshotHost`1-RegisterSnap-System-Action{System-Linq-Expressions-Expression}-'></a>
### RegisterSnap(callback) `method`

##### Summary

Register a callback to receive the [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') when snapped.

##### Returns

A unique identifier used to unregister.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| callback | [System.Action{System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.Linq.Expressions.Expression}') | The callback to use. |

<a name='M-ExpressionPowerTools-Core-Signatures-IQuerySnapshotHost`1-UnregisterSnap-System-String-'></a>
### UnregisterSnap(id) `method`

##### Summary

Unregister for callbacks.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The unique identifier of the registration. |

<a name='T-ExpressionPowerTools-Core-Signatures-IQuerySnapshotProvider`1'></a>
## IQuerySnapshotProvider\`1 `type`

##### Namespace

ExpressionPowerTools.Core.Signatures

##### Summary

Provider to intercept query execution for inspection.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of snapshot to provide for. |

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

<a name='M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-CreateInterceptedQueryable``1-System-Linq-IQueryable{``0},ExpressionPowerTools-Core-ExpressionTransformer-'></a>
### CreateInterceptedQueryable\`\`1(source,transformation) `method`

##### Summary

Creates a query that can transformation the [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression')
wen run.

##### Returns

The new intercepting query.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The source query. |
| transformation | [ExpressionPowerTools.Core.ExpressionTransformer](#T-ExpressionPowerTools-Core-ExpressionTransformer 'ExpressionPowerTools.Core.ExpressionTransformer') | The transformation to apply. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The entity type. |

<a name='M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-CreateQueryTemplate``1'></a>
### CreateQueryTemplate\`\`1() `method`

##### Summary

Creates a queryable from an empty list used for templates to compare.

##### Returns

The [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1') to build on.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of entity. |

<a name='M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-CreateQueryTemplate``1-System-Linq-IQueryable{``0}-'></a>
### CreateQueryTemplate\`\`1(noop) `method`

##### Summary

Creates a new queryable to build a template from.

##### Returns

The [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1') to build on.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| noop | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The source [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1'). |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of entity. |

<a name='M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-CreateSnapshotQueryable``1-System-Linq-IQueryable{``0},System-Action{System-Linq-Expressions-Expression}-'></a>
### CreateSnapshotQueryable\`\`1(source,callback) `method`

##### Summary

Creates a snapshot that allows a registered callback to
inspect the expression when the query is executed.

##### Returns

The query with snapshot applied.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The source query. |
| callback | [System.Action{System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.Linq.Expressions.Expression}') | The callback. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type. |

<a name='M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-HasFragment``1-System-Linq-IQueryable{``0},System-Func{System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}}-'></a>
### HasFragment\`\`1(source,fragment) `method`

##### Summary

Determine whether a fragment of queryable exists in the
target query.

##### Returns

A flag indicating whether the fragment is part of the parent query.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1') to check. |
| fragment | [System.Func{System.Linq.IQueryable{\`\`0},System.Linq.IQueryable{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.IQueryable{``0},System.Linq.IQueryable{``0}}') | The fragment to test. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of entity. |

##### Remarks

This will return true if all parts of the fragment's expression tree
are similar to all parts of a similar expression in the source.

<a name='M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-IsEquivalentTo-System-Linq-IQueryable,System-Linq-IQueryable-'></a>
### IsEquivalentTo(source,target) `method`

##### Summary

Determines whether the expression tree of the query is equivalent to the other query.

##### Returns

A flag indicating whether the queries are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable') | The source [IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable'). |
| target | [System.Linq.IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable') | The target [IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable'). |

<a name='M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-IsEquivalentTo``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}-'></a>
### IsEquivalentTo\`\`1(source,target) `method`

##### Summary

Determines whether the expression tree of the query is equivalent to the other query.

##### Returns

A flag indicating whether the queries are equivalent.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The source [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1'). |
| target | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The target [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1'). |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The entity being queried. |

<a name='M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-IsSimilarTo-System-Linq-IQueryable,System-Linq-IQueryable-'></a>
### IsSimilarTo(source,target) `method`

##### Summary

Determines whether the expression tree of the query is similar to the other query.

##### Returns

A flag indicating whether the queries are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable') | The source [IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable'). |
| target | [System.Linq.IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable') | The target [IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable'). |

<a name='M-ExpressionPowerTools-Core-Extensions-IQueryableExtensions-IsSimilarTo``1-System-Linq-IQueryable{``0},System-Linq-IQueryable{``0}-'></a>
### IsSimilarTo\`\`1(source,target) `method`

##### Summary

Determines whether the expression tree of the query is similar to the other query.

##### Returns

A flag indicating whether the queries are similar.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The source [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1'). |
| target | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The target [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1'). |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The entity being queried. |

<a name='T-ExpressionPowerTools-Core-Hosts-QueryHost`2'></a>
## QueryHost\`2 `type`

##### Namespace

ExpressionPowerTools.Core.Hosts

##### Summary

Base class for custom query host.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The entity type. |
| TProvider | The [ICustomQueryProvider\`1](#T-ExpressionPowerTools-Core-Signatures-ICustomQueryProvider`1 'ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1') to use. |

<a name='M-ExpressionPowerTools-Core-Hosts-QueryHost`2-#ctor-System-Linq-Expressions-Expression,`1-'></a>
### #ctor(expression,provider) `constructor`

##### Summary

Initializes a new instance of the [QueryHost\`2](#T-ExpressionPowerTools-Core-Hosts-QueryHost`2 'ExpressionPowerTools.Core.Hosts.QueryHost`2') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](#P-ExpressionPowerTools-Core-Hosts-QueryHost`2-Expression 'ExpressionPowerTools.Core.Hosts.QueryHost`2.Expression'). |
| provider | [\`1](#T-`1 '`1') | The [ICustomQueryProvider\`1](#T-ExpressionPowerTools-Core-Signatures-ICustomQueryProvider`1 'ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when expression or provider are null. |

<a name='P-ExpressionPowerTools-Core-Hosts-QueryHost`2-CustomProvider'></a>
### CustomProvider `property`

##### Summary

Gets or sets the instance of the [ICustomQueryProvider\`1](#T-ExpressionPowerTools-Core-Signatures-ICustomQueryProvider`1 'ExpressionPowerTools.Core.Signatures.ICustomQueryProvider`1').

<a name='P-ExpressionPowerTools-Core-Hosts-QueryHost`2-ElementType'></a>
### ElementType `property`

##### Summary

Gets the type of element.

<a name='P-ExpressionPowerTools-Core-Hosts-QueryHost`2-Expression'></a>
### Expression `property`

##### Summary

Gets the [Expression](#P-ExpressionPowerTools-Core-Hosts-QueryHost`2-Expression 'ExpressionPowerTools.Core.Hosts.QueryHost`2.Expression') for the query.

<a name='P-ExpressionPowerTools-Core-Hosts-QueryHost`2-Provider'></a>
### Provider `property`

##### Summary

Gets the instance of the [IQueryProvider](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryProvider 'System.Linq.IQueryProvider').

<a name='M-ExpressionPowerTools-Core-Hosts-QueryHost`2-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Gets an [IEnumerator\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerator`1 'System.Collections.Generic.IEnumerator`1') for the query results.

##### Returns

The [IEnumerator\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerator`1 'System.Collections.Generic.IEnumerator`1').

##### Parameters

This method has no parameters.

<a name='M-ExpressionPowerTools-Core-Hosts-QueryHost`2-System#Collections#IEnumerable#GetEnumerator'></a>
### System#Collections#IEnumerable#GetEnumerator() `method`

##### Summary

Gets the non-typed [IEnumerator](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.IEnumerator 'System.Collections.IEnumerator').

##### Returns

The [IEnumerator](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.IEnumerator 'System.Collections.IEnumerator').

##### Parameters

This method has no parameters.

<a name='T-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1'></a>
## QueryInterceptingProvider\`1 `type`

##### Namespace

ExpressionPowerTools.Core.Providers

##### Summary

Provider that intercepts the [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') when run.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The entity type. |

<a name='M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-#ctor-System-Linq-IQueryable-'></a>
### #ctor(sourceQuery) `constructor`

##### Summary

Initializes a new instance of the [QueryInterceptingProvider\`1](#T-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1 'ExpressionPowerTools.Core.Providers.QueryInterceptingProvider`1') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceQuery | [System.Linq.IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable') | The query to snapshot. |

<a name='F-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-transformation'></a>
### transformation `constants`

##### Summary

The transformatoin to apply.

<a name='M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-CreateQuery-System-Linq-Expressions-Expression-'></a>
### CreateQuery(expression) `method`

##### Summary

Creates a query host with this provider.

##### Returns

The [IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to use. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Throw when expression is null. |

<a name='M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-CreateQuery``1-System-Linq-Expressions-Expression-'></a>
### CreateQuery\`\`1(expression) `method`

##### Summary

Creates a query host with a different type.

##### Returns

The [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to use. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TElement | The entity type. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Throw when expression is null. |

<a name='M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-Execute-System-Linq-Expressions-Expression-'></a>
### Execute(expression) `method`

##### Summary

Execute with transformation.

##### Returns

Result of executing the transformed expression.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The base [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when expression is null. |

<a name='M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-ExecuteEnumerable-System-Linq-Expressions-Expression-'></a>
### ExecuteEnumerable(expression) `method`

##### Summary

Execute the enumerable.

##### Returns

The result of the transformed expression.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to execute. |

<a name='M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-RegisterInterceptor-ExpressionPowerTools-Core-ExpressionTransformer-'></a>
### RegisterInterceptor(transformation) `method`

##### Summary

Registers the transformation to apply.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| transformation | [ExpressionPowerTools.Core.ExpressionTransformer](#T-ExpressionPowerTools-Core-ExpressionTransformer 'ExpressionPowerTools.Core.ExpressionTransformer') | A method that transforms an [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when transformation is null. |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown when interceptor already registered. |

<a name='M-ExpressionPowerTools-Core-Providers-QueryInterceptingProvider`1-TransformExpression-System-Linq-Expressions-Expression-'></a>
### TransformExpression(source) `method`

##### Summary

Perform the transformation.

##### Returns

The transformed [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The original [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |

<a name='T-ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs'></a>
## QuerySnapshotEventArgs `type`

##### Namespace

ExpressionPowerTools.Core.Providers

##### Summary

Encapsulates an [Expression](#P-ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs-Expression 'ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs.Expression').

<a name='M-ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs-#ctor-System-Linq-Expressions-Expression-'></a>
### #ctor(expression) `constructor`

##### Summary

Initializes a new instance of the [QuerySnapshotEventArgs](#T-ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs 'ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](#P-ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs-Expression 'ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs.Expression') to host. |

<a name='P-ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs-Expression'></a>
### Expression `property`

##### Summary

Gets the [Expression](#P-ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs-Expression 'ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs.Expression').

<a name='T-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1'></a>
## QuerySnapshotHost\`1 `type`

##### Namespace

ExpressionPowerTools.Core.Hosts

##### Summary

A host to snapshot the query on execution.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the query. |

<a name='M-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1-#ctor-System-Linq-IQueryable{`0}-'></a>
### #ctor(source) `constructor`

##### Summary

Initializes a new instance of the [QuerySnapshotHost\`1](#T-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1 'ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{`0}') | The [IQueryable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable`1 'System.Linq.IQueryable`1') to snapshot. |

<a name='M-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1-#ctor-System-Linq-IQueryable,System-Linq-Expressions-Expression-'></a>
### #ctor(source,expression) `constructor`

##### Summary

Initializes a new instance of the [QuerySnapshotHost\`1](#T-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1 'ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable') | The query source. |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to use. |

<a name='M-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1-#ctor-System-Linq-Expressions-Expression,ExpressionPowerTools-Core-Signatures-IQuerySnapshotProvider{`0}-'></a>
### #ctor(expression,provider) `constructor`

##### Summary

Initializes a new instance of the [QuerySnapshotHost\`1](#T-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1 'ExpressionPowerTools.Core.Hosts.QuerySnapshotHost`1') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to use. |
| provider | [ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider{\`0}](#T-ExpressionPowerTools-Core-Signatures-IQuerySnapshotProvider{`0} 'ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider{`0}') | The [IQuerySnapshotProvider\`1](#T-ExpressionPowerTools-Core-Signatures-IQuerySnapshotProvider`1 'ExpressionPowerTools.Core.Signatures.IQuerySnapshotProvider`1') instance. |

<a name='M-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1-RegisterSnap-System-Action{System-Linq-Expressions-Expression}-'></a>
### RegisterSnap(callback) `method`

##### Summary

Register for a callback when the [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') is executed.

##### Returns

A unique identifier for the registration.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| callback | [System.Action{System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.Linq.Expressions.Expression}') | The callback to pass the expression to. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when callback is null. |

<a name='M-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1-SnapshotProvider_QueryExecuted-System-Object,ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs-'></a>
### SnapshotProvider_QueryExecuted(sender,e) `method`

##### Summary

Handle snap.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The sender. |
| e | [ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs](#T-ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs 'ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs') | The [QuerySnapshotEventArgs](#T-ExpressionPowerTools-Core-Providers-QuerySnapshotEventArgs 'ExpressionPowerTools.Core.Providers.QuerySnapshotEventArgs'). |

<a name='M-ExpressionPowerTools-Core-Hosts-QuerySnapshotHost`1-UnregisterSnap-System-String-'></a>
### UnregisterSnap(id) `method`

##### Summary

Stop listenining.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The unique identifier. |

<a name='T-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1'></a>
## QuerySnapshotProvider\`1 `type`

##### Namespace

ExpressionPowerTools.Core.Providers

##### Summary

Provider that raises an event just before the query is executed.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of entity. |

<a name='M-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1-#ctor-System-Linq-IQueryable-'></a>
### #ctor(sourceQuery) `constructor`

##### Summary

Initializes a new instance of the [QuerySnapshotProvider\`1](#T-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1 'ExpressionPowerTools.Core.Providers.QuerySnapshotProvider`1') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceQuery | [System.Linq.IQueryable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable') | The query to snapshot. |

<a name='P-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1-Parent'></a>
### Parent `property`

##### Summary

Gets or sets the [IQuerySnapshot](#T-ExpressionPowerTools-Core-Signatures-IQuerySnapshot 'ExpressionPowerTools.Core.Signatures.IQuerySnapshot') parent.

<a name='M-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1-CreateQuery-System-Linq-Expressions-Expression-'></a>
### CreateQuery(expression) `method`

##### Summary

Creates the query.

##### Returns

The query.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The query [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when expression is null. |

<a name='M-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1-CreateQuery``1-System-Linq-Expressions-Expression-'></a>
### CreateQuery\`\`1(expression) `method`

##### Summary

Creates the query.

##### Returns

The query.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The query [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression'). |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TElement | The entity type. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when expression is null. |

<a name='M-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1-ExecuteEnumerable-System-Linq-Expressions-Expression-'></a>
### ExecuteEnumerable(expression) `method`

##### Summary

Return the enumerable result.

##### Returns

The [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') to parse. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when expression is null. |

<a name='M-ExpressionPowerTools-Core-Providers-QuerySnapshotProvider`1-OnExecuteEnumerableCalled-System-Linq-Expressions-Expression-'></a>
### OnExecuteEnumerableCalled(expression) `method`

##### Summary

Raise the event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The [Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') used. |

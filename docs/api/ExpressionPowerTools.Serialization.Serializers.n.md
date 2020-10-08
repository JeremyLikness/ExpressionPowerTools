# ExpressionPowerTools.Serialization.Serializers Namespace

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > **ExpressionPowerTools.Serialization.Serializers**

## Classes

| Class | Description |
| :-- | :-- |
| [AnonType](ExpressionPowerTools.Serialization.Serializers.AnonType.cs.md) | Adapter for anonymous types. |
| [AnonymousTypeAdapter](ExpressionPowerTools.Serialization.Serializers.AnonymousTypeAdapter.cs.md) | Adapter to serialize and deserialize anonymous types. |
| [BaseSerializer&lt;TExpression, TSerializable>](ExpressionPowerTools.Serialization.Serializers.BaseSerializer`2.cs.md) | Base class for serializers. |
| [Binary](ExpressionPowerTools.Serialization.Serializers.Binary.cs.md) | Represents a serializable [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) . |
| [BinarySerializer](ExpressionPowerTools.Serialization.Serializers.BinarySerializer.cs.md) | Serialization services for [BinaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.binaryexpression) . |
| [Constant](ExpressionPowerTools.Serialization.Serializers.Constant.cs.md) | Represents a serializable [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) . |
| [ConstantSerializer](ExpressionPowerTools.Serialization.Serializers.ConstantSerializer.cs.md) | Serializer for [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) . |
| [CtorExpr](ExpressionPowerTools.Serialization.Serializers.CtorExpr.cs.md) | Represents a serializable [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) . |
| [CtorSerializer](ExpressionPowerTools.Serialization.Serializers.CtorSerializer.cs.md) | Serialization services for [NewExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newexpression) . |
| [ExpressionSerializer](ExpressionPowerTools.Serialization.Serializers.ExpressionSerializer.cs.md) | Top-level serializer that passes work off to specific types. |
| [ExpressionSerializerAttribute](ExpressionPowerTools.Serialization.Serializers.ExpressionSerializerAttribute.cs.md) | Attribute to tag a serializer. |
| [Invocation](ExpressionPowerTools.Serialization.Serializers.Invocation.cs.md) | A serializable version of [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) . |
| [InvocationSerializer](ExpressionPowerTools.Serialization.Serializers.InvocationSerializer.cs.md) | Serialization logic for expressions of type [InvocationExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.invocationexpression) . |
| [Lambda](ExpressionPowerTools.Serialization.Serializers.Lambda.cs.md) | Serializable version of [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) . |
| [LambdaSerializer](ExpressionPowerTools.Serialization.Serializers.LambdaSerializer.cs.md) | Serialization logic for expressions of type [LambdaExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.lambdaexpression) . |
| [MemberBindingAssignment](ExpressionPowerTools.Serialization.Serializers.MemberBindingAssignment.cs.md) | Serializable [MemberAssignment](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberassignment) . |
| [MemberBindingInitializer](ExpressionPowerTools.Serialization.Serializers.MemberBindingInitializer.cs.md) | Serializable version of [ElementInit](https://docs.microsoft.com/dotnet/api/system.linq.expressions.elementinit) . |
| [MemberBindingList](ExpressionPowerTools.Serialization.Serializers.MemberBindingList.cs.md) | Serializable version of the [MemberListBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberlistbinding) class. |
| [MemberBindingMember](ExpressionPowerTools.Serialization.Serializers.MemberBindingMember.cs.md) | Serializable version of the [MemberMemberBinding](https://docs.microsoft.com/dotnet/api/system.linq.expressions.membermemberbinding) class. |
| [MemberExpr](ExpressionPowerTools.Serialization.Serializers.MemberExpr.cs.md) | Helper to serialize a [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) . |
| [MemberInit](ExpressionPowerTools.Serialization.Serializers.MemberInit.cs.md) | Serializable representation of [MemberInitExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberinitexpression) . |
| [MemberInitSerializer](ExpressionPowerTools.Serialization.Serializers.MemberInitSerializer.cs.md) | Serialization services for [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) . |
| [MemberSerializer](ExpressionPowerTools.Serialization.Serializers.MemberSerializer.cs.md) | Serialization services for [MemberExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.memberexpression) . |
| [MethodExpr](ExpressionPowerTools.Serialization.Serializers.MethodExpr.cs.md) | Serializable container for [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) . |
| [MethodSerializer](ExpressionPowerTools.Serialization.Serializers.MethodSerializer.cs.md) | Serializer for [MethodCallExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.methodcallexpression) . |
| [NewArray](ExpressionPowerTools.Serialization.Serializers.NewArray.cs.md) | New array serialization. |
| [NewArraySerializer](ExpressionPowerTools.Serialization.Serializers.NewArraySerializer.cs.md) | Serializer for [NewArrayExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.newarrayexpression) . |
| [Parameter](ExpressionPowerTools.Serialization.Serializers.Parameter.cs.md) | A serializable type for [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) . |
| [ParameterSerializer](ExpressionPowerTools.Serialization.Serializers.ParameterSerializer.cs.md) | Serializer for [ParameterExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.parameterexpression) . |
| [ReflectionHelper](ExpressionPowerTools.Serialization.Serializers.ReflectionHelper.cs.md) | Helper class to cache [Type](https://docs.microsoft.com/dotnet/api/system.type) and [MethodInfo](https://docs.microsoft.com/dotnet/api/system.reflection.methodinfo) information. |
| [SerializableExpression](ExpressionPowerTools.Serialization.Serializers.SerializableExpression.cs.md) | Class for serialization expressions. |
| [SerializationRoot](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.cs.md) | Root of [Expression](ExpressionPowerTools.Serialization.Serializers.SerializationRoot.Expression.prop.md) tree. |
| [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State info passed recurisvely through the serialization process. |
| [Unary](ExpressionPowerTools.Serialization.Serializers.Unary.cs.md) | Serializable version of the [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) . |
| [UnarySerializer](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.cs.md) | Serializer for [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) . |


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 10/08/2020 05:23:03 | (c) Copyright 2020 Jeremy Likness. | 0.9.3-alpha |

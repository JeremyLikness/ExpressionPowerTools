// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System.Dynamic;
using System.Linq.Expressions;
using ExpressionPowerTools.Serialization.Serializers;

namespace ExpressionPowerTools.Serialization.Signatures
{
    /// <summary>
    /// Interface to work with anonymous types.
    /// </summary>
    public interface IAnonymousTypeAdapter
    {
        /// <summary>
        /// Transforms the object to an anonymous type.
        /// </summary>
        /// <param name="anonymous">The anonymous object.</param>
        /// <returns>The anonymous type.</returns>
        AnonType TransformAnonymousObject(object anonymous);

        /// <summary>
        /// Transform a <see cref="ConstantExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="ConstantExpression"/>.</param>
        /// <returns>Transformed to handle anonymous types.</returns>
        ConstantExpression TransformConstant(ConstantExpression expression);

        /// <summary>
        /// Transform anonymous initializer.
        /// </summary>
        /// <param name="expression">The <see cref="NewExpression"/>.</param>
        /// <returns>A new expression that returns <see cref="AnonType"/>.</returns>
        NewExpression TransformNew(NewExpression expression);

        /// <summary>
        /// Transform a <see cref="LambdaExpression"/> that returns an anonymous type.
        /// </summary>
        /// <param name="lambda">The <see cref="LambdaExpression"/>.</param>
        /// <returns>The new Lambda expression.</returns>
        LambdaExpression TransformLambda(LambdaExpression lambda);

        /// <summary>
        /// Parses a type to swap (i.e. anonymous to <see cref="ExpandoObject"/>).
        /// </summary>
        /// <param name="memberToTransform">The type to transform.</param>
        /// <returns>The transformed typed.</returns>
        string MemberKeyTransformer(string memberToTransform);
    }
}

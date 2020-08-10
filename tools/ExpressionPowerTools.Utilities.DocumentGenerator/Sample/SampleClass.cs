// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExpressionPowerTools.Core;
using ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Sample
{
    /// <summary>
    /// An implementation of the <see cref="SampleBaseClass{T1, T2}"/>.
    /// </summary>
    /// <typeparam name="T">The type to implement.</typeparam>
    public class SampleClass<T> : SampleBaseClass<TypeRef, T>, IComparable<SampleClass<T>>
        where T : IComparable<IEnumerator<TypeRef>>
    {
        /// <summary>
        /// Initializes static members of the <see cref="SampleClass{T}"/> class.
        /// </summary>
        static SampleClass()
        {
            SampleBaseClass<TypeRef, IComparable<IEnumerator<TypeRef>>>
                .SetInstance(new SampleClass<IComparable<IEnumerator<TypeRef>>>());
        }

        /// <summary>
        /// Gets the typed instance.
        /// </summary>
        public static SampleBaseClass<TypeRef, IComparable<IEnumerator<TypeRef>>> TypedInstance =>
            SampleBaseClass<TypeRef, IComparable<IEnumerator<TypeRef>>>.Instance;

        /// <summary>
        /// Gets a cross-assembly reference.
        /// </summary>
        public ExpressionEnumerator CrossAssemblyReference => new ExpressionEnumerator(Expression.Constant(5));

        /// <summary>
        /// Compare to.
        /// </summary>
        /// <param name="other">The other to compare to.</param>
        /// <returns>A value for the comparison.</returns>
        public int CompareTo(SampleClass<T> other) => Id.CompareTo(other?.Id);

        /// <summary>
        /// Get the enumerator.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The enumerator.</returns>
        public override IEnumerator<TypeRef> GetEnumerableFor(TypeRef entity)
            => new List<TypeRef> { entity }.GetEnumerator();

        /// <summary>
        /// Is it ready test.
        /// </summary>
        /// <typeparam name="T5">The type of the test.</typeparam>
        /// <param name="test">The value to test.</param>
        /// <returns>A value that indicates whether it is ready.</returns>
        public override bool IsReady<T5>(T5 test)
        {
            return test.GetHashCode() > 53;
        }

        /// <summary>
        /// Processes a comparable.
        /// </summary>
        /// <typeparam name="T4">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The instance.</returns>
        public override T ProcessComparable<T4>(T4 parameter) => default;
    }
}

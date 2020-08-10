// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Sample
{
    /// <summary>
    /// A sample base class.
    /// </summary>
    /// <typeparam name="T1">The first type.</typeparam>
    /// <typeparam name="T2">The second type.</typeparam>
    public abstract class SampleBaseClass<T1, T2> : ISampleInterface<T1, IEnumerator<T1>, T2>
        where T1 : class, new()
        where T2 : IComparable<IEnumerator<T1>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleBaseClass{T1, T2}"/> class.
        /// </summary>
        public SampleBaseClass()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleBaseClass{T1, T2}"/> class.
        /// Saves an entity and identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        public SampleBaseClass(T1 entity, string id)
        {
            Entity = entity;
            Id = id;
        }

        /// <summary>
        /// Gets a static instance.
        /// </summary>
        public static SampleBaseClass<T1, T2> Instance { get; private set; }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        public T1 Entity { get; private set; }

        /// <summary>
        /// Gets the identity.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Set the instance.
        /// </summary>
        /// <param name="instance">The instance to set.</param>
        public static void SetInstance(SampleBaseClass<T1, T2> instance)
        {
            Instance = instance;
        }

        /// <summary>
        /// Does stuff.
        /// </summary>
        public virtual void DoStuff()
        {
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// The abstract enumerator.
        /// </summary>
        /// <param name="entity">The entity to enumerate.</param>
        /// <returns>The <see cref="IEnumerator{T}"/>.</returns>
        public abstract IEnumerator<T1> GetEnumerableFor(T1 entity);

        /// <summary>
        /// Test for readiness.
        /// </summary>
        /// <typeparam name="T5">The type to test.</typeparam>
        /// <param name="test">The list to test.</param>
        /// <returns>A flag indicating whether it is ready.</returns>
        public abstract bool IsReady<T5>(T5 test)
            where T5 : IList<T2>;

        /// <summary>
        /// Test for comparability.
        /// </summary>
        /// <typeparam name="T4">The value type.</typeparam>
        /// <param name="parameter">The value.</param>
        /// <returns>An instance of <see cref="IEnumerable{T}"/>.</returns>
        public abstract T2 ProcessComparable<T4>(T4 parameter)
            where T4 : struct;

        /// <summary>
        /// Just another method.
        /// </summary>
        /// <param name="x">The <see cref="long"/> to convert.</param>
        /// <returns>An <see cref="int"/>.</returns>
        public int ConvertLongToInt(long x)
        {
            return (int)(x & int.MaxValue);
        }
    }
}

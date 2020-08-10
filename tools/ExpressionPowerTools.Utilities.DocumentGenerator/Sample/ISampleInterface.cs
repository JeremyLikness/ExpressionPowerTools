using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Sample
{
    /// <summary>
    /// Sample interface for testing.
    /// </summary>
    /// <typeparam name="T1">The main type.</typeparam>
    /// <typeparam name="T2">The enumerator.</typeparam>
    /// <typeparam name="T3">The comparable.</typeparam>
    public interface ISampleInterface<in T1, out T2, T3>
        where T1 : class, new()
        where T2 : IEnumerator<T1>
        where T3 : IComparable<T2>
    {
        /// <summary>
        /// Do stuff.
        /// </summary>
        void DoStuff();

        /// <summary>
        /// Gets an enumerable for the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The instance.</returns>
        T2 GetEnumerableFor(T1 entity);

        /// <summary>
        /// Process a comparable item.
        /// </summary>
        /// <typeparam name="T4">The type of the value to process.</typeparam>
        /// <param name="parameter">The value to process.</param>
        /// <returns>A comparable.</returns>
        T3 ProcessComparable<T4>(T4 parameter)
            where T4 : struct;

        /// <summary>
        /// Is it ready?
        /// </summary>
        /// <typeparam name="T5">The <see cref="IList{T}"/> type.</typeparam>
        /// <param name="test">The list to test.</param>
        /// <returns>A flag indicating whether or not it is ready.</returns>
        bool IsReady<T5>(T5 test)
            where T5 : IList<T3>;
    }
}

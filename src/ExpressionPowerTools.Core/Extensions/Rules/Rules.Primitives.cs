using System;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Extensions
{
    /// <summary>
    /// Primitive rules.
    /// </summary>
    public static partial class ExpressionRulesExtensions
    {
        /// <summary>
        /// Truth.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>Always <c>true</c>.</returns>
        public static Expression<Func<T, T, bool>> True<T>()
            where T : Expression => (_, __) => true;

        /// <summary>
        /// Lies.
        /// </summary>
        /// <typeparam name="T">The <see cref="Expression"/> type.</typeparam>
        /// <returns>Always <c>false</c>.</returns>
        public static Expression<Func<T, T, bool>> False<T>()
            where T : Expression => (_, __) => false;
    }
}

using System;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Core.Providers
{
    /// <summary>
    /// Encapsulates an <see cref="Expression"/>.
    /// </summary>
    public class QuerySnapshotEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySnapshotEventArgs"/> class.
        /// </summary>
        /// <param name="expression">The <see cref="Expression"/> to host.</param>
        public QuerySnapshotEventArgs(Expression expression)
        {
            Expression = expression;
        }

        /// <summary>
        /// Gets the <see cref="Expression"/>.
        /// </summary>
        public Expression Expression { get; private set; }
    }
}

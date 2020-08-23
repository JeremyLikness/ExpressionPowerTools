using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Serializable version of <see cref="LambdaExpression"/>.
    /// </summary>
    [Serializable]
    public class Lambda : SerializableExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lambda"/> class.
        /// </summary>
        public Lambda()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lambda"/> class with
        /// the provided <see cref="LambdaExpression"/>.
        /// </summary>
        /// <param name="expression">The <see cref="LambdaExpression"/> to parse.</param>
        public Lambda(LambdaExpression expression)
            : base(expression)
        {
            Name = expression.Name;
            LambdaType = expression.Type.FullName;
            ReturnType = expression.ReturnType.FullName;
        }

        /// <summary>
        /// Gets or sets the body of the lambda.
        /// </summary>
        public object Body { get; set; }

        /// <summary>
        /// Gets or sets the name of the lambda.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets thte list of parameters for the lambda.
        /// </summary>
        public List<object> Parameters { get; set; } =
            new List<object>();

        /// <summary>
        /// Gets or sets the type of the lambda.
        /// </summary>
        public string LambdaType { get; set; }

        /// <summary>
        /// Gets or sets the return type of the lambda.
        /// </summary>
        public string ReturnType { get; set; }
    }
}

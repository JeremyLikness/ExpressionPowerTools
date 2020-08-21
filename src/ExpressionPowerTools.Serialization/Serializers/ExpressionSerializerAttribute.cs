using System;
using System.Linq.Expressions;

namespace ExpressionPowerTools.Serialization.Serializers
{
    /// <summary>
    /// Attribute to tag a serializer.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExpressionSerializerAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionSerializerAttribute"/>
        /// class with an <see cref="ExpressionType"/>.
        /// </summary>
        /// <param name="type">The <see cref="ExpressionType"/> the serializer handles.</param>
        public ExpressionSerializerAttribute(ExpressionType type)
        {
            Type = type;
        }

        /// <summary>
        /// Gets the <see cref="ExpressionType"/> the serializer handles.
        /// </summary>
        public ExpressionType Type { get; private set; }
    }
}

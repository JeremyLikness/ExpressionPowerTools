namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    /// <summary>
    /// Represents a parameter.
    /// </summary>
    public class DocParameter : DocBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocParameter"/> class with the
        /// specified parent.
        /// </summary>
        /// <param name="parent">The parent <see cref="DocBase"/>.</param>
        public DocParameter(DocBase parent)
        {
            Parent = parent;
        }

        /// <summary>
        /// Gets or sets the type of the parameter.
        /// </summary>
        public DocBaseType ParameterType { get; set; }

        /// <summary>
        /// Gets the owning type.
        /// </summary>
        public DocBase Parent { get; private set; }

        /// <summary>
        /// Gets the extension.
        /// </summary>
        public override string Extension => "p";
    }
}

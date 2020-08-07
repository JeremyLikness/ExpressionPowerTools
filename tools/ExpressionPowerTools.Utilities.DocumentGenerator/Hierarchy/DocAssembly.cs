using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    public class DocAssembly : DocBase
    {
        public DocAssembly(string assemblyName)
        {
            Name = assemblyName;
        }

        public ICollection<DocNamespace> Namespaces { get; set; } =
            new List<DocNamespace>();

        public override string Extension => "a";
    }
}

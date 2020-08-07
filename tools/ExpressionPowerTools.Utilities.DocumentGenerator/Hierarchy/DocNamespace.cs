using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    public class DocNamespace : DocBase
    {
        public DocAssembly Assembly { get; set; }

        public DocNamespace(string nspace)
        {
            Name = nspace;
        }

        public ICollection<DocExportedType> Types { get; set; }
            = new List<DocExportedType>();

        public override string Extension => "n";
    }
}

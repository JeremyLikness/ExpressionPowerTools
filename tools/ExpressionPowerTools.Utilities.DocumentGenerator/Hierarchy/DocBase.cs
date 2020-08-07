using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    public abstract class DocBase
    {
        public virtual string Name { get; set; } = "";

        public virtual string Description { get; set; } = "";

        public virtual string Remarks { get; set; } = "";

        public virtual string Example { get; set; } = "";
            
        public IList<(string name, string displayName)> Extensions { get; set; } = new List<(string name, string displayName)>();

        public virtual IList<string> Exceptions { get; set; } = new List<string>();

        public IList<DocTypeParameter> TypeParameters { get; set; } = new List<DocTypeParameter>();

        public abstract string Extension { get; }

        public string FileName => $"{Name}.{Extension}.md";
    }
}

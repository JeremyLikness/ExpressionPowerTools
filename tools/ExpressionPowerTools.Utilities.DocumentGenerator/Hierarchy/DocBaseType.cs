using System.Collections.Generic;

namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    public abstract class DocBaseType : DocBase
    {
        public bool IsInterface { get; set; }

        public IList<(string name, string displayName)> ImplementedInterfaces
        { get; set; } = new List<(string name, string displayName)>();

        public IList<(string name, string displayName)> Inheritance
        { get; set; } = new List<(string name, string displayName)>();

        public string TypeName { get; set; }

        public string Code { get; set; }
    }
}

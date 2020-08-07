namespace ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy
{
    public class DocExportedType : DocBaseType
    {
        public DocNamespace Namespace { get; set; }

        public override string Extension => IsInterface ? "i" : "cs";
    }
}

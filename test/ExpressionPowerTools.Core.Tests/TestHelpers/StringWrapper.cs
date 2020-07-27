namespace ExpressionPowerTools.Core.Tests.TestHelpers
{
    public class StringWrapper
    {
        public string Id { get; set; }

        public string _Id;

        public int IdVal { get; set; }

        public string OtherId { get; set; }

        public static bool IsNullOrEmpty(string value) =>
            string.IsNullOrEmpty(value);

        public static bool IsNullOrWhitespace(string value) =>
            string.IsNullOrWhiteSpace(value);
    }
}

namespace ExpressionPowerTools.Core.Tests.TestHelpers
{
    public class IdType
    {
        public string Id { get; set; }
        public int IdVal { get; set; }

        public string GetId() => Id;
        public int GetIdVal() => IdVal;

        public string Echo(string echo) => echo;
        public string EchoStr(string echo) => echo;

        public string LongParameterList(string one, string two, string three, string four, string fix, string six, string seven, string eight) => "8";
        public string LongParameterList(string one, string two, string three, string four, string fix, string six, string seven, string eight, string nine) => "9";

        public string Echo(string echo, string more) => $"{echo} => {more}";
    }
}

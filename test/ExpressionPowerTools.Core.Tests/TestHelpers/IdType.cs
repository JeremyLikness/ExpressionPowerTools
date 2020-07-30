using System;

namespace ExpressionPowerTools.Core.Tests.TestHelpers
{
    public class IdType : IEquatable<IdType>
    {
        public IdType()
        {
            Id = Guid.NewGuid().ToString();
            IdVal = new Random().Next(int.MinValue, int.MaxValue);
        }

        public string Message { get; private set; }

        public void Callback(string message)
        {
            Message = message;
        }

        public string Id { get; set; }
        public int IdVal { get; set; }

        public string GetId() => Id;
        public int GetIdVal() => IdVal;

        public string Echo(string echo) => echo;
        public string EchoStr(string echo) => echo;

        public string LongParameterList(string one, string two, string three, string four, string fix, string six, string seven, string eight) => "8";
        public string LongParameterList(string one, string two, string three, string four, string fix, string six, string seven, string eight, string nine) => "9";

        public string Echo(string echo, string more) => $"{echo} => {more}";

        public bool Equals(IdType other)
        {
            return other?.Id == Id && other?.IdVal == IdVal;
        }
    }
}

using System;

namespace ExpressionPowerTools.Core.Tests.TestHelpers
{
    public class StringWrapper : IComparable
    {
        public StringWrapper()
        {

        }

        public StringWrapper(bool initialize)
        {
            if (initialize)
            {
                Id = Guid.NewGuid().ToString();
                IdVal = new Random().Next(int.MinValue, int.MaxValue);
            }
        }

        public StringWrapper(IdType id)
        {
            if (id == null)
            {
                NullIdTypeInjected = true;
            }

            Id = id?.Id;
            IdVal = id == null ? int.MaxValue : id.IdVal;
        }

        public bool NullIdTypeInjected = false;

        public string Id { get; set; }

        public string _Id;

        public int IdVal { get; set; }

        public string OtherId { get; set; }

        public static bool IsNullOrEmpty(string value) =>
            string.IsNullOrEmpty(value);

        public static bool IsNullOrWhitespace(string value) =>
            string.IsNullOrWhiteSpace(value);

        public int CompareTo(object obj)
        {
            if (obj is StringWrapper str)
            {
                var id = Id.CompareTo(str.Id);
                return id == 0 ? IdVal.CompareTo(str.IdVal) : id;
            }
            return 1;
        }
    }
}

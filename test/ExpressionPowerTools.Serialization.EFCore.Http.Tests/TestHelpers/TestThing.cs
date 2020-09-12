using System;
using System.Collections.Generic;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Tests.TestHelpers
{
    public class TestThing
    {
        private static readonly Random _random = new Random();
        public string Id { get; set; }
        public int Value { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }

        public TestThing()
        {
            Id = Guid.NewGuid().ToString();
            Value = _random.Next();
            IsActive = _random.NextDouble() < 0.501;
            Created = DateTime.Now.AddMinutes(-1 * _random.Next(5, 60 * 24 * 7));
        }

        public static ICollection<TestThing> GetThings(int count)
        {
            var result = new List<TestThing>();
            while (count-- > 0)
            {
                result.Add(new TestThing());
            }
            return result;
        }
    }
}

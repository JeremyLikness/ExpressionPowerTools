using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionPowerTools.Serialization.Tests.TestHelpers
{
    public class TestableThing
    {
        public TestableThing()
        {
        }

        public TestableThing(string id)
        {
            Id = id;
            Value = int.MinValue;
            IsActive = true;
        }

        private static readonly Random randomizer = new Random();
        private static int MinutesAgo() => -1 * randomizer.Next(2, 365 * 24 * 60);

        public static IQueryable<TestableThing> MakeQuery(int count = 0)
        {
            var idx = 0;
            var list = new List<TestableThing>();
            while (idx++ < count)
            {
                list.Add(new TestableThing());
            }
            return list.AsQueryable();
        }

        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public DateTime Created { get; private set; } = DateTime.Now.AddMinutes(MinutesAgo());
        public int Value { get; private set; } = randomizer.Next();
        public bool IsActive { get; private set; } = randomizer.NextDouble() > 0.5;
    }
}

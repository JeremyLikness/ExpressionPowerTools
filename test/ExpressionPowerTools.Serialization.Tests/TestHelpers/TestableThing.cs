using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionPowerTools.Serialization.Tests.TestHelpers
{
    public class TestableData
    {
        public string Data { get; set; }
    }

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
                var newThing = new TestableThing();
                for (var childIdx = 0; childIdx < idx; childIdx++)
                {
                    var child = new TestableThing();
                    newThing.ChildThings.Add(child);
                    for (var grandChildIdx = 0; grandChildIdx < childIdx;
                        grandChildIdx++)
                    {
                        child.ChildThings.Add(new TestableThing());
                    }
                }
                list.Add(newThing);
            }
            return list.AsQueryable();
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public TestableData Data { get; set; } = new TestableData { Data = randomizer.Next().ToString() };
        public DateTime Created { get; set; } = DateTime.Now.AddMinutes(MinutesAgo());
        public int Value { get; private set; } = randomizer.Next();
        public bool IsActive { get; private set; } = randomizer.NextDouble() > 0.5;
        public List<TestableThing> ChildThings { get; set; } = new List<TestableThing>();
    }
}

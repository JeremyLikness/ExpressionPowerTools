using System;
using System.Collections.Generic;
using System.Linq;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Tests.TestHelpers
{
    public class QueryHelper
    {
        public string Id { get; set; }
        public DateTimeOffset Created { get; set; }

        private static readonly List<QueryHelper> src = new List<QueryHelper>();

        public static IQueryable<QueryHelper> QuerySkip2Take3 =>
            src
            .AsQueryable()
            .Where(q => q.Id == nameof(QuerySkip2Take3) &&
            q.Created > DateTime.Now.AddDays(-1))
            .Skip(2)
            .Take(3)
            .OrderBy(q => q.Created);

        public static IQueryable<QueryHelper> QuerySkip2Take4 =>
            new List<QueryHelper>()
            .AsQueryable()
            .Where(q => q.Id == nameof(QuerySkip2Take3) &&
            q.Created > DateTime.Now.AddDays(-1))
            .Skip(2)
            .Take(4)
            .OrderBy(q => q.Created);

        public static IExpressionEnumerator NullEnumerator
            => null;

        public static IExpressionEnumerator QueryEnumerator
            => QuerySkip2Take3.AsEnumerableExpression();
    }
}

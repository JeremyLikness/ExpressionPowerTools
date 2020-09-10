using System;
using System.Collections.Generic;
using System.Text;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Middleware;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Signatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.AspNetCore.Routing.Template;
using Xunit;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests
{
    public class RouteProcessorTests
    {
        private readonly IRouteProcessor target = new RouteProcessor();

        private readonly RouteTemplate route = TemplateParser.Parse(MiddlewareExtensions.DefaultPattern);

        public static IEnumerable<object[]> GetPathMatrix()
        {
            (string context, string collection) nullResult =
                (null, null);

            yield return new object[]
            {
                null, nullResult
            };

            yield return new object[]
            {
                string.Empty, nullResult
            };

            yield return new object[]
            {
                "efcore", nullResult
            };

            yield return new object[]
            {
                "/efcore", nullResult
            };

            yield return new object[]
            {
                "/efcore/context", nullResult
            };

            yield return new object[]
            {
                "efcore/context", nullResult
            };

            yield return new object[]
            {
                "/efcore/context/", nullResult
            };

            yield return new object[]
            {
                "/efcore/context/collection",
                ("context", "collection")
            };

            yield return new object[]
            {
                "/efcore/context/collection/",
                ("context", "collection")
            };

            yield return new object[]
            {
                "efcore/context/collection",
                nullResult
            };

            yield return new object[]
            {
                "efcore/context/collection/",
                nullResult
            };
        }

        [Theory]
        [MemberData(nameof(GetPathMatrix))]
        public void GivenPathWhenParsePathCalledThenShouldReturnParts(
            string path, (string context, string collection) expected)
        {
            var matcher = new TemplateMatcher(route, null);
            RouteValueDictionary values = path == null ? null : new RouteValueDictionary();
            string context = null;
            string collection = null;
            try
            {
                if (values != null)
                {
                    matcher.TryMatch(path, values);
                }
                (context, collection) = target.ParseRoute(values);
            }
            catch
            {

            }
            Assert.Equal(expected.context, context);
            Assert.Equal(expected.collection, collection);
        }
    }
}

using System;
using System.Globalization;
using ExpressionPowerTools.Core.Resources;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class ExceptionHelperTests
    {
        private CultureInfo EnglishUs => new CultureInfo("en-US");

        [Fact]
        public void WhiteSpaceNotAllowedReturnsProperlyPopulatedArgumentException()
        {
            var culture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = EnglishUs;
            ArgumentException target =
                ExceptionHelper.WhitespaceNotAllowedException(
                    nameof(target));
            CultureInfo.CurrentCulture = culture;
            Assert.NotNull(target);
            Assert.Contains("whitespace", target.Message);
            Assert.Equal(nameof(target), target.ParamName);
        }

        [Fact]
        public void NullReferenceReturnsProperlyPopulatedNullReferenceException()
        {
            var culture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = EnglishUs;
            NullReferenceException target =
                ExceptionHelper.NullReferenceNotAllowedException(
                    nameof(target));
            CultureInfo.CurrentCulture = culture;
            Assert.NotNull(target);
            Assert.Contains("null", target.Message);
            Assert.Contains(nameof(target), target.Message);
        }

        [Fact]
        public void MethodCallOnTypeRequiredExceptionReturnsProperlyPopulatedArgumentException()
        {
            var culture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = EnglishUs;
            ArgumentException target =
                ExceptionHelper.MethodCallOnTypeRequiredException(
                    nameof(target));
            CultureInfo.CurrentCulture = culture;
            Assert.NotNull(target);
            Assert.Contains("method", target.Message);
            Assert.Equal(nameof(target), target.ParamName);
        }

    }
}

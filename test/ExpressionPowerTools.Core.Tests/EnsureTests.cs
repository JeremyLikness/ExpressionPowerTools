using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ExpressionPowerTools.Core.Contract;
using Xunit;

namespace ExpressionPowerTools.Core.Tests
{
    public class EnsureTests
    {
        [Fact]
        public void GivenExpressionThatResolvesToNullWhenNotNullCalledThenShouldThrowArgumentNull()
        {
            string foo = null;
            Assert.Throws<ArgumentNullException>(
                () => Ensure.NotNull(() => foo));
        }

        [Fact]
        public void GivenArgumentNullThrownThenShouldHaveTargetName()
        {
            string foo = null;
            try
            {
                Ensure.NotNull(() => foo);
            }
            catch (ArgumentNullException ex)
            {
                Assert.Equal(nameof(foo), ex.ParamName);
            }
            catch (Exception ex)
            {
                Assert.IsType<ArgumentNullException>(ex);
            }
        }

        [Fact]
        public void GivenExpressionThatDoesNotResolveToNullWhenNotNullCalledThenShouldReturn()
        {
            var foo = string.Empty;
            Ensure.NotNull(() => foo);
        }

        [Fact]
        public void GivenExpressionThatResolvesToNullWhenPropertyNotNullCalledThenShouldThrowNullReference()
        {
            string foo = null;
            Assert.Throws<NullReferenceException>(
                () => Ensure.PropertyNotNull(() => foo));
        }

        [Fact]
        public void GivenNullReferenceThrownThenShouldHaveTargetName()
        {
            string foo = null;
            try
            {
                Ensure.PropertyNotNull(() => foo);
            }
            catch (NullReferenceException ex)
            {
                Assert.Contains(nameof(foo), ex.Message);
            }
            catch (Exception ex)
            {
                Assert.IsType<NullReferenceException>(ex);
            }
        }

        [Fact]
        public void GivenExpressionThatDoesNotResolveToNullWhenPropertyNotNullCalledThenShouldReturn()
        {
            var foo = string.Empty;
            Ensure.NotNull(() => foo);
        }

        [Fact]
        public void GivenExpressionThatResolvesToNullWhenNotNullOrWhitespaceCalledThenShouldThrowArgument()
        {
            string foo = null;
            Assert.Throws<ArgumentException>(
                () => Ensure.NotNullOrWhitespace(() => foo));
        }

        [Fact]
        public void GivenExpressionThatResolvesToWhitespaceWhenNotNullOrWhitespaceCalledThenShouldThrowArgument()
        {
            string foo = new string(' ', 5);
            Assert.Throws<ArgumentException>(
                () => Ensure.NotNullOrWhitespace(() => foo));
        }

        [Fact]
        public void GivenExpressionThatResolvesToValueWhenNotNullOrWhitespaceCalledThenShouldReturn()
        {
            string foo = nameof(foo);
            Ensure.NotNullOrWhitespace(() => foo);
        }
    }
}

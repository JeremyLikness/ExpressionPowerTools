using System;
using System.Threading.Tasks;
using BlazorMvvmExample.Shared.Commands;
using Xunit;

namespace BlazorMVVMExample.Shared.Tests
{
    public class MvvmCommandTests
    {
        [Fact]
        public void GivenActionWhenCanExecuteCalledThenShouldReturnTrue()
        {
            var command = new MvvmCommand<object>(() => { });
            Assert.True(command.CanExecute(null));
        }

        [Fact]
        public void GivenActionWhenExecuteCalledThenShouldExecute()
        {
            var id = 0;
            var command = new MvvmCommand<object>(() => id++);
            command.Execute(null);
            Assert.Equal(1, id);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GivenActionWithPredicateWhenCanExecuteCalledThenShouldReturnValue(bool allow)
        {
            var command = new MvvmCommand<object>(() => { }, () => allow);
            Assert.Equal(allow, command.CanExecute(null));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GivenActionWithPredicateWhenExecuteCalledThenShouldOnlyExecuteIfAllowed(bool allow)
        {
            var id = 0;
            var expected = allow ? 1 : 0;
            var command = new MvvmCommand<object>(() => id++, () => allow);
            command.Execute(null);
            Assert.Equal(expected, id);
        }

        [Fact]
        public void GivenAsyncActionWhenCanExecuteCalledThenShouldReturnTrue()
        {
            var command = new MvvmCommand<object>(() => Task.CompletedTask);
            Assert.True(command.CanExecute(null));
        }

        private async Task AsyncTask(Action action)
        {
            await Task.Delay(5);
            action();
        }

        [Fact]
        public async Task GivenAsyncActionWhenExecuteCalledThenShouldExecute()
        {
            var id = 0;
            var command = new MvvmCommand<object>(() => AsyncTask(() => id++));
            await command.ExecuteAsync(null);
            Assert.Equal(1, id);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GivenAsyncActionWithPredicateWhenCanExecuteCalledThenShouldReturnValue(bool allow)
        {
            var command = new MvvmCommand<object>(() => Task.CompletedTask, () => allow);
            Assert.Equal(allow, command.CanExecute(null));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task GivenAsyncActionWithPredicateWhenExecuteCalledThenShouldOnlyExecuteIfAllowed(bool allow)
        {
            var id = 0;
            var expected = allow ? 1 : 0;
            var command = new MvvmCommand<object>(() => AsyncTask(() => id++), () => allow);
            await command.ExecuteAsync(null);
            Assert.Equal(expected, id);
        }

        [Fact]
        public void GivenActionWithValueWhenCanExecuteCalledThenShouldReturnTrue()
        {
            var command = new MvvmCommand<double>(() => { });
            Assert.True(command.CanExecute(0.5));
        }

        [Fact]
        public void GivenActionWithValueWhenExecuteCalledThenShouldExecute()
        {
            var id = 0;
            var command = new MvvmCommand<double>(() => id++);
            command.Execute(0.5);
            Assert.Equal(1, id);
        }

        static bool predicate(double val) => val > 0.5;

        [Theory]
        [InlineData(0.1)]
        [InlineData(0.9)]
        public void GivenActionWithPredicateWithValueWhenCanExecuteCalledThenShouldReturnValue(double value)
        {
            var allow = predicate(value);
            var command = new MvvmCommand<double>(val => { }, predicate);
            Assert.Equal(allow, command.CanExecute(value));
        }

        [Theory]
        [InlineData(0.1)]
        [InlineData(0.9)]
        public void GivenActionWithPredicateWithValueWhenExecuteCalledThenShouldOnlyExecuteIfAllowed(double value)
        {
            var allow = predicate(value);
            var id = 0;
            var expected = allow ? 1 : 0;
            var command = new MvvmCommand<double>(val => id++, predicate);
            command.Execute(value);
            Assert.Equal(expected, id);
        }

        [Fact]
        public void GivenAsyncActionWithValueWhenCanExecuteCalledThenShouldReturnTrue()
        {
            var command = new MvvmCommand<double>(val => Task.CompletedTask);
            Assert.True(command.CanExecute(0.5));
        }

        [Fact]
        public async Task GivenAsyncActionWithValueWhenExecuteCalledThenShouldExecute()
        {
            double id = 0;
            var command = new MvvmCommand<double>(val => AsyncTask(() => id = val));
            await command.ExecuteAsync(0.5);
            Assert.Equal(0.5, id);
        }

        [Theory]
        [InlineData(0.1)]
        [InlineData(0.9)]
        public void GivenAsyncActionWithValueWithPredicateWhenCanExecuteCalledThenShouldReturnValue(double value)
        {
            var allow = predicate(value);           
            var command = new MvvmCommand<double>(val => Task.CompletedTask, predicate);
            Assert.Equal(allow, command.CanExecute(value));
        }

        [Theory]
        [InlineData(0.1)]
        [InlineData(0.9)]
        public async Task GivenAsyncActionWithValueWithPredicateWhenExecuteCalledThenShouldOnlyExecuteIfAllowed(double value)
        {
            double id = 0;
            var allow = predicate(value);
            var expected = allow ? value : 0;
            var command = new MvvmCommand<double>(val => AsyncTask(() => id = val), predicate);
            await command.ExecuteAsync(value);
            Assert.Equal(expected, id);
        }
    }
}

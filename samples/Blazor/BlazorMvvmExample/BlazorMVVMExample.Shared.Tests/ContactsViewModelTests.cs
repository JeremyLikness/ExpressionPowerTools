using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorMvvmExample.Shared.Signatures;
using BlazorMvvmExample.Shared.ViewModels;
using BlazorMVVMExample.Shared.Tests.TestHelpers;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.Compression;
using Xunit;

namespace BlazorMVVMExample.Shared.Tests
{
    public class ContactsViewModelTests
    {
        private readonly TestContactsQuery querySource;

        private readonly ContactsViewModel vm;

        public ContactsViewModelTests()
        {
            querySource = new TestContactsQuery();
            vm = new ContactsViewModel(querySource);
        }

        [Fact]
        public async Task LoadAsyncCallsGetBaseQuery()
        {
            await vm.LoadAsync();
            Assert.Equal(1, querySource.BaseQueryCalledCount);
        }

        [Fact]
        public async Task LoadAsyncAppliesSkip()
        {
            vm.Pager.Page = 3;
            await vm.LoadAsync();
            Assert.True(querySource.LastContactQuery.HasFragment(
                q => q.Skip(40)));
        }

        [Fact]
        public async Task LoadAsyncAppliesTake()
        {
            vm.Pager.Page = 3;
            await vm.LoadAsync();
            Assert.True(querySource.LastContactQuery.HasFragment(
                q => q.Take(20)));
        }

        [Fact]
        public async Task LoadAsyncSetsAndResetsLoadingFlag()
        {
            // delay the count
            querySource.DelayTaskSwitch = true;
            var task = vm.LoadAsync();
            Assert.True(vm.Loading);
            // release the task
            querySource.DelayTaskSwitch = false;
            await task;
            Assert.False(vm.Loading);
        }

        [Fact]
        public async Task LoadAsyncSetsAndResetsDisabledOnPagingViewModel()
        {
            // delay the count
            querySource.DelayTaskSwitch = true;
            var task = vm.LoadAsync();
            Assert.True(vm.Pager.Disabled);
            // release the task
            querySource.DelayTaskSwitch = false;
            await task;
            Assert.False(vm.Pager.Disabled);
        }

        [Fact]
        public async Task LoadAsyncPopulatesTheContactsList()
        {
            await vm.LoadAsync();
            Assert.NotEmpty(vm.Contacts);
            Assert.Equal(vm.Pager.PageSize, vm.Contacts.Count);
        }

        [Fact]
        public async Task LoadAsyncSetsTotalItemsOnPagingViewModel()
        {
            await vm.LoadAsync();
            Assert.Equal(100, vm.Pager.TotalItemCount);
        }

        [Fact]
        public async Task LoadAsyncSetsPageItemsOnPagingViewModel()
        {
            querySource.ResultCandidateSize = 9;
            await vm.LoadAsync();
            Assert.Equal(9, vm.Pager.PageItems);
        }

        [Fact]
        public void LoadAsyncTriggersOnPageSizeChange()
        {
            var count = querySource.BaseQueryCalledCount;
            vm.Pager.PageSize++;
            Assert.Equal(count + 1, querySource.BaseQueryCalledCount);
        }

        [Fact]
        public void LoadAsyncTriggersOnPageChange()
        {
            var count = querySource.BaseQueryCalledCount;
            vm.Pager.Page = 3;
            Assert.Equal(count + 1, querySource.BaseQueryCalledCount);
        }

        [Fact]
        public async Task GivenLoadingWhenLoadAsyncCalledThenReturnsAfterLoad()
        {
            // pause the query
            querySource.DelayTaskSwitch = true;

            var task = vm.LoadAsync();
            var secondTask = vm.LoadAsync();
            Assert.False(secondTask.IsCompleted);

            // release the query
            querySource.DelayTaskSwitch = false;
            await task;

            Assert.True(secondTask.IsCompleted);
        }

        [Fact]
        public async Task GivenLoadAsyncThrowsExceptionThenCapturesAndSetsErrorMessage()
        {
            querySource.ExceptionSwitch = true;
            await vm.LoadAsync();
            Assert.False(vm.Loading);
            Assert.NotEmpty(vm.ErrorMessage);
        }
    }
}

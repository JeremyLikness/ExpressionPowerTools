using System;
using BlazorMvvmExample.Shared.ViewModels;
using BlazorMVVMExample.Shared.Tests.TestHelpers;
using Xunit;

namespace BlazorMVVMExample.Shared.Tests
{
    public class PagingViewModelTests : IDisposable
    {
        private readonly PagingViewModel vm = new PagingViewModel();
        private readonly PropertyChangeTracker tracker;

        public PagingViewModelTests()
        {
            tracker = new PropertyChangeTracker(vm);
        }

        [Fact]
        public void GivenPageTrackerWhenPageChangesThenShouldRaisePropertyChange()
        {
            vm.Page = 2;
            Assert.True(
                tracker.HasChangesForType<PagingViewModel>());
            Assert.True(
                tracker.HasChangesForProperty<PagingViewModel>(
                    nameof(PagingViewModel.Page)));
        }

        [Fact]
        public void GivenPageTrackerWith100ItemsWhenPageSizeSetTo50ThenShouldUpdatePageCountTo2()
        {
            Assert.Equal(20, vm.PageSize);
            vm.TotalItemCount = 100;
            Assert.Equal(5, vm.PageCount);
            vm.PageSize = 50;
            Assert.Equal(2, vm.PageCount);
        }

        [Fact]
        public void GivenPageTrackerPageThenDbPageShouldBeOneLess()
        {
            var testPage = 5;
            var expectedDb = testPage - 1;
            vm.Page = testPage;
            Assert.Equal(expectedDb, vm.DbPage);
        }

        [Fact]
        public void GivenTotalItemCountOf0ThenPageCountShouldBe0()
        {
            vm.TotalItemCount = 0;
            Assert.Equal(0, vm.PageCount);
        }

        [Fact]
        public void GivenPageSizeOf20AndItemCountOf40ThenPageCountShouldBe2()
        {
            vm.TotalItemCount = 40;
            Assert.Equal(2, vm.PageCount);
        }

        [Fact]
        public void GivenPageSizeOf20AndItemCountOf41ThenPageCountShouldBe3()
        {
            vm.TotalItemCount = 41;
            Assert.Equal(3, vm.PageCount);
        }

        [Fact]
        public void GivenFirstPageThenPrevPageShouldBeTheSame()
        {
            vm.Page = 1;
            Assert.Equal(vm.Page, vm.PrevPage);
        }

        [Fact]
        public void GivenPage2ThenPrevPageShouldBe1()
        {
            vm.Page = 2;
            var expected = vm.Page - 1;
            Assert.Equal(expected, vm.PrevPage);

        }

        [Fact]
        public void GivenFirstPageThenHasPrevShouldBeFalse()
        {
            vm.Page = 1;
            Assert.False(vm.HasPrev);
        }

        [Fact]
        public void GivenPage2ThenHasPrevPageShouldBeTrue()
        {
            vm.Page = 2;
            Assert.True(vm.HasPrev);
        }

        [Fact]
        public void GivenLastPageThenNextPageShouldBeSame()
        {
            vm.TotalItemCount = 100; // 5 pages
            vm.Page = 5;
            Assert.Equal(vm.Page, vm.NextPage);
        }

        [Fact]
        public void GivenLastPageThenHasNextShouldBeFalse()
        {
            vm.TotalItemCount = 100; // 5 pages
            vm.Page = 5;
            Assert.False(vm.HasNext);
        }

        [Fact]
        public void GivenFirstPageAnd19ItemsThenNextPageShouldBe1()
        {
            vm.TotalItemCount = 19; // 1 page
            vm.Page = 1;
            Assert.Equal(vm.Page, vm.NextPage);
        }

        [Fact]
        public void GivenFirstPageAnd19ItemsThenHasNextPageShouldBeFalse()
        {
            vm.TotalItemCount = 19; // 1 page
            vm.Page = 1;
            Assert.False(vm.HasNext);
        }

        [Fact]
        public void GivenFirstPageAnd100ItemsThenNextPageShouldBe2()
        {
            vm.TotalItemCount = 100; // 5 pages
            vm.Page = 1;
            var expected = vm.Page + 1;
            Assert.Equal(expected, vm.NextPage);
        }

        [Fact]
        public void GivenFirstPageAnd100ItemsThenHasNextPageShouldBeTrue()
        {
            vm.TotalItemCount = 100; // 5 pages
            vm.Page = 1;
            Assert.True(vm.HasNext);
        }

        [Fact]
        public void GivenPageSizeOf20AndPage1ThenSkipShouldBe0()
        {
            vm.Page = 1;
            Assert.Equal(0, vm.Skip);
        }

        [Fact]
        public void GivenPageSizeOf20AndPage2ThenSkipShouldBe20()
        {
            vm.Page = 2;
            Assert.Equal(20, vm.Skip);
        }

        [Fact]
        public void GivenPageItemsWhenSetThenShouldGet()
        {
            vm.PageItems = 11;
            Assert.Equal(11, vm.PageItems);
        }

        public void Dispose()
        {
            tracker.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BlazorMvvmExample.Shared.Commands;
using BlazorMvvmExample.Shared.ViewModels;
using Xunit;

namespace BlazorMVVMExample.Shared.Tests
{
    public class PageCommandTests
    {
        public static IEnumerable<object[]> PageCommandTestMatrix()
        {
            static PagingViewModel makeVm(int totalItems, int page) => new PagingViewModel
            {
                TotalItemCount = totalItems,
                Page = page
            };

            yield return new object[]
            {
                true,
                makeVm(1,1),
                false,
                false
            };

            yield return new object[]
            {
                true,
                makeVm(1,1),
                true,
                false
            };

            yield return new object[]
            {
                true,
                makeVm(100,1),
                false,
                true
            };

            yield return new object[]
            {
                true,
                makeVm(100,1),
                true,
                true
            };

            yield return new object[]
            {
                false,
                makeVm(1,1),
                false,
                false
            };

            yield return new object[]
            {
                false,
                makeVm(1,1),
                true,
                false
            };

            yield return new object[]
            {
                false,
                makeVm(100,2),
                false,
                true
            };

            yield return new object[]
            {
                false,
                makeVm(100,2),
                true,
                true
            };
        }

        [Theory]
        [MemberData(nameof(PageCommandTestMatrix))]
        public void GivenPageCommandAndDirectionThenExecutesBasedOnCondition(
            bool pageNextCommand,
            PagingViewModel vm,
            bool doExecute,
            bool shouldPass)
        {
            var pageCommand = pageNextCommand ? vm.PagingNextCommand : vm.PagingPrevCommand;
            if (doExecute)
            {
                var page = vm.Page;
                pageCommand.Execute(vm);
                if (shouldPass)
                {
                    var offset = pageNextCommand ?
                        1 : -1;
                    Assert.Equal(page + offset, vm.Page);
                }
                else
                {
                    Assert.Equal(page, vm.Page);
                }
            }
            else
            {
                Assert.Equal(shouldPass, pageCommand.CanExecute(vm));
            }
        }
    }
}

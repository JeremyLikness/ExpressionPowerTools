using System;
using System.Collections.Generic;
using System.Text;
using BlazorMVVMExample.Shared.Tests.TestHelpers;
using Xunit;

namespace BlazorMVVMExample.Shared.Tests
{
    public class BaseViewModelTests
    {
        private object sender = null;
        private string propertyName = string.Empty;

        [Fact]
        public void GivenPropertyChangedThenRaisesPropertyChangeNotification()
        {
            using var vm = new TestViewModel();
            vm.PropertyChanged += Vm_PropertyChanged;
            vm.Id = 1;
            Assert.Same(sender, vm);
            Assert.Equal(nameof(TestViewModel.Id), propertyName);
            vm.PropertyChanged -= Vm_PropertyChanged;
        }

        [Fact]
        public void GivenListenToWhenChildEventFiredThenShouldCallObservedChanged()
        {
            using var child = new TestViewModel();
            using var vm = new TestViewModel(child);
            child.Id = 1;
            Assert.Equal(1, vm.Vm1Count);
        }

        [Fact]
        public void GivenListenToWhenParentDisposedThenShouldUnregisterChildNotifications()
        {
            using var child = new TestViewModel();
            var vm = new TestViewModel(child);
            vm.Dispose();
            child.Id = 1;
            Assert.Equal(0, vm.Vm1Count);
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.sender = sender;
            propertyName = e.PropertyName;
        }
    }
}

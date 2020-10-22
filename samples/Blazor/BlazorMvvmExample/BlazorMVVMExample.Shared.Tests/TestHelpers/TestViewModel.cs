using System.ComponentModel;
using BlazorMvvmExample.Shared.ViewModels;

namespace BlazorMVVMExample.Shared.Tests.TestHelpers
{
    public class TestViewModel : BaseViewModel
    {
        private readonly TestViewModel vm1;
        private TestViewModel vm2;
        private int id;

        public int Vm1Count { get; private set; }
        public int Vm2Count { get; private set; }

        public TestViewModel(TestViewModel child1 = null, TestViewModel child2 = null)
        {
            if (child1 != null)
            {
                vm1 = child1;
                ListenTo(vm1);
            }

            if (child2 != null)
            {
                vm2 = child2;
                ListenTo(vm2);
            }
        }

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value, nameof(Id));
        }

        protected override void ObservedChanged(INotifyPropertyChanged sender, string propertyName)
        {
            if (ReferenceEquals(sender, vm1))
            {
                Vm1Count++;
            }
            else if (ReferenceEquals(sender, vm2))
            {
                Vm2Count++;
            }
        }

        public void Wipe()
        {
            vm2 = null;
        }
    }
}

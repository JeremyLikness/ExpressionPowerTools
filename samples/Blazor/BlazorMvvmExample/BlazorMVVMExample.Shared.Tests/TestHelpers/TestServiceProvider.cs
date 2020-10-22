using System;
using BlazorMvvmExample.Shared.Data;

namespace BlazorMVVMExample.Shared.Tests.TestHelpers
{
    public class TestServiceProvider : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            return new ContactContext();
        }
    }
}

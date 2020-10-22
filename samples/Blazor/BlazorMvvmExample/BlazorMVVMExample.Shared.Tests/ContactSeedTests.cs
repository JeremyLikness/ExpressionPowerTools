using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazorMvvmExample.Shared.Data;
using BlazorMVVMExample.Shared.Tests.TestHelpers;
using Xunit;

namespace BlazorMVVMExample.Shared.Tests
{
    public class ContactSeedTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(1000)]
        public void GetContactsGeneratesCountOfContacts(int count)
        {
            var contacts = ContactSeed.GetContacts(count);
            Assert.Equal(count, contacts.Count);
        }

        [Fact]
        public void GetContactsGeneratesUniqueIds()
        {
            var contacts = ContactSeed.GetContacts(500);
            var ids = contacts.Select(c => c.Id).ToList();
            var uniqueIds = new HashSet<int>(ids);
            Assert.Equal(ids.Count, uniqueIds.Count);
        }

        [Fact]
        public void GetContactsGeneratesUniqueContactInformation()
        {
            var contacts = ContactSeed.GetContacts(500);
            var contactStr = contacts.Select(c => c.ToString()).ToList();
            var uniqueStr = new HashSet<string>(contactStr);
            Assert.Equal(contactStr.Count, uniqueStr.Count);
        }

        [Fact]
        public void CheckAndSeedContactsExtensionCallsCheckAndSeedOnTheContext()
        {
            var sp = new TestServiceProvider();
            Assert.Throws<InvalidOperationException>(
                () => sp.CheckAndSeedContacts()); // no provider configured
        }
    }
}

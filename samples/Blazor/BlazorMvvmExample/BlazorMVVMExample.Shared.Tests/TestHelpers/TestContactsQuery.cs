using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMvvmExample.Shared;
using BlazorMvvmExample.Shared.Data;
using BlazorMvvmExample.Shared.Signatures;
using Xunit.Sdk;

namespace BlazorMVVMExample.Shared.Tests.TestHelpers
{
    public class TestContactsQuery : IContactsQuery
    {
        private bool delayTask;

        private List<Contact> contacts;

        private TaskCompletionSource<int> delayedTask;

        private int delayedCount;

        private bool throwException = false;

        /// <summary>
        /// Set this to throw on next query.
        /// </summary>
        public bool ExceptionSwitch
        {
            get => false;
            set => throwException = value;    
        }

        /// <summary>
        /// Set this to pause the next query. Reset to
        /// release it
        /// </summary>
        public bool DelayTaskSwitch
        {
            get
            {
                var value = delayTask;
                delayTask = false;
                return value;
            }

            set
            {
                if (value == false && delayedTask != null)
                {
                    delayedTask.SetResult(delayedCount);
                }

                delayTask = value;
            }
        }

        public int ResultCandidateSize { get; set; } = 100;

        public int BaseQueryCalledCount { get; private set; } = 0;

        public IQueryable<Contact> LastContactQuery { get; private set; }

        public IQueryable<Contact> GetBaseQuery()
        {
            BaseQueryCalledCount++;
            contacts = ContactSeed.GetContacts(ResultCandidateSize);
            return contacts.AsQueryable();
        }

        public Task<List<Contact>> GetContactsAsync(IQueryable<Contact> query)
        {
            LastContactQuery = query;
            if (throwException)
            {
                throwException = false;
                throw new InvalidOperationException();
            }

            return Task.FromResult(query.ToList());
        }

        public async Task<(int count, List<Contact> contacts)> GetContactsWithCountAsync(IQueryable<Contact> query, IQueryable<Contact> queryPage) =>
            (await GetCountAsync(query), await GetContactsAsync(queryPage));

        public Task<int> GetCountAsync(IQueryable<Contact> query)
        {
            delayedCount = query.Count();
            if (DelayTaskSwitch)
            {
                delayedTask = new TaskCompletionSource<int>();
                return delayedTask.Task;
            }

            return Task.FromResult(delayedCount);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressionPowerTools.Serialization.EFCore.AspNetCore.Tests.TestHelpers
{
    public class TestServerFactory : IDisposable
    {
        private readonly List<TestServer> servers = new List<TestServer>();
        private readonly List<DbContext> contexts = new List<DbContext>();

        private bool disposedValue;

        public TestServer CreateTestServer(
            Action<IServiceCollection> configureServices,
            Action<IApplicationBuilder> configureApp)
        {
            var builder = new WebHostBuilder()
                .Configure(configureApp)
                .ConfigureServices(services =>
                {
                    services.AddHttpContextAccessor();
                    services.AddTransient(sp => GetDbContext<TestWidgetsContext>());
                    configureServices?.Invoke(services);
                });

            var server = new TestServer(builder);
            servers.Add(server);
            return server;
        }

        public T GetDbContext<T>()
            where T : DbContext
        {
            if (typeof(T) == typeof(TestWidgetsContext))
            {
                return GetTestWidgetsContext() as T;
            }

            if (typeof(T) == typeof(TestProductsContext))
            {
                return GetTestProductsContext() as T;
            }
            return null;
        }

        private DbContext GetTestProductsContext()
        {
            var dbName = Guid.NewGuid().ToString().Replace("-", "");
            var options = new DbContextOptionsBuilder<TestProductsContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
            var context = new TestProductsContext(options);
            var category = new TestCategory
            {
                Id = 1,
                Name = "Test",
                Products = new[]
                {
                    new TestProduct
                    {
                        Id = 1,
                        CategoryId = 1,
                        Name = "Foo",
                        Price = 1.99
                    },

                    new TestProduct
                    {
                        Id = 2,
                        CategoryId = 1,
                        Name = "Bar",
                        Price = 24.99
                    }
                }
            };
            context.Categories.Add(category);
            context.SaveChanges();
            return context;
        }

        private DbContext GetTestWidgetsContext()
        {
            var dbName = Guid.NewGuid().ToString().Replace("-", "");
            var options = new DbContextOptionsBuilder<TestWidgetsContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
            var context = new TestWidgetsContext(options);
            contexts.Add(context);
            var widgets = new List<TestWidget>();
            for (var idx = 0; idx < 10; idx += 1)
            {
                var widget = new TestWidget
                {
                    Id = Guid.NewGuid(),
                    Name = idx == 0 ? null : $"Widget on db {dbName}"
                };
                widgets.Add(widget);
            }
            context.Widgets.AddRange(widgets);
            context.SaveChanges();
            return context;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    var disposables = servers.OfType<IDisposable>()
                        .Union(contexts.OfType<IDisposable>());
                    foreach(var disposable in disposables)
                    {
                        try
                        {
                            disposable.Dispose();
                        }
                        catch
                        {
                            // I was told never to do this. Muwahahah.
                        }
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorMvvmExample.Shared.Signatures;
using BlazorMvvmExample.Shared.ViewModels;
using ExpressionPowerTools.Serialization.EFCore.Http.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorMvvmExample.Client
{
    /// <summary>
    /// Main program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>An asynchronous <see cref="Task"/>.</returns>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddExpressionPowerToolsEFCore(new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddSingleton<IContactsQuery, ContactsQuery>();
            builder.Services.AddSingleton<ContactsViewModel>();

            await builder.Build().RunAsync();
        }
    }
}

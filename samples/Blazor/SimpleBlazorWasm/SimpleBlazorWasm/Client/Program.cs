// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using ExpressionPowerTools.Core.Dependencies;
using ExpressionPowerTools.Serialization;
using ExpressionPowerTools.Serialization.EFCore.Http.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimpleBlazorWasm.Client.Shared;
using SimpleBlazorWasm.Shared;

namespace SimpleBlazorWasm.Client
{
    /// <summary>
    /// Main WebAssembly program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Arguments passed in.</param>
        /// <returns>A <see cref="Task"/> for asychronous processing.</returns>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // this adds the client with the base address to post to /efcore/{context}/{collection}
            builder.Services.AddExpressionPowerToolsEFCore(new Uri(builder.HostEnvironment.BaseAddress));

            if (builder.HostEnvironment.IsDevelopment())
            {
                QueryExprSerializer.ConfigureDefaults(config => config.CompressTypes(false));
            }

            // this adds a helper class for composing the query
            builder.Services.AddScoped(
                sp => new RemoteQueryClientService());

            await builder.Build().RunAsync();
        }
    }
}

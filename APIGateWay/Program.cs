using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.Middleware;
using Ocelot.DependencyInjection;

namespace APIGateWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (environment == Environments.Development)
            {
                new WebHostBuilder()
                   .UseIIS()
                   .UseContentRoot(Directory.GetCurrentDirectory())
                   .ConfigureAppConfiguration((hostingContext, config) =>
                   {
                       config
                           .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                           .AddJsonFile("appsettings.json", true, true)
                           .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                           .AddJsonFile($"Configuration.{hostingContext.HostingEnvironment.EnvironmentName}.json", false, true)
                           .AddEnvironmentVariables();
                   })
                   .ConfigureServices(s =>
                   {
                       s.AddOcelot();
                   })
                   .ConfigureLogging((hostingContext, logging) =>
                   {
                       //add your logging
                   })
                   .UseIISIntegration()
                   .Configure(app =>
                   {
                       app.UseOcelot().Wait();
                   })
                   .Build()
                   .Run();
            }
            else
            {
                new WebHostBuilder()
                   .UseKestrel()
                   .UseContentRoot(Directory.GetCurrentDirectory())
                   .ConfigureAppConfiguration((hostingContext, config) =>
                   {
                       config
                           .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                           .AddJsonFile("appsettings.json", true, true)
                           .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                           .AddJsonFile($"Configuration.{hostingContext.HostingEnvironment.EnvironmentName}.json", false, true)
                           .AddEnvironmentVariables();
                   })
                   .ConfigureServices(s =>
                   {
                       s.AddOcelot();
                   })
                   .ConfigureLogging((hostingContext, logging) =>
                   { })
                   .UseIISIntegration()
                   .Configure(app =>
                   {
                       app.UseOcelot().Wait();
                   })
                   .Build()
                   .Run();
            }

        }
    }
}

using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoApi.Data;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            UpdateDatabase(host.Services);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        // https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/
        private static void UpdateDatabase(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            using var db = serviceScope.ServiceProvider.GetService<TodoDbContext>();
            db.Database.Migrate();
        }
    }
}

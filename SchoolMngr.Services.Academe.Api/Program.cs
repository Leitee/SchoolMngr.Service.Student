
namespace SchoolMngr.Services.Academe
{
    using Codeit.Enterprise.Base.Identity;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using SchoolMngr.Infrastructure.Shared.Configuration;
    using SchoolMngr.Services.Academe.Application.Common.Abstractions;
    using SchoolMngr.Services.Academe.Infrastructure.Persistence.Context;
    using SchoolMngr.Services.Backoffice.DAL.Context;
    using Serilog;
    using System;

    public class Program
    {
        public static readonly string _appName = typeof(Program).Namespace;

        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            Log.Logger = SharedHostConfiguration.CreateSerilogLogger(_appName);

            try
            {
                Log.Information("Configuring web host ({ApplicationContext})...", _appName);
                var host = Host
                    .CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(wb => wb.UseStartup<Startup>())
                    .UseSerilog()
                    .Build();

                Log.Information("Applying migrations ({ApplicationContext})...", _appName);
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var context = services.GetRequiredService<AcademeDbContext>();

                        if (context.Database.IsSqlServer())
                            context.TryApplyMigration();

                        context.TrySeedAll();
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        Log.Error(ex, "An error occurred while migrating or initializing the database.");
                    }
                }

                Log.Information("Starting web host ({ApplicationContext})...", _appName);
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application failed at start up");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

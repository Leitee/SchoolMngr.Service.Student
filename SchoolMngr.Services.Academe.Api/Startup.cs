
namespace SchoolMngr.Services.Academe
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using SchoolMngr.Services.Academe.Application;
    using SchoolMngr.Services.Academe.Persistence;
    using SchoolMngr.Services.Academe.Persistence.Context;
    using Serilog;
    using System;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddPersistence("DALSection");
            //services.AddInfrastructure(Configuration, Environment);

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

            services.AddHealthChecks()
                .AddCheck("Self", _ => HealthCheckResult.Healthy())
                .AddDbContextCheck<AcademeDbContext>();

            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolMngr.Academe", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseIf(env.IsDevelopment(), app => app.UseDeveloperExceptionPage());
            app.UseIf(env.IsProduction(), app => app.UseExceptionHandler("/Error"));

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseIf(env.IsProduction(), app => app.UseHsts());

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.OAuthClientId("trainers-web");
                options.OAuthClientSecret("trainers-pass");
                options.OAuthAppName("Catalog API - Swagger");
                options.OAuthUsePkce();
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolMngr.Backoffice V1");
            });


            // This will make the HTTP requests log as rich logs instead of plain text.
            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/hc");
                endpoints.MapControllers();
            });
        }
    }
}

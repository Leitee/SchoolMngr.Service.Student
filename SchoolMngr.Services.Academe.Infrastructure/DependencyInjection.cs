namespace SchoolMngr.Services.Academe.Infrastructure
{
    using Codeit.Enterprise.Base.DataAccess;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using SchoolMngr.Services.Academe.Application.Common.Abstractions;
    using SchoolMngr.Services.Academe.Infrastructure.Persistence.Context;
    using System;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string sectionKey)
        {
            DALSettings dalSettings;
            using (var servProv = services.BuildServiceProvider())
            {
                var config = servProv.GetService<IConfiguration>();
                dalSettings = config.GetSection(sectionKey).Get<DALSettings>();
            }

            if (dalSettings is null)
                throw new ArgumentNullException(nameof(dalSettings));

            services.Configure<DALSettings>(sp => sp = dalSettings);
            var efPersistenceBuilder = EFPersistenceBuilder.Build(dalSettings);

            services.AddDbContext<AcademeDbContext>(efPersistenceBuilder.BuildConfiguration);
            services.AddScoped<IAcademeDbContext>(provider => provider.GetService<AcademeDbContext>());


            return services;
        }
    }
}

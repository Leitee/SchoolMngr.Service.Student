﻿
namespace SchoolMngr.Services.Academe.Persistence.Context
{
    using Codeit.NetStdLibrary.Base.Abstractions.DataAccess;
    using Codeit.NetStdLibrary.Base.DataAccess;
    using Microsoft.EntityFrameworkCore;

    public class EFPersistenceBuilder : IPersistenceBuilder
    {
        private static EFPersistenceBuilder instance;
        private readonly DALSettings _setting;

        private EFPersistenceBuilder(DALSettings settings)
        {
            _setting = settings ?? throw new DataAccessLayerException(nameof(settings));
        }

        public void BuildConfiguration(DbContextOptionsBuilder options)
        {
            //Uncomment if you want to apply LazyLoading globally and skip including it manually for each entity.
            //options.UseLazyLoadingProxies();
            options.EnableDetailedErrors(_setting.EnableDetailedDebug);
            options.EnableSensitiveDataLogging(_setting.EnableDetailedDebug);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);

            if (_setting.UseDatabase)
            {
                options.UseSqlServer(_setting.DatabaseConnection, dbOpt =>
                {
                    dbOpt.MigrationsHistoryTable("Migrations", "CONFIG");
                });
            }
            else
            {
                options.UseInMemoryDatabase(_setting.DatabaseName);
            }
        }

        public static EFPersistenceBuilder Build(DALSettings settings)
        {
            if (instance == null)
                instance = new EFPersistenceBuilder(settings);

            return instance;
        }
    }
}
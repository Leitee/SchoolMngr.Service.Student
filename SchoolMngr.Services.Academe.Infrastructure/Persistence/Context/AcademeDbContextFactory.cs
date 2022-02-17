namespace SchoolMngr.Services.Academe.Infrastructure.Persistence.Context
{
    using Codeit.Enterprise.Base.Abstractions.DataAccess;
    using Codeit.Enterprise.Base.DataAccess;
    using Microsoft.EntityFrameworkCore;
    using SchoolMngr.Infrastructure.Shared.Configuration;

    public class AcademeDbContextFactory : DesignTimeDbContextFactoryBase<AcademeDbContext>
    {
        public AcademeDbContextFactory() : base(SharedHostConfiguration.BuildDefaultSettings())
        {
        }

        protected override AcademeDbContext CreateNewInstance(DbContextOptions<AcademeDbContext> options)
        {
            return new AcademeDbContext(options);
        }

        protected override IPersistenceBuilder CreatePersistenceBuilder(DALSettings settings)
        {
            return EFPersistenceBuilder.Build(settings);
        }
    }
}

namespace SchoolMngr.Services.Academe.Persistence.Context
{
    using Codeit.NetStdLibrary.Base.Abstractions.DataAccess;
    using Codeit.NetStdLibrary.Base.DataAccess;
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

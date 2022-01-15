namespace SchoolMngr.Services.Academe.Infrastructure.Persistence.EntitiesConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.Services.Academe.Domain.Entities;

    public class AttendConfiguration : IEntityTypeConfiguration<Attend>
    {
        public void Configure(EntityTypeBuilder<Attend> builder)
        {
            builder.ToTable("Attendances", "DOMAIN");
            builder.Property(e => e.Id).HasColumnName("AttendID");
        }
    }
}

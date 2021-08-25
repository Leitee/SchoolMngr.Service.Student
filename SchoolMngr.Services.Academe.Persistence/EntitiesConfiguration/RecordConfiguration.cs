
namespace SchoolMngr.Services.Academe.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.Services.Academe.Domain.Entities;

    public class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.ToTable("Records", "DOMAIN");
            builder.Property(e => e.Id).HasColumnName("RecordID");
        }
    }
}

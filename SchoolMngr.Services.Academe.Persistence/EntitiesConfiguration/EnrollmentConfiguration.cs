
namespace SchoolMngr.Services.Academe.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.Services.Academe.Domain.Entities;

    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollments", "DOMAIN");
            builder.Property(e => e.Id).HasColumnName("EnrollID");
        }
    }
}

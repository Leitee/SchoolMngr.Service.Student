
namespace SchoolMngr.Services.Academe.Persistence
{
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolMngr.Services.Academe.Domain.Entities;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students", "DOMAIN");
            builder.Property(e => e.Id).HasColumnName("StudentID");
            builder.Property(e => e.Address).HasMaxLength(100);
            builder.Property(e => e.ProfileId).IsRequired().HasMaxLength(10);
            builder.HasIndex(s => s.ProfileId).IsUnique();
        }
    }
}

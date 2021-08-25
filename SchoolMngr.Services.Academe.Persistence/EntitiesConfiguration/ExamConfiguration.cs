
namespace SchoolMngr.Services.Academe.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SchoolMngr.Services.Academe.Domain.Entities;

    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams", "DOMAIN");
            builder.Property(e => e.Id).HasColumnName("ExamID");
        }
    }
}


namespace SchoolMngr.Services.Academe.Persistence
{
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolMngr.Services.Academe.Domain.Entities;
using System;

    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("AcademicStatuses", "DOMAIN");
            builder.Property(e => e.Id).HasColumnName("StatusID");

            builder
                .HasOne(st => st.Student)
                .WithMany(s => s.Statuses)
                .HasForeignKey(x => x.StudentId);
        }
    }
}

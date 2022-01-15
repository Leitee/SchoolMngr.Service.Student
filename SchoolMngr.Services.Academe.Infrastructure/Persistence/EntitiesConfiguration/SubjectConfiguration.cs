
namespace SchoolMngr.Services.Academe.Persistence
{
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolMngr.Services.Academe.Domain.Entities;
using System;

    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects", "DOMAIN");
            builder.Property(e => e.Id).HasColumnName("SubjectID");
        }
    }
}


namespace SchoolMngr.Services.Academe.Application.Common.Abstractions
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMngr.Services.Academe.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAcademeDbContext
    {
        DbSet<Subject> Subjects { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Enrollment> Enrollments { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<Record> Records { get; set; }
        DbSet<Exam> Exams { get; set; }
        DbSet<Attend> Attends { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

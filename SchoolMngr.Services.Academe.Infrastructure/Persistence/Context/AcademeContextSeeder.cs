
namespace SchoolMngr.Services.Backoffice.DAL.Context
{
    using Microsoft.EntityFrameworkCore;
    using SchoolMngr.Services.Academe.Domain.Entities;
    using SchoolMngr.Services.Academe.Entities.Enums;
    using SchoolMngr.Services.Academe.Infrastructure.Persistence.Context;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public static class AcademeContextSeeder
    {
        private static AcademeDbContext _context;

        public static AcademeDbContext TryApplyMigration(this AcademeDbContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            return context;
        }

        public static void TrySeedAll(this AcademeDbContext context)
        {
            if (context.Subjects.Any()) return;

            SeedAllAsync(context, CancellationToken.None).Wait();
        }

        public static async Task SeedAllAsync(this AcademeDbContext context, CancellationToken cancellationToken)
        {
            _context = context;

            await SeedSubjectAsync(cancellationToken);
            await SeedAttendsAsync(cancellationToken);
            await SeedExamsAsync(cancellationToken);
            await SeedStudentsAsync(cancellationToken);
        }

        private static async Task SeedSubjectAsync(CancellationToken cancellationToken)
        {
            await _context.Subjects.AddRangeAsync(
                new Subject { Name = "Math", Grade = "1th", ShiftTime = "Morning" },
                new Subject { Name = "Progr", Grade = "2th", ShiftTime = "Evening" },
                new Subject { Name = "Prog2", Grade = "3th", ShiftTime = "Night" }
                );

            await _context.SaveChangesAsync();
        }

        private static async Task SeedStudentsAsync(CancellationToken cancellationToken)
        {
            var stud1 = new Student { ProfileId = "Student01", Address = "Somewhere 1", IdentityUserId = Guid.NewGuid() };
            stud1.Statuses.Add(new Status { AcademicStatus = StudentStatusEnum.ACTIVE, DateFrom = new DateTime() });

            var stud2 = new Student { ProfileId = "Student02", Address = "Somewhere 2", IdentityUserId = Guid.NewGuid() };
            stud2.Statuses.Add(new Status { AcademicStatus= StudentStatusEnum.INACTIVE, DateFrom = new DateTime() });

            var stud3 = new Student { ProfileId = "Student03", Address = "Somewhere 3", IdentityUserId = Guid.NewGuid() };
            stud3.Statuses.Add(new Status { AcademicStatus = StudentStatusEnum.ACHIEVED, DateFrom = new DateTime() });


            await _context.Students.AddRangeAsync(stud1, stud2, stud3);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private static async Task SeedAttendsAsync(CancellationToken cancellationToken)
        {
            await _context.Attends.AddRangeAsync(
                new Attend { Attendance = AttendanceEnum.ATTENDED, DateAndTime = DateTime.UtcNow },
                new Attend { Attendance = AttendanceEnum.MISSED, DateAndTime = DateTime.UtcNow },
                new Attend { Attendance = AttendanceEnum.REASONED, DateAndTime = DateTime.UtcNow, Observations = "Illing" }
                );

            await _context.SaveChangesAsync(cancellationToken);
        }

        private static async Task SeedExamsAsync(CancellationToken cancellationToken)
        {
            await _context.Exams.AddRangeAsync(
                new Exam { ExamType = ExamTypeEnum.FIRST, DateAndTime = new DateTime(), Score = 6.5f },
                new Exam { ExamType = ExamTypeEnum.SECOND, DateAndTime = new DateTime(), Score = 7.5f },
                new Exam { ExamType = ExamTypeEnum.FINAL, DateAndTime = new DateTime(), Score = 8.5f, Observations = "Accomplished" }
                );

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

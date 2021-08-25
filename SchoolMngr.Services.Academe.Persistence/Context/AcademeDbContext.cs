
namespace SchoolMngr.Services.Academe.Persistence.Context
{
    using Codeit.NetStdLibrary.Base.Abstractions.Common;
    using Codeit.NetStdLibrary.Base.DomainModel;
    using Microsoft.EntityFrameworkCore;
    using SchoolMngr.Services.Academe.Application.Common.Abstractions;
    using SchoolMngr.Services.Academe.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class AcademeDbContext : DbContext, IAcademeDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public AcademeDbContext(DbContextOptions<AcademeDbContext> options)
            : base(options)
        {
        }

        //public AcademeDbContext(
        //    DbContextOptions<AcademeDbContext> options,
        //    ICurrentUserService currentUserService,
        //    IDateTime dateTime)
        //    : base(options)
        //{
        //    _currentUserService = currentUserService;
        //    _dateTime = dateTime;
        //}

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Attend> Attends { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcademeDbContext).Assembly);
        }
    }
}

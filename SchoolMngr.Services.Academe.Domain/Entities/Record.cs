
namespace SchoolMngr.Services.Academe.Domain.Entities
{
    using Codeit.Enterprise.Base.DomainModel;
    using System;

    public class Record : AuditableEntity
    {
        public Guid? ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public Guid? AttandId { get; set; }
        public virtual Attend Attend { get; set; }
        public Guid EnrollmentId { get; set; }
        public virtual Enrollment Enrollment { get; set; }
    }
}

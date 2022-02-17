
namespace SchoolMngr.Services.Academe.Domain.Entities
{
    using Codeit.Enterprise.Base.DomainModel;
    using SchoolMngr.Services.Academe.Entities.Enums;
    using System;

    public class Status : EFEntity
    {
        public StudentStatusEnum AcademicStatus { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}

namespace SchoolMngr.Services.Academe.Domain.Entities
{
    using Codeit.Enterprise.Base.DomainModel;
    using System;
    using System.Collections.Generic;

    public class Enrollment : AuditableEntity
    {
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }

        public virtual ICollection<Record> Records { get; set; }

    }
}
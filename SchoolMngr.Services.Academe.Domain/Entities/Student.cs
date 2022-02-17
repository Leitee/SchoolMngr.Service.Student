namespace SchoolMngr.Services.Academe.Domain.Entities
{
    using Codeit.Enterprise.Base.Abstractions.DomainModel;
    using Codeit.Enterprise.Base.DomainModel;
    using System;
    using System.Collections.Generic;

    public class Student : EFEntity, IDeleteableEntity
    {
        public Student()
        {
            Statuses = new HashSet<Status>();
        }

        public string ProfileId { get; set; }

        public string Address { get; set; }

        public bool Deleted { get; set; }

        public Guid IdentityUserId { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }
    }
}

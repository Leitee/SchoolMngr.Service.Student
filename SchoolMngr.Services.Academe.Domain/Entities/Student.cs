namespace SchoolMngr.Services.Academe.Domain.Entities
{
    using Codeit.NetStdLibrary.Base.Abstractions.DomainModel;
    using Codeit.NetStdLibrary.Base.DomainModel;
    using System;
    using System.Collections.Generic;

    public class Student : EFEntity, IDeleteableEntity
    {
        public Student()
        {
            Statuses = new HashSet<Status>();
        }

        public string ProfileId { get; set; }

        public string Adress { get; set; }

        public bool Deleted { get; set; }

        public virtual Guid IdentityUserId { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }
    }
}

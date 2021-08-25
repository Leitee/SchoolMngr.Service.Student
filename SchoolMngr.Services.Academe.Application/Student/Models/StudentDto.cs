namespace SchoolMngr.Services.Academe.Application.Student.Models
{
    using Codeit.NetStdLibrary.Base.BusinessLogic;
    using System;

    public class StudentDto : Dto
    {
        public string ProfileId { get; set; }

        public string Adress { get; set; }

        public bool Deleted { get; set; }

        public Guid IdentityUserId { get; set; }

        public string LastValidStatus { get; set; }
    }
}

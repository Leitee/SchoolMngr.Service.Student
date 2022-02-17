
namespace SchoolMngr.Services.Academe.Domain.Entities
{
    using Codeit.Enterprise.Base.DomainModel;
    using SchoolMngr.Services.Academe.Entities.Enums;
    using System;

    public class Attend : EFEntity
    {
        public AttendanceEnum Attendance { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Observations { get; set; }
    }
}

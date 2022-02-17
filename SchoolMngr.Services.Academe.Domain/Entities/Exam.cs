
namespace SchoolMngr.Services.Academe.Domain.Entities
{
    using Codeit.Enterprise.Base.DomainModel;
    using SchoolMngr.Services.Academe.Entities.Enums;
    using System;

    public class Exam : EFEntity
    {
        public ExamTypeEnum ExamType { get; set; }
        public float Score { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Observations { get; set; }

    }
}

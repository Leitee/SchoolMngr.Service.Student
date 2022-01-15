namespace SchoolMngr.Services.Academe.Application.Student.Models
{
    using AutoMapper;
    using Codeit.NetStdLibrary.Base.BusinessLogic;
    using SchoolMngr.Services.Academe.Application.Common.Mappings;
    using SchoolMngr.Services.Academe.Domain.Entities;
    using System;
    using System.Linq;

    public class StudentDto : Dto, IMapFrom<Student>
    {
        public string ProfileId { get; set; }

        public string Address { get; set; }

        public bool Deleted { get; set; }

        public Guid IdentityUserId { get; set; }

        public string LastValidStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDto>()
                .ForMember(d => d.LastValidStatus, opt => opt.MapFrom(s => s.Statuses.SingleOrDefault(x => x.DateTo == null).AcademicStatus));
        }
    }
}

namespace SchoolMngr.Services.Academe.Application.Student.Queries
{
    using Codeit.Enterprise.Base.Abstractions.BusinessLogic;
    using MediatR;
    using SchoolMngr.Services.Academe.Application.Student.Models;
    using System;

    public class GetStudentByIdQuery : IRequest<IBLSingleResponse<StudentDto>>
    {
        public Guid Id { get; set; }
    }
}

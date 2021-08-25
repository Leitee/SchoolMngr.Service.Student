namespace SchoolMngr.Services.Academe.Application.Student.Queries.GetStudentsList
{
    using Codeit.NetStdLibrary.Base.Abstractions.BusinessLogic;
    using MediatR;
    using SchoolMngr.Services.Academe.Application.Student.Models;

    public class GetStudentsListQuery : IRequest<IBLListResponse<StudentDto>>
    {

    }
}

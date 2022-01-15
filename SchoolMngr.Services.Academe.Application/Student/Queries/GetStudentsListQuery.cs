namespace SchoolMngr.Services.Academe.Application.Student.Queries
{
    using Codeit.NetStdLibrary.Base.Abstractions.BusinessLogic;
    using MediatR;
    using SchoolMngr.Services.Academe.Application.Student.Models;

    public class GetStudentsListQuery : IRequest<IBLListResponse<StudentDto>>
    {

    }
}

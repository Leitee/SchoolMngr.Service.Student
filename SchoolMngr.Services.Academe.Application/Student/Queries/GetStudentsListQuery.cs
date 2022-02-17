namespace SchoolMngr.Services.Academe.Application.Student.Queries
{
    using Codeit.Enterprise.Base.Abstractions.BusinessLogic;
    using MediatR;
    using SchoolMngr.Services.Academe.Application.Student.Models;

    public class GetStudentsListQuery : IRequest<IBLListResponse<StudentDto>>
    {

    }
}

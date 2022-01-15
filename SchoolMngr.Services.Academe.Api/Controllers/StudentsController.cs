
namespace SchoolMngr.Services.Academe.Controllers
{
    using Codeit.NetStdLibrary.Base.Abstractions.BusinessLogic;
    using Codeit.NetStdLibrary.Base.Application;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using SchoolMngr.Services.Academe.Application.Student.Models;
    using SchoolMngr.Services.Academe.Application.Student.Queries;
    using SchoolMngr.Services.Academe.Application.Student.Queries.GetStudentsList;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class StudentsController : BaseController<StudentsController>
    {
        public StudentsController(ILoggerFactory loggerFactory) : base(loggerFactory)
        {

        }

        // GET: api/students
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesDefaultResponseType(typeof(IBLSingleResponse<StudentDto>))]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery {Id = id }, cancellationToken);
            return response.ToHttpResponse();
        }

        // GET: api/students/{id}
        [HttpGet]
        [AllowAnonymous]
        [ProducesDefaultResponseType(typeof(IBLListResponse<StudentDto>))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(new GetStudentsListQuery(), cancellationToken);
            return response.ToHttpResponse();
        }
    }
}

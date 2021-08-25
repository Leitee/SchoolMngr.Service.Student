
namespace SchoolMngr.Services.Academe.Controllers
{
    using Codeit.NetStdLibrary.Base.Abstractions.BusinessLogic;
    using Codeit.NetStdLibrary.Base.Application;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using SchoolMngr.Services.Academe.Application.Student.Models;
    using SchoolMngr.Services.Academe.Application.Student.Queries.GetStudentsList;
    using System.Threading;
    using System.Threading.Tasks;

    public class StudentController : BaseController<StudentController>
    {
        public StudentController(ILoggerFactory loggerFactory) : base(loggerFactory)
        {

        }

        // GET: api/<ProductsController>
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

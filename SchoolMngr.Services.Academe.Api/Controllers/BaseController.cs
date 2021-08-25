
namespace SchoolMngr.Services.Academe.Controllers
{
    using Codeit.NetStdLibrary.Base.Application;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class BaseController<TController> : ApiBaseController<TController>
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public BaseController(ILoggerFactory loggerFactory) : base(loggerFactory)
        {

        }

        [HttpGet("echo")]
        public IActionResult Echo()
        {
            return Ok($"Calling {typeof(TController).Name} is healthy");
        }
    }
}

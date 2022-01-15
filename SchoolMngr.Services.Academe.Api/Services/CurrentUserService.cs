namespace SchoolMngr.Services.Academe.Services;

using Microsoft.AspNetCore.Http;
using SchoolMngr.Services.Academe.Application.Common.Abstractions;
using System.Security.Claims;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier); 
}

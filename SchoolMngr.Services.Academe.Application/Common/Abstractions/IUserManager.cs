using SchoolMngr.Services.Academe.Application.Common.Models;
using System.Threading.Tasks;

namespace SchoolMngr.Services.Academe.Application.Common.Abstractions
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}

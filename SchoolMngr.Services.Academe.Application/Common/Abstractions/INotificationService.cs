using SchoolMngr.Services.Academe.Application.Notifications.Models;
using System.Threading.Tasks;

namespace SchoolMngr.Services.Academe.Application.Common.Abstractions
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}

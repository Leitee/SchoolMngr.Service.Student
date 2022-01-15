namespace SchoolMngr.Services.Academe.Application.Common.Abstractions
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        //bool IsAuthenticated { get; }
    }
}

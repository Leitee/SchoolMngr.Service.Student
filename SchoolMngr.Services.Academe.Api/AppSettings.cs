
namespace SchoolMngr.Services.Academe
{
    using Codeit.Enterprise.Base.Common;
    using Codeit.Enterprise.Base.DataAccess;
    using SchoolMngr.Infrastructure.Shared.Configuration;

    public class AppSettings : BaseSettings<AppSettings>
    {
        public DALSettings DalSection { get; set; }
        public INFRASettings InfraSection { get; set; }
    }
}

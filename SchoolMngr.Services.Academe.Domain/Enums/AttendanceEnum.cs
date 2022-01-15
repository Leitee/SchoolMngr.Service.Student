
namespace SchoolMngr.Services.Academe.Entities.Enums
{
    using System.ComponentModel;

    public enum AttendanceEnum
    {
        [Description("Presente")]
        ATTENDED = 1,
        [Description("Ausente")]
        MISSED,
        [Description("Justificado")]
        REASONED,
    }
}

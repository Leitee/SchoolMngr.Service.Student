namespace SchoolMngr.Services.Academe.Infrastructure.ClientModel
{
    using Reinforced.Typings.Ast.TypeNames;
    using Reinforced.Typings.Fluent;
    using SchoolMngr.Services.Academe.Application.Student.Models;
    using SchoolMngr.Services.Academe.Entities.Enums;

    public static class ModelConfiguration
    {
        public static void Configure(ConfigurationBuilder builder)
        {
            //Global config
            builder
                .Substitute(typeof(System.Guid), new RtSimpleTypeName("string"))
                .Substitute(typeof(System.DateTime), new RtSimpleTypeName("Date"))
                .Global(config =>
                {
                    config.CamelCaseForProperties(true);
                    config.UseModules(true);
                    config.AutoOptionalProperties(true);
                    config.ExportPureTypings(true);
                });

            builder.ExportAsInterface<StudentDto>()
                .AutoI(false)
                .WithPublicProperties()
                .OverrideName("Student");

            builder.ExportAsEnum<ExamTypeEnum>()
                .DontIncludeToNamespace();

            builder.ExportAsEnum<AttendanceEnum>()
                .DontIncludeToNamespace();

            builder.ExportAsEnum<SchoolRolesEnum>()
                .DontIncludeToNamespace();

            builder.ExportAsEnum<StudentStatusEnum>()
                .DontIncludeToNamespace();
        }
    }
}